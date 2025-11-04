using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace xmlVersion
{
    public class Validator
    {
        public static bool IsValid(Product prod)
        {
            var type = prod.GetType();
            foreach (var item in type.GetProperties())
            {
                var attr = item.GetCustomAttribute<RequiredNonEmptyAttribute>(); // nincs tobbesszam!
                if(attr != null)
                {
                    var propValue = (string)item.GetValue(prod);
                    if (string.IsNullOrEmpty(propValue))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool IsBetween(Product prod)
        {
            var type = prod.GetType();
            foreach(var item in type.GetProperties())
            {
                var attr = item.GetCustomAttribute<PriceLimitAttribute>();
                if(attr != null)
                {
                    var propValue = (int)item.GetValue(prod); // (int)
                    if(propValue >= attr.MinValue && propValue <= attr.MaxValue)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
