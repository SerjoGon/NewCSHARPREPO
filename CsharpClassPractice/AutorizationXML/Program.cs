using AuthoriseXML;
using AutorizationXML;
using System.Xml;
using System.Xml.Linq;


namespace AuthoriseXML
{
    internal class Program
    {
        static bool AuthoriseFailed = true;
        static void Main(string[] args)
        {
            do {
                if (ConsoleCommand.UserStart() == "auth")
                {
                    while (AuthoriseFailed)
                    {
                        ConsoleCommand.MustAuth();
                        AuthoriseFailed = Authorize.GetUserAuthorize(ConsoleCommand.Auth());
                        if (AuthoriseFailed) ConsoleCommand.FailedAuth();
                    }
                    if (!AuthoriseFailed) ConsoleCommand.SucessAuth();
                }
                else
                {
                    string login;
                    do
                    {
                        Console.WriteLine("Введите желаемый логин");
                        login = Console.ReadLine();
                    }
                    while (Authorize.ExistUser(login));
                    Console.WriteLine("Введите желаемый пароль");
                    string password = Console.ReadLine();
                    Console.WriteLine("Введите дату рождения в формате 2000.12.28");
                    string[] date = Console.ReadLine().Split('.');
                    DateTime dateOfBirth = new DateTime(Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2]));
                    Authorize.SaveUserData(login, password, dateOfBirth);
                }
            } while (Authorize.UserInSystem == true);
        }
    }
           
}