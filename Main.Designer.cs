namespace Sacred_Launcher
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.gamesList = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.gameDescription = new System.Windows.Forms.TextBox();
            this.gameIcon = new System.Windows.Forms.PictureBox();
            this.playButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.gameName = new System.Windows.Forms.Label();
            this.gamePath = new System.Windows.Forms.Label();
            this.modifyButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.executeCooldown = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gameIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // gamesList
            // 
            this.gamesList.FormattingEnabled = true;
            resources.ApplyResources(this.gamesList, "gamesList");
            this.gamesList.Name = "gamesList";
            this.gamesList.SelectedIndexChanged += new System.EventHandler(this.gamesList_SelectedIndexChanged);
            this.gamesList.DoubleClick += new System.EventHandler(this.gamesList_DoubleClick);
            this.gamesList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gamesList_MouseUp);
            // 
            // addButton
            // 
            resources.ApplyResources(this.addButton, "addButton");
            this.addButton.Name = "addButton";
            this.toolTip1.SetToolTip(this.addButton, resources.GetString("addButton.ToolTip"));
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // gameDescription
            // 
            resources.ApplyResources(this.gameDescription, "gameDescription");
            this.gameDescription.Name = "gameDescription";
            this.gameDescription.ReadOnly = true;
            // 
            // gameIcon
            // 
            this.gameIcon.Image = global::Sacred_Launcher.Properties.Resources.unknown;
            resources.ApplyResources(this.gameIcon, "gameIcon");
            this.gameIcon.Name = "gameIcon";
            this.gameIcon.TabStop = false;
            // 
            // playButton
            // 
            resources.ApplyResources(this.playButton, "playButton");
            this.playButton.Name = "playButton";
            this.toolTip1.SetToolTip(this.playButton, resources.GetString("playButton.ToolTip"));
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // deleteButton
            // 
            resources.ApplyResources(this.deleteButton, "deleteButton");
            this.deleteButton.Name = "deleteButton";
            this.toolTip1.SetToolTip(this.deleteButton, resources.GetString("deleteButton.ToolTip"));
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.toolTip1.SetToolTip(this.button3, resources.GetString("button3.ToolTip"));
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // gameName
            // 
            this.gameName.AutoEllipsis = true;
            resources.ApplyResources(this.gameName, "gameName");
            this.gameName.Name = "gameName";
            // 
            // gamePath
            // 
            this.gamePath.AutoEllipsis = true;
            resources.ApplyResources(this.gamePath, "gamePath");
            this.gamePath.Name = "gamePath";
            this.toolTip1.SetToolTip(this.gamePath, resources.GetString("gamePath.ToolTip"));
            this.gamePath.Click += new System.EventHandler(this.gamePath_Click);
            this.gamePath.MouseEnter += new System.EventHandler(this.gamePath_MouseEnter);
            this.gamePath.MouseLeave += new System.EventHandler(this.gamePath_MouseLeave);
            // 
            // modifyButton
            // 
            resources.ApplyResources(this.modifyButton, "modifyButton");
            this.modifyButton.Name = "modifyButton";
            this.toolTip1.SetToolTip(this.modifyButton, resources.GetString("modifyButton.ToolTip"));
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // executeCooldown
            // 
            this.executeCooldown.Interval = 1000;
            this.executeCooldown.Tick += new System.EventHandler(this.executeCooldown_Tick);
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.gamePath);
            this.Controls.Add(this.gameName);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.gameIcon);
            this.Controls.Add(this.gameDescription);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.gamesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gameIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox gamesList;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox gameDescription;
        private System.Windows.Forms.PictureBox gameIcon;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label gameName;
        private System.Windows.Forms.Label gamePath;
        private System.Windows.Forms.Button modifyButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer executeCooldown;
    }
}

