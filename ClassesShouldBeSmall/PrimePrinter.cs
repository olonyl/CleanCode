using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesShouldBeSmall
{
    public class PrimePrinter:PrimeGenerator
    {
        public static void Print()
        {
            const int NUMBER_OF_PRIMES = 1000;
            int[] primes = PrimeGenerator.Generate(NUMBER_OF_PRIMES);

            const int ROWS_PER_PAGE = 50;
            const int COLUMNS_PER_PAGE = 4;
            RowColumnPagePrinter tablePrinter = new RowColumnPagePrinter(ROWS_PER_PAGE, COLUMNS_PER_PAGE, $"The First {NUMBER_OF_PRIMES} Prime Numbers");
            tablePrinter.Print(primes);
        }
    }
}
