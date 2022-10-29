using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace QuizExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            List<string> variant = new List<string>() {"var1", "var2", "var3","var4" };
            List<int> answer = new List<int>() {1,0,0,0 };
            Question q1 = new Question("testquestion1", variant, answer);
            Question q2 = new Question("testquestion2", variant, answer);
            Question q3 = new Question("testquestion3", variant, answer);
            Question q4 = new Question("testquestion4", variant, answer);
            Question q5 = new Question("testquestion5", variant, answer);
            Question q6 = new Question("testquestion6", variant, answer);
            Question q7 = new Question("testquestion7", variant, answer);
            Question q8 = new Question("testquestion8", variant, answer);
            Question q9 = new Question("testquestion9", variant, answer);
            Question q10 = new Question("testquestion10", variant, answer);
            List<Question> questions = new List<Question>() { q1,q2,q3,q4,q5,q6,q7,q8,q9,q10};
            Victorina victorina = new Victorina("TestVictorina","TestXmlv1.xml",questions);
            MyXmlFile myXmlFile = new MyXmlFile();
            //myXmlFile.SaveVictorina("test.xml",victorina);
            XDocument xdoc = new XDocument();
            XElement victorinatest = new XElement(victorina.Name);

            
        }
    }

    interface IMassiveVictorins
    {
        IMyXmlFile XmlFile { get; set; }
        List<IVictorina> VictorinaList { get; set; }
    }

    public interface IVictorina
    {
        public IMyXmlFile XmlFile { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        List<IQuestion> Questions { get; set; }

    }

    public interface IQuestion
    {
        public string Name { set; get; }
        List<string> variants { get; set; }
        List<int> answers { get; set; }
    }

    public interface IUser
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
    }
    public interface IMyXmlFile
    {
        bool ExistFile(string path);
        IVictorina GetVictorina(string path);
        void SaveVictorina(string path, IVictorina victorina);
        IUser GetUser(string path);
        bool SaveUser(string path, IUser user, bool rewrite = false);
      

    }

    interface IResultTable
    {
        public string Name { get; set; }
        public IMyXmlFile XmlFile { get; set; }
        public List<TableItem> TableItems { get; set; }
        public string Path { get; set; }

    }

    interface ITableItem
    {
        public string Score { get; set; }
        public string NameUser { get; set; }
        public string NameVictorina { get; set; }

    }

    interface IEditor
    {
        IMyXmlFile XmlFile { get; set; }
        IVictorina Victorina { get; set; }

    }
    [Serializable]
    class MyXmlFile : IMyXmlFile
    {
        public bool ExistFile(string path)
        {
            if (path == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Victorina GetVictorina( Victorina? quiz)
        {
            quiz = new Victorina();
                XmlSerializer xmlFormat = new XmlSerializer(typeof(Victorina));
            try
            {
                using (Stream fStream = File.OpenRead(quiz.Path))
                {
                    quiz = xmlFormat.Deserialize(fStream) as Victorina;
                }
            }
            catch (Exception ex) { }
            return quiz;
        }
        public void SaveVictorina(string path, Victorina victorina)
        {
            #region TextWritertry
            /*XmlTextWriter? xmltw = null;
            try
            {
                xmltw = new XmlTextWriter(path, Encoding.Unicode);
                xmltw.Formatting = Formatting.Indented;
                xmltw.Indentation = 2;
                xmltw.WriteStartDocument();
                xmltw.WriteStartElement($"Victorina {victorina.Name} ");
                for (int i = 0; i < 20; i++)
                {
                    xmltw.WriteStartElement($"Quest {i}");
                    xmltw.WriteAttributeString("Quest message", victorina.questions[i].Name);
                    for (int j = 0; j < 4; j++)
                    {
                        xmltw.WriteElementString("Variants", victorina.questions[j]._variants.ToString());
                        xmltw.WriteElementString("Answers", victorina.questions[j]._answers.ToString());
                    }
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
            }*/
            #endregion
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Victorina));
            try 
            {
                using (Stream fStream = File.Create(victorina.Path))
                {
                    xmlFormat.Serialize(fStream, victorina);
                }
                Console.WriteLine("Serialize Done!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public IUser GetUser(string path, User? user)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(User));
            try
            {
                using (Stream fStream = File.OpenRead(path))
                {
                    user = xmlFormat.Deserialize(fStream) as User;
                }
            }
            catch (Exception ex) { }
            return user;

        }
        public bool SaveUser(string path, IUser user, bool rewrite = false)
        {
            List<User> users = new List<User>();
            XElement root;
            XmlDocument xdoc;
            FileInfo file = new FileInfo(path);
            if (!file.Exists)
            {
                FileStream fs = file.Create();
                fs.Close();
                users.Add(new User(user.Name,user.Login,user.Password,user.BirthDay));
            }
            else
            {
                xdoc = new XmlDocument();
                xdoc.Load(path);
                foreach (XmlElement element in xdoc.GetElementsByTagName("user"))
                {
                    users.Add(new User(
                        element.GetElementsByTagName("Name")[0].InnerText,
                        element.GetElementsByTagName("Login")[0].InnerText,
                        element.GetElementsByTagName("Password")[0].InnerText,
                        Convert.ToDateTime(element.GetElementsByTagName("Dateofbirth")[0].InnerText)));
                    users.Add(new User(user.Name, user.Login, user.Password, user.BirthDay));
                }
                xdoc.RemoveAll();
            }
            root = new XElement("users");
            foreach (User us in users)
            {
                XElement element = new XElement("user");
                element.Add(
                    new XElement("Name",us.Name),
                    new XElement("Login", us.Login),
                    new XElement("Password", us.Password),
                    new XElement("Dateofbirth", us.BirthDay));
                root.Add(element);
            }
            root.Save(path);
            return ExistFile(path);
            
        }
        public ResultTable GetResultTable(string path) { return null; }
        public void SaveResultTable(string path, ResultTable rt) { }
        public IMassiveVictorins GetAllVictorins() { return null; }

        public IVictorina GetVictorina(string path)
        {
            throw new NotImplementedException();
        }

        public void SaveVictorina(string path, IVictorina victorina)
        {
            throw new NotImplementedException();
        }

        IUser IMyXmlFile.GetUser(string path)
        {
            throw new NotImplementedException();
        }
    }
    [Serializable]
    class Victorina : IVictorina
    {
        public MyXmlFile XmlFile { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public List<Question> Questions { get; set; }

        IMyXmlFile IVictorina.XmlFile { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        List<IQuestion> IVictorina.Questions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Victorina(string name, string path, List<Question> questions)
        {
            Name = name;
            Path = path;
            Questions = questions;
        }
        public Victorina() { }

    }
    [Serializable]
    class MassiveVictorins : IMassiveVictorins
    {
        public MyXmlFile XmlFile { get; set; }
        public List<Victorina> VictorinaList { get; set; }
        IMyXmlFile IMassiveVictorins.XmlFile { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        List<IVictorina> IMassiveVictorins.VictorinaList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    [Serializable]
    class Question : IQuestion
    {
        public string Name { set; get; }
        public List<string> variants { get; set; }
        public List<int> answers { get; set; }
       
        public Question(string name, List<string> variant, List<int> answer)
        {
            Name = name;
            variants = variant;
            answers = answer;
        }
    }
    [Serializable]
    class ResultTable : IResultTable
    {
        public string Name { get; set; }
        public IMyXmlFile XmlFile { get; set; }
        public List<TableItem>? TableItems { get; set; }
        public string Path { get; set; }
        public ResultTable(string name, IMyXmlFile xmlfile, List<TableItem> tableitm, string path)
        {
            Name = name;
            XmlFile = xmlfile;
            TableItems = tableitm;
            Path = path;
        }

    }
    [Serializable]
    class TableItem : ITableItem
    {
        public string Score { get; set; }
        public string NameUser { get; set; }
        public string NameVictorina { get; set; }

    }
    [Serializable]
    public class User:IUser
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
        public User(string name, string login, string password, DateTime birthDay)
        {
            Name = name;
            Login = login;
            Password = password;
            BirthDay = birthDay;
        }
    }
}