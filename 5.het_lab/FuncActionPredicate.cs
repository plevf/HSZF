using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.het_lab
{
    internal class FuncActionPredicate
    {
        int StudentDiscount(int price)
        {
            return (int)(price * 0.8);
        }
        int SeniorDiscount(int p) => (int)(p * 0.7);

        public FuncActionPredicate()
        {
            int OriginalPrice = 1000;
            Func<int, int> calc = StudentDiscount; // van visszateres
            Action<int, Func<int, int>> act = PricePrinter; // nincs visszateres
            //Predicate - bool visszateres
            calc += SeniorDiscount;

            act(OriginalPrice, calc);
        }

        void PricePrinter(int price, Func<int, int> calc)
        {
            Console.WriteLine($"New Price: {calc(price)}");
        }
    }
}
