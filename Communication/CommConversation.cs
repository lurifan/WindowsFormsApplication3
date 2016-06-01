using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using LogHelper;

namespace Communication
{
    public class CommConversation
    {
        public Comm hComm;
        public string m_strPortname;
        public int m_iBaudrate;
        public bool initflag=false;
  
        public  CommConversation()
        {
            hComm = new Comm();
        }

        public bool IsOpen
        {
            get
            {
                return hComm.IsOpen;
            }
        }

        public bool init(string Portname, int Baudrate)
        {
            if (hComm==null)
            {
                hComm = new Comm();
            }
            else
            {
                if (hComm.IsOpen)
                {
                    hComm.Close();
                }     
            }

            if (hComm.Open(Portname, Baudrate) == true) return true;

            return false;
        }

        public void CommClose()
        {
            hComm.Close();
        }

        public int talk(byte[] buffin, List<byte> buffout)
        {
            int tcount = 0;
redo:
            try
            {               
                hComm.clearbuff();
                      
                hComm.WritePort(buffin, buffin.Length);

                int nReady = 0;

                long dwBorn = System.Environment.TickCount;

                while (nReady < 5)
                {
                    long dwNow = System.Environment.TickCount;
                    if (dwNow - dwBorn > 100)
                    {
                        if (tcount == 10)
                        {
                                                
                            hComm.Close();
                            
                            return 0;
                        }
                        tcount++;
                        goto redo;
                    }
                    Thread.Sleep(1);
                    nReady = hComm.BytesReady();
                }

                byte[] val = new byte[nReady];

                int readlen = hComm.ReadPort(val);

                if (val[0] != 0x02 || val[nReady - 1] != 0x03)
                {
                    tcount++;
                    if (tcount == 10)
                    {
                        hComm.Close();
                        return 0;
                    } 
                    goto redo;
                }

                buffout.AddRange(val);
               
            
                return readlen;

            }
            catch (System.Exception ex)
            {
                if (tcount == 10)
                {
                   // CommonLogger.Write("Read Timeout:" + ex.ToString());
                    hComm.Close();
                    return 0;
                }
                tcount++;
                goto redo;
            }

        }

        public int talk(byte[] buffin, byte[] buffout,int timeout)
        {
            int tcount = 0;
        redo:
            try
            {
                hComm.clearbuff();

                hComm.WritePort(buffin, buffin.Length);

                int nReady = 0;

                long dwBorn = System.Environment.TickCount;

                for (; nReady <5; )
                {
                    long dwNow = System.Environment.TickCount;
                    if (dwNow - dwBorn > timeout)
                    {
                        if (tcount == 10)
                        {                           
                            hComm.Close();
                            return 0;
                        }
                        tcount++;
                        goto redo;
                    }
                    Thread.Sleep(1);
                    nReady = hComm.BytesReady();
                }

                int readlen=hComm.ReadPort(buffout);

                if (buffout[0] != 0x02 || buffout[nReady - 1] != 0x03)
                {
                    tcount++;
                    if (tcount == 10)
                    {
                        hComm.Close();
                        return 0;
                    }  
                    goto redo;
                }

                return readlen;

            }
            catch (System.Exception ex)
            {
                if (tcount == 10)
                {
                    //CommonLogger.Write("Read Timeout:" + ex.ToString());
                    hComm.Close();
                    return 0;
                }
                tcount++;
                goto redo;
            }

        }
  
    }
}
