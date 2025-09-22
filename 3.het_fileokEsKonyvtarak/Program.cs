using System.Globalization;
using System.IO;

namespace _3.het_fileokEsKonyvtarak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1-3
            //DateTime creation = File.GetCreationTime("pp.png");
            //Console.WriteLine(creation);

            //string[] lines =

            //{

            //    "John",

            //    "Jack",

            //    "Kate",

            //    "Sawyer"

            //};


            //string[] lines2 =

            //{

            //    "George",

            //    "Anne",

            //    "Lee",

            //    "Bush"

            //};
            //File.WriteAllLines("data.txt", lines); //felulir
            //File.AppendAllLines("data.txt", lines2); //hozzarak

            //string content = File.ReadAllText("data.txt");
            //Console.WriteLine(content);

            //StreamReader sr = new StreamReader("data.txt");
            //while (!sr.EndOfStream)
            //{
            //    Console.WriteLine(sr.ReadLine());
            //}
            //sr.Close();

            ////igy nem kell bezarni:
            //using (StreamReader sr1 = new StreamReader("data.txt"))

            //{

            //    while (!sr1.EndOfStream)

            //    {

            //        Console.WriteLine(sr1.ReadLine()); ;

            //    }

            //}
            //Random r = new Random();
            //using (StreamWriter sw = new StreamWriter("numbers.txt"))
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        sw.WriteLine(r.Next(0, 101));
            //    }
            //}

            //StreamWriter sw2 = new StreamWriter("numbers.txt", true); // a true miatt már hozaafuzes tortenne

            //string path = "a";
            //File.WriteAllText(Path.Combine(path, "video.txt"), "texttttttttt"); //Pl. ha path = "C:\\Temp", akkor az eredmény C:\Temp\video.txt

            //string[] lines1 = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "files", "data.txt")); //igy mindegy milyen OS-en van az eleresi ut
            //string[] lines3 = File.ReadAllLines(@".\files\data.txt"); //tehat ua az mint pl ez

            //// Verbatim string (kukaccal):
            //string path1 = @"C:\Users\Peter\data.txt";

            //// Normál string (kukac nélkül, dupla backslash kell):
            //string path2 = "C:\\Users\\Peter\\data.txt";

            ////Csak a jpg kiterjesztésű fájlok

            //string[] fileNames = Directory.GetFiles(path, "*.jpg");

            ////osszes almappa neve:
            //string[] directoryNames = Directory.GetDirectories(path);
            //Directory.GetCurrentDirectory(); // itt a bin/debug/.net
            #endregion

            //04
            // A csatolt fájlban telephelyeket, szervezeti egységeket és azokon belül személyeket tárolunk.

            // Hozzon létre minden telephelynek mappákat, azokon belül a szervezeti egységeknek is mappákat.
            // Ezeken belül minden dolgozónak a nevére hozzon létre vezetéknév_keresztnév.log nevű fájlt!

            List<Location> location = new List<Location>();
            Import(location);
            Generator(location);

            static void Import(List<Location> location)
            {
                using (StreamReader sr = new StreamReader("input.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        if (line.StartsWith("#") && line != null)
                        {
                            location.Add(new Location
                            {
                                Name = line.Substring(1) //# nem lesz benne mert elso karaktertol indulunk
                            });
                        }
                        else if (line.StartsWith("\t>") && line != null)
                        {

                            location.Last().Departments.Add(new Department // az utoljara hozzaadott locationhoz megy a department (mivel a fileban egymas alatt vannak) - location.Departments.Add nem elég mert ez egy lista, location[i] lehetne még
                            {
                                Name = line.Substring(2)
                            });
                        }
                        else if (line.StartsWith("\t\t-") && line != null)
                        {
                            location.Last().Departments.Last().People.Add(new Person
                            {
                                Name = line.Substring(3)
                            });
                        }
                    }
                }
            }
            
            static void Generator(List<Location> location)
            {
                //string path = @"C:\Users\porle\Documents\temp repos";
                string path = Path.Combine("C:", "Users", "porle", "Documents", "temp repos");
                foreach (var l in location)
                {
                    Directory.CreateDirectory(Path.Combine(path, l.Name)); // temp repos mappaban pl washingtol nevu mappa lesz
                    foreach (var d in l.Departments)
                    {
                        Directory.CreateDirectory(Path.Combine(path, l.Name, d.Name));
                        foreach(var p in d.People)
                        {
                            File.Create(Path.Combine(path, l.Name, d.Name, p.Name + ".log")); //itt a letezo mappakon belul hoz letre egy filet
                        }
                    }
                }
            }
        }
    }
}
