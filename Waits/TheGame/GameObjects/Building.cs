using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public abstract class Building : GameObject, IRenderable
    {

        public Building(string name, MatrixCoords position)
            : base(name)
        {
            this.Position = position;
        }

        public MatrixCoords Position { get; set; }
        public MatrixCoords GetTopLeftCoordOfPosition()
        {
            return this.Position;
        }

        
    }
}
