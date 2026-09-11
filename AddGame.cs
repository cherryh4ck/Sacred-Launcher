using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Sacred_Launcher.Main;

namespace Sacred_Launcher
{
    public partial class AddGame : Form
    {
        private readonly Main form;
        public AddGame(Main form)
        {
            InitializeComponent();
            this.form = form;
        }

        private bool CheckIfValid()
        {
            var folders = System.IO.Path.GetDirectoryName(path.Text);
            var checks = new[]
            {
                System.IO.File.Exists(System.IO.Path.Combine(folders, "Settings.cfg")),
                System.IO.Directory.Exists(System.IO.Path.Combine(folders, "scripts")),
                System.IO.Directory.Exists(System.IO.Path.Combine(folders, "movie")),
                System.IO.Directory.Exists(System.IO.Path.Combine(folders, "bin")),
                System.IO.Directory.Exists(System.IO.Path.Combine(folders, "pak"))
            };
            return checks.Count(x => x) >= 3;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            var descriptionText = description.Text;
            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(path.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(descriptionText))
            {
                descriptionText = "No description available.";
            }

            var game = new Game
            {
                Name = name.Text,
                Path = path.Text,
                Description = descriptionText
            };
            form.addGame(game);

            this.Close();
        }

        private void pathButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Executables (*.exe)|*.exe";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path.Text = dialog.FileName;
            }
        }

        private void path_TextChanged(object sender, EventArgs e)
        {
            acceptButton.Enabled = false;
            status.Visible = false;
            timer.Stop();
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            if (string.IsNullOrWhiteSpace(path.Text))
            {
                return;
            }
            if (!System.IO.File.Exists(path.Text))
            {
                status.BackColor = Color.Red;
                status.Text = "Not a valid path.";
                status.Visible = true;
                return;
            }

            var isValid = CheckIfValid();
            if (isValid)
            {
                status.BackColor = Color.LightGreen;
                status.Text = "Valid game.";
                acceptButton.Enabled = true;
            }
            else
            {
                status.BackColor = Color.Red;
                status.Text = "Not a valid game.";
            }
            status.Visible = true;
        }
    }
}
