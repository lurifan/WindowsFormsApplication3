using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Communication;

namespace WindowsFormsApplication3
{
    class DoWork

    {
        /// <summary>
        /// 开始加样
        /// </summary>
        /// <param name="list"></param>
        /// <param name="volume"></param>
        /// <returns></returns>
        /// 

        int curX=0;//当前X坐标位置
        int curY=0;//当前Y坐标位置

        List<Point> list;

        int volume = 0;


        public DoWork(List<Point> curlist,int a)
        {
            list = new List<Point>(curlist);

            volume = a;
        }
        public bool startWork()
        {
            // CommMachine.DCM_GOHM_X();
            // CommMachine.DCM_GOHM_Y();
            CommMachine.STM_PUAIR_PUSH(); //排气

            Thread.Sleep(1000);

            /* bool homed = false;
             while(homed==false)
             {
                 homed=CommMachine.sp4_Status_get("a");
                 Thread.Sleep(100);
             }

             homed = false;
             CommMachine.sp4_Home_work("b");
             while (homed == false)
             {
                 homed = CommMachine.sp4_Status_get("b");
                 Thread.Sleep(100);
             }
             */

            CommMachine.DCM_SHIFT_NUMBER_X(37818);//A1点
            curX = 37818;
            CommMachine.DCM_SHIFT_NUMBER_Y(-23000);
            curY = -23000;

            // adding();
            Point[] point = list.ToArray();//list转为数组
            Point p;
             for (int i = 0; i < list.ToArray().GetLength(0); i++)
             {

               p = point[i];
                //  CommMachine.DCM_SHIFT_NUMBER_X(p.X *0  + 500);
                //  CommMachine.DCM_SHIFT_NUMBER_Y(p.Y *20 + 500);
                int tmpX = 37818 - ((p.Y - 1) * 3300);

                if (tmpX != curX)
                {
                    CommMachine.DCM_SHIFT_NUMBER_X(tmpX);
                    curX = tmpX;
                }

                int tmpY = -23000 + ((p.X - 1) * 3300);
                if(tmpY!=curY)
                {
                    CommMachine.DCM_SHIFT_NUMBER_Y(tmpY);
                    curY = tmpY;
                }
            
       
            //先按体积进行加样                
            //Point p1 = point[i];//当前孔的位置
           // Point p2 = point[i + 1];//下一个孔的位置
           // int distance_x = p1.Y - p2.Y;//x轴位移坐标距离
            //int distance_y = p1.X - p2.X;//y轴位移坐标距离

            //move_x(distance_x);

            //move_y(distance_y);

            for (int j = 0; j < volume / 50; j++)
            {
                    // Thread.Sleep(400);
                    //拉，转，推，转四个过程
                    // adding();
                    CommMachine.STM_PLSA_PUSH();
            }
            //Thread.Sleep(800);
        }
            //   }
            CommMachine.DCM_SHIFT_NUMBER_X(45000);
            CommMachine.DCM_SHIFT_NUMBER_Y(-24000);
            return true;
          
        }
        /// <summary>
        /// 当前x轴坐标和目标x轴坐标
        /// </summary>
        /// <returns></returns>
        public void move_x(int distance_x)
        {
            //一个孔的间距为3360c
            CommMachine.sp4_Move_distance_set("a",distance_x*3360);            
            CommMachine.sp4_move_work("a");            
        }

        public void move_y(int distance_y)
        {
            CommMachine.sp4_Move_distance_set("b", distance_y * 3360);
            CommMachine.sp4_move_work("b");          
        }
        /// <summary>
        /// 回到模板第一个加样孔的位置
        /// </summary>
        /// <param name="p_first"></param>
        /// <returns></returns>
        public void  back2first(Point p_first)
        {
            
        }
        public void adding()
        {         
            CommMachine.STM_SHIFT_NUMBER_PUSH(-236); 
            CommMachine.STM_SHIFT_NUMBER_ROTATE(400);           
            CommMachine.STM_SHIFT_NUMBER_PUSH(236);         
            CommMachine.STM_SHIFT_NUMBER_ROTATE(-400);                      
        }
    }
}
