using System.IO;

namespace AttributePropertyDZ12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Human hum = new Human();
            Console.WriteLine(hum.ToString());

        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyAttribute : Attribute
    {
        public static string? _path { get; set; }
        public PropertyAttribute(string path)
        {
            _path = path;

        }
    }
    class Human
    {
        [Property("name.ini")]
        public string Name { get 
            {
                return Name;
            }
            set 
            {
           
                using (StreamReader reader = new StreamReader(PropertyAttribute._path))
                {
                    Name = reader.ReadToEnd();
                }
            }
        }

        [Property("lastname.ini")]
        public string LastName
        {
            get
            {
                return LastName;
            }
            set
            {
                using (StreamReader reader = new StreamReader(PropertyAttribute._path))
                {
                    LastName = reader.ReadToEnd();
                }
            }
        }
            [Property("dateofbirth.ini")]
        public DateTime _dateofbirth
        {
            get { return _dateofbirth; }
            set
            {
                using (StreamReader reader = new StreamReader(PropertyAttribute._path))
                {
                    _dateofbirth =  Convert.ToDateTime(reader.ReadToEnd());
                }
            }
        }
        public Human()
        { }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}