using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public class Grandmother : Character
    {

        public override void Move(MatrixCoords changeWith)
        {
            throw new NotImplementedException();
        }

        public Grandmother(string name, Sex sex, MatrixCoords position)
            : base(name, sex, position)
        {
            // empty
        }
    }
}
