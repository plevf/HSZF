using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2.zh_gyak
{
    public class Validator
    {
        public static bool Isvalid(Product prod)
        {
            var type = prod.GetType();
            foreach (var prop in type.GetProperties())
            {
                var attr = prop.GetCustomAttribute<RequiredNonEmptyAttribute>();
                if (attr != null)
                {
                    var propValue = (string)prop.GetValue(prod);
                    if (string.IsNullOrEmpty(propValue)) // tehat ha a product skull prop-ja null vagy ures
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
