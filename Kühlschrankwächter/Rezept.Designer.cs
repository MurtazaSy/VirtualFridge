namespace Kühlschrankwächter
{
    partial class Rezept
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelrezeptinfo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelrezeptinfo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 218);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rezepte suchen";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // labelrezeptinfo
            // 
            this.labelrezeptinfo.Location = new System.Drawing.Point(6, 16);
            this.labelrezeptinfo.Name = "labelrezeptinfo";
            this.labelrezeptinfo.Size = new System.Drawing.Size(247, 93);
            this.labelrezeptinfo.TabIndex = 1;
            this.labelrezeptinfo.Text = "Sie wählen ein Produkt in checkbox und klicken auf das Button Rezept suchen.\r\nDan" +
    "n geeignete Rezepte für abgelaufende Produkte in Website.\r\n";
            this.labelrezeptinfo.Click += new System.EventHandler(this.labelrezeptinfo_Click);
            // 
            // Rezept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Rezept";
            this.Text = "Rezept suchen";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelrezeptinfo;
    }
}