using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApi.Helper
{
    public class LogHelper
    {
        public LogHelper()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "\\Log\\";
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
            string infoPath = path + "LogInfo\\";
            if (Directory.Exists(infoPath) == false)
            {
                Directory.CreateDirectory(infoPath);
            }
            string errorPath = path + "LogError\\";
            if (Directory.Exists(errorPath) == false)
            {
                Directory.CreateDirectory(errorPath);
            }
        }
        public void Info(string info)
        {
            string path = CheckLogFileExist("LogInfo");
            string content = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
            content += info + "\r\n\r\n";
            File.AppendAllText(path, content);
        }
        public void Error(string info)
        {
            string path = CheckLogFileExist("LogError");
            string content = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
            content += info + "\r\n\r\n";
            File.AppendAllText(path, content);
        }
        private string CheckLogFileExist(string type)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "\\Log\\" + type + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            return path;
        }

    }
}