using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Programmer.DataRepository
{
    /// <summary>
    /// 
    /// </summary>
    public class FileRepository : IRepository
    {
        private const string fileName = "dataFile_";
        private string dataFilePath;
        private const char Seperator = ',';
        public FileRepository()
        {
            var userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)+"\\ProgrammerTest\\";
            dataFilePath = Path.Combine(userProfilePath, fileName);
            if (!Directory.Exists(userProfilePath))
                Directory.CreateDirectory(userProfilePath);
        }

        public void Delete(string id)
        {
            File.Delete(dataFilePath + id);
        }

        public T Find<T>(string id)
        {
            var filePath = dataFilePath + id;
            if (File.Exists(dataFilePath + id))
            {
                var result = File.ReadAllLines(filePath);

                var Object = string.Join("", result).FromXml<T>();
                return Object;
            }
            else
                return default(T);
        }

        public void Save(string data,string id)
        {
            using (StreamWriter streamWriter = new StreamWriter(File.Open(
                        dataFilePath +id,
                        FileMode.Append,
                        FileAccess.Write,
                        FileShare.ReadWrite)))
            {
                streamWriter.WriteLine(data);
            }
        }

        public void Save(object instance)
        {
            var fld = instance.GetType().BaseType.GetProperty("Id");
           

            var data = instance.ToXml();
            Save(data, fld.GetValue(instance).ToString());
        }

      
    }
}
