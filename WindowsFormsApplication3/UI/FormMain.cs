using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Communication;
using System.Threading;
using CCWin;

namespace WindowsFormsApplication3
{
    public partial class FormMain : CCSkinMain
    {
        
        DBconnect dBconnect = new DBconnect();
        //private SerialPort sp = new SerialPort();
        //private StringBuilder sb = new StringBuilder();
       // DoWork dw = new DoWork();
       
      //  Init init = new Init();
     



        public FormMain()
        {

            InitializeComponent();

            //串口初始化
            //Thread t = new Thread(() => { CommMachine.init("COM3", 9600);});
            //t.IsBackground = true;
            //t.Start();
            //电机初始化
            CommMachine.init("COM6", "COM7", 115200);

            //init.initDianji();
        }
        private void Form1_Load(object sender, EventArgs e)
        {            
            OleDbConnection dbcon = dBconnect.GetCon();
            OleDbCommand cmd1 = dbcon.CreateCommand();
            OleDbCommand cmd2 = dbcon.CreateCommand();
            cmd1.CommandText = "SELECT  DISTINCT Name FROM hole";        //在这儿写sql语句
            cmd2.CommandText = "SELECT Name FROM form";
            OleDbDataReader sdr1 = cmd1.ExecuteReader();        //创建一个OracleDateReader对象 
            OleDbDataReader sdr2 = cmd2.ExecuteReader();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();      //清空ComBox
            while (sdr1.Read())
            {
                comboBox1.Items.Add(sdr1[0].ToString());        //循环读区数据
            }
            while (sdr2.Read())
            {
                comboBox2.Items.Add(sdr2[0].ToString());        //循环读区数据
            }
            dbcon.Close();



            
            cbV.SelectedIndex = 0;
            cbType.SelectedIndex = 0;



            //CommMachine.STM_SHIFT_NUMBER_ROTATE(1000000);
           

            if (CommMachine.DCM_GOHM_X()) CommMachine.DCM_GOHM_Y();
            CommMachine.STM_GOHM_PUSH();
            CommMachine.STM_SHIFT_NUMBER_PUSH(400);
            CommMachine.STM_GOHM_ROTATE();

            CommMachine.DCM_SHIFT_NUMBER_X(45000);
            CommMachine.DCM_SHIFT_NUMBER_Y(-24000);
        }



        /*private void STARTWORK()
        {
            DoWork dw = new DoWork();
        }*/
        private void button1_Click(object sender, EventArgs e)
        {
            //数据库连接
            OleDbConnection dbcon = dBconnect.GetCon();
            string strsql = "SELECT hole.X,hole.Y FROM hole WHERE Name='a'";
            OleDbCommand dbcommand = new OleDbCommand(strsql, dbcon);
            OleDbDataReader dr = dbcommand.ExecuteReader();
            List<Point> list = new List<Point>(128);        
            while (dr.Read())
            {
                list.Add(new Point(Convert.ToInt32(dr["X"]), Convert.ToInt32(dr["Y"])));
            }
            dbcon.Close();  
            
                      
            int a= Convert.ToInt32(cbV.Text);

            //STARTWORK(); 

            DoWork dw = new DoWork(list, a);
            // dw.startWork(list,a);  
            dw.startWork();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            OleDbConnection dbcon = dBconnect.GetCon();
            string strsql = "SELECT hole.X,hole.Y FROM hole WHERE Name='half_left'";
            OleDbCommand dbcommand = new OleDbCommand(strsql, dbcon);
            OleDbDataReader dr = dbcommand.ExecuteReader();
            List<Point> list = new List<Point>(128);
            while (dr.Read())
            {
                list.Add(new Point(Convert.ToInt32(dr["X"]), Convert.ToInt32(dr["Y"])));
            }
            dbcon.Close();
            int a = Convert.ToInt32(cbV.Text);

            DoWork dw = new DoWork(list, a);
            //dw.startWork(list, a);

            dw.startWork();
            new FormAdding().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new FormDefind_96().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }
          
        private void btnadd_Click(object sender, EventArgs e)
        {
            //int i = 1; i < 7; i++
            //int i=6;i>0;i--
            /*OleDbConnection dbcon = dBconnect.GetCon();
            for(int i = 6; i > 0; i--)
            {
                string abc = i.ToString();
                string strsql1 = "insert into hole([X],Y,Name) values(8,'"+abc+"' ,'a')";
                OleDbCommand dbcommand = new OleDbCommand(strsql1, dbcon);
                dbcommand.ExecuteNonQuery();
            }
            */
            //string strsql1 = "insert into hole([X],Y,Name) values('1', '7','a')";            
            //OleDbCommand dbcommand = new OleDbCommand(strsql1,dbcon);
            //dbcommand.ExecuteNonQuery();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            new FormAdding().Show();
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            FormDefind_96 f96 = new FormDefind_96();
            f96.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            new FormDefind_96().Show();
        }

        private void btndebug_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }
    }
}
