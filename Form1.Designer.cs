namespace FileEncrypter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ivLabel = new System.Windows.Forms.Label();
            this.keyLabel = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.ivBox = new System.Windows.Forms.TextBox();
            this.keyBox = new System.Windows.Forms.TextBox();
            this.setButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(394, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Encrypt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button3.Location = new System.Drawing.Point(0, 134);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(394, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Decrypt";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // ivLabel
            // 
            this.ivLabel.AutoSize = true;
            this.ivLabel.Location = new System.Drawing.Point(13, 39);
            this.ivLabel.Name = "ivLabel";
            this.ivLabel.Size = new System.Drawing.Size(17, 13);
            this.ivLabel.TabIndex = 11;
            this.ivLabel.Text = "IV";
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Location = new System.Drawing.Point(13, 12);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(28, 13);
            this.keyLabel.TabIndex = 10;
            this.keyLabel.Text = "KEY";
            // 
            // generateButton
            // 
            this.generateButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.generateButton.Location = new System.Drawing.Point(0, 88);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(394, 23);
            this.generateButton.TabIndex = 9;
            this.generateButton.Text = "Generate new key and iv";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // ivBox
            // 
            this.ivBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ivBox.Location = new System.Drawing.Point(54, 36);
            this.ivBox.Name = "ivBox";
            this.ivBox.Size = new System.Drawing.Size(333, 20);
            this.ivBox.TabIndex = 8;
            // 
            // keyBox
            // 
            this.keyBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyBox.Location = new System.Drawing.Point(54, 9);
            this.keyBox.Name = "keyBox";
            this.keyBox.Size = new System.Drawing.Size(333, 20);
            this.keyBox.TabIndex = 7;
            // 
            // setButton
            // 
            this.setButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.setButton.Location = new System.Drawing.Point(0, 111);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(394, 23);
            this.setButton.TabIndex = 6;
            this.setButton.Text = "Set";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(394, 180);
            this.Controls.Add(this.ivLabel);
            this.Controls.Add(this.keyLabel);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.ivBox);
            this.Controls.Add(this.keyBox);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(410, 219);
            this.Name = "Form1";
            this.Text = "Aes Crypter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label ivLabel;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox ivBox;
        private System.Windows.Forms.TextBox keyBox;
        private System.Windows.Forms.Button setButton;
    }
}

