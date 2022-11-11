using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ExamConsole
{
    public class MyXmlFile : IMyXmlFile
    {
        public bool ExistFile(string path)
        {
            bool fileExist = File.Exists(path);
            return fileExist;
        }

        public IMassiveVictorins GetAllVictorins()
        {
            throw new NotImplementedException();
        }

        public IResultTable GetResultTable(string path)
        {
            throw new NotImplementedException();
        }

        public IUser GetUser(string path)
        {
            throw new NotImplementedException();
        }
        public IVictorina GetVictorina(string path)
        {
            IVictorina v = new Victorina(path);
            Question quest = new Question();

            XDocument xdoc = XDocument.Load(path);

            XElement vic = xdoc.Element("victorina");
            if (vic != null)
            {
                XAttribute Vname = vic.Attribute("name");
                v.Name = Vname.Value;
                v.Path = v.Name + ".xml";
                foreach (XElement question in vic.Elements("question"))
                {

                    XAttribute Qname = question.Attribute("name");
                    List<string> variants = new List<string>(4);
                    List<int> answers = new List<int>(4);
                    foreach (XElement variant in question.Elements("variant"))
                    {

                        variants.Add(variant.Value);
                        answers.Add(Int32.Parse(variant.Attribute("answer").Value));
                    }
                    quest.Name = Qname.Value;
                    quest.variants = variants;
                    quest.answers = answers;
                    v.questions.Add(quest);
                }
            }
            return v;
        }

        public bool SaveResultTable(string path, IResultTable rt)
        {
            throw new NotImplementedException();
        }

        public bool SaveUser(string path, IUser user, bool rewrite = false)
        {
            throw new NotImplementedException();
        }

        public bool SaveVictorina(IVictorina victorina)
        {
            try
            {
                XDocument xdoc = new XDocument();
                XElement v = new XElement("victorina");
                XAttribute vName = new XAttribute("name", victorina.Name);
                v.Add(vName);
                for (int i = 0; i < 2; i++)
                {
                    XElement vQuestion = new XElement("question");
                    XAttribute vQuestionName = new XAttribute("name", victorina.questions[i].Name);
                    vQuestion.Add(vQuestionName);
                    for (int j = 0; j < 4; j++)
                    {
                        XElement variant = new XElement("variant", victorina.questions[i].variants[j]);
                        XAttribute answer = new XAttribute("answer", victorina.questions[i].answers[j]);
                        variant.Add(answer);
                        vQuestion.Add(variant);
                    }
                    v.Add(vQuestion);
                }
                xdoc.Add(v);
                xdoc.Save(victorina.Path);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public MyXmlFile()
        {

        }
    }
}
