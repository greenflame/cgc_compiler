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
            this.tabControlLoggers.Location = new System.Drawing.Point(318, 63);
            this.tabControlLoggers.Name = "tabControlLoggers";
            this.tabControlLoggers.SelectedIndex = 0;
            this.tabControlLoggers.Size = new System.Drawing.Size(483, 229);
            this.tabControlLoggers.TabIndex = 32;
            // 
            // tabPageBrief
            // 
            this.tabPageBrief.Controls.Add(this.richTextBoxBrief);
            this.tabPageBrief.Location = new System.Drawing.Point(4, 22);
            this.tabPageBrief.Name = "tabPageBrief";
            this.tabPageBrief.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBrief.Size = new System.Drawing.Size(475, 203);
            this.tabPageBrief.TabIndex = 0;
            this.tabPageBrief.Text = "Brief logger";
            this.tabPageBrief.UseVisualStyleBackColor = true;
            // 
            // richTextBoxBrief
            // 
            this.richTextBoxBrief.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxBrief.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxBrief.Name = "richTextBoxBrief";
            this.richTextBoxBrief.Size = new System.Drawing.Size(469, 197);
            this.richTextBoxBrief.TabIndex = 16;
            this.richTextBoxBrief.Text = "";
            // 
            // tabPageExecution
            // 
            this.tabPageExecution.Controls.Add(this.richTextBoxExecution);
            this.tabPageExecution.Location = new System.Drawing.Point(4, 22);
            this.tabPageExecution.Name = "tabPageExecution";
            this.tabPageExecution.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExecution.Size = new System.Drawing.Size(352, 159);
            this.tabPageExecution.TabIndex = 1;
            this.tabPageExecution.Text = "Execution logger";
            this.tabPageExecution.UseVisualStyleBackColor = true;
            // 
            // richTextBoxExecution
            // 
            this.richTextBoxExecution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxExecution.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxExecution.Name = "richTextBoxExecution";
            this.richTextBoxExecution.Size = new System.Drawing.Size(346, 153);
            this.richTextBoxExecution.TabIndex = 17;
            this.richTextBoxExecution.Text = "";
            // 
            // tabPageGame
            // 
            this.tabPageGame.Controls.Add(this.richTextBoxGame);
            this.tabPageGame.Location = new System.Drawing.Point(4, 22);
            this.tabPageGame.Name = "tabPageGame";
            this.tabPageGame.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGame.Size = new System.Drawing.Size(352, 159);
            this.tabPageGame.TabIndex = 2;
            this.tabPageGame.Text = "Game logger";
            this.tabPageGame.UseVisualStyleBackColor = true;
            // 
            // richTextBoxGame
            // 
            this.richTextBoxGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxGame.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxGame.Name = "richTextBoxGame";
            this.richTextBoxGame.Size = new System.Drawing.Size(346, 153);
            this.richTextBoxGame.TabIndex = 21;
            this.richTextBoxGame.Text = "";
            // 
            // buttonStopBuild
            // 
            this.buttonStopBuild.Location = new System.Drawing.Point(141, 51);
            this.buttonStopBuild.Name = "buttonStopBuild";
            this.buttonStopBuild.Size = new System.Drawing.Size(75, 23);
            this.buttonStopBuild.TabIndex = 45;
            this.buttonStopBuild.Text = "Stop build";
            this.buttonStopBuild.UseVisualStyleBackColor = true;
            this.buttonStopBuild.Click += new System.EventHandler(this.buttonStopBuild_Click);
            // 
            // buttonPlayGame
            // 
            this.buttonPlayGame.Location = new System.Drawing.Point(12, 80);
            this.buttonPlayGame.Name = "buttonPlayGame";
            this.buttonPlayGame.Size = new System.Drawing.Size(123, 23);
            this.buttonPlayGame.TabIndex = 44;
            this.buttonPlayGame.Text = "4. Play game";
            this.buttonPlayGame.UseVisualStyleBackColor = true;
            this.buttonPlayGame.Click += new System.EventHandler(this.buttonPlayGame_Click);
            // 
            // buttonBuildGame
            // 
            this.buttonBuildGame.Location = new System.Drawing.Point(12, 51);
            this.buttonBuildGame.Name = "buttonBuildGame";
            this.buttonBuildGame.Size = new System.Drawing.Size(123, 23);
            this.buttonBuildGame.TabIndex = 43;
            this.buttonBuildGame.Text = "3. Build game";
            this.buttonBuildGame.UseVisualStyleBackColor = true;
            this.buttonBuildGame.Click += new System.EventHandler(this.buttonBuildGame_Click);
            // 
            // labelLeftStrategyName
            // 
            this.labelLeftStrategyName.AutoSize = true;
            this.labelLeftStrategyName.Location = new System.Drawing.Point(12, 9);
            this.labelLeftStrategyName.Name = "labelLeftStrategyName";
            this.labelLeftStrategyName.Size = new System.Drawing.Size(35, 13);
            this.labelLeftStrategyName.TabIndex = 46;
            this.labelLeftStrategyName.Text = "label1";
            // 
            // labelRightStrategyName
            // 
            this.labelRightStrategyName.AutoSize = true;
            this.labelRightStrategyName.Location = new System.Drawing.Point(12, 22);
            this.labelRightStrategyName.Name = "labelRightStrategyName";
            this.labelRightStrategyName.Size = new System.Drawing.Size(35, 13);
            this.labelRightStrategyName.TabIndex = 47;
            this.labelRightStrategyName.Text = "label2";
            // 
            // labelGameStatus
            // 
            this.labelGameState.AutoSize = true;
            this.labelGameState.Location = new System.Drawing.Point(12, 35);
            this.labelGameState.Name = "labelGameStatus";
            this.labelGameState.Size = new System.Drawing.Size(35, 13);
            this.labelGameState.TabIndex = 48;
            this.labelGameState.Text = "label3";
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 431);
            this.Controls.Add(this.labelGameState);
            this.Controls.Add(this.labelRightStrategyName);
            this.Controls.Add(this.labelLeftStrategyName);
            this.Controls.Add(this.buttonStopBuild);
            this.Controls.Add(this.buttonPlayGame);
            this.Controls.Add(this.buttonBuildGame);
            this.Controls.Add(this.tabControlLoggers);
            this.Name = "FormGame";
            this.Text = "FormGame";
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
    }
}