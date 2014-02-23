using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    class Tree : IRenderable
    {
        public Tree(MatrixCoords position)
        {
            this.Position = position;
            this.TreeChar = (char)64;
        }
        public MatrixCoords Position { get; private set; }
        public char TreeChar { get; private set; }


        public MatrixCoords GetTopLeftCoordOfPosition()
        {
             return this.Position;
        }

        public char[,] GetImage()
        {
            return new char[,] {{this.TreeChar}};
        }
    }
}
