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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxExecutable = new System.Windows.Forms.TextBox();
            this.textBoxInterpreter = new System.Windows.Forms.TextBox();
            this.textBoxExecutionPattern = new System.Windows.Forms.TextBox();
            this.comboBoxPattern = new System.Windows.Forms.ComboBox();
            this.buttonBrowseExecutable = new System.Windows.Forms.Button();
            this.buttonBrowseInterpreter = new System.Windows.Forms.Button();
            this.richTextBoxBrief = new System.Windows.Forms.RichTextBox();
            this.richTextBoxExecution = new System.Windows.Forms.RichTextBox();
            this.richTextBoxGame = new System.Windows.Forms.RichTextBox();
            this.buttonBuild = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageBrief = new System.Windows.Forms.TabPage();
            this.tabPageExecution = new System.Windows.Forms.TabPage();
            this.tabPageGame = new System.Windows.Forms.TabPage();
            this.buttonInterrupt = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxGames = new System.Windows.Forms.ListBox();
            this.buttonBrowsePlayer = new System.Windows.Forms.Button();
            this.buttonBatch = new System.Windows.Forms.Button();
            this.numericUpDownBatch = new System.Windows.Forms.NumericUpDown();
            this.labelBatchProgress = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageBrief.SuspendLayout();
            this.tabPageExecution.SuspendLayout();
            this.tabPageGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBatch)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxStrategies
            // 
            this.listBoxStrategies.FormattingEnabled = true;
            this.listBoxStrategies.Location = new System.Drawing.Point(15, 25);
            this.listBoxStrategies.Name = "listBoxStrategies";
            this.listBoxStrategies.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxStrategies.Size = new System.Drawing.Size(253, 329);
            this.listBoxStrategies.TabIndex = 0;
            this.listBoxStrategies.SelectedIndexChanged += new System.EventHandler(this.listBoxStrategies_SelectedIndexChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(112, 360);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(193, 360);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(274, 25);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(360, 20);
            this.textBoxName.TabIndex = 3;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Strategy name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Executable:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Interpreter:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Execution pattern:";
            // 
            // textBoxExecutable
            // 
            this.textBoxExecutable.Location = new System.Drawing.Point(274, 64);
            this.textBoxExecutable.Name = "textBoxExecutable";
            this.textBoxExecutable.Size = new System.Drawing.Size(279, 20);
            this.textBoxExecutable.TabIndex = 10;
            this.textBoxExecutable.TextChanged += new System.EventHandler(this.textBoxExecutable_TextChanged);
            // 
            // textBoxInterpreter
            // 
            this.textBoxInterpreter.Location = new System.Drawing.Point(274, 103);
            this.textBoxInterpreter.Name = "textBoxInterpreter";
            this.textBoxInterpreter.Size = new System.Drawing.Size(279, 20);
            this.textBoxInterpreter.TabIndex = 11;
            this.textBoxInterpreter.TextChanged += new System.EventHandler(this.textBoxInterpreter_TextChanged);
            // 
            // textBoxExecutionPattern
            // 
            this.textBoxExecutionPattern.Location = new System.Drawing.Point(394, 142);
            this.textBoxExecutionPattern.Name = "textBoxExecutionPattern";
            this.textBoxExecutionPattern.Size = new System.Drawing.Size(240, 20);
            this.textBoxExecutionPattern.TabIndex = 12;
            this.textBoxExecutionPattern.TextChanged += new System.EventHandler(this.textBoxExecutionPattern_TextChanged);
            // 
            // comboBoxPattern
            // 
            this.comboBoxPattern.FormattingEnabled = true;
            this.comboBoxPattern.Location = new System.Drawing.Point(274, 142);
            this.comboBoxPattern.Name = "comboBoxPattern";
            this.comboBoxPattern.Size = new System.Drawing.Size(114, 21);
            this.comboBoxPattern.TabIndex = 13;
            this.comboBoxPattern.SelectedIndexChanged += new System.EventHandler(this.comboBoxPattern_SelectedIndexChanged);
            // 
            // buttonBrowseExecutable
            // 
            this.buttonBrowseExecutable.Location = new System.Drawing.Point(559, 62);
            this.buttonBrowseExecutable.Name = "buttonBrowseExecutable";
            this.buttonBrowseExecutable.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseExecutable.TabIndex = 14;
            this.buttonBrowseExecutable.Text = "Browse";
            this.buttonBrowseExecutable.UseVisualStyleBackColor = true;
            this.buttonBrowseExecutable.Click += new System.EventHandler(this.buttonBrowseExecutable_Click);
            // 
            // buttonBrowseInterpreter
            // 
            this.buttonBrowseInterpreter.Location = new System.Drawing.Point(559, 101);
            this.buttonBrowseInterpreter.Name = "buttonBrowseInterpreter";
            this.buttonBrowseInterpreter.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseInterpreter.TabIndex = 15;
            this.buttonBrowseInterpreter.Text = "Browse";
            this.buttonBrowseInterpreter.UseVisualStyleBackColor = true;
            this.buttonBrowseInterpreter.Click += new System.EventHandler(this.buttonBrowseInterpreter_Click);
            // 
            // richTextBoxBrief
            // 
            this.richTextBoxBrief.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxBrief.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxBrief.Name = "richTextBoxBrief";
            this.richTextBoxBrief.Size = new System.Drawing.Size(346, 153);
            this.richTextBoxBrief.TabIndex = 16;
            this.richTextBoxBrief.Text = "";
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
            // richTextBoxGame
            // 
            this.richTextBoxGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxGame.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxGame.Name = "richTextBoxGame";
            this.richTextBoxGame.Size = new System.Drawing.Size(346, 153);
            this.richTextBoxGame.TabIndex = 21;
            this.richTextBoxGame.Text = "";
            // 
            // buttonBuild
            // 
            this.buttonBuild.Location = new System.Drawing.Point(327, 360);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Size = new System.Drawing.Size(75, 23);
            this.buttonBuild.TabIndex = 22;
            this.buttonBuild.Text = "Build";
            this.buttonBuild.UseVisualStyleBackColor = true;
            this.buttonBuild.Click += new System.EventHandler(this.buttonBuild_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(818, 360);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 23;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageBrief);
            this.tabControl1.Controls.Add(this.tabPageExecution);
            this.tabControl1.Controls.Add(this.tabPageGame);
            this.tabControl1.Location = new System.Drawing.Point(274, 169);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(360, 185);
            this.tabControl1.TabIndex = 24;
            // 
            // tabPageBrief
            // 
            this.tabPageBrief.Controls.Add(this.richTextBoxBrief);
            this.tabPageBrief.Location = new System.Drawing.Point(4, 22);
            this.tabPageBrief.Name = "tabPageBrief";
            this.tabPageBrief.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBrief.Size = new System.Drawing.Size(352, 159);
            this.tabPageBrief.TabIndex = 0;
            this.tabPageBrief.Text = "Brief logger";
            this.tabPageBrief.UseVisualStyleBackColor = true;
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
            // buttonInterrupt
            // 
            this.buttonInterrupt.Location = new System.Drawing.Point(559, 360);
            this.buttonInterrupt.Name = "buttonInterrupt";
            this.buttonInterrupt.Size = new System.Drawing.Size(75, 23);
            this.buttonInterrupt.TabIndex = 25;
            this.buttonInterrupt.Text = "Interrupt";
            this.buttonInterrupt.UseVisualStyleBackColor = true;
            this.buttonInterrupt.Click += new System.EventHandler(this.buttonInterrupt_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(637, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Games:";
            // 
            // listBoxGames
            // 
            this.listBoxGames.FormattingEnabled = true;
            this.listBoxGames.Location = new System.Drawing.Point(640, 25);
            this.listBoxGames.Name = "listBoxGames";
            this.listBoxGames.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxGames.Size = new System.Drawing.Size(253, 329);
            this.listBoxGames.TabIndex = 26;
            this.listBoxGames.SelectedIndexChanged += new System.EventHandler(this.listBoxGames_SelectedIndexChanged);
            // 
            // buttonBrowsePlayer
            // 
            this.buttonBrowsePlayer.Location = new System.Drawing.Point(708, 360);
            this.buttonBrowsePlayer.Name = "buttonBrowsePlayer";
            this.buttonBrowsePlayer.Size = new System.Drawing.Size(104, 23);
            this.buttonBrowsePlayer.TabIndex = 28;
            this.buttonBrowsePlayer.Text = "Browse player";
            this.buttonBrowsePlayer.UseVisualStyleBackColor = true;
            this.buttonBrowsePlayer.Click += new System.EventHandler(this.buttonBrowsePlayer_Click);
            // 
            // buttonBatch
            // 
            this.buttonBatch.Location = new System.Drawing.Point(478, 360);
            this.buttonBatch.Name = "buttonBatch";
            this.buttonBatch.Size = new System.Drawing.Size(75, 23);
            this.buttonBatch.TabIndex = 29;
            this.buttonBatch.Text = "Batch build";
            this.buttonBatch.UseVisualStyleBackColor = true;
            this.buttonBatch.Click += new System.EventHandler(this.buttonBatch_Click);
            // 
            // numericUpDownBatch
            // 
            this.numericUpDownBatch.Location = new System.Drawing.Point(408, 363);
            this.numericUpDownBatch.Name = "numericUpDownBatch";
            this.numericUpDownBatch.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownBatch.TabIndex = 30;
            this.numericUpDownBatch.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // labelBatchProgress
            // 
            this.labelBatchProgress.AutoSize = true;
            this.labelBatchProgress.Location = new System.Drawing.Point(12, 365);
            this.labelBatchProgress.Name = "labelBatchProgress";
            this.labelBatchProgress.Size = new System.Drawing.Size(0, 13);
            this.labelBatchProgress.TabIndex = 31;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 393);
            this.Controls.Add(this.labelBatchProgress);
            this.Controls.Add(this.numericUpDownBatch);
            this.Controls.Add(this.buttonBatch);
            this.Controls.Add(this.buttonBrowsePlayer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBoxGames);
            this.Controls.Add(this.buttonInterrupt);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonBuild);
            this.Controls.Add(this.buttonBrowseInterpreter);
            this.Controls.Add(this.buttonBrowseExecutable);
            this.Controls.Add(this.comboBoxPattern);
            this.Controls.Add(this.textBoxExecutionPattern);
            this.Controls.Add(this.textBoxInterpreter);
            this.Controls.Add(this.textBoxExecutable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBoxStrategies);
            this.Name = "FormMain";
            this.Text = "Show builder";
            this.tabControl1.ResumeLayout(false);
            this.tabPageBrief.ResumeLayout(false);
            this.tabPageExecution.ResumeLayout(false);
            this.tabPageGame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBatch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxStrategies;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxExecutable;
        private System.Windows.Forms.TextBox textBoxInterpreter;
        private System.Windows.Forms.TextBox textBoxExecutionPattern;
        private System.Windows.Forms.ComboBox comboBoxPattern;
        private System.Windows.Forms.Button buttonBrowseExecutable;
        private System.Windows.Forms.Button buttonBrowseInterpreter;
        private System.Windows.Forms.RichTextBox richTextBoxBrief;
        private System.Windows.Forms.RichTextBox richTextBoxExecution;
        private System.Windows.Forms.RichTextBox richTextBoxGame;
        private System.Windows.Forms.Button buttonBuild;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageBrief;
        private System.Windows.Forms.TabPage tabPageExecution;
        private System.Windows.Forms.TabPage tabPageGame;
        private System.Windows.Forms.Button buttonInterrupt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxGames;
        private System.Windows.Forms.Button buttonBrowsePlayer;
        private System.Windows.Forms.Button buttonBatch;
        private System.Windows.Forms.NumericUpDown numericUpDownBatch;
        private System.Windows.Forms.Label labelBatchProgress;
    }
}

