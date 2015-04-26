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

namespace Kühlschrankwächter
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
            dataGridView1.Columns.Clear();
        }

        void ReadXML(String file)
        {
            DataSet myDataSet = new DataSet();
            myDataSet.ReadXml(file);
            dataGridView1.DataSource = myDataSet.Tables[0].DefaultView;
        }


        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Index == 0 && column.Visible)
                {
                    // You could potentially name the column based on the DGV column name (beware of dupes)
                    // or assign a type based on the data type of the data bound to this DGV column.
                    dt.Columns.Add("Name");
                }

                if (column.Index == 1 && column.Visible)
                {
                    // You could potentially name the column based on the DGV column name (beware of dupes)
                    // or assign a type based on the data type of the data bound to this DGV column.
                    dt.Columns.Add("Ablaufdatum (MHD)");
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
            if (File.Exists("fridgeitems.xml"))
            {
                Clear_all();
                ReadXML("fridgeitems.xml");

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
            dataGridView1.CurrentCell.Style.BackColor = Color.Gold;
             switch (accessType)
            {
                case 1:
                    chkReadOnly.Checked = true;
                    break;
                case 2:
                    chkModify.Checked = true;
                    break;
            }
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
            this.Close();
        }

    }
}


