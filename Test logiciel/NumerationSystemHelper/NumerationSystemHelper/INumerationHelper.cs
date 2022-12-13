using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumerationSystemHelper
{
    public interface INumerationHelper
    {
        string ArabicToRomanConverter(int value);
        int RomanToArabicConverter(string value);
        void PrintRomanNumber(int ArabicValue);
    }
}
