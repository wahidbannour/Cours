using System;

namespace Calculatrice
{


    public class CalculSimple : ICalculSimple
    {
        public CalculSimple()
        {
        }

        public int Addition(int x, int y)
        {
            if (x == int.MaxValue || y == int.MaxValue)
                throw new ArgumentException("Limite supérieure ateinte dans l'une des opérandes");
            return x + y;
            //throw new NotImplementedException("pas encore implémenté");
        }

        public int Soustraction(int x, int y)
        {
            return x - y;
            //throw new NotImplementedException("pas encore implémenté");
        }

        public int Multiplication(int x, int y)
        {
            throw new NotImplementedException("pas encore implémenté");
        }

        public int Division(int x, int y)
        {
            throw new NotImplementedException("pas encore implémenté");
        }


    }
}
