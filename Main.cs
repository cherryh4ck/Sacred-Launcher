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
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Sacred_Launcher
{
    public partial class Main : Form
    {
        static string dataFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.json");
        public Main()
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
            loadData();
        }

        public void saveData()
        {
            var games = new List<Game>();
            foreach (var item in gamesList.Items)
            {
                if (item is Game game)
                {
                    games.Add(game);
                }
            }
            try
            {
                var json = JsonConvert.SerializeObject(games, Formatting.Indented);
                File.WriteAllText(dataFile, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"there was an error when trying to save your data!! error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadData()
        {
            if (!File.Exists(dataFile))
            {
                return;
            }

            var games = new List<Game>();
            try
            {
                var json = File.ReadAllText(dataFile);
                games = JsonConvert.DeserializeObject<List<Game>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"there was an error when trying to load your data!! error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var game in games)
            {
                gamesList.Items.Add(game);
            }
        }
        public void addGame(Game game)
        {
            gamesList.Items.Add(game);
            saveData();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddGame form = new AddGame(this);
            form.ShowDialog();
        }

        private void gamesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gamesList.SelectedItem is Game game)
            {
                gameDescription.Text = game.Description;
                gameName.Text = game.Name;
                gamePath.Text = game.Path;
                Icon extractedIcon;
                try
                {
                    extractedIcon = Icon.ExtractAssociatedIcon(game.Path);
                }
                catch (Exception)
                {
                    gameName.Text = "Invalid game";
                    gameDescription.Text = "Game couldn't be found.";
                    gamePath.Visible = false;
                    MessageBox.Show($"Game couldn't be found. Please check if the path is correct!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (extractedIcon != null)
                {
                    gameIcon.Image = extractedIcon.ToBitmap();
                }

                gamePath.Visible = true;
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
                    gamePath.Visible = false;
                    gameIcon.Visible = false;
                    gameName.Visible = false;
                    gameDescription.Visible = false;
                    playButton.Enabled = false;
                    deleteButton.Enabled = false;

                    saveData();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ServerBrowser form = new ServerBrowser();
            form.ShowDialog();
        }

        private void gamesList_DoubleClick(object sender, EventArgs e)
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
    }
}
