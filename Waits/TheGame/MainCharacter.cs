using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    class MainCharacter : Character, IRenderable
    {
        private const char MainChar = (char)38;
        public MainCharacter(string name, Sex sex, MatrixCoords position)
            : base(name, sex, position)
        {
            this.PlayerChar = MainChar;
        }

    }
}
