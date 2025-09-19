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

            st.ItemAdded += St_ItemAdded;
            st.ColumnFull += St_ColumnFull;
            st.RowFull += St_RowFull;

            //columnfull test
            //st.matrix[0, 0] = "a";
            //st.matrix[1, 0] = "b";
            //st.matrix[2, 0] = "c";

            //Console.WriteLine(st.IsThisColumnFull(0));

            st.Add("a");
            st.Add("b");
            st.Add("c");
            st.Add("d");
            st.Add("e");
            st.Add("f");
            st.Add("g");
            st.Add("h");
            st.Add("i");

        }

        private static void St_ItemAdded(string item, int i, int j)
        {
            Console.WriteLine($"{item} added to row {i}, column {j}");
        }

        private static void St_RowFull(int index)
        {
            Console.WriteLine($"Row is full: {index}");
        }

        private static void St_ColumnFull(int index)
        {
            Console.WriteLine($"Column is full: {index}");
        }
    }
}
