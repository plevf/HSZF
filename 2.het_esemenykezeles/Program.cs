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

            st.Add("alma");
            st.Add("körte");
            st.Add("barack");
            st.Add("szilva");
            st.Add("dinnye");
            st.Add("mangó");
            st.Add("ribizli");
            st.Add("banán");
            st.Add("szőlő");

            ;
        }

        private static void MatrixFullToDisplay()
        {
            throw new NotImplementedException();
        }

        private static void St_MatrixFull1()
        {
            throw new NotImplementedException();
        }

        private static void St_MatrixFull()
        {
            throw new NotImplementedException();
        }
    }
}
