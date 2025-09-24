using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.het_lab
{
    public class FileProcessor
    {
        public event Action<string> FileProcessed; // event fajta delegalt

        public void Process(string file)
        {
            Console.WriteLine($"Processing {file}...");
        }
    }
    internal class Basic
    {
        public Basic()
        {
            var processor = new FileProcessor();

            processor.FileProcessed += f => Console.WriteLine($"Log: {f} done."); //eventnek nem lehet erteket adni
        }
    }
}
