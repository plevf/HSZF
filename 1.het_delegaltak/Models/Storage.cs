using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.het_delegaltak.Models
{
    public class Storage<T>
    {
        public delegate void Traverser(T item);
        public delegate void Transformer(T input);

        T[] array;
        int pointer;
        Transformer transformers;

        public void AddTransformer(Transformer tr)
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

        public void Traverse(Traverser tr)
        {
            for (int i = 0; i < pointer; i++)
            {
                T result = array[i];
                foreach(var item in transformers.GetInvocationList())
                {
                    if(item != null)
                    {
                        result = (item as Transformer).Invoke(result);
                    }
                }

                tr?.Invoke(array[i]);

                //tr(array[i]);
            }
        }
    }
}
