using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.het_lab_3
{
    internal class Basic
    {
        public Basic()
        {
            string filePath = Path.Combine("data", "example.txt");
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }
            File.WriteAllText(filePath, "Első sor\n");
            File.AppendAllText(filePath, "Második");
            IEnumerable<string> lines = File.ReadLines(filePath);

            using(var reader = new StreamReader(filePath))
            {
                string? line;
                while (!reader.EndOfStream)
                {
                    Console.WriteLine(reader.ReadLine().ToUpper()); // ha nem zarjuk be a streamreadert akkor nyitva marad a file es nem lehet szerkeszteni vagy mashol megnyitni
                }
            }
        }
    }
}
