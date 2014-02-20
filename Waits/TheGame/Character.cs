using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    abstract class Character
    {
        private string name;
        private Sex sex;
        private Inventory inventory;

        public Character(string name, Sex sex)
        {
            this.Name = name;
            this.sex = sex;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; } //TODO name restrictions
        }

        public Sex Sex
        {
            get { return this.sex; }
        }
    }
}
