using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Sacred_Launcher.ServerBrowser;

namespace Sacred_Launcher
{
    public partial class AddServer : Form
    {
        private readonly ServerBrowser form;
        public AddServer(ServerBrowser form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void addButton_Click(object sender, EventArgs e)
        { 
            var ipe = Regex.Replace(ip.Text, @"\s+", "");
            if (string.IsNullOrWhiteSpace(ipe))
            {
                MessageBox.Show("Please fill in the IP field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.TryParse(port.Text, out int parsedPort))
            {
                var server = new Server
                {
                    IP = ipe,
                    Port = parsedPort,
                    Status = false
                };

                form.addServer(server);
                form.ScanIPs();
                this.Close();
            }
            else
            {
                MessageBox.Show("The port is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
