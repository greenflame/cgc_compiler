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
            this.components = new System.ComponentModel.Container();
            this.listBoxStrategies = new System.Windows.Forms.ListBox();
            this.contextMenuStripStrategy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextGameAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.contextGameDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.contextGameRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAddStrategy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxGames = new System.Windows.Forms.ListBox();
            this.contextMenuStripGame = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.buildToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stopBuildToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonStrategyDetails = new System.Windows.Forms.Button();
            this.buttonCreateGame = new System.Windows.Forms.Button();
            this.buttonGameDetails = new System.Windows.Forms.Button();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.strategyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopBuildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripStrategy.SuspendLayout();
            this.contextMenuStripGame.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxStrategies
            // 
            this.listBoxStrategies.ContextMenuStrip = this.contextMenuStripStrategy;
            this.listBoxStrategies.FormattingEnabled = true;
            this.listBoxStrategies.Location = new System.Drawing.Point(15, 50);
            this.listBoxStrategies.Name = "listBoxStrategies";
            this.listBoxStrategies.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxStrategies.Size = new System.Drawing.Size(260, 160);
            this.listBoxStrategies.TabIndex = 0;
            this.listBoxStrategies.DoubleClick += new System.EventHandler(this.StrategyDetails);
            // 
            // contextMenuStripStrategy
            // 
            this.contextMenuStripStrategy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextGameAdd,
            this.contextGameDetails,
            this.contextGameRemove});
            this.contextMenuStripStrategy.Name = "contextMenuStripStrategy";
            this.contextMenuStripStrategy.Size = new System.Drawing.Size(118, 70);
            // 
            // contextGameAdd
            // 
            this.contextGameAdd.Name = "contextGameAdd";
            this.contextGameAdd.Size = new System.Drawing.Size(117, 22);
            this.contextGameAdd.Text = "Add";
            this.contextGameAdd.Click += new System.EventHandler(this.AddStrategy);
            // 
            // contextGameDetails
            // 
            this.contextGameDetails.Name = "contextGameDetails";
            this.contextGameDetails.Size = new System.Drawing.Size(117, 22);
            this.contextGameDetails.Text = "Details";
            this.contextGameDetails.Click += new System.EventHandler(this.StrategyDetails);
            // 
            // contextGameRemove
            // 
            this.contextGameRemove.Name = "contextGameRemove";
            this.contextGameRemove.Size = new System.Drawing.Size(117, 22);
            this.contextGameRemove.Text = "Remove";
            this.contextGameRemove.Click += new System.EventHandler(this.RemoveStrategies);
            // 
            // buttonAddStrategy
            // 
            this.buttonAddStrategy.Location = new System.Drawing.Point(15, 216);
            this.buttonAddStrategy.Name = "buttonAddStrategy";
            this.buttonAddStrategy.Size = new System.Drawing.Size(123, 23);
            this.buttonAddStrategy.TabIndex = 1;
            this.buttonAddStrategy.Text = "Add strategy";
            this.buttonAddStrategy.UseVisualStyleBackColor = true;
            this.buttonAddStrategy.Click += new System.EventHandler(this.AddStrategy);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Strategies:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(278, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Games:";
            // 
            // listBoxGames
            // 
            this.listBoxGames.ContextMenuStrip = this.contextMenuStripGame;
            this.listBoxGames.FormattingEnabled = true;
            this.listBoxGames.Location = new System.Drawing.Point(281, 50);
            this.listBoxGames.Name = "listBoxGames";
            this.listBoxGames.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxGames.Size = new System.Drawing.Size(260, 160);
            this.listBoxGames.TabIndex = 26;
            this.listBoxGames.DoubleClick += new System.EventHandler(this.GameDetails);
            // 
            // contextMenuStripGame
            // 
            this.contextMenuStripGame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem1,
            this.detailsToolStripMenuItem2,
            this.deleteToolStripMenuItem1,
            this.toolStripSeparator3,
            this.buildToolStripMenuItem1,
            this.stopBuildToolStripMenuItem1,
            this.playToolStripMenuItem1});
            this.contextMenuStripGame.Name = "contextMenuStripGame";
            this.contextMenuStripGame.Size = new System.Drawing.Size(129, 142);
            // 
            // createToolStripMenuItem1
            // 
            this.createToolStripMenuItem1.Name = "createToolStripMenuItem1";
            this.createToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.createToolStripMenuItem1.Text = "Create";
            this.createToolStripMenuItem1.Click += new System.EventHandler(this.CreateGame);
            // 
            // detailsToolStripMenuItem2
            // 
            this.detailsToolStripMenuItem2.Name = "detailsToolStripMenuItem2";
            this.detailsToolStripMenuItem2.Size = new System.Drawing.Size(128, 22);
            this.detailsToolStripMenuItem2.Text = "Details";
            this.detailsToolStripMenuItem2.Click += new System.EventHandler(this.GameDetails);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.RemoveGames);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(125, 6);
            // 
            // buildToolStripMenuItem1
            // 
            this.buildToolStripMenuItem1.Name = "buildToolStripMenuItem1";
            this.buildToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.buildToolStripMenuItem1.Text = "Build";
            this.buildToolStripMenuItem1.Click += new System.EventHandler(this.BuildGame);
            // 
            // stopBuildToolStripMenuItem1
            // 
            this.stopBuildToolStripMenuItem1.Name = "stopBuildToolStripMenuItem1";
            this.stopBuildToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.stopBuildToolStripMenuItem1.Text = "Stop build";
            this.stopBuildToolStripMenuItem1.Click += new System.EventHandler(this.StopBuild);
            // 
            // playToolStripMenuItem1
            // 
            this.playToolStripMenuItem1.Name = "playToolStripMenuItem1";
            this.playToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.playToolStripMenuItem1.Text = "Play";
            // 
            // buttonStrategyDetails
            // 
            this.buttonStrategyDetails.Location = new System.Drawing.Point(144, 216);
            this.buttonStrategyDetails.Name = "buttonStrategyDetails";
            this.buttonStrategyDetails.Size = new System.Drawing.Size(75, 23);
            this.buttonStrategyDetails.TabIndex = 35;
            this.buttonStrategyDetails.Text = "Details";
            this.buttonStrategyDetails.UseVisualStyleBackColor = true;
            this.buttonStrategyDetails.Click += new System.EventHandler(this.StrategyDetails);
            // 
            // buttonCreateGame
            // 
            this.buttonCreateGame.Location = new System.Drawing.Point(281, 216);
            this.buttonCreateGame.Name = "buttonCreateGame";
            this.buttonCreateGame.Size = new System.Drawing.Size(123, 23);
            this.buttonCreateGame.TabIndex = 36;
            this.buttonCreateGame.Text = "Create game";
            this.buttonCreateGame.UseVisualStyleBackColor = true;
            this.buttonCreateGame.Click += new System.EventHandler(this.CreateGame);
            // 
            // buttonGameDetails
            // 
            this.buttonGameDetails.Location = new System.Drawing.Point(410, 216);
            this.buttonGameDetails.Name = "buttonGameDetails";
            this.buttonGameDetails.Size = new System.Drawing.Size(75, 23);
            this.buttonGameDetails.TabIndex = 37;
            this.buttonGameDetails.Text = "Details";
            this.buttonGameDetails.UseVisualStyleBackColor = true;
            this.buttonGameDetails.Click += new System.EventHandler(this.GameDetails);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strategyToolStripMenuItem,
            this.gameToolStripMenuItem,
            this.preferencesToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(554, 24);
            this.menuStripMain.TabIndex = 48;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // strategyToolStripMenuItem
            // 
            this.strategyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.detailsToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.strategyToolStripMenuItem.Name = "strategyToolStripMenuItem";
            this.strategyToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.strategyToolStripMenuItem.Text = "Strategy";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.AddStrategy);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.detailsToolStripMenuItem.Text = "Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.StrategyDetails);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveStrategies);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.detailsToolStripMenuItem1,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator1,
            this.buildToolStripMenuItem,
            this.stopBuildToolStripMenuItem,
            this.playToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.CreateGame);
            // 
            // detailsToolStripMenuItem1
            // 
            this.detailsToolStripMenuItem1.Name = "detailsToolStripMenuItem1";
            this.detailsToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.detailsToolStripMenuItem1.Text = "Details";
            this.detailsToolStripMenuItem1.Click += new System.EventHandler(this.GameDetails);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.RemoveGames);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.buildToolStripMenuItem.Text = "Build";
            this.buildToolStripMenuItem.Click += new System.EventHandler(this.BuildGame);
            // 
            // stopBuildToolStripMenuItem
            // 
            this.stopBuildToolStripMenuItem.Name = "stopBuildToolStripMenuItem";
            this.stopBuildToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.stopBuildToolStripMenuItem.Text = "Stop build";
            this.stopBuildToolStripMenuItem.Click += new System.EventHandler(this.StopBuild);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.playToolStripMenuItem.Text = "Play";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem1,
            this.toolStripSeparator2,
            this.saveStateToolStripMenuItem,
            this.loadStateToolStripMenuItem});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // saveStateToolStripMenuItem
            // 
            this.saveStateToolStripMenuItem.Name = "saveStateToolStripMenuItem";
            this.saveStateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveStateToolStripMenuItem.Text = "Save games";
            this.saveStateToolStripMenuItem.Click += new System.EventHandler(this.saveStateToolStripMenuItem_Click);
            // 
            // loadStateToolStripMenuItem
            // 
            this.loadStateToolStripMenuItem.Name = "loadStateToolStripMenuItem";
            this.loadStateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadStateToolStripMenuItem.Text = "Load games";
            this.loadStateToolStripMenuItem.Click += new System.EventHandler(this.loadStateToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // preferencesToolStripMenuItem1
            // 
            this.preferencesToolStripMenuItem1.Name = "preferencesToolStripMenuItem1";
            this.preferencesToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.preferencesToolStripMenuItem1.Text = "Player";
            this.preferencesToolStripMenuItem1.Click += new System.EventHandler(this.preferencesToolStripMenuItem1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 250);
            this.Controls.Add(this.buttonGameDetails);
            this.Controls.Add(this.buttonCreateGame);
            this.Controls.Add(this.buttonStrategyDetails);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBoxGames);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAddStrategy);
            this.Controls.Add(this.listBoxStrategies);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormMain";
            this.Text = "Show builder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.contextMenuStripStrategy.ResumeLayout(false);
            this.contextMenuStripGame.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
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
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem strategyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopBuildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripStrategy;
        private System.Windows.Forms.ToolStripMenuItem contextGameAdd;
        private System.Windows.Forms.ToolStripMenuItem contextGameDetails;
        private System.Windows.Forms.ToolStripMenuItem contextGameRemove;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGame;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stopBuildToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem1;
    }
}

