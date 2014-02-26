using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public abstract class GameObject
    {
        static readonly Random random = new Random();
        public string Id { get; private set; }
        private const int IdLength = 128;
        private const string IdChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "abcdefghijklmnopqrstuvwxyz" + "0123456789_";
        private static HashSet<string> allObjectIds = new HashSet<string>();

        public string Name { get; protected set; }

        protected GameObject(string name = "")
        {
            this.Name = name;
            this.Id = GameObject.GenerateObjectId();
        }

        public static Random Randomiser
        {
            get
            {
                return random;
            }
        }

        public static string GenerateObjectId()
        {

            StringBuilder resultBuilder = new StringBuilder();
            string result;

            do
            {
                for (int i = 0; i < GameObject.IdLength; i++)
                {
                    resultBuilder.Append(IdChars[random.Next(0, GameObject.IdChars.Length)]);
                }

                result = resultBuilder.ToString();
            }
            while (allObjectIds.Contains(result));

            return result;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Id.Equals((obj as GameObject).Id);
        }
    }
}
