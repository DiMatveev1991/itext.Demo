using System;
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
        }
    }
}
