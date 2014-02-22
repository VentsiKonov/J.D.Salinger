using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial_1._0
{
    public class House : IRenderable
    {
        private const char HouseChar = '\u2591';
        public House(MatrixCoords position, int height, int width)
        {
            this.HouseImage = new char[height, width];
            this.Position = position;
        }

        public MatrixCoords Position { get; protected set; }
        public char[,] HouseImage { get; protected set; }
        public MatrixCoords GetTopLeftCoordOfPosition()
        {
            return this.Position;
        }

        public char[,] GetImage()
        {
            for (int row = 0; row < this.HouseImage.GetLength(0); row++)
            {
                for (int col = 0; col < this.HouseImage.GetLength(1); col++)
                {
                    this.HouseImage[row, col] = HouseChar;
                }
            }

            return this.HouseImage;
        }
    }
}
