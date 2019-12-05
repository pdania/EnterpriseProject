using System;
using System.IO;
using System.Threading.Tasks;

namespace UI.Tools
{
    public class LogWriter
    {
        private string text;
        private string path;



        public LogWriter()
        {
            //            text = massage;
            //            writePath = path;
            //            // writePath = @"\logs.txt";
            //            writeInFile(writePath, text);
        }

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
            }
        }
        public string Path
        {
            get { return path; }
            set
            {
                path = value;
            }
        }
        public static async Task writeInFile(string path, string text)
        {

            StreamWriter sw = null;
            try
            {
                //                using (sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                //                {
                //                    await sw.WriteLineAsync(text);
                //                }

                using (sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync(text);
                    sw.Close();
                }

                //                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            finally
            {
                sw?.Close();
            }
        }

        public static string readFromFile(string path)
        {
            string res = null;
            StreamReader sr = null;
            try
            {
                using (sr = new StreamReader(path))
                {
                    res = sr.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                //      Console.WriteLine(e.Message);
            }
            finally
            {
                sr?.Close();
            }

            return res;
        }

        public static async Task clearFile(string path)
        {
            string text = "";
            StreamWriter sw = null;
            try
            {
                using (sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync(text);
                }


                //                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            finally
            {
                sw?.Close();
            }
        }
    }
}