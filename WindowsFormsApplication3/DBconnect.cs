using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    
    class DBconnect
    {
        //string strcon = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\LRF\\Documents\\Database1.accdb.accdb";
        string strcon = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + Environment.CurrentDirectory + "\\" + "Database\\Database1.accdb.accdb";
        OleDbConnection dbcon = null;
        public OleDbConnection GetCon()
        {
            dbcon = new OleDbConnection(strcon);
            dbcon.Open();
            //MessageBox.Show("已经成功连接数据库");
            return dbcon;
        }
    }
}
