
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFLIBMatika
{
    class CLogger
    {
        public abstract class LogBase
        {
            public abstract void Log(string Messsage);
        }

        public class Logger : LogBase
        {

            private String CurrentDirectory
            {
                get;
                set;
            }

            private String FileName
            {
                get;
                set;
            }

            private String FilePath
            {
                get;
                set;
            }

            public Logger()
            {
                Console.WriteLine(" Directory.GetCurrentDirectory(); " + Directory.GetCurrentDirectory());

                string pathFile = AppDomain.CurrentDomain.BaseDirectory;

                // + "PublicTempStorage" + Path.DirectorySeparatorChar + "nombreArchivo" + ".txt";
                Console.WriteLine(" pathFile; " + pathFile);

                this.CurrentDirectory = pathFile;
                this.FileName = "Log.txt";
                this.FilePath = this.CurrentDirectory + Path.DirectorySeparatorChar + this.FileName;

            }

            public override void Log(string Messsage)
            {

                System.Console.WriteLine("Logged : {0}", Messsage);

                using (System.IO.StreamWriter w = System.IO.File.AppendText(this.FilePath))
                {
                    w.Write("\r\nLog Entry : ");
                    w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                    w.WriteLine("  :{0}", Messsage);
                    w.WriteLine("-----------------------------------------------");
                }
            }
        }
    }
}
