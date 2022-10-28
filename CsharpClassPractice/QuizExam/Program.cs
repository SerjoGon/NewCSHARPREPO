using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace QuizExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    interface IMassiveVictorins
    {
        IMyXmlFile XmlFile { get; set; }
        List<IVictorina> VictorinaList { get; set; }
    }

    public interface IVictorina
    {
        IMyXmlFile XmlFile { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        List<IQuestion> questions { get; set; }
        public void Start();
        public void Save();
        public void Load();

    }

    public interface IQuestion
    {
        public string Name { set; get; }
        List<string> variants { get; set; }
        List<int> answers { get; set; }
        public string ToString();
    }

    public interface IUser
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
        public string ToString();
    }

    interface IAuth
    {
        IMyXmlFile XmlFile { get; set; }
        public bool GetAuth(IUser user);
        public string GetUserName(IUser user);


    }

    interface IRegister
    {
        IMyXmlFile XmlFile { get; set; }
        public bool SaveNewUser(IUser user);
        public bool ExistUser(IUser user);

    }
    interface Settings
    {
        IMyXmlFile XmlFile { get; set; }
        public bool ChangeUserSettingsPassword(IUser user, string password);
        public bool ChangeUserSettingsBirthDate(IUser user, DateTime date);
        public bool ChangeUserSettingsAll(IUser user, string password, DateTime date);
    }

    public interface IMyXmlFile
    {
        public bool ExistFile(string path);
        public IVictorina GetVictorina(string path);
        public void SaveVictorina(string path, IVictorina victorina);
        public IUser GetUser(string path);
        public void SaveUser(string path, IUser user, bool rewrite = false);
        public ResultTable GetResultTable(string path);
        public void SaveResultTable(string path, ResultTable rt);
        public IMassiveVictorins GetAllVictorins();

    }

    interface ResultTable
    {
        public string Name { get; set; }
        IMyXmlFile XmlFile { get; set; }
        List<TableItem> TableItems { get; set; }
        public string Path { get; set; }
        public void SaveResultTable();
        public string Top20(string name);
        public string AllResults(string name);


    }

    interface TableItem
    {
        public string Score { get; set; }
        public string NameUser { get; set; }
        public string NameVictorina { get; set; }
        public string ToString();

    }

    interface IEditor
    {
        IMyXmlFile XmlFile { get; set; }
        IVictorina Victorina { get; set; }
        public void NewVictorina();

        public void SaveVictorina();

        public void EditVictorina();
    }
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
        public Victorina GetVictorina(string path, Victorina quiz)
        {
            XmlTextReader? xmltr = null;
            try
            {
                xmltr = new XmlTextReader(path);
                xmltr.ReadStartElement("Victorina");
                string quest = "";
                List<string> variants = new List<string>();
                List<int> answers = new List<int>();
                while (xmltr.Read())
                {
                    for (int i = 0; i < 20; i++)
                    {
                        if (xmltr.NodeType == XmlNodeType.Element && xmltr.Name == "Quest")
                        {
                            xmltr.MoveToAttribute(0);
                            quiz.questions  = xmltr.Value;
                        }
                        for (int j = 0; i < 4; i++)
                        {
                            if (xmltr.NodeType == XmlNodeType.Element && xmltr.Name == "Variants")
                            {
                                xmltr.MoveToContent();
                                variants[j] = xmltr.Value;
                            }
                        }
                        for (int j = 0; i < 4; i++)
                        {
                            if (xmltr.NodeType == XmlNodeType.Element && xmltr.Name == "Answers")
                            {
                                xmltr.MoveToContent();
                                answers[j] = Int32.Parse(xmltr.Value);
                            }
                        }
                    }

                }
            }
        }
        public void SaveVictorina(string path, Victorina victorina)
        {
            XmlTextWriter? xmltw = null;
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
            }

        }
        public IUser GetUser(string path) { }
        public void SaveUser(string path, IUser user, bool rewrite = false) { }
        public ResultTable GetResultTable(string path) { }
        public void SaveResultTable(string path, ResultTable rt) { }
        public IMassiveVictorins GetAllVictorins() { }

    }
    class Victorina : IVictorina
    {
        public MyXmlFile XmlFile { get; set; }
        public string Name
        {
            get => Name;
            set
            {
                this.Name = value;
            }
        }
        public string Path { get; set; }
        public List<Question> questions { get => questions; set { this.questions = value; } }

        public void Start()
        { }
        public void Save()
        {

        }
        public void Load() { }
    }
    class MassiveVictorins : IMassiveVictorins
    {
        public MyXmlFile XmlFile { get; set; }
        public List<Victorina> VictorinaList { get; set; }
    }
    class Question : IQuestion
    {
        public string Name { set; get; }
        public List<string> _variants { get; set; }
        public List<int> _answers { get; set; }
        public Question(string name, List<string> variants, List<int> answers)
        {
            Name = name;
            _variants = variants;
            _answers = answers;
        }
        public string ToString()
        {
            return Name;
        }
    }
}