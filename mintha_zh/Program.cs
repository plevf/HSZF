namespace mintha_zh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = ReadFile("autok.txt");
        }

        public static List<Car> ReadFile(string filename)
        {
            List<Car> cars = new List<Car>();
            using (var sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string[] car = sr.ReadLine().Split(';');
                    cars.Add(new Car(car[0], car[1], int.Parse(car[2]), int.Parse(car[3])));
                }
            }
            return cars;
        }

        public event EventHandler<Car> CarCountByBrand;

    }
}
