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

namespace Kühlschrankwächter                        //Name der Funktion ist "Kühlschrankwächter"
{
    public partial class VirtualFridge : Form               
    {
        DateTimePicker dtpOrder;                    


        public VirtualFridge()
        {
            InitializeComponent();
        }
        void Clear_all()
        {
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
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    int count = 0;
                   // DateTime dateValue = (DateTime)dataGridView1.Rows[dataGridView1.SelectedRows[count].Index].Cells[1].Value;
                    //double currentDate = (dateValue - DateTime.Today).TotalDays;
                    
                    if (dataGridView1.CurrentCell.RowIndex == 0)
                    
                        dataGridView1.CurrentCell.Style.BackColor = Color.Red;
                        //dataGridView1.CurrentCell.Style.BackColor = Color.green;

                                for (int i = 0; i < 7; i++)
                        {
                            
                        }
                       
                    
                    //this.dataGridView1.Sort(this.dataGridView1.Columns["Ablaufdatum (MHD)"], ListSortDirection.Ascending);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DataTable dT = GetDataTableFromDGV(dataGridView1);                      
            DataSet dS = new DataSet();
            dS.Tables.Add(dT);
            File.Delete("fridgeitems.xml");
           
                dS.WriteXml(File.OpenWrite("fridgeitems.xml"));
            MessageBox.Show("Daten gespeichert.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {


        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



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
           if(toolStripComboBox1.SelectedIndex==1){

               for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
               {
                   for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count; col++)
                   {
                       date = dataGridView1.Rows[rows].Cells[1].Value.ToString();
           

                     DateTime time = DateTime.Parse(date);
                      

                   int result = DateTime.Compare(time, DateTime.Now);

                    if (result == 0)
                    {
                        dataGridView1.Rows[rows].Cells[1].Style.BackColor=Color.Red;
                    }

                   }
               } 
              
               //dataGridView1.Columns.Clear();   

           }
               
        }
       
    }
}


