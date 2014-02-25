using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public abstract class Character
    {
        private string name;
        private Sex sex;
        private Inventory inventory;

        public Character(string name, Sex sex, MatrixCoords position)
        {
            this.Name = name;
            this.sex = sex;
            this.Position = position;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; } //TODO name restrictions
        }

        public Sex Sex
        {
            get { return this.sex; }
        }

        public MatrixCoords Position { get; set; }
        public char PlayerChar { get; protected set; }
        public MatrixCoords GetTopLeftCoordOfPosition()
        {
            return this.Position;
        }

        public char[,] GetImage()
        {
            return new char[,] { { this.PlayerChar } };
        }
    }
}
