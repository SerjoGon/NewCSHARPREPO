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
        static System.Timers.Timer timer = new System.Timers.Timer();
        Dog dog = new Dog(1);
        Random rnd = new Random();

        static void Main(string[] args, Dog dog)
        {

            timer.Interval = 3000;
            dog.Calm();
            dog.Sad();
            dog.WannaEat();
        }
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Interval = rnd.Next(1000, 3000);
        }

    }
    class Dog
    {
        int _state = 0;
        int _life = 3;
        bool _death = false;
        public Dog(int state)
        {
            _state = state;
        }
        public void WannaEat(string wish)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Гав!" + wish, wish, (MessageBoxButtons)MessageBoxButton.OKCancel);
            if (DialogResult.OK == dr)
            {
                if (_life < 3)
                {
                    _life++;
                }
            }

        }
        public void Sad()
        {
            string saddog = @"
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
            MessageBox.Show(saddog, "Я грустный", (MessageBoxButtons)MessageBoxButton.YesNoCancel);
        }
        public void Calm()
        {
            string dogcalm = @"
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
            Console.WriteLine(dogcalm);
            MessageBox.Show(dogcalm, "Я здесь Кожаный Мешок!!!!", (MessageBoxButtons)MessageBoxButton.YesNoCancel);
        }
    }

}
