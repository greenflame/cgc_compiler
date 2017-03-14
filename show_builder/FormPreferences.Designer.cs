namespace show_builder
{
    partial class FormPreferences
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPlayerExecutable = new System.Windows.Forms.TextBox();
            this.buttonBrowsePlayerExecutable = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player executable:";
            // 
            // textBoxPlayerExecutable
            // 
            this.textBoxPlayerExecutable.Location = new System.Drawing.Point(112, 12);
            this.textBoxPlayerExecutable.Name = "textBoxPlayerExecutable";
            this.textBoxPlayerExecutable.Size = new System.Drawing.Size(287, 20);
            this.textBoxPlayerExecutable.TabIndex = 1;
            this.textBoxPlayerExecutable.TextChanged += new System.EventHandler(this.textBoxPlayerExecutable_TextChanged);
            // 
            // buttonBrowsePlayerExecutable
            // 
            this.buttonBrowsePlayerExecutable.Location = new System.Drawing.Point(405, 10);
            this.buttonBrowsePlayerExecutable.Name = "buttonBrowsePlayerExecutable";
            this.buttonBrowsePlayerExecutable.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowsePlayerExecutable.TabIndex = 2;
            this.buttonBrowsePlayerExecutable.Text = "Browse";
            this.buttonBrowsePlayerExecutable.UseVisualStyleBackColor = true;
            this.buttonBrowsePlayerExecutable.Click += new System.EventHandler(this.buttonBrowsePlayerExecutable_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(405, 63);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Save";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // FormPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 97);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonBrowsePlayerExecutable);
            this.Controls.Add(this.textBoxPlayerExecutable);
            this.Controls.Add(this.label1);
            this.Name = "FormPreferences";
            this.Text = "FormPreferences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPlayerExecutable;
        private System.Windows.Forms.Button buttonBrowsePlayerExecutable;
        private System.Windows.Forms.Button buttonClose;
    }
}