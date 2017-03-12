namespace show_builder
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxStrategies = new System.Windows.Forms.ListBox();
            this.buttonAddStrategy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxGames = new System.Windows.Forms.ListBox();
            this.buttonStrategyDetails = new System.Windows.Forms.Button();
            this.buttonCreateGame = new System.Windows.Forms.Button();
            this.buttonGameDetails = new System.Windows.Forms.Button();
            this.buttonDeleteGame = new System.Windows.Forms.Button();
            this.buttonBrowsePlayer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxStrategies
            // 
            this.listBoxStrategies.FormattingEnabled = true;
            this.listBoxStrategies.Location = new System.Drawing.Point(15, 25);
            this.listBoxStrategies.Name = "listBoxStrategies";
            this.listBoxStrategies.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxStrategies.Size = new System.Drawing.Size(360, 134);
            this.listBoxStrategies.TabIndex = 0;
            // 
            // buttonAddStrategy
            // 
            this.buttonAddStrategy.Location = new System.Drawing.Point(15, 165);
            this.buttonAddStrategy.Name = "buttonAddStrategy";
            this.buttonAddStrategy.Size = new System.Drawing.Size(123, 23);
            this.buttonAddStrategy.TabIndex = 1;
            this.buttonAddStrategy.Text = "Add strategy";
            this.buttonAddStrategy.UseVisualStyleBackColor = true;
            this.buttonAddStrategy.Click += new System.EventHandler(this.buttonStrategyAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Strategies:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(378, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Games:";
            // 
            // listBoxGames
            // 
            this.listBoxGames.FormattingEnabled = true;
            this.listBoxGames.Location = new System.Drawing.Point(381, 25);
            this.listBoxGames.Name = "listBoxGames";
            this.listBoxGames.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxGames.Size = new System.Drawing.Size(400, 134);
            this.listBoxGames.TabIndex = 26;
            // 
            // buttonStrategyDetails
            // 
            this.buttonStrategyDetails.Location = new System.Drawing.Point(144, 165);
            this.buttonStrategyDetails.Name = "buttonStrategyDetails";
            this.buttonStrategyDetails.Size = new System.Drawing.Size(99, 23);
            this.buttonStrategyDetails.TabIndex = 35;
            this.buttonStrategyDetails.Text = "Details";
            this.buttonStrategyDetails.UseVisualStyleBackColor = true;
            this.buttonStrategyDetails.Click += new System.EventHandler(this.buttonStrategyDetails_Click);
            // 
            // buttonCreateGame
            // 
            this.buttonCreateGame.Location = new System.Drawing.Point(381, 165);
            this.buttonCreateGame.Name = "buttonCreateGame";
            this.buttonCreateGame.Size = new System.Drawing.Size(123, 23);
            this.buttonCreateGame.TabIndex = 36;
            this.buttonCreateGame.Text = "2. Create game";
            this.buttonCreateGame.UseVisualStyleBackColor = true;
            this.buttonCreateGame.Click += new System.EventHandler(this.buttonCreateGame_Click);
            // 
            // buttonGameDetails
            // 
            this.buttonGameDetails.Location = new System.Drawing.Point(706, 165);
            this.buttonGameDetails.Name = "buttonGameDetails";
            this.buttonGameDetails.Size = new System.Drawing.Size(75, 23);
            this.buttonGameDetails.TabIndex = 37;
            this.buttonGameDetails.Text = "Details";
            this.buttonGameDetails.UseVisualStyleBackColor = true;
            this.buttonGameDetails.Click += new System.EventHandler(this.buttonGameDetails_Click);
            // 
            // buttonDeleteGame
            // 
            this.buttonDeleteGame.Location = new System.Drawing.Point(510, 165);
            this.buttonDeleteGame.Name = "buttonDeleteGame";
            this.buttonDeleteGame.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteGame.TabIndex = 38;
            this.buttonDeleteGame.Text = "Delete";
            this.buttonDeleteGame.UseVisualStyleBackColor = true;
            this.buttonDeleteGame.Click += new System.EventHandler(this.buttonDeleteGame_Click);
            // 
            // buttonBrowsePlayer
            // 
            this.buttonBrowsePlayer.Location = new System.Drawing.Point(15, 222);
            this.buttonBrowsePlayer.Name = "buttonBrowsePlayer";
            this.buttonBrowsePlayer.Size = new System.Drawing.Size(99, 23);
            this.buttonBrowsePlayer.TabIndex = 47;
            this.buttonBrowsePlayer.Text = "Browse player";
            this.buttonBrowsePlayer.UseVisualStyleBackColor = true;
            this.buttonBrowsePlayer.Click += new System.EventHandler(this.buttonBrowsePlayer_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 257);
            this.Controls.Add(this.buttonBrowsePlayer);
            this.Controls.Add(this.buttonDeleteGame);
            this.Controls.Add(this.buttonGameDetails);
            this.Controls.Add(this.buttonCreateGame);
            this.Controls.Add(this.buttonStrategyDetails);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBoxGames);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAddStrategy);
            this.Controls.Add(this.listBoxStrategies);
            this.Name = "FormMain";
            this.Text = "Show builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxStrategies;
        private System.Windows.Forms.Button buttonAddStrategy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxGames;
        private System.Windows.Forms.Button buttonStrategyDetails;
        private System.Windows.Forms.Button buttonCreateGame;
        private System.Windows.Forms.Button buttonGameDetails;
        private System.Windows.Forms.Button buttonDeleteGame;
        private System.Windows.Forms.Button buttonBrowsePlayer;
    }
}

