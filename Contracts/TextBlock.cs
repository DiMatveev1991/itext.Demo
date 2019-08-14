using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public class TextBlock
    {
        public string Text { get; set; }
        public double Left { get; set; }
        public double Right { get; set; }
        public double Top { get; set; }
        public double Bottom { get; set; }
        public string Font { get; set; }
        /// <summary>
        /// Returns the total height occupied by this element
        /// </summary>
        public double Height
        {
            get
            {
                return Math.Abs(this.Top - this.Bottom);
            }
        }
        /// <summary>
        /// Returns the total width occupied by this element
        /// </summary>
        public double Width
        {
            get
            {
                return Math.Abs(this.Left - this.Right);
            }
        }
        public override string ToString()
        {
            return string.Format("Text={0},Left={1},Right={2},Bottom={3},Top={4}, W={5},Ht={6}", Text, Left, Right, Bottom, Top,Width,Height);
        }

    }
}
