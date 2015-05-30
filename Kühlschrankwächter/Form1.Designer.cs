namespace Kühlschrankwächter
{
    partial class VirtualFridge
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VirtualFridge));
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonSearchreci = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.neuerKühlschrankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kühlschrankÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schließenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anzeigeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.suchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxSuchen = new System.Windows.Forms.ToolStripTextBox();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.farbcodierungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rezepteSuchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.überVirtualFridgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkedListBoxProducts = new System.Windows.Forms.CheckedListBox();
            this.labelProduktechecklist = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(12, 357);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(248, 39);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Speichern";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonSearchreci
            // 
            this.buttonSearchreci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearchreci.Location = new System.Drawing.Point(470, 357);
            this.buttonSearchreci.Name = "buttonSearchreci";
            this.buttonSearchreci.Size = new System.Drawing.Size(247, 39);
            this.buttonSearchreci.TabIndex = 4;
            this.buttonSearchreci.Text = "Rezepte suchen";
            this.buttonSearchreci.UseVisualStyleBackColor = true;
            this.buttonSearchreci.Click += new System.EventHandler(this.buttonSearchreci_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(452, 324);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Ablaufdatum (MHD)";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.Width = 200;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.anzeigeToolStripMenuItem,
            this.suchenToolStripMenuItem,
            this.einstellungenToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(722, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuerKühlschrankToolStripMenuItem,
            this.kühlschrankÖffnenToolStripMenuItem,
            this.schließenToolStripMenuItem});
            this.toolStripMenuItem1.Image = global::Kühlschrankwächter.Properties.Resources.menu_alt_512;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(66, 20);
            this.toolStripMenuItem1.Text = "Menü";
            // 
            // neuerKühlschrankToolStripMenuItem
            // 
            this.neuerKühlschrankToolStripMenuItem.Image = global::Kühlschrankwächter.Properties.Resources.New_File_256;
            this.neuerKühlschrankToolStripMenuItem.Name = "neuerKühlschrankToolStripMenuItem";
            this.neuerKühlschrankToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.neuerKühlschrankToolStripMenuItem.Text = "Neuer Kühlschrank";
            this.neuerKühlschrankToolStripMenuItem.Click += new System.EventHandler(this.neuerKühlschrankToolStripMenuItem_Click);
            // 
            // kühlschrankÖffnenToolStripMenuItem
            // 
            this.kühlschrankÖffnenToolStripMenuItem.Image = global::Kühlschrankwächter.Properties.Resources.folder;
            this.kühlschrankÖffnenToolStripMenuItem.Name = "kühlschrankÖffnenToolStripMenuItem";
            this.kühlschrankÖffnenToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.kühlschrankÖffnenToolStripMenuItem.Text = "Kühlschrank öffnen";
            this.kühlschrankÖffnenToolStripMenuItem.Click += new System.EventHandler(this.kühlschrankÖffnenToolStripMenuItem_Click);
            // 
            // schließenToolStripMenuItem
            // 
            this.schließenToolStripMenuItem.Image = global::Kühlschrankwächter.Properties.Resources.button_cancel;
            this.schließenToolStripMenuItem.Name = "schließenToolStripMenuItem";
            this.schließenToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.schließenToolStripMenuItem.Text = "Kühlschrank schließen";
            this.schließenToolStripMenuItem.Click += new System.EventHandler(this.schließenToolStripMenuItem_Click);
            // 
            // anzeigeToolStripMenuItem
            // 
            this.anzeigeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.anzeigeToolStripMenuItem.Image = global::Kühlschrankwächter.Properties.Resources.filter;
            this.anzeigeToolStripMenuItem.Name = "anzeigeToolStripMenuItem";
            this.anzeigeToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.anzeigeToolStripMenuItem.Text = "Anzeige";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Kein Filter",
            "MHD > 7 Tage",
            "MHD 3-7 Tage",
            "MHD 0-3 Tage",
            "MHD < 0 Tage"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBox1.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // suchenToolStripMenuItem
            // 
            this.suchenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSuchen});
            this.suchenToolStripMenuItem.Image = global::Kühlschrankwächter.Properties.Resources._229;
            this.suchenToolStripMenuItem.Name = "suchenToolStripMenuItem";
            this.suchenToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.suchenToolStripMenuItem.Text = "Suchen";
            this.suchenToolStripMenuItem.Click += new System.EventHandler(this.suchenToolStripMenuItem_Click);
            // 
            // toolStripTextBoxSuchen
            // 
            this.toolStripTextBoxSuchen.Name = "toolStripTextBoxSuchen";
            this.toolStripTextBoxSuchen.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxSuchen.Tag = "";
            this.toolStripTextBoxSuchen.ToolTipText = "Produktnamen eingeben";
            this.toolStripTextBoxSuchen.Click += new System.EventHandler(this.toolStripTextBoxSuchen_Click);
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.Image = global::Kühlschrankwächter.Properties.Resources.application_x_desktop;
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            this.einstellungenToolStripMenuItem.Click += new System.EventHandler(this.einstellungenToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.farbcodierungToolStripMenuItem,
            this.rezepteSuchenToolStripMenuItem,
            this.überVirtualFridgeToolStripMenuItem});
            this.hilfeToolStripMenuItem.Image = global::Kühlschrankwächter.Properties.Resources._512;
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // farbcodierungToolStripMenuItem
            // 
            this.farbcodierungToolStripMenuItem.Name = "farbcodierungToolStripMenuItem";
            this.farbcodierungToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.farbcodierungToolStripMenuItem.Text = "Farbcodierung";
            this.farbcodierungToolStripMenuItem.Click += new System.EventHandler(this.farbcodierungToolStripMenuItem_Click);
            // 
            // rezepteSuchenToolStripMenuItem
            // 
            this.rezepteSuchenToolStripMenuItem.Name = "rezepteSuchenToolStripMenuItem";
            this.rezepteSuchenToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.rezepteSuchenToolStripMenuItem.Text = "Rezepte suchen";
            this.rezepteSuchenToolStripMenuItem.Click += new System.EventHandler(this.rezepteSuchenToolStripMenuItem_Click);
            // 
            // überVirtualFridgeToolStripMenuItem
            // 
            this.überVirtualFridgeToolStripMenuItem.Name = "überVirtualFridgeToolStripMenuItem";
            this.überVirtualFridgeToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.überVirtualFridgeToolStripMenuItem.Text = "Über Virtual Fridge";
            this.überVirtualFridgeToolStripMenuItem.Click += new System.EventHandler(this.überVirtualFridgeToolStripMenuItem_Click);
            // 
            // checkedListBoxProducts
            // 
            this.checkedListBoxProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxProducts.FormattingEnabled = true;
            this.checkedListBoxProducts.Location = new System.Drawing.Point(470, 47);
            this.checkedListBoxProducts.Name = "checkedListBoxProducts";
            this.checkedListBoxProducts.Size = new System.Drawing.Size(247, 304);
            this.checkedListBoxProducts.TabIndex = 8;
            this.checkedListBoxProducts.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxProducts_SelectedIndexChanged);
            // 
            // labelProduktechecklist
            // 
            this.labelProduktechecklist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProduktechecklist.AutoSize = true;
            this.labelProduktechecklist.Location = new System.Drawing.Point(471, 28);
            this.labelProduktechecklist.Name = "labelProduktechecklist";
            this.labelProduktechecklist.Size = new System.Drawing.Size(189, 13);
            this.labelProduktechecklist.TabIndex = 9;
            this.labelProduktechecklist.Text = "Vorhandene Produkte im Kühlschrank:";
            // 
            // VirtualFridge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(722, 435);
            this.Controls.Add(this.labelProduktechecklist);
            this.Controls.Add(this.checkedListBoxProducts);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonSearchreci);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VirtualFridge";
            this.Text = "Virtual Fridge";
            this.Load += new System.EventHandler(this.VirtualFridge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonSearchreci;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem anzeigeToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem schließenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suchenToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSuchen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ToolStripMenuItem kühlschrankÖffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox checkedListBoxProducts;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem farbcodierungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rezepteSuchenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem überVirtualFridgeToolStripMenuItem;
        private System.Windows.Forms.Label labelProduktechecklist;
        private System.Windows.Forms.ToolStripMenuItem neuerKühlschrankToolStripMenuItem;
    }
}

