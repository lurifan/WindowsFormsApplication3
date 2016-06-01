using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class FormDefind_48 : Form
    {
        public FormDefind_48()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                i = this.dataGridView2.Rows.Add();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
