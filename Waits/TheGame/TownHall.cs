using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    class TownHall : Building, IRenderable
    {
        private const char TownHallChar = '\u2593';
        public TownHall(MatrixCoords position, int height, int width)
            : base (position, height, width)
        { 
        }

        public override char[,] GetImage()
        {
            for (int row = 0; row < this.BuildingImage.GetLength(0); row++)
            {
                for (int col = 0; col < this.BuildingImage.GetLength(1); col++)
                {
                    this.BuildingImage[row, col] = TownHallChar;
                }
            }

            return this.BuildingImage;
        }
    }
}
