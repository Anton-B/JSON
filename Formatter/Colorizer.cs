using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Documents;
using JSON;
using System.Windows.Media;

namespace Formatter
{
    static class Colorizer
    {
        public static SolidColorBrush GetColor(JToken token)
        {
            if (token == JToken.Colon)
                return new SolidColorBrush(Colors.SteelBlue);
            else if (token == JToken.Comma || token == JToken.CloseArrayBrace || token == JToken.CloseObjectBrace)
                return new SolidColorBrush(Colors.DarkRed);
            else if (token == JToken.True || token == JToken.False || token == JToken.Null)
                return new SolidColorBrush(Colors.Blue);
            return new SolidColorBrush(Colors.Black);
        }
    }
}
