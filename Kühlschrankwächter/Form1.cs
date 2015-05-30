using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml;                                    //Library for xml file
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net.Mail;                      //Libaray for email

using System.Diagnostics;                   //Um eine Webseite im Standardbrowser des Benutzers öffnen zu lassen

namespace Kühlschrankwächter                        //Name der Funktion ist "Kühlschrankwächter"
{
    /// <summary>
    /// In Klasse VirtualFridge werden mehrere klassen mit ein Objekt zugeweisen   
    /// Es wird 2 Variablen erstellt. Diesen variablen haben den string als Datentyp
    /// </summary>
    public partial class VirtualFridge : Form
    {
        DateTimePicker dtpOrder;
        Einstellungen settingsWindow;
        string savefilepath, openfilepath;
        Über_VirtualFridge infoWindow;
        Farbcodierung ColourWindow;
        Rezept Rezeptwindow;
        
        public VirtualFridge()
        {
            InitializeComponent();
            //password.PasswordChar = '*';
            
        }
        /// <summary>
        /// hier werden Zeile entleert von Datengridview
        /// dann wird Datagridview aktualisieren
        /// als letzte wird Spalte entleert in Datagridview
        /// </summary>
        void Clear_all()
        {
            checkedListBoxProducts.Items.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.Columns.Clear();      //Datagridview Spalte entleeren
        }
        /// <summary>
        /// hier wird eine Dataset erzeugt
        /// dataset lese von xml datei
        /// 
        /// </summary>
        /// <param name="file"></param>
        void ReadXML(String file)
        {
            DataSet myDataSet = new DataSet();
            myDataSet.ReadXml(file);
            dataGridView1.DataSource = myDataSet.Tables[0].DefaultView;                 //XML wird gelesen

        }

        /// <summary>
        /// es werden Tabellen erstellt in Datagridview
        /// In datagridview gibt zwei Spalten
        /// 1 spalte ist Name
        /// 2 Spalte ist Ablaufsdatum
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns>Ein DataTable mit den Werten für DataGridView</returns>
        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Index == 0 && column.Visible)            //Spalte 1 ist Name
                {
                    // You could potentially name the column based on the DGV column name (beware of dupes)
                    // or assign a type based on the data type of the data bound to this DGV column.
                    dt.Columns.Add("Name");                     //ADD Spalte Name
                    //dataGridView1.Columns["Name"].Visible = false;
                    //dataGridView1.Columns[0].Visible = false; 
                }


