using _2.het_esemenykezeles.Models;
using System;
using System.Reflection;

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

            //eventhandler storage
            MStoragewEH<string> stEH = new MStoragewEH<string>(3, 3);

            stEH.Add("a");
            stEH.Add("b");
            stEH.Add("c");
            stEH.Add("d");
            stEH.Add("e");
            stEH.Add("f");
            stEH.Add("g");
            stEH.Add("h");
            stEH.Add("i");

            stEH.MatrixFull += StEH_MatrixFull;
            stEH.ItemAdded += StEH_ItemAdded;
            stEH.RowFull += StEH_RowFull;
            stEH.ColumnFull += StEH_ColumnFull;

        }

        private static void StEH_ColumnFull(object? sender, MStoragewEH<string>.MatrixIndexEventArgs e)
        {
            Console.WriteLine($"Column is full: {e.Index}");
        }

        private static void StEH_RowFull(object? sender, MStoragewEH<string>.MatrixIndexEventArgs e)
        {
            Console.WriteLine($"Row is full: {e.Index}");
        }

        private static void StEH_ItemAdded(object? sender, MStoragewEH<string>.ItemAddedEventArgs e)
        {
            Console.WriteLine($"{e.Item} added to row {e.Row}, column {e.Column}");
        }

        private static void StEH_MatrixFull(object? sender, EventArgs e)
        {
            Console.WriteLine("Matrix is full!");
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
