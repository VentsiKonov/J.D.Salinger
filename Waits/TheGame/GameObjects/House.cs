using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public class House : Building, IRenderable 
    {
        private const char HouseChar = '\u2593';
        public House(MatrixCoords position, int height, int width, int songRequest)
            : base(position, height, width)
        {
            this.SongRequest = songRequest;
        }

        public List<Item> MyProperty { get; set; }
        public int SongRequest { get; set; } //Song from the enum.
    }
}
