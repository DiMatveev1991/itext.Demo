using System;
using System.Collections.Generic;
using Contracts;
using iText.Kernel.Pdf.Canvas.Parser;

namespace SampleLib.itext7
{
    public class Class1 : Contracts.IExtractDocument
    {
        public Page[] GetBlocks(byte[] contents)
        {
            List<Page> lstPages = new List<Page>();
            using (var stm = new System.IO.MemoryStream(contents))
            {
                using (var pdfReader = new iText.Kernel.Pdf.PdfReader(stm))
                {
                    using (iText.Kernel.Pdf.PdfDocument doc = new iText.Kernel.Pdf.PdfDocument(pdfReader))
                    {
                        int numOfPages = doc.GetNumberOfPages();
                        for (int page = 1; page <= numOfPages; page++)
                        {
                            var pdfPage = doc.GetPage(page);
                            var pg = new Page();
                            var rotation = pdfPage.GetPageSizeWithRotation();
                            pg.Height = rotation.GetHeight();
                            pg.Width = rotation.GetWidth();
                            var customListener = new CustomEventListener();
                            var parser = new PdfCanvasProcessor(customListener);
                            parser.ProcessPageContent(pdfPage);
                            var lstBlocks = customListener.Blocks;
                            pg.Blocks = customListener.Blocks.ToArray();
                            lstPages.Add(pg);
                        }
                    }
                }
            }
            return lstPages.ToArray();
        }
    }
}
