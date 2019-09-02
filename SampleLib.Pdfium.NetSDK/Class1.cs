using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Patagames.Pdf.Net;

namespace SampleLib.Pdfium.NetSDK
{
    public class Class1 : Contracts.IExtractDocument
    {
        public Page[] GetBlocks(byte[] contents)
        {
            List<Page> lstPages = new List<Page>();
            using (var doc = PdfDocument.Load(contents))
            {
                int countPages = doc.Pages.Count;
                for(int pageIndex=0;pageIndex<countPages;pageIndex++)
                {
                    var oNewPage = new Page();
                    lstPages.Add(oNewPage);
                    var page = doc.Pages[0];
                    oNewPage.Width = page.Width;
                    oNewPage.Height = page.Height;
                    var pageObjects = page.PageObjects;
                    var rotation = page.Rotation;//Funny!
                    var lstTinyBlocks = new List<TextBlock>();
                    float widthSpace;

                    foreach (var oPageObj in pageObjects)
                    {
                        var oTextObj = oPageObj as PdfTextObject;
                        if (oTextObj == null) continue;//Vector graphics should be ignored
                        Patagames.Pdf.Pdfium.FPDFTextObj_GetSpaceCharWidth(oTextObj.Handle, out widthSpace);
                        var oFont = oTextObj.Font;
                        string text = oTextObj.TextAnsi;
                        var sb = new StringBuilder(text);
                        for (int charindex = 0; charindex < oTextObj.CharsCount; charindex++)
                        {
                            var rectChar = oTextObj.GetCharRect(charindex);
                            char sCharAtIndex = sb[charindex];
                            var tiny = new TextBlock
                            {
                                Font=oFont.BaseFontName,
                                SpaceWidth=widthSpace,
                                Text=new string(sCharAtIndex,1),
                                Left=rectChar.left,
                                Right=rectChar.right,
                                Bottom=rectChar.bottom,
                                Top=rectChar.top
                            };
                            lstTinyBlocks.Add(tiny);
                        }
                    }
                    oNewPage.Blocks = lstTinyBlocks.ToArray();
                }
            }
            return lstPages.ToArray();
        }
    }
}
