using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Communication
{
    public static class CommMachine
    {
        public static CommConversation m_Comm = new CommConversation();

        public static CommConversation m_Comm2 = new CommConversation();

        public static bool IsOpen
        {
            get
            {
                return m_Comm.IsOpen&& m_Comm2.IsOpen;
            }
        }

        public static bool init(string Portname, string Portname2 ,int Baudrate)
        {
            //return m_Comm.init(Portname, Baudrate);

            if (m_Comm.init(Portname, Baudrate) && m_Comm2.init(Portname2, Baudrate)) return true;

            return false;
        }

        public static void close()
        {
            m_Comm.CommClose();
            m_Comm2.CommClose();
        }

       

        /*  Enables the drive in programmed position mode 
        21 = Programmed Position Mode, Servo 31 = Programmed Position Mode, Stepper*/
        public static void sp4_Enables(string axisletter)
        {
            byte[] buffin = Encoding.ASCII.GetBytes("." + axisletter+" s r0x24 21\r");

            List<byte> buffout = new List<byte>();
            int outlen=m_Comm.talk(buffin, buffout);
                      
            string receive = Encoding.ASCII.GetString(buffout.ToArray());

        }
        /// <summary>
        /// 步进电机
        /// </summary>
        /// <param name="axisletter"></param>
        public static void sp4_Enables_stepper(string axisletter)
        {
            byte[] buffin = Encoding.ASCII.GetBytes("." + axisletter + " s r0x24 31\r");

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());

        }

        //Disable the drive in programmed position mode
        public static void sp4_Disable(string axisletter)
        {
            byte[] buffin = Encoding.ASCII.GetBytes("." + axisletter + " s r0x24 0\r");

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());
        }

        /*  move mode
            0 = Absolute move, trapezoidal profile. 
            1 = Absolute move, S-curve profile.
            256 = Relative move, trapezoidal profile. 
            257 = Relative move, S-curve profile.
            2 = Velocity move.*/
        public static void sp4_Move_mode_set(string axisletter, int mode)
        {
            byte[] buffin = Encoding.ASCII.GetBytes("." + axisletter + " s r0xc8 " + mode.ToString() + "\r");

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());
        }

        /*Position command. Units: counts.*/
        public static void sp4_Move_distance_set(string axisletter, int count)
        {
            byte[] buffin = Encoding.ASCII.GetBytes("." + axisletter + " s r0xca " + count.ToString()  +"\r");

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());
        }


        /*Maximum velocity. Units: 0.1 counts/second.*/
        public static void sp4_Move_velocity_set(string axisletter, int velocity)
        {
            byte[] buffin = Encoding.ASCII.GetBytes("." + axisletter + " s r0xcb " + velocity.ToString() + "\r");

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());
        }

        public static void sp4_Move_addvelocity_set(string axisletter, int velocity)
        {
            byte[] buffin = Encoding.ASCII.GetBytes("." + axisletter + " s r0xcc " + velocity.ToString() + "\r");

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());
        }

        public static void sp4_Move_delvelocity_set(string axisletter, int velocity)
        {
            byte[] buffin = Encoding.ASCII.GetBytes("." + axisletter + " s r0xcd " + velocity.ToString() + "\r");

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());
        }


        public static void sp4_move_work(string axisletter)
        {
            byte[] buffin = Encoding.ASCII.GetBytes("." + axisletter + " t 1\r");

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());
        }


        /*home Maximum velocity. Units: 0.1 counts/second.*/
        public static void sp4_Home_velocity_set(string axisletter, int velocity)
        {
            byte[] buffin = Encoding.ASCII.GetBytes("." + axisletter + " s r0xc3 " + velocity.ToString() + "\r");

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());

            byte[] buffinslow = Encoding.ASCII.GetBytes("." + axisletter + " s r0xc4 " + (velocity/3).ToString() + "\r");

            List<byte> buffoutslow = new List<byte>();
            int outlenslow = m_Comm.talk(buffinslow, buffoutslow);

            string receiveslow = Encoding.ASCII.GetString(buffoutslow.ToArray());
        }

        public static void sp4_Home_work(string axisletter)
        {
            byte[] buffin = Encoding.ASCII.GetBytes("." + axisletter + " t 2\r");

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());
        }

        public static bool sp4_Status_get(string axislette)
        {
            byte[] buffin = Encoding.ASCII.GetBytes("." + axislette + " g r0xa0\r");

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());

            if (receive == "v 0\r") return true;

            return false;
        }

        public static int sp4_Position_get(string axislette)
        {
            byte[] buffin = Encoding.ASCII.GetBytes("." + axislette + " g r0x32\r");

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);
            
            if(buffout[0]=='v')
            {
                buffout.Remove(0);
                buffout.Remove(1);
                string receive = Encoding.ASCII.GetString(buffout.ToArray());
                int receive_int = int.Parse(receive);
                return receive_int;         
            }
            else
            {
                return -1;
            }
              
        }


        //m_Comm 控制X轴和推拉轴
        public static bool DCM_GOHM_X()
        {
            List<byte> list = new List<byte>();
            list.Add(0x02);
            byte[] bufftmp = Encoding.ASCII.GetBytes("DCM;GOHM;");
            list.AddRange(bufftmp);
            list.Add(0x03);
            byte[] buffin = list.ToArray();

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());

            if (receive == "\u0002OK;\u0003")
            {
                int count = 0;
                while (DCM_SHIFT_FLAG_X() == false)
                {           
                    Thread.Sleep(3);
                    count++;

                    if (count >= 8000) return false;
                }
                return true;
            }

            return false;

        }

        public static bool STM_GOHM_PUSH()
        {

            List<byte> list = new List<byte>();
            list.Add(0x02);
            byte[] bufftmp = Encoding.ASCII.GetBytes("STM;GOHM;");
            list.AddRange(bufftmp);
            list.Add(0x03);
            byte[] buffin = list.ToArray();

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());

            if (receive == "\u0002OK;\u0003")
            {
                int count = 0;
                while (STM_SHIFT_FLAG_PUSH() == false)
                {
                    Thread.Sleep(3);
                    count++;

                    if (count >= 2000) return false;
                }
                return true;
            }

            return false;


            
        }


        /// <summary>
        /// 直流电机位移
        /// </summary>
        /// <param name="number"></param>
        public static bool DCM_SHIFT_NUMBER_X(int number)
        {

            List<byte> list = new List<byte>();
            list.Add(0x02);
            byte[] bufftmp = Encoding.ASCII.GetBytes("DCM;SHIFT;" + number + ";");
            list.AddRange(bufftmp);
            list.Add(0x03);
            byte[] buffin = list.ToArray();

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());

            if (receive == "\u0002OK;\u0003")
            {
                int count = 0;
                while (DCM_SHIFT_FLAG_X() == false)
                {
                    Thread.Sleep(3);
                    count++;

                    if (count >= 8000) return false;
                }
                return true;
            }
            return false;
        }
        public static bool STM_SHIFT_NUMBER_PUSH(int number)
        {

            List<byte> list = new List<byte>();
            list.Add(0x02);
            byte[] bufftmp = Encoding.ASCII.GetBytes("STM;SHIFT;" + number + ";");
            list.AddRange(bufftmp);
            list.Add(0x03);
            byte[] buffin = list.ToArray();

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());

            if (receive == "\u0002OK;\u0003")
            {
                int count = 0;
                while (STM_SHIFT_FLAG_PUSH() == false)
                {
                    Thread.Sleep(3);
                    count++;

                    if (count >= 4000) return false;
                }
                return true;
            }
            return false;
        }

        public static bool DCM_SHIFT_FLAG_X()
        {

            List<byte> list = new List<byte>();
            list.Add(0x02);
            byte[] bufftmp = Encoding.ASCII.GetBytes("DCM;SHIFT;FLAG;");
            list.AddRange(bufftmp);
            list.Add(0x03);
            byte[] buffin = list.ToArray();

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());

            if (receive.Length == 0||receive.Length<16) return false;

            string result = receive.Substring(11, receive.Length - 13);

            if (result == "SET") return true;
            else if (result == "RESET") return false;

            return false;
        }

        public static bool STM_SHIFT_FLAG_PUSH()
        {

            List<byte> list = new List<byte>();
            list.Add(0x02);
            byte[] bufftmp = Encoding.ASCII.GetBytes("STM;SHIFT;FLAG;");
            list.AddRange(bufftmp);
            list.Add(0x03);
            byte[] buffin = list.ToArray();

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());

            if (receive.Length == 0 || receive.Length < 16) return false;

            string result = receive.Substring(11, receive.Length - 13);

            if (result == "SET") return true;
            else if (result == "RESET") return false;

            return false;          
        }


        //排气功能
        public static bool STM_PUAIR_PUSH()
        {

            List<byte> list = new List<byte>();
            list.Add(0x02);
            byte[] bufftmp = Encoding.ASCII.GetBytes("STM;PUAIR;");
            list.AddRange(bufftmp);
            list.Add(0x03);
            byte[] buffin = list.ToArray();

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());

            if (receive == "\u0002OK;\u0003") return true;

            return false;
        }

        public static bool STM_PLSA_PUSH() //加样组合动作
        {

            List<byte> list = new List<byte>();
            list.Add(0x02);
            byte[] bufftmp = Encoding.ASCII.GetBytes("STM;PLSA;");
            list.AddRange(bufftmp);
            list.Add(0x03);
            byte[] buffin = list.ToArray();

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());

            if (receive == "\u0002OK;\u0003")
            {
                int count = 0;
                while (STM_SHIFT_FLAG_PUSH() == false)
                {
                    Thread.Sleep(3);
                    count++;

                    if (count >= 4000) return false;
                }
                return true;
            }         
            return false;
        }


        //m_Comm2 控制 Y轴和转轴
        public static bool DCM_GOHM_Y()
        {

            List<byte> list = new List<byte>();
            list.Add(0x02);
            byte[] bufftmp = Encoding.ASCII.GetBytes("DCM;GOHM;");
            list.AddRange(bufftmp);
            list.Add(0x03);
            byte[] buffin = list.ToArray();

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm2.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());

            if (receive == "\u0002OK;\u0003")
            {
                int count = 0;
                while (DCM_SHIFT_FLAG_Y() == false)
                {
                    Thread.Sleep(3);
                    count++;

                    if (count >= 4000) return false;
                }
                return true;
            }
            return false;
        }
        public static bool STM_GOHM_ROTATE()
        {

            List<byte> list = new List<byte>();
            list.Add(0x02);
            byte[] bufftmp = Encoding.ASCII.GetBytes("STM;GOHM;");
            list.AddRange(bufftmp);
            list.Add(0x03);
            byte[] buffin = list.ToArray();

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm2.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());

            if (receive == "\u0002OK;\u0003")
            {
                int count = 0;
                while (STM_SHIFT_FLAG_ROTATE() == false)
                {
                    Thread.Sleep(3);
                    count++;

                    if (count >= 4000) return false;
                }
                return true;
            }
            return false;
        }
             

        public static bool DCM_SHIFT_NUMBER_Y(int number)
        {

            List<byte> list = new List<byte>();
            list.Add(0x02);
            byte[] bufftmp = Encoding.ASCII.GetBytes("DCM;SHIFT;" + number + ";");
            list.AddRange(bufftmp);
            list.Add(0x03);
            byte[] buffin = list.ToArray();

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm2.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());

            if (receive == "\u0002OK;\u0003")
            {
                int count = 0;
                while (DCM_SHIFT_FLAG_Y() == false)
                {
                    Thread.Sleep(3);
                    count++;

                    if (count >= 6000) return false;
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// 直流电机位移设置
        /// </summary>
        public static bool STM_SHIFT_NUMBER_ROTATE(int number)
        {

            List<byte> list = new List<byte>();
            list.Add(0x02);
            byte[] bufftmp = Encoding.ASCII.GetBytes("STM;SHIFT;" + number + ";");
            list.AddRange(bufftmp);
            list.Add(0x03);
            byte[] buffin = list.ToArray();

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm2.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());

            if (receive == "\u0002OK;\u0003")
            {
                int count = 0;
                while (STM_SHIFT_FLAG_ROTATE() == false)
                {
                    Thread.Sleep(3);
                    count++;

                    if (count >= 4000) return false;
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// 直流电机位移flag
        /// </summary>
        public static bool DCM_SHIFT_FLAG_Y()
        {

            List<byte> list = new List<byte>();
            list.Add(0x02);
            byte[] bufftmp = Encoding.ASCII.GetBytes("DCM;SHIFT;FLAG;");
            list.AddRange(bufftmp);
            list.Add(0x03);
            byte[] buffin = list.ToArray();

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm2.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());

            if (receive.Length == 0 || receive.Length < 16) return false;

            string result = receive.Substring(11, receive.Length - 13);

            if (result == "SET") return true;
            else if (result == "RESET") return false;

            return false;
        }

        public static bool STM_SHIFT_FLAG_ROTATE()
        {

            List<byte> list = new List<byte>();
            list.Add(0x02);
            byte[] bufftmp = Encoding.ASCII.GetBytes("STM;SHIFT;FLAG;");
            list.AddRange(bufftmp);
            list.Add(0x03);
            byte[] buffin = list.ToArray();

            List<byte> buffout = new List<byte>();
            int outlen = m_Comm2.talk(buffin, buffout);

            string receive = Encoding.ASCII.GetString(buffout.ToArray());

            if (receive.Length == 0 || receive.Length < 16) return false;

            string result = receive.Substring(11, receive.Length - 13);

            if (result == "SET") return true;
            else if (result == "RESET") return false;

            return false;
        }

        /// 步进电机起始位置偏移量
        /// </summary>
        /// <param name="number"></param>
        /* public static void STM_STALI_NUMBER_ROTATE(int number)
         {

             List<byte> list = new List<byte>();
             list.Add(0x02);
             byte[] bufftmp = Encoding.ASCII.GetBytes("STM;STALI;"+number+";");
             list.AddRange(bufftmp);
             list.Add(0x03);
             byte[] buffin = list.ToArray();

             List<byte> buffout = new List<byte>();
             int outlen = m_Comm.talk(buffin, buffout);

             string receive = Encoding.ASCII.GetString(buffout.ToArray());
         }

         public static void STM_STALI_NUMBER_PUSH(int number)
         {

             List<byte> list = new List<byte>();
             list.Add(0x02);
             byte[] bufftmp = Encoding.ASCII.GetBytes("STM;STALI;" + number + ";");
             list.AddRange(bufftmp);
             list.Add(0x03);
             byte[] buffin = list.ToArray();

             List<byte> buffout = new List<byte>();
             int outlen = m_Comm2.talk(buffin, buffout);

             string receive = Encoding.ASCII.GetString(buffout.ToArray());
         }
         public static void STM_PUAIR()
         {

             List<byte> list = new List<byte>();
             list.Add(0x02);
             byte[] bufftmp = Encoding.ASCII.GetBytes(";STM;PUAIR;");
             list.AddRange(bufftmp);
             list.Add(0x03);
             byte[] buffin = list.ToArray();

             List<byte> buffout = new List<byte>();
             int outlen = m_Comm.talk(buffin, buffout);

             string receive = Encoding.ASCII.GetString(buffout.ToArray());
         }
         public static void STM_PLAS()
         {

             List<byte> list = new List<byte>();
             list.Add(0x02);
             byte[] bufftmp = Encoding.ASCII.GetBytes(";STM;PLAS;");
             list.AddRange(bufftmp);
             list.Add(0x03);
             byte[] buffin = list.ToArray();

             List<byte> buffout = new List<byte>();
             int outlen = m_Comm.talk(buffin, buffout);

             string receive = Encoding.ASCII.GetString(buffout.ToArray());
         }*/
    }
}
