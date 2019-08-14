using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1_itext5()
        {
            string file = "data\\CS15.page6.pdf";
            string folder = Util.GetProjectDir2();
            string fullpath = System.IO.Path.Combine(folder, file);
            byte[] contents = System.IO.File.ReadAllBytes(fullpath);
            Contracts.IExtractDocument extractor = new SampleLib.itext5.Class1();
            var pages=extractor.GetBlocks(contents);
            Trace.WriteLine($"Text={pages[0].Blocks[0]}");
        }
        [TestMethod]
        public void TestMethod1_itext7()
        {
            string file = "data\\CS15.page6.pdf";
            string folder = Util.GetProjectDir2();
            string fullpath = System.IO.Path.Combine(folder, file);
            byte[] contents = System.IO.File.ReadAllBytes(fullpath);
            Contracts.IExtractDocument extractor = new SampleLib.itext7.Class1();
            var pages = extractor.GetBlocks(contents);
            Trace.WriteLine($"Text={pages[0].Blocks[0]}");
        }
        [TestMethod]
        public void Fire_Both_itext5_And_itext7()
        {
            string file = "data\\CS15.page6.pdf";
            string folder = Util.GetProjectDir2();
            string fullpath = System.IO.Path.Combine(folder, file);
            byte[] contents = System.IO.File.ReadAllBytes(fullpath);
            ///
            /// Invoke itext7
            ///
            Contracts.IExtractDocument extractor7 = new SampleLib.itext7.Class1();
            var pages7 = extractor7.GetBlocks(contents);
            Trace.WriteLine($"itext7    Text={pages7[0].Blocks[0]}");
            ///
            /// Invoke itext5
            ///
            Contracts.IExtractDocument extractor5 = new SampleLib.itext5.Class1();
            var pages = extractor5.GetBlocks(contents);
            Trace.WriteLine($"itextsharp5   Text={pages[0].Blocks[0]}");
        }
    }
}
