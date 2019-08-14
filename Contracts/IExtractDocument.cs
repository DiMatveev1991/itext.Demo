using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IExtractDocument
    {
        Page[] GetBlocks(byte[] contents);
    }
}
