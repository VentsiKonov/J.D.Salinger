using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public class Building : IRenderable
    {
        private const char BuildingChar = '\u2591';
        public Building(MatrixCoords position, int height, int width)
        {
            this.BuildingImage = new char[height, width];
            this.Position = position;
        }

        public MatrixCoords Position { get; protected set; }
        public char[,] BuildingImage { get; protected set; }
        public MatrixCoords GetTopLeftCoordOfPosition()
        {
            return this.Position;
        }

        public virtual char[,] GetImage()
        {
            for (int row = 0; row < this.BuildingImage.GetLength(0); row++)
            {
                for (int col = 0; col < this.BuildingImage.GetLength(1); col++)
                {
                    this.BuildingImage[row, col] = BuildingChar;
                }
            }

            return this.BuildingImage;
        }
    }
}
