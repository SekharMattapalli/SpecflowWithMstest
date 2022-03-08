using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace SpecFlowCalucator
{
    internal class ResourceReader
    {
        internal static string LoadTextFromResource(string name)
        {
            Console.WriteLine("loading LoadTextFromResource " + name);
            string result = string.Empty;
            using (StreamReader sr = new StreamReader(
                   StreamFromResource(name)))
            {
                result = sr.ReadToEnd();
            }
            return result;
        }

        internal static Stream StreamFromResource(string name)
        {
            Console.WriteLine(" loading StreamFromResource " + name);
            string fileName;
            //From the assembly where this code lives!
            //return this. GetType().Assembly.GetManifestResourceNames();
            //string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //DirectoryInfo di = new DirectoryInfo(baseDirectory);
            //foreach (FileInfo file in di.GetFiles("*.exe"))
            //{
            //    fileName = file.Name;
            //}
            //return fileName + "." + name;

            //  FileInfo trxFileName = di.GetFiles("*.exe");// baseDirectory + "TrxerConsole." + name;// Assembly.GetExecutingAssembly().GetManifestResourceInfo("SpecFlowCalucator.").FileName;
            //   return Assembly.GetExecutingAssembly().GetManifestResourceStream();
            //or from the entry point to the application - there is a difference!
            //  return Assembly.GetExecutingAssembly().GetManifestResourceNames("TrxerConsole." +name).FirstOrDefault();
            //  return  Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourceName); 
            //  return   Assembly.GetEntryAssembly().Location;

            //Assembly.GetExecutingAssembly().GetManifestResourceNames()[0]
             return Assembly.GetExecutingAssembly().GetManifestResourceStream("SpecFlowCalucator." + name);

        }
    }
}
