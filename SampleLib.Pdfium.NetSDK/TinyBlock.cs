using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLib.Pdfium.NetSDK
{
    public class TinyBlock
    {
        public double SpaceWidth { get; set; }
        public string Font { get; set; }
        public string Text { get; internal set; }

        public override string ToString()
        {
            return $"Font={Font}    SpaceWidth={SpaceWidth} Text={Text}";
        }
    }
}
