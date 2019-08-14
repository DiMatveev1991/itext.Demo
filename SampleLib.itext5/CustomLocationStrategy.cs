using Contracts;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleLib.itext5
{
    public class CustomLocationStrategy : LocationTextExtractionStrategy
    {
        List<Contracts.TextBlock> _blocks = new List<Contracts.TextBlock>();

        public List<TextBlock> Blocks { get => _blocks;  }

        public override void RenderText(TextRenderInfo renderInfo)
        {
            base.RenderText(renderInfo);
            IList<TextRenderInfo> textinfos = renderInfo.GetCharacterRenderInfos();
            foreach (TextRenderInfo textinfo in textinfos)
            {
                RenderText_inner(textinfo);
            }
        }
        public void RenderText_inner(TextRenderInfo renderInfo)
        {
            var bottomLeft = renderInfo.GetDescentLine().GetStartPoint();
            var topRight = renderInfo.GetAscentLine().GetEndPoint();
            double x1 = bottomLeft[Vector.I1];
            double x2 = topRight[Vector.I1];
            double y1 = bottomLeft[Vector.I2];
            double y2 = topRight[Vector.I2];
            var tb = new TextBlock
            {
                Text= renderInfo.GetText(),
                Bottom=y1,
                Top=y2,
                Left=x1,
                Right=x2
            };
            Blocks.Add(tb);
        }

    }
}
