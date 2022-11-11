using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ExamConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyXmlFile xmlFile = new MyXmlFile();
            IEditor editor = new Editor(xmlFile);
            //editor.NewVictorina();
            //editor.EditVictorina();
            IVictorina newVic = new Victorina();
            newVic = (Victorina)xmlFile.GetVictorina("IT.xml");
            newVic.Path = "IT2.xml";
            newVic.Name = "IT2";
            xmlFile.SaveVictorina(newVic);
        }
    }

    public interface IMassiveVictorins
    {
        IMyXmlFile XmlFile { get; set; }
        List<IVictorina> VictorinaList { get; set; }
    }

    public interface IVictorina
    {
        IMyXmlFile XmlFile { get; set; }
        string Name { get; set; }
        string Path { get; set; }
        List<IQuestion> questions { get; set; }
        void Start();
        void Save();
        void Load();

    }

    public interface IQuestion
    {
        string Name { set; get; }
        List<string> variants { get; set; }
        List<int> answers { get; set; }
        string ToString();
    }

    public interface IUser
    {
        string Name { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        DateTime BirthDay { get; set; }
        string ToString();
    }

    public interface IAuth
    {
        IMyXmlFile XmlFile { get; set; }
        bool GetAuth(IUser user);
        string GetUserName(IUser user);


    }

    public interface IRegister
    {
        IMyXmlFile XmlFile { get; set; }
        bool SaveNewUser(IUser user);
        bool ExistUser(IUser user);

    }
    public interface ISettings
    {
        IMyXmlFile XmlFile { get; set; }
        bool ChangeUserSettingsPassword(IUser user, string password);
        bool ChangeUserSettingsBirthDate(IUser user, DateTime date);
        bool ChangeUserSettingsAll(IUser user, string password, DateTime date);
    }

    public interface IMyXmlFile
    {
        bool ExistFile(string path);
        IVictorina GetVictorina(string path);
        bool SaveVictorina(IVictorina victorina);
        IUser GetUser(string path);
        bool SaveUser(string path, IUser user, bool rewrite = false);
        IResultTable GetResultTable(string path);
        bool SaveResultTable(string path, IResultTable rt);
        IMassiveVictorins GetAllVictorins();

    }

    public interface IResultTable
    {
        string Name { get; set; }
        IMyXmlFile XmlFile { get; set; }
        List<ITableItem> TableItems { get; set; }
        string Path { get; set; }
        void SaveResultTable();
        string Top20(string name);
        string AllResults(string name);


    }

    public interface ITableItem
    {
        string Score { get; set; }
        string NameUser { get; set; }
        string NameVictorina { get; set; }
        string ToString();

    }

    public interface IEditor
    {
        IMyXmlFile XmlFile { get; set; }
        IVictorina Victorina { get; set; }
        void NewVictorina();

        void SaveVictorina();

        void EditVictorina();
    }
}