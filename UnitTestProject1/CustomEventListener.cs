using Contracts;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Data;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleLib.itext7
{
    class CustomEventListener : IEventListener
    {
        List<Contracts.TextBlock> _blocks = new List<Contracts.TextBlock>();

        public List<TextBlock> Blocks { get => _blocks; }
        public void EventOccurred(IEventData data, EventType type)
        {
            if (type == EventType.RENDER_TEXT)
            {
                var r = (TextRenderInfo)data;
                RenderText(r);
            }
        }
        public ICollection<EventType> GetSupportedEvents()
        {
            return new EventType[]
            {
                EventType.RENDER_TEXT
            };
        }
        private void RenderText(TextRenderInfo renderInfo)
        {
            IList<TextRenderInfo> textinfos = renderInfo.GetCharacterRenderInfos();
            foreach (TextRenderInfo textinfo in textinfos)
            {
                RenderText_inner(textinfo);
            }
        }
        private void RenderText_inner(TextRenderInfo textinfo)
        {
            string text = textinfo.GetText();
            var bottomLeft = textinfo.GetDescentLine().GetStartPoint();
            var topRight = textinfo.GetAscentLine().GetEndPoint();
            double x1 = bottomLeft.Get(Vector.I1);
            double x2 = topRight.Get(Vector.I1);
            double y1 = bottomLeft.Get(Vector.I2);
            double y2 = topRight.Get(Vector.I2);

            var tb = new TextBlock
            {
                Text = textinfo.GetText(),
                Bottom = y1,
                Top = y2,
                Left = x1,
                Right = x2
            };
            Blocks.Add(tb);
        }
    }
}
