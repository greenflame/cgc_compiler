namespace show_builder
{
    partial class FormStrategy
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
            this.buttonBrowseInterpreter = new System.Windows.Forms.Button();
            this.buttonBrowseExecutable = new System.Windows.Forms.Button();
            this.comboBoxPattern = new System.Windows.Forms.ComboBox();
            this.textBoxExecutionPattern = new System.Windows.Forms.TextBox();
            this.textBoxInterpreter = new System.Windows.Forms.TextBox();
            this.textBoxExecutable = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBrowseInterpreter
            // 
            this.buttonBrowseInterpreter.Location = new System.Drawing.Point(396, 62);
            this.buttonBrowseInterpreter.Name = "buttonBrowseInterpreter";
            this.buttonBrowseInterpreter.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseInterpreter.TabIndex = 26;
            this.buttonBrowseInterpreter.Text = "Browse";
            this.buttonBrowseInterpreter.UseVisualStyleBackColor = true;
            this.buttonBrowseInterpreter.Click += new System.EventHandler(this.buttonBrowseInterpreter_Click);
            // 
            // buttonBrowseExecutable
            // 
            this.buttonBrowseExecutable.Location = new System.Drawing.Point(396, 36);
            this.buttonBrowseExecutable.Name = "buttonBrowseExecutable";
            this.buttonBrowseExecutable.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseExecutable.TabIndex = 25;
            this.buttonBrowseExecutable.Text = "Browse";
            this.buttonBrowseExecutable.UseVisualStyleBackColor = true;
            this.buttonBrowseExecutable.Click += new System.EventHandler(this.buttonBrowseExecutable_Click);
            // 
            // comboBoxPattern
            // 
            this.comboBoxPattern.FormattingEnabled = true;
            this.comboBoxPattern.Location = new System.Drawing.Point(111, 90);
            this.comboBoxPattern.Name = "comboBoxPattern";
            this.comboBoxPattern.Size = new System.Drawing.Size(114, 21);
            this.comboBoxPattern.TabIndex = 24;
            this.comboBoxPattern.SelectedIndexChanged += new System.EventHandler(this.comboBoxPattern_SelectedIndexChanged);
            // 
            // textBoxExecutionPattern
            // 
            this.textBoxExecutionPattern.Location = new System.Drawing.Point(231, 91);
            this.textBoxExecutionPattern.Name = "textBoxExecutionPattern";
            this.textBoxExecutionPattern.Size = new System.Drawing.Size(240, 20);
            this.textBoxExecutionPattern.TabIndex = 23;
            this.textBoxExecutionPattern.TextChanged += new System.EventHandler(this.textBoxExecutionPattern_TextChanged);
            // 
            // textBoxInterpreter
            // 
            this.textBoxInterpreter.Location = new System.Drawing.Point(111, 64);
            this.textBoxInterpreter.Name = "textBoxInterpreter";
            this.textBoxInterpreter.Size = new System.Drawing.Size(279, 20);
            this.textBoxInterpreter.TabIndex = 22;
            // 
            // textBoxExecutable
            // 
            this.textBoxExecutable.Location = new System.Drawing.Point(111, 38);
            this.textBoxExecutable.Name = "textBoxExecutable";
            this.textBoxExecutable.Size = new System.Drawing.Size(279, 20);
            this.textBoxExecutable.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Execution pattern:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Interpreter:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Executable:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Strategy name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(111, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(360, 20);
            this.textBoxName.TabIndex = 16;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(315, 117);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 27;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(396, 117);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 28;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormStrategy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 150);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
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
            this.Controls.Add(this.textBoxName);
            this.Name = "FormStrategy";
            this.Text = "FormStrategy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowseInterpreter;
        private System.Windows.Forms.Button buttonBrowseExecutable;
        private System.Windows.Forms.ComboBox comboBoxPattern;
        private System.Windows.Forms.TextBox textBoxExecutionPattern;
        private System.Windows.Forms.TextBox textBoxInterpreter;
        private System.Windows.Forms.TextBox textBoxExecutable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}