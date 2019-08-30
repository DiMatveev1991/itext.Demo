using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFwk
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string file = "CS15.page6.pdf";
                byte[] contents = System.IO.File.ReadAllBytes(file);
                ///
                /// Invoke itext7
                ///
                var extractorPdfium = new SampleLib.Pdfium.NetSDK.Class1();
                var pagesV7 = extractorPdfium.GetBlocks(contents);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
