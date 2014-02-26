using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public class House : Building, IRenderable 
    {

        public House(string name, MatrixCoords position, int songRequest)
            : base(name, position)
        {
            this.SongRequest = (Song)songRequest;
        }

        public List<Item> MyProperty { get; set; }
        public Song SongRequest { get; set; } //Song from the enum.
    }
}
