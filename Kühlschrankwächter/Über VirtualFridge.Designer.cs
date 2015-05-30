namespace Kühlschrankwächter
{
    partial class Über_VirtualFridge
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
            this.pictureBoxinfo = new System.Windows.Forms.PictureBox();
            this.labelinfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxinfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxinfo
            // 
            this.pictureBoxinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxinfo.Image = global::Kühlschrankwächter.Properties.Resources.icon_fridge_104360;
            this.pictureBoxinfo.Location = new System.Drawing.Point(13, 56);
            this.pictureBoxinfo.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxinfo.Name = "pictureBoxinfo";
            this.pictureBoxinfo.Size = new System.Drawing.Size(137, 140);
            this.pictureBoxinfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxinfo.TabIndex = 1;
            this.pictureBoxinfo.TabStop = false;
            // 
            // labelinfo
            // 
            this.labelinfo.BackColor = System.Drawing.SystemColors.Menu;
            this.labelinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelinfo.ForeColor = System.Drawing.Color.Black;
            this.labelinfo.Location = new System.Drawing.Point(10, 209);
            this.labelinfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelinfo.Name = "labelinfo";
            this.labelinfo.Size = new System.Drawing.Size(249, 140);
            this.labelinfo.TabIndex = 2;
            this.labelinfo.Text = "Virtual Fridge v.1.0\r\nEntwickler: Murtaza Syed\r\nHochschule Worms\r\nEmail: inf2057@" +
    "hs-worms.de\r\n";
            this.labelinfo.Click += new System.EventHandler(this.gggg_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "Virtual Fridge";
            // 
            // Über_VirtualFridge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 358);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelinfo);
            this.Controls.Add(this.pictureBoxinfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Über_VirtualFridge";
            this.Text = "Über_VirtualFridge";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxinfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxinfo;
        private System.Windows.Forms.Label labelinfo;
        private System.Windows.Forms.Label label1;
    }
}