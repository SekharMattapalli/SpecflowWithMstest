using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System.Xml;
using System.Xml.Xsl;
using BoDi;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpecFlowCalucator.Hooks
{
    [Binding]
   public  class DataSetupHooks
    {


        /// <summary>
        /// Embedded Resource name
        /// </summary>
        private const string XSLT_FILE = "Trxer.xslt";
        /// <summary>
        /// Trxer output format
        /// </summary>
        private const string OUTPUT_FILE_EXT = ".html";
        private readonly IObjectContainer _objectContainer;
        public DataSetupHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

      //  [AfterTestRun]
        public static void CreateHappyPathData()
        {
          
            // Construct DirectoryInfo for the folder path passed in as an argument
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory + "TestResults";
            //baseDirectory = baseDirectory.Substring(0, baseDirectory.IndexOf("bin"));
            DirectoryInfo di = new DirectoryInfo(baseDirectory);
            // ResultTable resultTable = new ResultTable();
            // testResultTable = resultTable.CreateTestResultTable();
            // For each .trx file in the given folder process it
            FileInfo trxFileName=di.GetFiles("*.trx").FirstOrDefault();

            if(trxFileName.Length>0)
             //trxFileName.Name;

            //foreach (FileInfo file in di.GetFiles("*.trx"))
            //{
            //    fileName = file.Name;
            //}

                Console.WriteLine("Test DataHook class");
        //    System.IO.File.AppendAllText(@"C:/Users/smadhavi/source/repos/DataHookslogs.txt", "TEst");
        //    Transform("C:/Users/smadhavi/source/repos/SpecFlowCalucator/SpecFlowCalucator/bin/Debug/net5.0/TestResults/smadhavi_CHQ-MICROKNOT15_2022-03-04_01_08_10.trx", PrepareXsl());

        }


        ///// <summary>
        ///// Main entry of TrxerConsole
        ///// </summary>
        ///// <param name="args">First cell shoud be TRX path</param>
        //static void Main(string[] args)
        //{
        //    // args[0] = "C:/Users/smadhavi/source/repos/SpecFlowCalucator/SpecFlowCalucator/bin/Debug/net5.0/TestResults/smadhavi_CHQ - MICROKNOT15_2022 - 03 - 04_01_08_10.trx";
        //    if (args.Any() == false)
        //    {

        //        Console.WriteLine("No trx file,  Trxer.exe <filename>");
        //        return;
        //    }
        //    Console.WriteLine("Trx File\n{0}", args[0]);
        //    Transform("C:/Users/smadhavi/source/repos/SpecFlowCalucator/SpecFlowCalucator/bin/Debug/net5.0/TestResults/smadhavi_CHQ-MICROKNOT15_2022-03-04_01_08_10.trx", PrepareXsl());
        //}
        /// <summary>
        /// Transforms trx int html document using xslt
        /// </summary>
        /// <param name="fileName">Trx file path</param>
        /// <param name="xsl">Xsl document</param>
        
       
        private static void Transform(string fileName, XmlDocument xsl)
        {
            try
            {
                Console.WriteLine("FIlename is : " + fileName, " xsl is : " + xsl);
                XslCompiledTransform x = new XslCompiledTransform(true);
                //  var path = System.IO.Directory.GetParent(System.IO.Directory.GetParent(TestContext.CurrentContext.TestDirectory).ToString());
                var resolver = new XmlUrlResolver();
                // x.Load("visio.xsl", sets, resolver);
                var setttings = new XsltSettings(true,true);
               
            
                x.Load(xsl, setttings, new XmlUrlResolver());
               // setttings.EnableScript = true;
                Console.WriteLine("Transforming...");
                x.Transform(fileName, fileName + OUTPUT_FILE_EXT);
                Console.WriteLine("Done transforming xml into html");
            }
            catch(Exception e)
            {

            }
        }

        /// <summary>
        /// Loads xslt form embedded resource
        /// </summary>
        /// <returns>Xsl document</returns>
        private static XmlDocument PrepareXsl()
        {
            XmlDocument xslDoc = new XmlDocument();
          //  XslCompiledTransform myXslTransform = new XslCompiledTransform();
            Console.WriteLine("Loading xslt template...");
     //   C: \Users\smadhavi\source\repos\SpecFlowCalucator\SpecFlowCalucator\Trxer.xslt
          

           // xslDoc.Load(@"C:\Users\smadhavi\source\repos\SpecFlowCalucator\SpecFlowCalucator\Trxer.xslt"); ;

            xslDoc.Load(ResourceReader.StreamFromResource(XSLT_FILE));
               MergeCss(xslDoc);
           //   MergeJavaScript(xslDoc);
            return xslDoc;
        }
        /// <summary>
        ///// Merges all javascript linked to page into Trxer html report itself
        ///// </summary>
        ///// <param name="xslDoc">Xsl document</param>
        private static void MergeJavaScript(XmlDocument xslDoc)
        {
            Console.WriteLine("Loading javascript...");
            XmlNode scriptEl = xslDoc.GetElementsByTagName("script")[0];
            XmlAttribute scriptSrc = scriptEl.Attributes["src"];
            string script = ResourceReader.LoadTextFromResource(scriptSrc.Value);
            scriptEl.Attributes.Remove(scriptSrc);
            scriptEl.InnerText = script;
        }

        /// <summary>
        /// Merges all css linked to page ito Trxer html report itself
        /// </summary>
        /// <param name="xslDoc">Xsl document</param>
        private static void MergeCss(XmlDocument xslDoc)
        {
            Console.WriteLine("Loading css...");
            XmlNode headNode = xslDoc.GetElementsByTagName("head")[0];
            XmlNodeList linkNodes = xslDoc.GetElementsByTagName("link");
            List<XmlNode> toChangeList = linkNodes.Cast<XmlNode>().ToList();

            foreach (XmlNode xmlElement in toChangeList)
            {
                XmlElement styleEl = xslDoc.CreateElement("style");
                styleEl.InnerText = ResourceReader.LoadTextFromResource(xmlElement.Attributes["href"].Value);
                headNode.ReplaceChild(styleEl, xmlElement);
            }
        }
    }
}
