using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;

namespace Communication
{
    public class Comm
    {
        private readonly SerialPort serialPort;

        private string m_strPortName;

        private int m_iBaudRate;

        public Comm()
        {
            serialPort = new SerialPort();
            m_strPortName = "";
            m_iBaudRate = 0;
        }

        public string[] GetPortNames()
        {
            return System.IO.Ports.SerialPort.GetPortNames();
        }

        public bool Open(string comname, int baudrate)
        {
            if (comname.Length < 1) return false;

            try
            {
                string[] portnamelist = System.IO.Ports.SerialPort.GetPortNames();
                //   if (Array.IndexOf<string>(portnamelist, comname) == -1) return false;
                if (!portnamelist.Contains(comname)) return false;
                serialPort.PortName = comname;
                serialPort.BaudRate = baudrate;//57600;//波特率
                serialPort.DataBits = 8; //数据位
                serialPort.StopBits = System.IO.Ports.StopBits.One; //两个停止位
                serialPort.Parity = System.IO.Ports.Parity.None; //无奇偶校验位
                serialPort.ReadTimeout = 100;
                serialPort.WriteTimeout = -1;
                serialPort.Open();

                if (serialPort.IsOpen)
                {
                    m_strPortName = comname;
                    m_iBaudRate = baudrate;
                    return true;
                }
                else
                {
                   // CommonLogger.Write("Comm open faild :" + comname + baudrate);
                    return false;
                }
            }
            catch (System.Exception ex)
            {
              //  CommonLogger.Write(ex.ToString() + comname + baudrate);
                return false;
            }

        }

        public void Close()
        {
            serialPort.Close();
        }


        public bool IsOpen
        {
            get
            {
                return serialPort.IsOpen;
            }
        }

        public int ReadPort(byte[] readBuffer)
        {
            if (serialPort.IsOpen)
            {
                int count = serialPort.BytesToRead;

                if (count > 0)
                {
                    try
                    {
                        int outcount = serialPort.Read(readBuffer, 0, count);

                        return outcount;
                    }
                    catch (TimeoutException)
                    {
                        return 0;
                    }
                }
            }

            return 0;

        }

        public int BytesReady()
        {
            if (serialPort.IsOpen)
            {
                return serialPort.BytesToRead;
            }

            return 0;

        }

        public void WritePort(byte[] send, int count)
        {
            if (IsOpen)
            {
                serialPort.Write(send, 0, count);
            }
        }


        public void clearbuff()
        {
            if (!IsOpen) return;

            byte[] buff = new byte[256];
            int nReady = serialPort.BytesToRead;

            for (; nReady != 0;)
            {
                int nRead = serialPort.Read(buff, 0, Math.Min(256, nReady));

                nReady = serialPort.BytesToRead;
            }
        }
    }
}
