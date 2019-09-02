using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace UnitTestProject1
{
    /// <summary>
    /// Summary description for PdfiumNet
    /// </summary>
    [TestClass]
    public class PdfiumNet
    {
        public PdfiumNet()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void VeryBasic()
        {
            string file = "data\\CS15.page6.pdf";
            string folder = Util.GetProjectDir2();
            string fullpath = System.IO.Path.Combine(folder, file);
            byte[] contents = System.IO.File.ReadAllBytes(fullpath);
            ///
            /// Invoke itext7
            ///
            Contracts.IExtractDocument extractorPdfium = new SampleLib.Pdfium.NetSDK.Class1();
            var pagesV7 = extractorPdfium.GetBlocks(contents);

        }
        /// <summary>
        /// Troubleshooting assembly loading failures
        /// </summary>
        [TestMethod]
        public void AssemblyLoadFailures()
        {
            try
            {
                string file = "data\\CS15.page6.pdf";
                string folder = Util.GetProjectDir2();
                string fullpath = System.IO.Path.Combine(folder, file);
                byte[] contents = System.IO.File.ReadAllBytes(fullpath);
                var c1 = new SampleLib.Pdfium.NetSDK.Dummy(contents);
                c1.DoSomeStuff();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }
        [TestMethod]
        public void FireItext5_Pdfium()
        {
            string file = "data\\CS15.page6.pdf";
            string folder = Util.GetProjectDir2();
            string fullpath = System.IO.Path.Combine(folder, file);
            byte[] contents = System.IO.File.ReadAllBytes(fullpath);
            ///
            /// Invoke itext5
            ///
            Contracts.IExtractDocument extractor5 = new SampleLib.itext5.Class1();
            var pagesV5 = extractor5.GetBlocks(contents);
            var blockV5_C = pagesV5[0].Blocks[40];
            var blockV5_T = pagesV5[0].Blocks[231];
            Trace.WriteLine($"Results obtained using itext5");
            Trace.WriteLine($"itext5    Text={blockV5_C}");
            Trace.WriteLine($"itext5    Text={blockV5_T}");
            double gapBetweenRowsV5 = blockV5_C.Bottom - blockV5_T.Top;
            Trace.WriteLine($"Gap between 2 rows={gapBetweenRowsV5}");
            Trace.WriteLine("-------------------------------------------");
            ///
            /// Invoke itext5
            ///
            Contracts.IExtractDocument extractorPdfium = new SampleLib.Pdfium.NetSDK.Class1();
            var pagesVium = extractorPdfium.GetBlocks(contents);
            var blockVium_C = pagesVium[0].Blocks[40];
            var blockVium_T = pagesVium[0].Blocks[231];
            Trace.WriteLine($"Results obtained using Pdfium");
            Trace.WriteLine($"pdfium    Text={blockVium_C}");
            Trace.WriteLine($"pdfium    Text={blockVium_T}");
            double gapBetweenRowsVium = blockVium_C.Bottom - blockVium_T.Top;
            Trace.WriteLine($"Gap between 2 rows={gapBetweenRowsVium}");
            Trace.WriteLine("-------------------------------------------");

        }
        [TestMethod]
        public void Rotation_TOBEDONE()
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public void Dutta_TOBEDONE()
        {
            /*
             * 
             MRB5
             baml5
             TopDownCharts
             */ 
            throw new NotImplementedException();
        }
        [TestMethod]
        public void GetTextColor()
        {
            throw new NotImplementedException();
        }
    }
}
