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
        /// <summary>
        /// This method will help you evaluate the coordinates of "4 May 2017" in 
        /// the document CS15.page6.pdf
        /// </summary>
        [TestMethod]
        public void Fire_Both_itext5_And_itext7_Compare4May2017()
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
            var pages5 = extractor5.GetBlocks(contents);
            Trace.WriteLine($"itextsharp5   Text={pages5[0].Blocks[0]}");
        }
        /// <summary>
        /// In this test method we are comparing the vertical gap between the lines "Credit suisse" and "To the extent"
        /// We are using the difference betwen the Bottom of the upper line and the Top of the lower line.
        /// Observations
        ///     itextsharp produces a positive gap of 0.98
        ///     itext7 produces a negative gap of -0.31
        /// Inferences
        ///     The positive gap is expected. I do not understand the implication of negative gap. This implies some kind of 
        ///     overlap but there is none.
        /// </summary>
        [TestMethod]
        public void Fire_Both_itext5_And_itext7_Compare_2ConsecutiveLines()
        {
            string file = "data\\CS15.page6.pdf";
            string folder = Util.GetProjectDir2();
            string fullpath = System.IO.Path.Combine(folder, file);
            byte[] contents = System.IO.File.ReadAllBytes(fullpath);
            ///
            /// Invoke itext7
            ///
            Contracts.IExtractDocument extractor7 = new SampleLib.itext7.Class1();
            var pagesV7 = extractor7.GetBlocks(contents);
            var blockV7_C = pagesV7[0].Blocks[40];
            var blockV7_T = pagesV7[0].Blocks[231];
            Trace.WriteLine($"Results obtained using itext7");
            Trace.WriteLine($"itext7    Text={blockV7_C}");
            Trace.WriteLine($"itext7    Text={blockV7_T}");
            double gapBetweenRowsV7 = blockV7_C.Bottom - blockV7_T.Top;
            Trace.WriteLine($"Gap between 2 rows={gapBetweenRowsV7}");
            Trace.WriteLine("-------------------------------------------");
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
        }
    }
}
