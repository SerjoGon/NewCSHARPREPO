using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace CsharpClassPractice
{
    internal class Program
    {

        static Dog dog = new Dog();
        static Random rnd = new Random();
        static System.Timers.Timer timer = new System.Timers.Timer();
        static DateTime dt;
        static void Main(string[] args)
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
            dt = DateTime.Now;
            dt = dt.AddMinutes(3);
            timer.Start();
            Console.ReadLine();
            //Dog dog1 = new Dog(3);
            //string wish = "еды!гав";
            //dog.Wanna(wish);
            //MessageBox.Show("");
        }
        static private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!dog.LivesDog() && DateTime.Now < dt)
            {
                if(DateTime.Now > dt)
                {
                    timer.Stop();
                    Console.WriteLine("Вы справились!");
                }
                Console.WriteLine(e.SignalTime.ToString());
                timer.Interval = rnd.Next(1000, 10000);
                int action = rnd.Next(1, 6);
                switch (action)
                {
                    case 1: dog.Wanna("Хочу Играть!!!гАААв"); break;
                    case 2: dog.Wanna("Хочу есть!!!ГАв"); break;
                    case 3: dog.Wanna("ГавГавГав Хочу спать!"); break;
                    case 4: dog.Wanna("Гав гав гав Хочу Гулять!!"); break;
                    case 5: dog.Wanna("Гав Хочу в туалет!!!"); break;
                    case 6: dog.Wanna("Гав гав гав гав чужой!!!"); break;
                    default: MessageBox.Show("Пес похищен!"); break;
                }
            }
            else
            {
                timer.Stop();
            }
        }

    }
    class Dog
    {
        int _live = 3;
        bool _death = false;
        public Dog()
        {

        }
        public bool LivesDog()
        {
            return _death;
        }
        public void Wanna(string wish)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("ГАВ! " + wish, wish, MessageBoxButtons.OKCancel);
            if (DialogResult.OK == dr)
            {
                if (_live < 3)
                {
                    _live++;
                }
                Console.Clear();
                Calm();
                Console.WriteLine($"Песик имеет {_live} жизней");
            }
            if (DialogResult.Cancel == dr)
            {
                Console.Clear();
                Sad();
                _live--;
                Console.WriteLine($"Песик имеет {_live} жизней");
            }
            if (_live == 0)
            {
                Console.WriteLine("Песик умер");
            }
        }
        public void Calm()
        {
            string calmdog = @"
░░░░██░░░░░░░░░██░░░░░░░░
░░░█░░█░░░░░░░█░░█░░░░░░░
░░█░██░█░░░░░█░██░█░░░░░░
░░█░██░███████░██░█░░░░░░
░░█░░░░░░░░░░░░░░░█░░░░░░
░░█░░░█░░░░░░█░░░░█░░░░░░
░█░░░░░░░█░░░░░░░░░█░░░░░
░░█░░░░█░█░█░░░░░░█░░░░░░
░░█░░░░█████░░░░░░█░░░░░░
";
            //Console.WriteLine(saddog);
            Console.WriteLine(calmdog);
            MessageBox.Show(calmdog, "Я живой,здоровый пес!", (MessageBoxButtons)MessageBoxButton.OK);
        }
        public void Sad()
        {
            string saddog = @"
░░░░░░░░░▄░░░░░░░░░░░░░░▄░░░░
░░░░░░░░▌▒█░░░░░░░░░░░▄▀▒▌░░░
░░░░░░░░▌▒▒█░░░░░░░░▄▀▒▒▒▐░░░
░░░░░░░▐▄▀▒▒▀▀▀▀▄▄▄▀▒▒▒▒▒▐░░░
░░░░░▄▄▀▒░▒▒▒▒▒▒▒▒▒█▒▒▄█▒▐░░░
░░░▄▀▒▒▒░░░▒▒▒░░░▒▒▒▀██▀▒▌░░░ 
░░▐▒▒▒▄▄▒▒▒▒░░░▒▒▒▒▒▒▒▀▄▒▒▌░░
░░▌░░▌█▀▒▒▒▒▒▄▀█▄▒▒▒▒▒▒▒█▒▐░░
░▐░░░▒▒▒▒▒▒▒▒▌██▀▒▒░░░▒▒▒▀▄▌░
░▌░▒▄██▄▒▒▒▒▒▒▒▒▒░░░░░░▒▒▒▒▌░
▐▒▀▐▄█▄█▌▄░▀▒▒░░░░░░░░░░▒▒▒▐░
▐▒▒▐▀▐▀▒░▄▄▒▄▒▒▒▒▒▒░▒░▒░▒▒▒▒▌
▐▒▒▒▀▀▄▄▒▒▒▄▒▒▒▒▒▒▒▒░▒░▒░▒▒▐░
░▌▒▒▒▒▒▒▀▀▀▒▒▒▒▒▒░▒░▒░▒░▒▒▒▌░
░▐▒▒▒▒▒▒▒▒▒▒▒▒▒▒░▒░▒░▒▒▄▒▒▐░░
░░▀▄▒▒▒▒▒▒▒▒▒▒▒░▒░▒░▒▄▒▒▒▒▌░░
░░░░▀▄▒▒▒▒▒▒▒▒▒▒▄▄▄▀▒▒▒▒▄▀░░░
░░░░░░▀▄▄▄▄▄▄▀▀▀▒▒▒▒▒▄▄▀░░░░░
░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▀▀░░░░░░░░";
            Console.WriteLine(saddog);
            MessageBox.Show(saddog, "Я грустный корми меня!!!!", (MessageBoxButtons)MessageBoxButton.OK);
        }
    }

}
