/*
 * 信息记录器
 * 职责：记录一些常用的日志信息
 */
using System;

namespace LogHelper
{
    public class CommonLogger
    {
        /// <summary>
        /// 记录消息内容
        /// </summary>
        public static void Write(string message)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("MyLog");
            logger.Debug(message);
        }

       
    }
}