using AuthoriseXML;
using System.Xml;
using System.Xml.Linq;


namespace AutorizationXML
{
    internal class Authorize
    {
        public static bool UserInSystem;
        public static bool GetUserAuthorize(User user)
        {
            bool tmp = true;
            FileInfo file = new FileInfo("users.xml");
            if (file.Exists)
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load("users.xml");
                foreach (XmlElement element in xdoc.GetElementsByTagName("user"))
                {
                    if (element.GetElementsByTagName("login")[0].InnerText == user.Login &&
                        element.GetElementsByTagName("password")[0].InnerText == user.Password)
                        tmp = false;
                }
                if (ConsoleCommand.AuthCount == 3)
                {
                    tmp = false;
                    ConsoleCommand.AuthCount = 0;
                    ConsoleCommand.UserStart();
                }
                return tmp;
            }
            else
            {
                Console.WriteLine("Eror! В системе нет такого пользователя");
                return tmp;
            }

        }
        public static bool ExistUser(string login)
        {
            FileInfo file = new FileInfo("users.xml");
            if (file.Exists)
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load("users.xml");
                bool findUser = false;
                foreach (XmlElement element in xdoc.GetElementsByTagName("user"))
                {
                    if (element.GetElementsByTagName("login")[0].InnerText == login)
                        findUser = true;
                }
                return findUser;
            }
            else
            {
                return false;
            }

        }
        public static void SaveUserData(string log, string pas, DateTime date)
        {
            List<User> users = new List<User>();
            XElement root;
            XmlDocument xdoc;
            FileInfo file = new FileInfo("users.xml");
            if (!file.Exists)
            {
                FileStream fs = file.Create();
                fs.Close();
                users.Add(new User(log, pas, date));
            }
            else
            {
                xdoc = new XmlDocument();
                xdoc.Load("users.xml");
                foreach (XmlElement element in xdoc.GetElementsByTagName("user"))
                {
                    users.Add(new User(
                        element.GetElementsByTagName("login")[0].InnerText,
                        element.GetElementsByTagName("password")[0].InnerText,
                        Convert.ToDateTime(element.GetElementsByTagName("dateofbirth")[0].InnerText)));
                    users.Add(new User(log, pas, date));
                }
                xdoc.RemoveAll();
            }
            root = new XElement("users");
            foreach (User user in users)
            {
                XElement element = new XElement("user");
                element.Add(
                    new XElement("login", user.Login),
                    new XElement("password", user.Password),
                    new XElement("dateofbirth", user.DateOfBirth));
                root.Add(element);
            }

            root.Save("users.xml");

        }

    }
}
