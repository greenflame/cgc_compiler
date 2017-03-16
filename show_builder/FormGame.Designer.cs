namespace show_builder
{
    partial class FormGame
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
            this.tabControlLoggers = new System.Windows.Forms.TabControl();
            this.tabPageBrief = new System.Windows.Forms.TabPage();
            this.richTextBoxBrief = new System.Windows.Forms.RichTextBox();
            this.tabPageExecution = new System.Windows.Forms.TabPage();
            this.richTextBoxExecution = new System.Windows.Forms.RichTextBox();
            this.tabPageGame = new System.Windows.Forms.TabPage();
            this.richTextBoxGame = new System.Windows.Forms.RichTextBox();
            this.buttonStopBuild = new System.Windows.Forms.Button();
            this.buttonPlayGame = new System.Windows.Forms.Button();
            this.buttonBuildGame = new System.Windows.Forms.Button();
            this.labelLeftStrategyName = new System.Windows.Forms.Label();
            this.labelRightStrategyName = new System.Windows.Forms.Label();
            this.labelGameState = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.comboBoxLeftStrategy = new System.Windows.Forms.ComboBox();
            this.comboBoxRightStrategy = new System.Windows.Forms.ComboBox();
            this.tabControlLoggers.SuspendLayout();
            this.tabPageBrief.SuspendLayout();
            this.tabPageExecution.SuspendLayout();
            this.tabPageGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlLoggers
            // 
            this.tabControlLoggers.Controls.Add(this.tabPageBrief);
            this.tabControlLoggers.Controls.Add(this.tabPageExecution);
            this.tabControlLoggers.Controls.Add(this.tabPageGame);
            this.tabControlLoggers.Location = new System.Drawing.Point(14, 92);
            this.tabControlLoggers.Name = "tabControlLoggers";
            this.tabControlLoggers.SelectedIndex = 0;
            this.tabControlLoggers.Size = new System.Drawing.Size(497, 229);
            this.tabControlLoggers.TabIndex = 32;
            // 
            // tabPageBrief
            // 
            this.tabPageBrief.Controls.Add(this.richTextBoxBrief);
            this.tabPageBrief.Location = new System.Drawing.Point(4, 22);
            this.tabPageBrief.Name = "tabPageBrief";
            this.tabPageBrief.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBrief.Size = new System.Drawing.Size(489, 203);
            this.tabPageBrief.TabIndex = 0;
            this.tabPageBrief.Text = "Brief logger";
            this.tabPageBrief.UseVisualStyleBackColor = true;
            // 
            // richTextBoxBrief
            // 
            this.richTextBoxBrief.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxBrief.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxBrief.Name = "richTextBoxBrief";
            this.richTextBoxBrief.Size = new System.Drawing.Size(483, 197);
            this.richTextBoxBrief.TabIndex = 16;
            this.richTextBoxBrief.Text = "";
            // 
            // tabPageExecution
            // 
            this.tabPageExecution.Controls.Add(this.richTextBoxExecution);
            this.tabPageExecution.Location = new System.Drawing.Point(4, 22);
            this.tabPageExecution.Name = "tabPageExecution";
            this.tabPageExecution.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExecution.Size = new System.Drawing.Size(489, 203);
            this.tabPageExecution.TabIndex = 1;
            this.tabPageExecution.Text = "Execution logger";
            this.tabPageExecution.UseVisualStyleBackColor = true;
            // 
            // richTextBoxExecution
            // 
            this.richTextBoxExecution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxExecution.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxExecution.Name = "richTextBoxExecution";
            this.richTextBoxExecution.Size = new System.Drawing.Size(483, 197);
            this.richTextBoxExecution.TabIndex = 17;
            this.richTextBoxExecution.Text = "";
            // 
            // tabPageGame
            // 
            this.tabPageGame.Controls.Add(this.richTextBoxGame);
            this.tabPageGame.Location = new System.Drawing.Point(4, 22);
            this.tabPageGame.Name = "tabPageGame";
            this.tabPageGame.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGame.Size = new System.Drawing.Size(489, 203);
            this.tabPageGame.TabIndex = 2;
            this.tabPageGame.Text = "Game logger";
            this.tabPageGame.UseVisualStyleBackColor = true;
            // 
            // richTextBoxGame
            // 
            this.richTextBoxGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxGame.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxGame.Name = "richTextBoxGame";
            this.richTextBoxGame.Size = new System.Drawing.Size(483, 197);
            this.richTextBoxGame.TabIndex = 21;
            this.richTextBoxGame.Text = "";
            // 
            // buttonStopBuild
            // 
            this.buttonStopBuild.Location = new System.Drawing.Point(413, 10);
            this.buttonStopBuild.Name = "buttonStopBuild";
            this.buttonStopBuild.Size = new System.Drawing.Size(98, 23);
            this.buttonStopBuild.TabIndex = 45;
            this.buttonStopBuild.Text = "Stop build";
            this.buttonStopBuild.UseVisualStyleBackColor = true;
            this.buttonStopBuild.Click += new System.EventHandler(this.buttonStopBuild_Click);
            // 
            // buttonPlayGame
            // 
            this.buttonPlayGame.Location = new System.Drawing.Point(309, 36);
            this.buttonPlayGame.Name = "buttonPlayGame";
            this.buttonPlayGame.Size = new System.Drawing.Size(98, 23);
            this.buttonPlayGame.TabIndex = 44;
            this.buttonPlayGame.Text = "Play game";
            this.buttonPlayGame.UseVisualStyleBackColor = true;
            this.buttonPlayGame.Click += new System.EventHandler(this.buttonPlayGame_Click);
            // 
            // buttonBuildGame
            // 
            this.buttonBuildGame.Location = new System.Drawing.Point(309, 10);
            this.buttonBuildGame.Name = "buttonBuildGame";
            this.buttonBuildGame.Size = new System.Drawing.Size(98, 23);
            this.buttonBuildGame.TabIndex = 43;
            this.buttonBuildGame.Text = "Build game";
            this.buttonBuildGame.UseVisualStyleBackColor = true;
            this.buttonBuildGame.Click += new System.EventHandler(this.buttonBuildGame_Click);
            // 
            // labelLeftStrategyName
            // 
            this.labelLeftStrategyName.AutoSize = true;
            this.labelLeftStrategyName.Location = new System.Drawing.Point(11, 15);
            this.labelLeftStrategyName.Name = "labelLeftStrategyName";
            this.labelLeftStrategyName.Size = new System.Drawing.Size(67, 13);
            this.labelLeftStrategyName.TabIndex = 46;
            this.labelLeftStrategyName.Text = "Game name:";
            // 
            // labelRightStrategyName
            // 
            this.labelRightStrategyName.AutoSize = true;
            this.labelRightStrategyName.Location = new System.Drawing.Point(11, 41);
            this.labelRightStrategyName.Name = "labelRightStrategyName";
            this.labelRightStrategyName.Size = new System.Drawing.Size(68, 13);
            this.labelRightStrategyName.TabIndex = 47;
            this.labelRightStrategyName.Text = "Left strategy:";
            // 
            // labelGameState
            // 
            this.labelGameState.AutoSize = true;
            this.labelGameState.Location = new System.Drawing.Point(11, 68);
            this.labelGameState.Name = "labelGameState";
            this.labelGameState.Size = new System.Drawing.Size(75, 13);
            this.labelGameState.TabIndex = 48;
            this.labelGameState.Text = "Right strategy:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(96, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(197, 20);
            this.textBoxName.TabIndex = 49;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // comboBoxLeftStrategy
            // 
            this.comboBoxLeftStrategy.FormattingEnabled = true;
            this.comboBoxLeftStrategy.Location = new System.Drawing.Point(96, 38);
            this.comboBoxLeftStrategy.Name = "comboBoxLeftStrategy";
            this.comboBoxLeftStrategy.Size = new System.Drawing.Size(197, 21);
            this.comboBoxLeftStrategy.TabIndex = 50;
            this.comboBoxLeftStrategy.SelectedIndexChanged += new System.EventHandler(this.comboBoxLeftStrategy_SelectedIndexChanged);
            // 
            // comboBoxRightStrategy
            // 
            this.comboBoxRightStrategy.FormattingEnabled = true;
            this.comboBoxRightStrategy.Location = new System.Drawing.Point(96, 65);
            this.comboBoxRightStrategy.Name = "comboBoxRightStrategy";
            this.comboBoxRightStrategy.Size = new System.Drawing.Size(197, 21);
            this.comboBoxRightStrategy.TabIndex = 51;
            this.comboBoxRightStrategy.SelectedIndexChanged += new System.EventHandler(this.comboBoxRightStrategy_SelectedIndexChanged);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 333);
            this.Controls.Add(this.comboBoxRightStrategy);
            this.Controls.Add(this.comboBoxLeftStrategy);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelGameState);
            this.Controls.Add(this.labelRightStrategyName);
            this.Controls.Add(this.labelLeftStrategyName);
            this.Controls.Add(this.buttonStopBuild);
            this.Controls.Add(this.buttonPlayGame);
            this.Controls.Add(this.buttonBuildGame);
            this.Controls.Add(this.tabControlLoggers);
            this.Name = "FormGame";
            this.Text = "FormGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGame_FormClosing);
            this.tabControlLoggers.ResumeLayout(false);
            this.tabPageBrief.ResumeLayout(false);
            this.tabPageExecution.ResumeLayout(false);
            this.tabPageGame.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControlLoggers;
        private System.Windows.Forms.TabPage tabPageBrief;
        private System.Windows.Forms.RichTextBox richTextBoxBrief;
        private System.Windows.Forms.TabPage tabPageExecution;
        private System.Windows.Forms.RichTextBox richTextBoxExecution;
        private System.Windows.Forms.TabPage tabPageGame;
        private System.Windows.Forms.RichTextBox richTextBoxGame;
        private System.Windows.Forms.Button buttonStopBuild;
        private System.Windows.Forms.Button buttonPlayGame;
        private System.Windows.Forms.Button buttonBuildGame;
        private System.Windows.Forms.Label labelLeftStrategyName;
        private System.Windows.Forms.Label labelRightStrategyName;
        private System.Windows.Forms.Label labelGameState;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ComboBox comboBoxLeftStrategy;
        private System.Windows.Forms.ComboBox comboBoxRightStrategy;
    }
}