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
            List<Product> listProduct = new List<Product>()
            {
                new Product("Accer", "SuperGamePC", 330000),
                 new Product("Asus", "OficePC", 130000),
                  new Product("Apple", "luxury", 2230000)
            };
            List<Product> listProduct2 = new List<Product>();
            Order ord = new Order(listProduct);
            Order ord2 = new Order(listProduct2);
            MyXml.SaveXML("1test.xml", ord);
            MyXml.XMLLoad("1test.xml");
            ord2 = MyXml.XMLLoad("1test.xml", ord2);
            foreach(Product product in ord2._products)
            {
                Console.WriteLine(product.ToString());
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
        public override string ToString()
        {
            return ($"{Name} + {Description} + {Price}");
        }
    }
    class MyXml
    {
        public static void SaveXML(string path, Order ord)
        {
            XmlTextWriter? xmltw = null;
            try
            {
                xmltw = new XmlTextWriter(path, Encoding.Unicode);
                xmltw.Formatting = Formatting.Indented;
                xmltw.Indentation = 2;
                xmltw.WriteStartDocument();
                xmltw.WriteStartElement("Orders");
                foreach (Product product in ord._products)
                {
                    xmltw.WriteStartElement("product");
                    xmltw.WriteAttributeString("name", product.Name);
                    xmltw.WriteElementString("Description", product.Description);
                    xmltw.WriteElementString("Price", product.Price.ToString());
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
                if (xmltw != null) xmltw.Close();
            }
        }
        public static void XMLLoad(string path)
        {
            XmlTextReader? xmltr = null;
            List<Product> products = new List<Product>();
            Product prod = new Product("", "", 0);
            try
            {
                xmltr = new XmlTextReader(path);
                xmltr.ReadStartElement("Orders");
                string name = ""; string description = "";
                int price = 0;
                while (xmltr.Read())
                {
                    if (xmltr.NodeType == XmlNodeType.Element && xmltr.Name == "product")
                    {
                        prod = new Product("", "", 0);
                        xmltr.MoveToAttribute(0);
                        name = xmltr.Value;
                    }
                    if (xmltr.NodeType == XmlNodeType.Element && xmltr.Name == "Description")
                    {
                        xmltr.MoveToContent();
                        description = xmltr.ReadString();
                    }
                    if (xmltr.NodeType == XmlNodeType.Element && xmltr.Name == "Price")
                    {
                        xmltr.MoveToContent();
                        price = Int32.Parse(xmltr.ReadString());
                    }
                    if (xmltr.NodeType == XmlNodeType.EndElement && xmltr.Name == "product")
                    {
                        prod.Name = name;
                        prod.Description = description;
                        prod.Price = price;
                        if (prod.Name.Length > 1 && prod.Description.Length > 1 && prod.Price > 0)
                        {
                            products.Add(prod);
                        }
                        else
                        {
                            Console.WriteLine("Error read xml-file");
                            Console.WriteLine(prod.ToString());
                        }
                    }
                }
                foreach (var product in products)
                {
                    Console.WriteLine(product.ToString());
                }
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
                if (xmltr != null) xmltr.Close();
            }
        }
        public static Order XMLLoad(string path, Order ord)
        {
            XmlDocument xdoc = new XmlDocument();
            if (path != null) xdoc.Load(path);
            foreach (XmlElement xel in xdoc.GetElementsByTagName("product"))
            {
                ord._products.Add(new Product(
                    xel.GetAttribute("name"),
                    xel.GetElementsByTagName("Description")[0].InnerText,
                    Int32.Parse(xel.GetElementsByTagName("Price")[0].InnerText)));
            }
            return ord;
        }
    }
}