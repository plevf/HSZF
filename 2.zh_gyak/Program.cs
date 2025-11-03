using System.Xml.Linq;

namespace _2.zh_gyak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument xdoc = new XDocument("termekek.xml");
            foreach (var category in xdoc.Descendants("Category"))
            {
                var productsXML = category.Element("Products").Elements("Product"); // ElementS!!!! mivel adott kategorian belul egy products van de tobb product
                var products = new List<Product>();

                foreach (var product in productsXML)
                {

                }
            }
        }
    }
}
