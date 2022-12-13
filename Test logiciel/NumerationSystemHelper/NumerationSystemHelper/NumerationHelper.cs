namespace NumerationSystemHelper
{
    public class NumerationHelper : INumerationHelper
    {
        INumericalView view;

        public NumerationHelper()
        {
            this.view = null;
        }
        public NumerationHelper(INumericalView view)
        {
            this.view = view;
        }

        public string ArabicToRomanConverter(int value)
        {
            switch (value)
            {
                case 1: return "I";
                case 2: return "II";
                case 3: return "III";
                case 4: return "IV";
                case 5: return "V";
                case 6: return "VI";
                case 7: return "VII";
                case 8: return "VIII";
                case 9: return "IX";
                default:  return "";
            }
        }

        public void PrintRomanNumber(int ArabicValue)
        {
            throw new NotImplementedException();
        }

        public int RomanToArabicConverter(string value)
        {
            throw new NotImplementedException();
        }
    }
}