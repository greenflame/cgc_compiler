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
            this.label1 = new System.Windows.Forms.Label();
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
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
            this.listBoxStrategies.Size = new System.Drawing.Size(253, 134);
            this.listBoxStrategies.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(31, 165);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(193, 165);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
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
            this.buttonBuild.Location = new System.Drawing.Point(529, 386);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Size = new System.Drawing.Size(75, 23);
            this.buttonBuild.TabIndex = 22;
            this.buttonBuild.Text = "Build";
            this.buttonBuild.UseVisualStyleBackColor = true;
            this.buttonBuild.Click += new System.EventHandler(this.buttonBuild_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(842, 386);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(172, 23);
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
            this.tabControl1.Location = new System.Drawing.Point(476, 195);
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
            this.buttonInterrupt.Location = new System.Drawing.Point(761, 386);
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
            this.label6.Location = new System.Drawing.Point(839, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Games:";
            // 
            // listBoxGames
            // 
            this.listBoxGames.FormattingEnabled = true;
            this.listBoxGames.Location = new System.Drawing.Point(842, 51);
            this.listBoxGames.Name = "listBoxGames";
            this.listBoxGames.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxGames.Size = new System.Drawing.Size(253, 303);
            this.listBoxGames.TabIndex = 26;
            this.listBoxGames.SelectedIndexChanged += new System.EventHandler(this.listBoxGames_SelectedIndexChanged);
            // 
            // buttonBrowsePlayer
            // 
            this.buttonBrowsePlayer.Location = new System.Drawing.Point(842, 357);
            this.buttonBrowsePlayer.Name = "buttonBrowsePlayer";
            this.buttonBrowsePlayer.Size = new System.Drawing.Size(91, 23);
            this.buttonBrowsePlayer.TabIndex = 28;
            this.buttonBrowsePlayer.Text = "Browse player";
            this.buttonBrowsePlayer.UseVisualStyleBackColor = true;
            this.buttonBrowsePlayer.Click += new System.EventHandler(this.buttonBrowsePlayer_Click);
            // 
            // buttonBatch
            // 
            this.buttonBatch.Location = new System.Drawing.Point(680, 386);
            this.buttonBatch.Name = "buttonBatch";
            this.buttonBatch.Size = new System.Drawing.Size(75, 23);
            this.buttonBatch.TabIndex = 29;
            this.buttonBatch.Text = "Batch build";
            this.buttonBatch.UseVisualStyleBackColor = true;
            this.buttonBatch.Click += new System.EventHandler(this.buttonBatch_Click);
            // 
            // numericUpDownBatch
            // 
            this.numericUpDownBatch.Location = new System.Drawing.Point(610, 389);
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
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(939, 357);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 32;
            this.buttonSave.Text = "Save all";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(1020, 357);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 33;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(1020, 386);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 34;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(112, 165);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 35;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 576);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
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
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonEdit;
    }
}

