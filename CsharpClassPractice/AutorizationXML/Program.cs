using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace XmlAutorizer
{
    internal class Program
    {
        static bool Authorisefailed = true;
        static void Main(string[] args)
        {
            while(Authorisefailed)
            {
                ConsoleCommand.MustAuthorize();
                Authorisefailed = Authorize;
            }
        }
    }
    class User
    {
        string _name;
        string _password;
        DateTime _birthday;
        public string Login { get => _name; set => _name = value; }
        public string Password { get => _password; set => _password = value; }
        public DateTime DateOfBirth { get => _birthday; set => _birthday = value; }
        public User(string name, string password, DateTime dateofbirth)
        {
            Login = name;
            Password = password;
            DateOfBirth = dateofbirth;
        }
        public User(string name, string password)
        {
            Login = name;
            Password = password;
            DateOfBirth = DateTime.Now;
        }
    }
    class Authorize
    {
        static bool GetUserAuthorize(User name)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("users.xml");

            foreach(XmlElement element in xdoc.GetElementsByTagName("user"))
            {
                if(element.GetElementsByTagName("login")[0].InnerText)
            }
        }
        static void SetUserData(string log, string pas, DateTime date)
        {
            
        }
    }
    class ConsoleCommand
    {
        public static void MustAuthorize()
        {
            Console.WriteLine("Авторизуйся Живо!!!");

        }
        public static void Auth()
        {
            Console.WriteLine("Введите логин!!!");
            string login = Console.ReadLine();
            Console.WriteLine("Введите Пароль!!!");
            string password = Console.ReadLine();
        }
    }
}