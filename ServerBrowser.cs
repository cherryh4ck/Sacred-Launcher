using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Sacred_Launcher.Main;

namespace Sacred_Launcher
{
    public partial class ServerBrowser : Form
    {
        static string dataFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "servers.json");
        static readonly byte[] logoffPacket = BuildLogoffPacket();

        public class Server
        {
            public string IP { get; set; }
            public int Port { get; set; } = 7066;
            [JsonIgnore]
            public bool Status { get; set; }
            [JsonIgnore]
            public long Ping { get; set; } = -1;
            public override string ToString() => IP;
        }

        public ServerBrowser()
        {
            InitializeComponent();
        }

        static byte[] BuildLogoffPacket()
        {
            var data = new byte[28];
            BitConverter.GetBytes(0xDABAFBEFu).CopyTo(data, 0);
            BitConverter.GetBytes((uint)4).CopyTo(data, 12);
            return data;
        }

        static long CheckServer(Server server)
        {
            // no, no es CÓDIGO ORIGINAL ok
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    var stopwatch = Stopwatch.StartNew();
                    var result = socket.BeginConnect(server.IP, server.Port, null, null);
                    var connected = result.AsyncWaitHandle.WaitOne(2000, true);
                    stopwatch.Stop();

                    if (!connected || !socket.Connected)
                    {
                        socket.Close();
                        return -1;
                    }

                    socket.EndConnect(result);
                    socket.LingerState = new LingerOption(true, 1);
                    socket.Send(logoffPacket);
                    return stopwatch.ElapsedMilliseconds;
                }
                catch
                {
                    return -1;
                }
            }
        }

        async public void ScanIPs()
        {
            foreach (ListViewItem item in serverList.Items)
            {
                var server = (Server)item.Tag;
                var ping = await Task.Run(() => CheckServer(server));

                server.Status = ping >= 0;
                server.Ping = ping;
                item.SubItems[2].Text = server.Status ? "Online" : "Offline";
                item.SubItems[3].Text = server.Status ? $"{ping} ms" : "-";
            }
        }

        public void addServer(Server server)
        {
            var item = new ListViewItem(server.IP);
            item.SubItems.Add(server.Port.ToString());
            item.SubItems.Add(server.Status ? "Online" : "Offline");
            item.SubItems.Add(server.Ping >= 0 ? $"{server.Ping} ms" : "-");
            item.Tag = server;
            serverList.Items.Add(item);
        }

        public void saveData()
        {
            var servers = new List<Server>();
            foreach (ListViewItem item in serverList.Items)
            {
                if (item.Tag is Server server)
                {
                    servers.Add(server);
                }
            }
            try
            {
                var json = JsonConvert.SerializeObject(servers, Formatting.Indented);
                File.WriteAllText(dataFile, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"there was an error when trying to save your data!! error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadData()
        {
            if (!File.Exists(dataFile)) {
                // add g00d lobbyservers
                addServer(new Server { IP = "94.16.105.70" });
                addServer(new Server { IP = "sacred.toms3.cc" });
                addServer(new Server { IP = "sacred.overture.bar" });
                saveData();
                return;
            }

            var servers = new List<Server>();
            try
            {
                var json = File.ReadAllText(dataFile);
                servers = JsonConvert.DeserializeObject<List<Server>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"there was an error when trying to load your data!! error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var server in servers)
            {
                addServer(server);
            }
        }

        private ContextMenuStrip menuItem;
        private ContextMenuStrip menuEmpty;
        private void Form3_Load(object sender, EventArgs e)
        {
            serverList.View = View.Details;
            serverList.Columns.Add("IP", 160);
            serverList.Columns.Add("Port", 40);
            serverList.Columns.Add("Status", 80);
            serverList.Columns.Add("Ping", 60);
            serverList.FullRowSelect = true;

            menuItem = new ContextMenuStrip();
            menuItem.Items.Add("Delete", null, DeleteServer_Click);

            menuEmpty = new ContextMenuStrip();
            menuEmpty.Items.Add("Add Server", null, AddServer_Click);

            loadData();
            ScanIPs();

            ping.Stop();
            ping.Start();
        }

        private void serverList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            var info = serverList.HitTest(e.Location);

            if (info.Item != null)
            {
                serverList.SelectedItems.Clear();
                info.Item.Selected = true;
                menuItem.Show(serverList, e.Location);
            }
            else
            {
                menuEmpty.Show(serverList, e.Location);
            }
        }

        private void DeleteServer_Click(object sender, EventArgs e)
        {
            if (serverList.SelectedItems.Count > 0)
            {
                serverList.Items.Remove(serverList.SelectedItems[0]);
            }
        }

        private void AddServer_Click(object sender, EventArgs e)
        {
            AddServer form = new AddServer(this);
            form.ShowDialog();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveData();
            ping.Stop();
        }

        private void ping_Tick(object sender, EventArgs e)
        {
            ping.Stop();
            ScanIPs();
            ping.Start();
        }
    }
}