                if (column.Index == 1 && column.Visible)               //Spalte 2 ist Ablaufsdatum (MHD)
                {
                    // You could potentially name the column based on the DGV column name (beware of dupes)
                    // or assign a type based on the data type of the data bound to this DGV column.
                    dt.Columns.Add("Ablaufdatum (MHD)");            //ADD Ablaufsdatum (MHD)

                    // dataGridView1.Columns["Ablaufdatum (MHD)"].Visible = false;
                    //dataGridView1.Columns[1].Visible = false; 
                }

            }

            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }

            return dt;
        }
        /// <summary>
        /// Hier wird ein Messagebox öffen und fragt ob sie vorhandene kühlschrank öffnen. Wenn sie auf Ja klicken öffnen sich ein Fenster sie wählen eine xml datei
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VirtualFridge_Load(object sender, EventArgs e)
        {
            sendEmailToUser();
            DialogResult dlgresult = MessageBox.Show("Möchten Sie einen vorhandenen Kühlschrank öffnen?", "Wilkommen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);       //Show the message in the messbox with messageboxicon
            if (dlgresult == DialogResult.Yes)
            {
                OpenFridge(this);

                if (File.Exists("fridgeitems.xml"))                                     //fridgeitem wird gelesen
                {
                    Clear_all();                                        // entleeren
                    ReadXML("fridgeitems.xml");                         //  Readxml ausgelesen
                }

                
            }
                toolStripComboBox1.SelectedIndex = 0;
                dtpOrder = new DateTimePicker();                //datetimepicker wird erzeugt
                dtpOrder.Format = DateTimePickerFormat.Short;
                dtpOrder.Visible = false;
                dtpOrder.Width = 100;
                dataGridView1.Controls.Add(dtpOrder);

                dtpOrder.ValueChanged += this.dtpOrder_ValueChanged;
                dataGridView1.CellBeginEdit += this.dataGridView1_CellBeginEdit;
                dataGridView1.CellEndEdit += this.dataGridView1_CellEndEdit;



              

                    
                
        }
        /// <summary>
        /// In Tabelle "Ablaufdatum MHD" wird ein Wert fest abgelegt
        /// Die Datum in MHD wird in string konvertiert in string
        /// Datum wird vergleichen mit heutigen Datum mit datum von Ablaufsdatum
        /// es werden bedingung überprüft wenn es erfolgt wird die beide Spalte mit eine markiert
        /// </summary>
        private void gridViewColoring()
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                object cellvalue = dr.Cells["Ablaufdatum (MHD)"].Value;
                int cell = Convert.ToString(cellvalue).Length;
                if (cell > 0)
                {
                    DateTime datetime = DateTime.Parse(dr.Cells["Ablaufdatum (MHD)"].Value.ToString());
                    int result = DateTime.Compare(datetime, DateTime.Now);
                    int daysdifference = (datetime - DateTime.Now).Days;

                    if (result > 0 && daysdifference > 7)
                    {

                        dr.Cells["Name"].Style.BackColor = Color.LimeGreen;
                        dr.Cells["Ablaufdatum (MHD)"].Style.BackColor = Color.LimeGreen;
                    }
                    else if (result > 0 && daysdifference >= 3 && daysdifference <= 7)
                    {
                        dr.Cells["Name"].Style.BackColor = Color.Yellow;
                        dr.Cells["Ablaufdatum (MHD)"].Style.BackColor = Color.Yellow;
                    }
                    else if (result > 0 && daysdifference < 3 && daysdifference >= 0)
                    {
                        dr.Cells["Name"].Style.BackColor = Color.Red;
                        dr.Cells["Ablaufdatum (MHD)"].Style.BackColor = Color.Red;
                    }
                    else if (result < 0 && daysdifference < 0)
                    {
                        dr.Cells["Name"].Style.BackColor = Color.SandyBrown;
                        dr.Cells["Ablaufdatum (MHD)"].Style.BackColor = Color.SandyBrown;
                    }
                }
            }
        }
        /// <summary>
        /// neue Tabelle wird hinzugefügt 
        /// daten wird als xml datei format gespeichert
        /// wenn sie speichert speichert es als xml und sie geben den dateiname und wird gespeichert
        /// Messegebox wird angezeigt Daten werden gespeichert.
        /// <hier werden colour methode und getproductslist geholt>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            DataTable dT = GetDataTableFromDGV(dataGridView1);
            DataSet dS = new DataSet();
            dS.Tables.Add(dT);
            //File.Delete("fridgeitems.xml");

            SaveFileDialog savefridgedialog = new SaveFileDialog();
            savefridgedialog.Filter = "XML files (*.xml)|*.xml";
            DialogResult savedialogresult = savefridgedialog.ShowDialog();
            if (savedialogresult == DialogResult.OK)
            {
                try
                {
                    savefilepath = savefridgedialog.FileName;
                    FileStream stream = new FileStream(savefilepath, FileMode.Create, FileAccess.ReadWrite);
                    dS.WriteXml(stream);
                    stream.Close();

                    MessageBox.Show("Daten gespeichert.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear_all();
                    ReadXML(savefilepath);
                    GetProductsList();
                    gridViewColoring();
               
                
                }
                catch (Exception)
                {
                    
                   throw;
                }  
                   
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// Hier wird ein andere Methode aufgerufen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gridViewColoring();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if ((dataGridView1.Focused) && (dataGridView1.CurrentCell.ColumnIndex == 1))
                {
                    dtpOrder.Location = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                    dtpOrder.Visible = true;
                    if (dataGridView1.CurrentCell.Value != DBNull.Value)
                    {
                        dtpOrder.Value = (DateTime)dataGridView1.CurrentCell.Value;
                    }
                    else
                    {
                        dtpOrder.Value = DateTime.Today;
                    }
                }
                else
                {
                    dtpOrder.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message); 
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((dataGridView1.Focused) && (dataGridView1.CurrentCell.ColumnIndex == 1))
                {
                    dataGridView1.CurrentCell.Value = dtpOrder.Value.Date;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message); 
            }
        }
        private void dtpOrder_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dtpOrder.Text;
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void schließenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();                           //Schließen den Programm
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
        /// <summary>
        /// Wenn Sie auf Schließen klicken fragt er den Benutzer ob sie schleißen wollen. Wenn sie auf nein klicken bricht das Programm ab und wenn Sie auf ja klicken schleißen das Programm
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown)
                return;

            switch (MessageBox.Show(this, "Soll das Fenster geschlossen werden?", "Schließen", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }


        private void suchenToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }
        /// <summary>
        /// Zuerst legt er in Ablaufsdatum ein Wert fest. Und es konviert den Wert in string.Es wird Wert von Ablaufsdatum mit heutigen Datum vergleichen.
        /// Wenn diese Bedingung überprüft wird.Legen Sie die Anfangsposition des Steuerelements.
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            string date;
            dtpOrder = new DateTimePicker();
            int comboboxindex = toolStripComboBox1.SelectedIndex;
            switch (comboboxindex)
            {
                case 0:
                    {
                        ShowAllEntries();
                    }
                    break;
                case 1:
                    {
                        ShowAllEntries();
                        foreach (DataGridViewRow dr in dataGridView1.Rows)
                        {
                            object cellvalue = dr.Cells["Ablaufdatum (MHD)"].Value;
                            int cell = Convert.ToString(cellvalue).Length;
                            if (cell > 0)
                            {
                                DateTime datetime = DateTime.Parse(dr.Cells["Ablaufdatum (MHD)"].Value.ToString());
                                int result = DateTime.Compare(datetime, DateTime.Now);
                                int daysdifference = (datetime - DateTime.Now).Days;
                                if (daysdifference <= 7)
                                {
                                    CurrencyManager currencyManager1 = (CurrencyManager)dataGridView1.BindingContext[dataGridView1.DataSource];

                                    currencyManager1.SuspendBinding();
                                    dr.Visible = false;
                                    currencyManager1.ResumeBinding();
                                }
                            }
                        }
                    }
                    break;
                case 2:
                    {
                        ShowAllEntries();
                        foreach (DataGridViewRow dr in dataGridView1.Rows)
                        {
                            object cellvalue = dr.Cells["Ablaufdatum (MHD)"].Value;
                            int cell = Convert.ToString(cellvalue).Length;
                            if (cell > 0)
                            {
                                DateTime datetime = DateTime.Parse(dr.Cells["Ablaufdatum (MHD)"].Value.ToString());
                                int result = DateTime.Compare(datetime, DateTime.Now);
                                int daysdifference = (datetime - DateTime.Now).Days;
                                if ((daysdifference < 3 || daysdifference > 7))
                                {
                                    CurrencyManager currencyManager1 = (CurrencyManager)dataGridView1.BindingContext[dataGridView1.DataSource];

                                    currencyManager1.SuspendBinding();
                                    dr.Visible = false;
                                    currencyManager1.ResumeBinding();
                                }
                            }
                        }
                    }

                    break;
                case 3:
                    {
                        ShowAllEntries();
                        foreach (DataGridViewRow dr in dataGridView1.Rows)
                        {
                            object cellvalue = dr.Cells["Ablaufdatum (MHD)"].Value;
                            int cell = Convert.ToString(cellvalue).Length;
                            if (cell > 0)
                            {
                                DateTime datetime = DateTime.Parse(dr.Cells["Ablaufdatum (MHD)"].Value.ToString());
                                int result = DateTime.Compare(datetime, DateTime.Now);
                                int daysdifference = (datetime - DateTime.Now).Days;
                                if (daysdifference >= 3 || daysdifference <= 0)
                                {
                                    CurrencyManager currencyManager1 = (CurrencyManager)dataGridView1.BindingContext[dataGridView1.DataSource];

                                    currencyManager1.SuspendBinding();
                                    dr.Visible = false;
                                    currencyManager1.ResumeBinding();
                                }
                            }
                        }
                    }
                    break;
                case 4:
                    {
                        ShowAllEntries();
                        foreach (DataGridViewRow dr in dataGridView1.Rows)
                        {
                            object cellvalue = dr.Cells["Ablaufdatum (MHD)"].Value;
                            int cell = Convert.ToString(cellvalue).Length;
                            if (cell > 0)
                            {
                                DateTime datetime = DateTime.Parse(dr.Cells["Ablaufdatum (MHD)"].Value.ToString());
                                int result = DateTime.Compare(datetime, DateTime.Now);
                                int daysdifference = (datetime - DateTime.Now).Days;
                                if (daysdifference >= 0)
                                {
                                    CurrencyManager currencyManager1 = (CurrencyManager)dataGridView1.BindingContext[dataGridView1.DataSource];

                                    currencyManager1.SuspendBinding();
                                    dr.Visible = false;
                                    currencyManager1.ResumeBinding();
                                }
                            }


                        }
                    }
                    break;
                default:
                    {
                        //TODO: Default Action.
                    }
                    break;
            }
        }
        /// <summary>
        /// legt ein Wert in Ablaufsdatum und konviert den wert in string format
        /// </summary>
        private void ShowAllEntries()
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                object cellvalue = dr.Cells["Ablaufdatum (MHD)"].Value;
                int cell = Convert.ToString(cellvalue).Length;
                if (cell > 0)
                {
                    dr.Visible = true;
                }
            }
        }
        /// <summary>
        /// Methode wird andere methoden aufgerufen. In textbox geben sie text ein. Es sucht eingeben Produkt in datagridview in spalte "Name". Es erkennt auch groß und kleinschreiben. Klein und großschreibung wird in if anweisung überprüft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripTextBoxSuchen_Click(object sender, EventArgs e)
        {
            ShowAllEntries();
            string searchText = toolStripTextBoxSuchen.Text;
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                object cellvalue = dr.Cells["Name"].Value;
                string cellText = Convert.ToString(cellvalue);
                int cell = Convert.ToString(cellvalue).Length;
                int compareStrings = String.Compare(searchText, cellText, true);
                if (cell > 0 && searchText.Length > 0)
                {
                    if (compareStrings < 0 || compareStrings > 0)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)dataGridView1.BindingContext[dataGridView1.DataSource];
                        currencyManager1.SuspendBinding();
                        dr.Visible = false;
                        currencyManager1.ResumeBinding();
                    }
                }
            }
        }

        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsWindow = new Einstellungen();
            settingsWindow.Show();
        }

        private void sendEmailToUser()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");

            mail.From = new MailAddress("murtaza.s@hotmail.de");
            //mail.To.Add("to_adresse");
            //mail.Subject = "Test Mail";
            //mail.Body = "This is for testing SMTP mail from GMAIL";

            //SmtpServer.Port = 587;
            //SmtpServer.Credentials = new System.Net.NetworkCredential("murtaza.s@live.de", "password");
            //SmtpServer.EnableSsl = true;

            //SmtpServer.Send(mail);
            //MessageBox.Show("mail Send");
        }
        /// <summary>
        /// hier wird ein Website(ein Link) zugeweisen und startet mit ein standardbroswer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearchreci_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.chefkoch.de/rs/s0/" + "banane" + "/Rezepte.html");
        }

        private List<String> GetProductsList()
        {
            List<String> productsList = new List<String>();
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                object cellvalue = dr.Cells["Name"].Value;
                int cell = Convert.ToString(cellvalue).Length;
                string cellText = Convert.ToString(cellvalue);

                if (cell > 0)
                {
                    productsList.Add(cellText);
                    checkedListBoxProducts.Items.Add(cellText);
                }
            }
            return productsList;
        }
        /// <summary>
        /// Es wird Wert von Datagridview in checkbox hinzugefügt. Wenn sie wert auswählen und öffnet sich in ein link und such ausgewählte produkte in checkbox  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearchreci_Click_1(object sender, EventArgs e)
        {
            List<String> selected = new List<String>();
            foreach (string item in checkedListBoxProducts.CheckedItems)
                selected.Add(item);
            string productnames = string.Join(" ", selected);
            if (checkedListBoxProducts.SelectedItem != null)            //wählt produkt in Checkbox und startet in ein browser den ausgewählte produkt
            {

                Process.Start("http://www.chefkoch.de/rs/s0/" + productnames + "/Rezepte.html");        
            }
            else
                MessageBox.Show("Bitte wählen Sie ein Produkt aus.", "Info für die Rezept Suche", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void kühlschrankÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFridge(this);
        }
        /// <summary>
        /// daten wird als xml format gespeichert
        /// List wird erzeugt und datum wird vergleichen mit heutigen und ausgewählten datum.
        /// Dann überprüft die if anweisung und es wird value von zelle in Messagebox ausgeben
        /// Weiter nutzen wir string.Join auf einer Liste von Zeichenketten . Dies ist hilfreich, wenn wir brauchen, um mehrere Zeichenfolgen in eine durch Kommas getrennte Zeichenfolge zu verwandeln.
        /// In Messegebox wird gezeigt welche Produkte abgelaufen sind
        private void OpenFridge(Form fridgeform)
        {
            OpenFileDialog fridgefiledialog = new OpenFileDialog();
            DialogResult opendialogresult = fridgefiledialog.ShowDialog();
            fridgefiledialog.Filter = "XML files (*.xml)|*.xml";
            if (opendialogresult == DialogResult.OK) // Test result.
            {
                 openfilepath = fridgefiledialog.FileName;
                 try
                 {
                     Clear_all();
                     ReadXML(openfilepath);
                     gridViewColoring();
                     GetProductsList();
                     List<String> expiredproducts = new List<String>();

                     foreach (DataGridViewRow dr in dataGridView1.Rows)
                     {
                         object cellvalue = dr.Cells["Name"].Value;
                         int cell = Convert.ToString(cellvalue).Length;
                         if (cell > 0)
                         {
                             DateTime datetime = DateTime.Parse(dr.Cells["Ablaufdatum (MHD)"].Value.ToString());
                             int result = DateTime.Compare(datetime, DateTime.Now);
                             int daysdifference = (datetime - DateTime.Now).Days;
                             if (result > 0 && daysdifference < 3 && daysdifference >= 0)
                             //if (daysdifference <3 || daysdifference <0)
                             {
                                 expiredproducts.Add(cellvalue.ToString());        //Gibt eine Zeichenfolge zurück, die das aktuelle Objekt darstellt. 
 
                             }
                                
                         }
                     }
                     string productnames = string.Join(", ", expiredproducts);
                          MessageBox.Show("Folgende Produkte sind abgelaufen: " + productnames, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
                 catch (IOException)
                 {
                 }
            }
        }
        /// <summary>
        /// hier wird ein neue Form geöffnet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuerKühlschrankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VirtualFridge newfridge = new VirtualFridge();
            Form newform = new Form();
            newfridge.Show(this);
        }
        /// <summary>
        /// hier wird neue Form geöffnet wenn Sie auf Hilfe-Übervirtualfridge klicken.Öffnen sich ein neue Fenster Über VirtualFridge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void überVirtualFridgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoWindow = new Über_VirtualFridge();
            infoWindow.Show();
        }
        /// <summary>
        /// hier wird neue Form geöffnet wenn Sie auf Hilfe-Farbcodierung klicken.Öffnen sich ein neue Fenster Farbcodierung
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void farbcodierungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColourWindow = new Farbcodierung();
            ColourWindow.Show();
        }

        private void checkedListBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// hier wird neue Form geöffnet wenn Sie auf Hilfe-Rezepte suchen klicken.Öffnen sich ein neue Fenster Über Rezepte suchen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rezepteSuchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rezeptwindow = new Rezept();
            Rezeptwindow.Show();
        }
        

    }
}