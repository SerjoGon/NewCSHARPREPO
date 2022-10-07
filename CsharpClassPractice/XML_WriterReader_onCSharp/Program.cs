using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace XML_WriterReader_onCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> listProduct = new List<Product>() {
                new Product("Accer", "SuperGamePC", 330000),
                 new Product("Asus", "OficePC", 130000),
                  new Product("Apple", "luxury", 2230000)
            };
            Order ord = new Order(listProduct);
            XmlTextWriter? xmltw = null;
            try
            {
                 xmltw = new XmlTextWriter("Test.xml", Encoding.Unicode);
                xmltw.Formatting = Formatting.Indented;
                xmltw.Indentation = 2;
                xmltw.WriteStartDocument();
                xmltw.WriteStartElement("Orders");
                foreach (Product product in ord._products)
                {
                    xmltw.WriteStartElement("product");
                    xmltw.WriteAttributeString("name", product.Name);
                    xmltw.WriteElementString("Description",product.Description);
                    xmltw.WriteElementString("Price",product.Price.ToString());
                    xmltw.WriteEndElement();
                }
                xmltw.WriteEndElement();
                xmltw.WriteEndDocument();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileLoadException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(xmltw != null) xmltw.Close();
            }
        }
    }
    class Order
    {
        public Random random = new Random();
        public int _id;
        public DateTime OrderDate { get; set; }
        public List<Product> _products = new List<Product>();
        public Order(List<Product> products)
        {
            _products = products;
            _id = DateTime.Now.Millisecond * random.Next(100);
        }
    }
    class Product
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public Product(string name, string desc, int price)
        {
            Name = name;
            Description = desc;
            Price = price;
        }
    }
}