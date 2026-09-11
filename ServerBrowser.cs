using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        // solo eso por ahora ejkfkjwsfkjsd
        // ynoseqe mas podria ir qwp
        // bueno solotengo paja je

        static string dataFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "servers.json");
        public class Server
        {
            public string IP { get; set; }
            public int Port { get; set; } = 7066;
            [JsonIgnore]
            public bool Status { get; set; }
            public override string ToString() => IP;
        }
        public ServerBrowser()
        {
            InitializeComponent();
        }

        async public void ScanIPs()
        {
            foreach (ListViewItem item in serverList.Items)
            {
                var server = (Server)item.Tag;
                bool online = false;

                using (var client = new TcpClient())
                {
                    try
                    {
                        var tarea = client.ConnectAsync(server.IP, server.Port);
                        online = await Task.WhenAny(tarea, Task.Delay(2000)) == tarea && client.Connected;
                    }
                    catch { }
                }

                server.Status = online;
                item.SubItems[2].Text = online ? "Online" : "Offline";
            }
        }

        public void addServer(Server server)
        {
            var item = new ListViewItem(server.IP);
            item.SubItems.Add(server.Port.ToString());
            item.SubItems.Add(server.Status ? "Online" : "Offline");
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
            serverList.FullRowSelect = true;

            menuItem = new ContextMenuStrip();
            menuItem.Items.Add("Delete", null, DeleteServer_Click);

            menuEmpty = new ContextMenuStrip();
            menuEmpty.Items.Add("Add Server", null, AddServer_Click);

            loadData();
            ScanIPs();
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
        }
    }
}
