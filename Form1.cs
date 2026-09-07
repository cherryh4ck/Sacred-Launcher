using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void addButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Executables (*.exe)|*.exe";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var game = new Game
                {
                    Name = System.IO.Path.GetFileNameWithoutExtension(dialog.FileName),
                    Path = dialog.FileName,
                    Description = "aaa"
                };
                gamesList.Items.Add(game);
            }
        }

        private void gamesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gamesList.SelectedItem is Game game)
            {
                gameDescription.Text = game.Description;
            }
        }
    }
}
