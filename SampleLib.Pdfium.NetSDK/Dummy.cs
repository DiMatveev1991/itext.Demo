using Patagames.Pdf.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SampleLib.Pdfium.NetSDK
{
    /// <summary>
    /// Troubleshooting assembly loading failures
    /// </summary>
    public class Dummy
    {
        PdfDocument _doc;
        public Dummy(byte[] contents)
        {
            _doc = PdfDocument.Load(contents);
        }
        public int PagesCount
        {
            get
            {
                return _doc.Pages.Count;
            }
        }

        public void DoSomeStuff()
        {
            int countPages = this.PagesCount;
            for (int pageIndex = 0; pageIndex < countPages; pageIndex++)
            {
                var page = _doc.Pages[0];
                double width = page.Width;
                double ht = page.Height;
                var pageObjects = page.PageObjects;
                foreach (var oPageObj in pageObjects)
                {
                    var oTextObj = oPageObj as PdfTextObject;
                    if (oTextObj == null) continue;//Vector graphics should be ignored
                    float widthSpace;
                    Patagames.Pdf.Pdfium.FPDFTextObj_GetSpaceCharWidth(oTextObj.Handle, out widthSpace);
                    var oFont = oTextObj.Font;
                    string text = oTextObj.TextAnsi;
                    Trace.TraceInformation(text);
                    for (int charindex = 0; charindex < oTextObj.CharsCount; charindex++)
                    {
                        var rectChar = oTextObj.GetCharRect(charindex);
                    }
                }
            }
        }
    }
}
