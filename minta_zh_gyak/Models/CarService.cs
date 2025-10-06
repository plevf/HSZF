using minta_zh_gyak.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minta_zh_gyak.Models
{
    public class CarService
    {
        public List<Car> ReadFile(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }
            else if (fi.Length == 0)
            {
                throw new EmptyFileException();
            }
            List<Car> cars = new List<Car>();
            using(StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    try
                    {
                        string[] line = sr.ReadLine().Split(';');
                        cars.Add(new Car(line[0], line[1], int.Parse(line[2]), int.Parse(line[3])));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Reading failed: {ex}");
                    }
                }
            }
            return cars;
        }
    }
}
