using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class FormDefind_96 : CCSkinMain
    {
        bool isdouble_row;
        DBconnect dbcon=new DBconnect();
        public FormDefind_96()
        {
            InitializeComponent();          
        }
       
        
        

        private void Form4_Load(object sender, EventArgs e)
        {
            
            for (int i = 0; i < 8; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].HeaderCell.Value = ((char)(65 + i)).ToString();               
                for (int j = 0; j < 12; j++)
                {
                    DataGridViewRow row = dataGridView2.Rows[i];
                    this.dataGridView2.Rows[i].Cells[j].Style.BackColor = Color.White;
                    this.dataGridView2.Rows[i].Height = 50;
                }
            }
            dataGridView2.RowsDefaultCellStyle.BackColor = Color.White;
         
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

      

        
        

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1)
            {
                MessageBox.Show("请按单元格选择!");
            }
            else
            {
                DataGridViewCellStyle Stye = new DataGridViewCellStyle();
                dataGridView2[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Blue;
            }
        }
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1)
            {
                MessageBox.Show("请按单元格选择!");
            }
            else
            {
                DataGridViewCellStyle Stye = new DataGridViewCellStyle();
                dataGridView2[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
            }
        }
      

        private void button2_Click(object sender, EventArgs e)
        {
            new FormDefind_48().Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            isdouble_row = false;
            List<Point> plist = new List<Point>();
            List<Point> xlist = new List<Point>();
            for (int i = 1; i < 9; i++)
            {
                isdouble_row = isdouble_row ? false : true;
                for (int j = 1; j < 13; j++)
                {
                    if (this.dataGridView2.Rows[i - 1].Cells[j - 1].Style.BackColor == Color.Blue)
                    {
                        if (isdouble_row == true)
                        {
                            plist.Add(new Point(Convert.ToInt32(i), Convert.ToInt32(j)));
                        }
                        else
                        {
                            xlist.Add(new Point(Convert.ToInt32(i), Convert.ToInt32(j)));
                        }
                    }
                }
                xlist.Reverse();
                plist.AddRange(xlist);
                xlist.Clear();
            }
            OleDbConnection odc = dbcon.GetCon();
            for (int k = 0; k < plist.Count; k++)
            {
                string strsql = "insert into hole(X,Y,Name)values('" + Convert.ToInt32(plist[k].X) + "','" + Convert.ToInt32(plist[k].Y) + "','" + tb_name.Text.Trim() + "')";
                OleDbCommand comm = new OleDbCommand(strsql, odc);
                comm.ExecuteNonQuery();
            }
            odc.Close();
        }
    }
}
