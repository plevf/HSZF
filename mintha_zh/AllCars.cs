using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minta_zh
{
    public class AllCars : EventArgs // Car listát csinál és tárol
    {
        public List<Car> Cars { get; set; }
        
        public AllCars(string fileName)
        {
            Cars = ReadFile(fileName);
        }
        public List<Car> ReadFile(string fileName)
        {
            List<Car> cars = new List<Car>();
            using (var sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string[] car = sr.ReadLine().Split(';');
                    cars.Add(new Car(car[0], car[1], int.Parse(car[2]), int.Parse(car[3])));
                }
            }
            return cars;
        }
        public event EventHandler<CarCounterByBrandEventArgs>? CarCountByBrand;
        public void Counter(string fileName, string brand)
        {
            CarCountByBrand?.Invoke(this, new CarCounterByBrandEventArgs(fileName, brand));
        }
    }
}
