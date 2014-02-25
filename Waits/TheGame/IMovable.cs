using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public interface IMovable
    {
        MatrixCoords Move(MatrixCoords changeWith);
    }
}
