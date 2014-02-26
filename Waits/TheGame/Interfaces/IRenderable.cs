using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public interface IRenderable
    {
        MatrixCoords Position { get; set; } //Is actually the coordinates of the top leftmost char of the object.
        MatrixCoords GetTopLeftCoordOfPosition(); //Used as initial position for rendering.
    }
}
