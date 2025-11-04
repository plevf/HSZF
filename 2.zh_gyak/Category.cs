using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.zh_gyak
{
    // XML

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Category
    {

        private string nameField;

        private List<Product> productsField;

        public int Id {  get; set; } // pluszba kell!

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Product", IsNullable = false)]
        public List<Product> Products
        {
            get
            {
                return this.productsField;
            }
            set
            {
                this.productsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Product
    {

        private string skuField;

        private string nameField;

        private int priceField; // at kellett irni intre

        public int Id { get; set; } // pluszba

        [System.Xml.Serialization.XmlIgnore]
        public int CatergoryId { get; set; } // pluszba

        [RequiredNonEmpty] // cikkszamra raktuk ra (attribute)
        /// <remarks/>
        public string Sku
        {
            get
            {
                return this.skuField;
            }
            set
            {
                this.skuField = value;
            }
        }

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [PriceRange(200, 20000)]
        /// <remarks/>
        public int Price
        {
            get
            {
                return this.priceField;
            }
            set
            {
                this.priceField = value;
            }
        }
    }


}
