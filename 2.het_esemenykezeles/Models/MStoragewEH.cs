using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.het_esemenykezeles.Models
{
    public class MStoragewEH<T>
    {
        public class ItemAddedEventArgs : EventArgs
        {
            public T Item { get; }
            public int Row { get; }
            public int Column { get; }

            public ItemAddedEventArgs(T item, int row, int column)
            {
                Item = item;
                Row = row;
                Column = column;
            }
        }
        public class MatrixIndexEventArgs : EventArgs
        {
            public int Index { get; }

            public MatrixIndexEventArgs(int index)
            {
                Index = index;
            }
        }

        /*public delegate void ParameterisedHandler(int index);*/ // sor/oszlop megtelt (melyik telt be)
        /*public delegate void MatrixHandler();*/ // ennek nincs parametere igy -> MatrixFull?.Invoke(this, new EventArgs()); de többihez szukseg van esemenyparamter osztalyra
        //public delegate void ThreeParameterisedHandler(T item, int row, int column);

        public event EventHandler<MatrixIndexEventArgs> RowFull;
        public event EventHandler<MatrixIndexEventArgs> ColumnFull;
        public event EventHandler MatrixFull;
        public event EventHandler<ItemAddedEventArgs> ItemAdded;

        T[,] matrix;
        int count;
        int capacity;
        Random r = new Random();
        public MStoragewEH(int row, int column)
        {
            matrix = new T[row, column];
            capacity = row * column;
        }
        public void Add(T item)
        {
            if (count < capacity) //hogy ne generalhasson a vegtelenbe
            {
                int[] result = FindPlace();
                this.matrix[result[0], result[1]] = item;
                ItemAdded?.Invoke(this, new ItemAddedEventArgs(item, result[0], result[1]));
                count++;

                if (IsThisColumnFull(result[1]))
                {
                    ColumnFull?.Invoke(this, new MatrixIndexEventArgs(result[1]));
                }
                if (IsThisRowFull(result[0]))
                {
                    RowFull?.Invoke(this, new MatrixIndexEventArgs(result[0]));
                }
                if (count == capacity)
                {
                    MatrixFull?.Invoke(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Matrix is already full!"); // ez akkor fut le, ha a matrix mar meg van telve, de meg akarunk belerakni
            }
        }
        private int[] FindPlace()
        {
            //return [row, column]
            int row = -1;
            int column = -1;
            do
            {
                row = r.Next(0, matrix.GetLength(0));
                column = r.Next(0, matrix.GetLength(1));
            } while (this.matrix[row, column] != null);
            /*
             *  Ha T pl. int, akkor default(T) = 0.

                Ha T pl. bool, akkor default(T) = false.

                Ha T egy osztály, akkor default(T) = null.
            */
            return new int[] { row, column };
        }

        private bool IsThisRowFull(int index)
        {
            int i = index;
            int j = 0;

            while (j < matrix.GetLength(1) && matrix[i, j] != null)
            {
                j++;
            }
            return j == matrix.GetLength(1);
        }

        bool IsThisColumnFull(int index)
        {
            int i = 0;
            int j = index;

            while (i < matrix.GetLength(0) && matrix[i, j] != null)
            {
                i++;
            }
            return i == matrix.GetLength(0);
        }
    }
}
