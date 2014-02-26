using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{


    public abstract class Character : GameObject, IRenderable, IMovable
    {
        private string name;
        private Sex sex;
        public Character(string name, Sex sex, MatrixCoords position)
        {
            this.Name = name;
            this.sex = sex;
            this.Position = position;
            this.CommitToDrawer();
        }

        public Sex Sex { get; set; }
        public MatrixCoords Position { get; set; }
        public char PlayerChar { get; protected set; }
        public MatrixCoords GetTopLeftCoordOfPosition()
        {
            return this.Position;
        }


        public abstract void Move(MatrixCoords newCoordinates);



        public void CommitToDrawer()
        {
            GridDrawer.objectList.Add(this);
        }
    }
}
