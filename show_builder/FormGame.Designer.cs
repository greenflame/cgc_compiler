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
            this.labelBatchProgress = new System.Windows.Forms.Label();
            this.tabControlLoggers = new System.Windows.Forms.TabControl();
            this.tabPageBrief = new System.Windows.Forms.TabPage();
            this.richTextBoxBrief = new System.Windows.Forms.RichTextBox();
            this.tabPageExecution = new System.Windows.Forms.TabPage();
            this.richTextBoxExecution = new System.Windows.Forms.RichTextBox();
            this.tabPageGame = new System.Windows.Forms.TabPage();
            this.richTextBoxGame = new System.Windows.Forms.RichTextBox();
            this.tabControlLoggers.SuspendLayout();
            this.tabPageBrief.SuspendLayout();
            this.tabPageExecution.SuspendLayout();
            this.tabPageGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelBatchProgress
            // 
            this.labelBatchProgress.AutoSize = true;
            this.labelBatchProgress.Location = new System.Drawing.Point(1, 61);
            this.labelBatchProgress.Name = "labelBatchProgress";
            this.labelBatchProgress.Size = new System.Drawing.Size(0, 13);
            this.labelBatchProgress.TabIndex = 33;
            // 
            // tabControlLoggers
            // 
            this.tabControlLoggers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlLoggers.Controls.Add(this.tabPageBrief);
            this.tabControlLoggers.Controls.Add(this.tabPageExecution);
            this.tabControlLoggers.Controls.Add(this.tabPageGame);
            this.tabControlLoggers.Location = new System.Drawing.Point(12, 12);
            this.tabControlLoggers.Name = "tabControlLoggers";
            this.tabControlLoggers.SelectedIndex = 0;
            this.tabControlLoggers.Size = new System.Drawing.Size(387, 199);
            this.tabControlLoggers.TabIndex = 32;
            // 
            // tabPageBrief
            // 
            this.tabPageBrief.Controls.Add(this.richTextBoxBrief);
            this.tabPageBrief.Location = new System.Drawing.Point(4, 22);
            this.tabPageBrief.Name = "tabPageBrief";
            this.tabPageBrief.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBrief.Size = new System.Drawing.Size(379, 173);
            this.tabPageBrief.TabIndex = 0;
            this.tabPageBrief.Text = "Brief logger";
            this.tabPageBrief.UseVisualStyleBackColor = true;
            // 
            // richTextBoxBrief
            // 
            this.richTextBoxBrief.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxBrief.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxBrief.Name = "richTextBoxBrief";
            this.richTextBoxBrief.Size = new System.Drawing.Size(373, 167);
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
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 219);
            this.Controls.Add(this.labelBatchProgress);
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

        private System.Windows.Forms.Label labelBatchProgress;
        private System.Windows.Forms.TabControl tabControlLoggers;
        private System.Windows.Forms.TabPage tabPageBrief;
        private System.Windows.Forms.RichTextBox richTextBoxBrief;
        private System.Windows.Forms.TabPage tabPageExecution;
        private System.Windows.Forms.RichTextBox richTextBoxExecution;
        private System.Windows.Forms.TabPage tabPageGame;
        private System.Windows.Forms.RichTextBox richTextBoxGame;
    }
}