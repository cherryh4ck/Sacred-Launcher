using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Sacred_Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Game
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Path { get; set; }

            public override string ToString() => Name;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: load from json file
            // also show a message if json doesn't exist
        }

        public void addGame(Game game)
        {
            gamesList.Items.Add(game);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(this);
            form.ShowDialog();
        }

        private void gamesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gamesList.SelectedItem is Game game)
            {
                gameDescription.Text = game.Description;
                gameName.Text = game.Name;
                Icon extractedIcon = Icon.ExtractAssociatedIcon(game.Path);
                if (extractedIcon != null)
                {
                    gameIcon.Image = extractedIcon.ToBitmap();
                }

                gameIcon.Visible = true;
                gameName.Visible = true;
                gameDescription.Visible = true;
                playButton.Enabled = true;
                deleteButton.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gamesList.SelectedItem is Game game)
            {
                var info = new ProcessStartInfo
                {
                    FileName = game.Path,
                    WorkingDirectory = Path.GetDirectoryName(game.Path),
                    UseShellExecute = true
                };

                Process.Start(info);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (gamesList.SelectedItem is Game game)
            {
                var result = MessageBox.Show($"Are you sure you want to delete {game.Name}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    gamesList.Items.Remove(game);
                    gameDescription.Text = "";
                    gameName.Text = "";
                    gameIcon.Image = null;
                    gameIcon.Visible = false;
                    gameName.Visible = false;
                    gameDescription.Visible = false;
                    playButton.Enabled = false;
                    deleteButton.Enabled = false;
                }
            }
        }
    }
}
