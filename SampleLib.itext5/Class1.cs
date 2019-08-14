using System;
using System.Collections.Generic;
using Contracts;

namespace SampleLib.itext5
{
    public class Class1 : Contracts.IExtractDocument
    {
        Page[] IExtractDocument.GetBlocks(byte[] contents)
        {
            List<Page> lstPages = new List<Page>();
            using (iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(contents))
            {
                int numOfPages = reader.NumberOfPages;
                for (int page = 1; page <= numOfPages; page++)
                {
                    iTextSharp.text.Rectangle r = reader.GetPageSizeWithRotation(page);
                    var pg = new Page();
                    pg.Width = r.Width;
                    pg.Height = r.Height;
                    lstPages.Add(pg);
                    var strat = new CustomLocationStrategy();
                    iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(reader, page, strat);
                    pg.Blocks = strat.Blocks.ToArray();
                }
            }
            return lstPages.ToArray();
        }
    }
}
