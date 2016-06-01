using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using Communication;
using System.Data.OleDb;
using CCWin;
using System.Threading;

namespace WindowsFormsApplication3
{


    public partial class Form2 : CCSkinMain
    {
        List<Point> list_a1 = new List<Point>();
        List<Point> list_a2 = new List<Point>();
        List<Point> list_h12 = new List<Point>();

        int curCountX = 0;
        int curCountY = 0;

        DBconnect dbcon = new DBconnect();
        
        public Form2()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            list_a2.Add(new Point(CommMachine.sp4_Position_get("a"), CommMachine.sp4_Position_get("b")));
            MessageBox.Show("已经成功记录A1孔位置");
            btn_ok_A1.Enabled =false;
            btn_ok_A2.Enabled = true;
            btn_ok_H12.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            list_h12.Add(new Point(CommMachine.sp4_Position_get("a"), CommMachine.sp4_Position_get("b")));
            MessageBox.Show("已经成功记录A1对角孔位置");
            btn_ok_A1.Enabled = false;
            btn_ok_A2.Enabled = false;
            btn_ok_H12.Enabled = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            btn_ok_A1.Enabled = true;
            btn_ok_A2.Enabled = false;
            btn_ok_H12.Enabled = false;

            CommMachine.DCM_GOHM_X();
            Thread.Sleep(5000);
            CommMachine.DCM_GOHM_Y();
            
            curCountX = 0;
            curCountY = 0;



        }

        private void btn_ok_A2_Click(object sender, EventArgs e)
        {
            list_a2.Add(new Point(CommMachine.sp4_Position_get("a"), CommMachine.sp4_Position_get("b")));
            btn_ok_A1.Enabled = false;
            btn_ok_A2.Enabled = false;
            btn_ok_H12.Enabled = true;
            MessageBox.Show("已经成功记录A2孔位置");
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            list_a1.Clear();
            list_a2.Clear();
            list_h12.Clear();
            btn_ok_A1.Enabled = true;
            btn_ok_A2.Enabled = false;
            btn_ok_H12.Enabled = false;
        }
        /// <summary>
        /// 由三点坐标得出孔距和孔数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("板条信息已成功保存");
            //单孔孔距
            double result_space = Math.Abs(list_a1[0].X - list_a2[0].X);
            //对角孔x轴距离
            double a= Math.Abs(list_a1[0].X - list_h12[0].X);
            //对角孔y轴距离
            double b = Math.Abs(list_a1[0].Y - list_h12[0].Y);
            //孔数x轴
            int hole_num_x = (int)Math.Round(a / result_space);
            //孔数y轴
            int hole_num_y = (int)Math.Round(b / result_space);

            result_space = a / hole_num_x;

            OleDbConnection odc = dbcon.GetCon();
            string strsql = "insert into form(space,A1_x,A1_y,Hole_num_x,Hole_num_y,Name)values('" + result_space + "','" + Convert.ToInt32(list_a1[0].X) + "','" + Convert.ToInt32(list_a1[0].Y) + "','" + hole_num_x+ "','" + hole_num_y + "','" + tbname.Text.Trim() + "')";
            OleDbCommand comm = new OleDbCommand(strsql, odc);
            comm.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbTrim.CheckState == CheckState.Checked){
                int tmpcount = curCountX - 100;
                if (tmpcount < 0) tmpcount = 0;

                CommMachine.DCM_SHIFT_NUMBER_X(tmpcount);

                curCountX = tmpcount;
            }
            else
            {
                int tmpcount = curCountX - 1000;
                if (tmpcount < 0) tmpcount = 0;

                CommMachine.DCM_SHIFT_NUMBER_X(tmpcount);

                curCountX = tmpcount;
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbTrim.CheckState == CheckState.Checked)
            {

                int tmpcount = curCountX +100;
                if (tmpcount >37818) tmpcount = 37818;

                CommMachine.DCM_SHIFT_NUMBER_X(tmpcount);

                curCountX = tmpcount;
            }
            else
            {
                int tmpcount = curCountX + 1000;
                if (tmpcount > 37818) tmpcount = 37818;

                CommMachine.DCM_SHIFT_NUMBER_X(tmpcount);

                curCountX = tmpcount;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cbTrim.CheckState == CheckState.Checked)
            {
                int tmpcount = curCountY + 100;
                if (tmpcount > 0) tmpcount = 0;

               CommMachine.DCM_SHIFT_NUMBER_Y(tmpcount);

                curCountY = tmpcount;                 
            }
            else
            {
                int tmpcount = curCountY + 300;
                if (tmpcount > 0) tmpcount = 0;

                CommMachine.DCM_SHIFT_NUMBER_Y(tmpcount);

                curCountY = tmpcount;
            }

            /*if (cbTrim.CheckState == CheckState.Checked)
            {
                CommMachine.sp4_Move_distance_set("b", 200);
                CommMachine.sp4_move_work("b");

            }
            else
            {
                CommMachine.sp4_Move_distance_set("b", 3000);
                CommMachine.sp4_move_work("b");
            }*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cbTrim.CheckState == CheckState.Checked)
            {

                int tmpcount = curCountY -100;
                if (tmpcount <- 23000) tmpcount  =-23000;

                CommMachine.DCM_SHIFT_NUMBER_Y(tmpcount);

                curCountY = tmpcount;
            }
            else
            {
                int tmpcount = curCountY - 300;
                if (tmpcount < -23000) tmpcount = -23000;

                CommMachine.DCM_SHIFT_NUMBER_Y(tmpcount);

                curCountY = tmpcount;
            }
        }
    }
}
