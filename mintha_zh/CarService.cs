using minta_zh.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minta_zh
{
    public class CarService
    {
        public List<Car> ReadFile(string fileName)
        {
            // ex handling
            var fi = new FileInfo(fileName);
            if (!fi.Exists)
            {
                throw new NoExistingFileException();
            }
            else if(fi.Length == 0)
            {
                throw new EmptyFileException();
            }

            // Reading
            List<Car> cars = new List<Car>();
            using (var sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string[] car = sr.ReadLine().Split(';');
                    cars.Add(new Car(car[0], car[1], int.Parse(car[2]), int.Parse(car[3])));
                }
            }
            if(cars.Count > 0)
            {
                return cars;
            }
            else
            {
                throw new ReadingFailedException();
            }
        }
    }
}
