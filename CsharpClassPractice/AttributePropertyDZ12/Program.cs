using System.IO;
using System.Xml.Linq;

namespace AttributePropertyDZ12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Human hum = new Human(typeof(Human));
            Console.WriteLine(hum.ToString());
        }
    }
    [AttributeUsage(AttributeTargets.All)]
    public class PropertyAttribute : Attribute
    {
        public string? _value_name { get; set; }
        public string? _value_lastname { get; set; }
        public string? _value_dofb { get; set; }
        public PropertyAttribute() { }
        public PropertyAttribute(string pathtoname,string pathtolastname,string pathtodofb)
        {
            try
            {
            using StreamReader? readername = new StreamReader(pathtoname);
            using StreamReader? readerlastname = new StreamReader(pathtolastname);
            using StreamReader? readerdofb = new StreamReader(pathtodofb);
            _value_name = readername.ReadToEnd();
            _value_lastname = readerlastname.ReadToEnd();
            _value_dofb = readerdofb.ReadToEnd();
            }
            catch(NullReferenceException ex)
            {
                throw new ArgumentException(ex.Message, nameof(pathtoname));
            }
        }
    }
     [Property("name.ini", "lastname.ini", "dateofbirth.ini")]
    class Human
    {
        PropertyAttribute? MyAttribute;
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Dayofbirth{ get; set; }
        /*
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
                    _dateofbirth =  Convert.ToDateTime(reader.ReadToEnd());
            }
        } */
        public Human() { }
        public Human(Type t)
        {
            try 
            {
            MyAttribute = (PropertyAttribute)Attribute.GetCustomAttribute(t, typeof(PropertyAttribute));
            Name = MyAttribute._value_name;
            LastName = MyAttribute._value_lastname;
            Dayofbirth = MyAttribute._value_dofb;
            }
            catch(NullReferenceException ex)
            {
                throw new ArgumentException(ex.Message, nameof(MyAttribute));
            }
        }
        
        public override string ToString()
        {
            return "Значение взято из INI файлов " + Name + " " + LastName + " " + Dayofbirth + " ";
        }
       
    }
}