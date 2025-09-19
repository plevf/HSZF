using _2.het_esemenykezeles.Models;

namespace _2.het_esemenykezeles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage<string> items = new Storage<string>(5);
            items.storageFull += () => Console.WriteLine("A tároló megtelt!");
            MStorage<string> st = new MStorage<string>(3, 3);

            // iratkozzunk fel a matrix tele delegáltra
            st.MatrixFull += MatrixFullToDisplay;
            void MatrixFullToDisplay() // ez a classbol hivodik meg, csak amikor megtelik a matrix (innen nem tudnank meghivni)
            {
                Console.WriteLine("Matrix is full!");
            }

            //columnfull test
            //st.matrix[0, 0] = "a";
            //st.matrix[1, 0] = "b";
            //st.matrix[2, 0] = "c";

            //Console.WriteLine(st.IsThisColumnFull(0));
        }
    }
}
