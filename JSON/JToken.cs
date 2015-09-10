using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    enum JToken
    {
        OpenObjectBrace = 1,
        CloseObjectBrace = 2,
        OpenArrayBrace = 3,
        CloseArrayBrace = 4,
        Comma = 5,
        Colon = 6,
        Quote = 7,
        String = 8,
        Int = 9,
        Double = 10
    }
}
