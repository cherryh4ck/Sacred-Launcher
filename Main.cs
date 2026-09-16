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

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string GameServerPath { get; set; } = "default";

            public override string ToString() => Name;
        }

        private ContextMenuStrip browseItem;
        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();

            browseItem = new ContextMenuStrip();
            browseItem.Items.Add("Execute game", null, Execute_Click);
            browseItem.Items.Add("Execute server", null, ExecuteServer_Click);
            browseItem.Items.Add("Browse local files", null, BrowseItem_Click);
            browseItem.Items.Add("Modify settings", null, ModifySettings_Click);
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            executeGame();
        }

        private void ExecuteServer_Click(object sender, EventArgs e)
        {
            if (gamesList.SelectedItem is Game game)
            {
                String serverPath;
                if (game.GameServerPath == "default" || game.GameServerPath == null)
                {
                    serverPath = "GameServer.exe";
                }
                else
                {
                    serverPath = game.GameServerPath;
                }

                var info = new ProcessStartInfo
                {
                    FileName = Path.Combine(Path.GetDirectoryName(game.Path), serverPath),
                    WorkingDirectory = Path.GetDirectoryName(game.Path),
                    UseShellExecute = true
                };
                try
                {
                    Process.Start(info);
                }
                catch
                {
                    MessageBox.Show("No gameserver binary was found. (" + game.GameServerPath + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BrowseItem_Click(object sender, EventArgs e)
        {
            openDirectory();
        }

        private void ModifySettings_Click(object sender, EventArgs e)
        {
            if (gamesList.SelectedItem is Game game)
            {
                try
                {
                    Process.Start(Path.Combine(Path.GetDirectoryName(game.Path), "settings.cfg"));
                }
                catch {
                    MessageBox.Show("No settings.cfg file was found. Are you sure this is a valid installation?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void saveData()
        {
            var games = new List<Game>();
            foreach (var item in gamesList.Items)
            {
                if (item is Game game)
                {
                    if (game.GameServerPath == "default")
                    {
                        game.GameServerPath = null;
                    }
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

        public void updateGame(Game game)
        {
            var index = gamesList.Items.IndexOf(game);
            if (index >= 0)
            {
                gamesList.Items[index] = game;
            }
            saveData();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddGame form = new AddGame(this, "ADD", null);
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
                    gameIcon.Image = Properties.Resources.unknown;
                    gameName.Text = "Invalid game";
                    gameDescription.Text = "Game couldn't be found.";
                    gamePath.Visible = false;
                    deleteButton.Enabled = true;
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
                modifyButton.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            executeGame();
        }

        private void executeGame()
        {
            if (gamesList.SelectedItem is Game game)
            {
                var info = new ProcessStartInfo
                {
                    FileName = game.Path,
                    WorkingDirectory = Path.GetDirectoryName(game.Path),
                    UseShellExecute = true
                };

                try
                {
                    Process.Start(info);
                }
                catch { }
            }
        }

        private void openDirectory()
        {
            if (gamesList.SelectedItem is Game game)
            {
                try
                {
                    Process.Start("explorer", Path.GetDirectoryName(game.Path));
                }
                catch { }
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
                    gameName.Text = "No game selected";
                    gameIcon.Image = Properties.Resources.unknown;
                    gamePath.Visible = false;
                    playButton.Enabled = false;
                    deleteButton.Enabled = false;
                    modifyButton.Enabled = false;

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
            executeGame();
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            if (gamesList.SelectedItem is Game game)
            {
                AddGame form = new AddGame(this, "MODIFY", game);
                form.ShowDialog();
            }
        }

        private void gamesList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            int index = gamesList.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                gamesList.SelectedIndex = index;
                browseItem.Show(gamesList, e.Location);
            }
        }

        private void gamePath_MouseEnter(object sender, EventArgs e)
        {
            gamePath.ForeColor = Color.Salmon;
            this.Cursor = Cursors.Hand;
        }

        private void gamePath_MouseLeave(object sender, EventArgs e)
        {
            gamePath.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void gamePath_Click(object sender, EventArgs e)
        {
            openDirectory();
        }
    }
}