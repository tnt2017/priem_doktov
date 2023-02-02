using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Reflection;
using System.Configuration;

namespace test111
{
    static class Logger
    {
        //----------------------------------------------------------
        // Статический метод записи строки в файл лога без переноса
        //----------------------------------------------------------

 

        public static void Write(string text)
        {
            string KassaLogPath = ConfigurationManager.AppSettings["KassaLogPath"];
            if (KassaLogPath == "")
                KassaLogPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            DateTime t = DateTime.Now;
            string dt = t.ToString("dd.MM.yyyy");

            using (StreamWriter sw = new StreamWriter(KassaLogPath + "\\log_" + dt + ".txt", true))
            {
                sw.Write(text);
            }
        }

        //---------------------------------------------------------
        // Статический метод записи строки в файл лога с переносом
        //---------------------------------------------------------
        public static void WriteLine(string message)
        {
            string KassaLogPath = ConfigurationManager.AppSettings["KassaLogPath"];
            if (KassaLogPath == "")
                KassaLogPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            DateTime t = DateTime.Now;
            string dt = t.ToString("dd.MM.yyyy");

            using (StreamWriter sw = new StreamWriter(KassaLogPath + "\\log_" + dt + ".txt", true))
            {
                sw.WriteLine(String.Format("{0,-23} {1}", DateTime.Now.ToString() + ":", message));
            }
        }
    }
}
