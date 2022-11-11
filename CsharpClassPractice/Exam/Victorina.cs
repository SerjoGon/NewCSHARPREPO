using System;
using System.Collections.Generic;
using System.Text;

namespace ExamConsole
{
    public class Victorina : IVictorina
    {
        public IMyXmlFile XmlFile { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public List<IQuestion> questions { get; set; }
        public Victorina()
        {
            Path = "";
            Name = "";
            questions = new List<IQuestion>();
            for (int i = 0; i < 2; i++)
            {
                questions.Add(new Question());
            }
        }
        public Victorina(string path)
        {
            Path = path;
            questions = new List<IQuestion>();
            for (int i = 0; i < 2; i++)
            {
                questions.Add(new Question());
            }
        }
        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}