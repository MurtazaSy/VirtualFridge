using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace Kühlschrankwächter                        //Name der Funktion ist "Kühlschrankwächter"
{
    public partial class VirtualFridge : Form
    {
        DateTimePicker dtpOrder;
        Einstellungen settingsWindow;

        public VirtualFridge()
        {
            InitializeComponent();
        }
        void Clear_all()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.Columns.Clear();      //Datagridview Spalte entleeren
        }

        void ReadXML(String file)
        {
            DataSet myDataSet = new DataSet();
            myDataSet.ReadXml(file);
            dataGridView1.DataSource = myDataSet.Tables[0].DefaultView;                 //XML wird gelesen

        }


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
        private void VirtualFridge_Load(object sender, EventArgs e)
        {
            sendEmailToUser();
            if (File.Exists("fridgeitems.xml"))                                     //fridgeitem wird gelesen
            {
                Clear_all();                                        // entleeren
                ReadXML("fridgeitems.xml");                         //  Readxml ausgelesen
            }

            gridViewColoring();

            toolStripComboBox1.SelectedIndex = 0;
            dtpOrder = new DateTimePicker();
            dtpOrder.Format = DateTimePickerFormat.Short;
            dtpOrder.Visible = false;
            dtpOrder.Width = 100;
            dataGridView1.Controls.Add(dtpOrder);

            dtpOrder.ValueChanged += this.dtpOrder_ValueChanged;
            dataGridView1.CellBeginEdit += this.dataGridView1_CellBeginEdit;
            dataGridView1.CellEndEdit += this.dataGridView1_CellEndEdit;


        }
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ShowAllEntries();
            DataTable dT = GetDataTableFromDGV(dataGridView1);
            DataSet dS = new DataSet();
            dS.Tables.Add(dT);
            File.Delete("fridgeitems.xml");

            dS.WriteXml(File.OpenWrite("fridgeitems.xml"));
            MessageBox.Show("Daten gespeichert.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridViewColoring();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {


        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gridViewColoring();
            


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

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
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

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
                                if (daysdifference < 7)
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
                                if (daysdifference >= 3 || daysdifference < 0)
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
            //MailMessage mail = new MailMessage();
            //SmtpClient SmtpServer = new SmtpClient("smtp.live.com");

            //mail.From = new MailAddress("murtaza.s@hotmail.de");
            //mail.To.Add("to_adresse");
            //mail.Subject = "Test Mail";
            //mail.Body = "This is for testing SMTP mail from GMAIL";

            //SmtpServer.Port = 587;
            //SmtpServer.Credentials = new System.Net.NetworkCredential("murtaza.s@live.de", "password");
            //SmtpServer.EnableSsl = true;

            //SmtpServer.Send(mail);
            //MessageBox.Show("mail Send");
        }

    }
}



