using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Sacred_Launcher.Form1;

namespace Sacred_Launcher
{
    public partial class Form2 : Form
    {
        private readonly Form1 form;
        public Form2(Form1 form)
        {
            InitializeComponent();
            this.form = form;
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
    }
}
