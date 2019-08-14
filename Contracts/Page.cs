using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public class Page
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public TextBlock[] Blocks { get; set; }
    }
}
