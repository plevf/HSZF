using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.het_esemenykezeles.Models
{
    public class Storage<T>
    {
        T[] array;
        int pointer;
        public delegate void StorageSign();
        public event StorageSign storageFull;
        //- Kívülről csak fel és leiratkozni tudunk, nem tudjuk nullal egyenlővé tenni
        //- Csak akkor tudunk leiratkoztatni egy függvényt, ha van rá referenciánk(saját függvényünk)
        //- A létrehozó osztályon belülről lehet csak elsütni
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
                storageFull?.Invoke();
            }
        }
    }
}
