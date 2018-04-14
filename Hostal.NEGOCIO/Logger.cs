using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class Logger
    {
        public static void Log(String lines)
        {

            // Write the string to a file.append mode is enabled so that the log
            // lines get appended to  test.txt than wiping content and writing the log
            string date;
            date = DateTime.Now.ToString();
            lines = "[" + date + "] - " + lines;
            System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Logger\\test.txt", true);
            file.WriteLine(lines);

            file.Close();

        }
    }
}
