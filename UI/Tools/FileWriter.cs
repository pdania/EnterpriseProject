using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DBModels;

namespace UI.Tools
{
    public class FileWriter
    {
        private string _path;


        public FileWriter(string path)
        {
            Path = path;
        }

        public string Path
        {
            get { return _path; }
            private set { _path = value; }
        }

        public void WriteInFile(string text)
        {
            StreamWriter sw = null;
            try
            {
                using (sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
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

//        public async Task WriteObjectInFile(User user)
//        {
//            StreamWriter sw = null;
//            try
//            {
//                XmlSerializer serializer = new XmlSerializer(typeof(User));
//                using (sw = new StreamWriter(Path, false))
//                {
//                    await Task.Run(() => serializer.Serialize(sw, user));
//                }
//            }
//            catch (Exception e)
//            {
//                //Console.WriteLine(e.Message);
//            }
//            finally
//            {
//                sw?.Close();
//            }
//        }
        internal void Serialize<TObject>(TObject obj)
        {
            try
            {
                var file = new FileInfo(Path);
                if (file.Exists)
                {
                    file.Delete();
                }
                var formatter = new BinaryFormatter();
                using (var stream = new FileStream(Path, FileMode.Create))
                {
                    formatter.Serialize(stream, obj);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to serialize data to file {Path}", ex);
            }
        }
        internal TObject Deserialize<TObject>() where TObject : class
        {
            try
            {
                if (!new FileInfo(Path).Exists)
                    throw new FileNotFoundException("File doesn't exist.");
                var formatter = new BinaryFormatter();
                using (var stream = new FileStream(Path, FileMode.Open))
                {
                    return (TObject)formatter.Deserialize(stream);
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException($"Failed to Deserialize Data From File {Path}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Deserialize Data From File {Path}", ex);
            }
        }

//        public async Task<User> ReadObjectFromFile()
//        {
//            StreamReader sw = null;
//            try
//            {
//                XmlSerializer serializer = new XmlSerializer(typeof(User));
//                using (sw = new StreamReader(Path))
//                {
//                    return (User) await Task.Run(() => serializer.Deserialize(sw));
//                }
//            }
//            catch (Exception e)
//            {
//                //Console.WriteLine(e.Message);
//            }
//            finally
//            {
//                sw?.Close();
//            }
//            return null;
//        }

//        public string ReadFromFile()
//        {
//            string res = null;
//            StreamReader sr = null;
//            try
//            {
//                using (sr = new StreamReader(Path))
//                {
//                    res = sr.ReadToEnd();
//                }
//            }
//            catch (Exception e)
//            {
//                //      Console.WriteLine(e.Message);
//            }
//            finally
//            {
//                sr?.Close();
//            }
//
//            return res;
//        }
//
//        public async Task ClearFile()
//        {
//            string text = "";
//            StreamWriter sw = null;
//            try
//            {
//                using (sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
//                {
//                    await sw.WriteLineAsync(text);
//                }
//            }
//            catch (Exception e)
//            {
//                //Console.WriteLine(e.Message);
//            }
//            finally
//            {
//                sw?.Close();
//            }
//        }
    }
}