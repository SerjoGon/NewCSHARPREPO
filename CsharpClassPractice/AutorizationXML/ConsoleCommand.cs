using AuthoriseXML;
using System.Xml;
using System.Xml.Linq;


namespace AutorizationXML
{
    internal class ConsoleCommand
    {

        public static int AuthCount = 0;
        public static void MustAuth()
        {
            Console.WriteLine("Авторизуйтесь! Заполните поля логина и пароля.");
        }
        public static User Auth()
        {
            Console.WriteLine("Введите логин:");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль:");
            string password = Console.ReadLine();
            User user = new User(login, password);
            return user;
        }
        public static void SucessAuth()
        {
            Console.WriteLine("Вы успешно авторизовались.");
        }
        public static void FailedAuth()
        {
            Console.WriteLine("Вы не смогли авторизоваться.");
        }
        public static string UserStart()
        {
            Console.WriteLine("Для авторизации наберите auth, для регистрации наберите register");
            string answer = "";
            switch (Console.ReadLine())
            {
                case "auth": answer = "auth"; break;
                case "register": answer = "register"; break;
                default: Console.WriteLine("Введенная вами команда не распознана."); UserStart(); break;
            }
            return answer;
        }
        public static void InformationAfterAuth()
        {
            Console.WriteLine("Возможные команды: \n quizlist");
        }
    }
}
