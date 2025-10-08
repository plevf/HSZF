using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zh_gyak_2.Exceptions;

namespace zh_gyak_2.Models
{
    public class CarService
    {
        public List<Car> ReadFile(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);
            if (!fi.Exists)
            {
                throw new FileNotFoundException(fileName);
            }
            else if (fi.Length == 0)
            {
                throw new EmptyFileException();
            }

            List<Car> cars = new List<Car>();

            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(';');
                        cars.Add(new Car(line[0], line[1], int.Parse(line[2]), int.Parse(line[3])));
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return cars;
        }
    }
}
