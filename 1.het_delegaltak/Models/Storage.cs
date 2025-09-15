using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.het_delegaltak.Models
{
    public class Storage<T>
    {
        //public delegate void Traverser(T item); // Action<T>
        //public delegate T Transformer(T input); // Func<T,T>

        T[] array;
        int pointer;
        Func<T, T> transformers;

        public void AddTransformer(Func<T, T> tr)
        {
            transformers += tr;
        } 

        public Storage(int size)
        {
            array = new T[size];
        }

        public void Add(T item)
        {
            if (pointer < array.Length)
            {
                array[pointer++] = item;
            }
            else
            {
                throw new Exception("Storage is full");
            }
        }

        public void Traverse(Action<T> tr)
        {
            for (int i = 0; i < pointer; i++)
            {
                T result = array[i];

                if(transformers != null)
                {
                    foreach (var item in transformers.GetInvocationList())
                    {
                        if (item != null)
                        {
                            result = (item as Func<T, T>).Invoke(result);
                        }
                    }
                }

                tr?.Invoke(result);

                //tr(array[i]);
            }
        }
    }
}
