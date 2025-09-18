using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.het_esemenykezeles.Models
{
    public class MStorage<T>
    {
        public delegate void ParameterisedHandler(int index); // sor/oszlop megtelt (melyik telt be)
        public delegate void MatrixHandler(); // matrix megtelt

        public event ParameterisedHandler RowFull;
        public event ParameterisedHandler ColumnFull;
        public event MatrixHandler MatrixFull;

        T[,] matrix;
        int count;
        int capacity;
        Random r = new Random();
        public MStorage(int row, int column)
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
                count++;
                if(count == capacity)
                {
                    MatrixFull?.Invoke();
                }
            }
            else
            {
                throw new Exception("Matrix is full"); // ez akkor fut le, ha a matrix mar meg van telve, de meg akarunk belerakni
            }
        }
        private int[] FindPlace()
        {
            //return [row, column]
            int row = -1;
            int column = -1;
            do
            {
                row = r.Next(0, matrix.GetLength(0)); //sorok szama
                column = r.Next(0, matrix.GetLength(1));
            } while (this.matrix[row, column] != null);
            /*
             *  Ha T pl. int, akkor default(T) = 0.

                Ha T pl. bool, akkor default(T) = false.

                Ha T egy osztály, akkor default(T) = null.
            */
            return new int[] { row, column };
        }
    }
}
