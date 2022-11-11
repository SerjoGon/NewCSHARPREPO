using System;
using System.Collections.Generic;
using System.Text;

namespace ExamConsole
{
    [Serializable]
    public class Question : IQuestion
    {
        public string Name { get; set; }
        public List<string> variants { get; set; }
        public List<int> answers { get; set; }

        public Question()
        {
            Name = "";
            variants = new List<string>() { "", "", "", "" };
            answers = new List<int>() { 0, 0, 0, 0 };
        }
    }
}