namespace Sacred_Launcher
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gamesList = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.gameDescription = new System.Windows.Forms.TextBox();
            this.gameIcon = new System.Windows.Forms.PictureBox();
            this.playButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.gameName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gameIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // gamesList
            // 
            this.gamesList.FormattingEnabled = true;
            this.gamesList.Location = new System.Drawing.Point(120, 12);
            this.gamesList.Name = "gamesList";
            this.gamesList.Size = new System.Drawing.Size(379, 173);
            this.gamesList.TabIndex = 0;
            this.gamesList.SelectedIndexChanged += new System.EventHandler(this.gamesList_SelectedIndexChanged);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(500, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(20, 20);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // gameDescription
            // 
            this.gameDescription.Location = new System.Drawing.Point(12, 48);
            this.gameDescription.Multiline = true;
            this.gameDescription.Name = "gameDescription";
            this.gameDescription.ReadOnly = true;
            this.gameDescription.Size = new System.Drawing.Size(100, 137);
            this.gameDescription.TabIndex = 3;
            this.gameDescription.Visible = false;
            // 
            // gameIcon
            // 
            this.gameIcon.Location = new System.Drawing.Point(12, 24);
            this.gameIcon.Name = "gameIcon";
            this.gameIcon.Size = new System.Drawing.Size(20, 20);
            this.gameIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gameIcon.TabIndex = 4;
            this.gameIcon.TabStop = false;
            this.gameIcon.Visible = false;
            // 
            // playButton
            // 
            this.playButton.Enabled = false;
            this.playButton.Location = new System.Drawing.Point(424, 191);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 5;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(500, 34);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(20, 20);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "-";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(343, 191);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Server list";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // gameName
            // 
            this.gameName.AutoSize = true;
            this.gameName.Location = new System.Drawing.Point(35, 32);
            this.gameName.Name = "gameName";
            this.gameName.Size = new System.Drawing.Size(35, 13);
            this.gameName.TabIndex = 8;
            this.gameName.Text = "label1";
            this.gameName.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 228);
            this.Controls.Add(this.gameName);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.gameIcon);
            this.Controls.Add(this.gameDescription);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.gamesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sacred Launcher";
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
    }
}

