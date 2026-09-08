using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Sacred_Launcher.Form1;

namespace Sacred_Launcher
{
    public partial class Form3 : Form
    {
        // solo eso por ahora ejkfkjwsfkjsd
        // ynoseqe mas podria ir qwp
        // bueno solotengo paja je
        public class Server
        {
            public string IP { get; set; }
            public override string ToString() => IP;
        }
        public Form3()
        {
            InitializeComponent();
        }

        async public void ScanIPs()
        {
            foreach (var item in serverList.Items)
            {
                if (item is Server server)
                {
                    var client = new TcpClient();
                    try
                    {
                        var tarea = client.ConnectAsync(server.IP, 7066);
                        if (await Task.WhenAny(tarea, Task.Delay(2000)) == tarea && client.Connected)
                        {
                            MessageBox.Show("Server " + server.IP + " is online!", "Server Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch { }
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            serverList.Items.Add(new Server { IP = "sacred.toms3.cc" });
            serverList.Items.Add(new Server { IP = "sacred.overture.bar" });
            serverList.Items.Add(new Server { IP = "asfsaffsaf.cc" });
            Console.WriteLine("scanning");
            ScanIPs();
        }
    }
}
