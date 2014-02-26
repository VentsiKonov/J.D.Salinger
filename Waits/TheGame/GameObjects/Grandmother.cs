using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public class Grandmother : Character
    {
        public const int NumberOfItems = 2;

        public override void Move(MatrixCoords changeWith)
        {
            throw new NotImplementedException();
        }

        public Grandmother(string name, Sex sex, MatrixCoords position) 
            : base(name, sex, position)
        {
            Random randomSong = new Random();
            randomSong.Next(0, Enum.GetNames(typeof(Song)).Length);
        }

        public Song GetSong
        {
            get 
            {
                Random randomSong = new Random();
                return (Song)randomSong.Next(0, Enum.GetNames(typeof(Song)).Length);
            }
            private set;
        }

        public int WantsSomething()
        {
            Random randomSomething = new Random();
            return randomSomething.Next(0, NumberOfItems + 1);
        }
    }
}
