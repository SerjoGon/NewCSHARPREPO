using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_7_RaceGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<RaceCar> raceCars = new List<RaceCar>() { 
                new RaceCar(0,160,20,true),
                new RaceCar(0,300,5,true),
                new RaceCar(0,200,15,true),
                new RaceCar(0,220,10,true)
            };
        }
    }
    abstract class Vehicle
    {
        public abstract UInt32 Speed { get; set; }
        public abstract UInt32 MaxSpeed { get; set; }
        public abstract UInt32 Boost{ get; set; }
        public abstract bool Start { get; set; }
        public abstract void Movement();
    }
    class RaceCar:Vehicle
    {
        public override UInt32 Speed { get; set; }
        public override UInt32 MaxSpeed { get; set; }
        public override UInt32 Boost { get; set; }
        public override bool Start { get; set; }

        public RaceCar(uint speed, uint maxSpeed, uint boost, bool start)
        {
            Speed = speed;
            MaxSpeed = maxSpeed;
            Boost = boost;
            Start = start;
        }
        public RaceCar()
        {
            Speed = 0;
            MaxSpeed = 150;
            Boost = 5;
            Start = true;
        }

        public override void Movement()
        {
            if(Start == true)
            {
                for (Speed = 0; Speed <= MaxSpeed; Speed+=Boost) ;
            }
        }

    }
    class Race
    {
        public List<RaceCar> _cars { get; set; }
        public uint _track { get; set; }

        public Race(List<RaceCar> cars, uint track)
        {
            _cars = cars;
            _track = track;
        }
        public void racing_race()
        {
            for(int i = 0;)
        }
    }
}
