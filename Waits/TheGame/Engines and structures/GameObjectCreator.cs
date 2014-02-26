using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Waits
{
    class GameObjectCreator
    {
        private const int MinObjectsCount = 1;
        private const int NumberOfGameObjectsType = 5;

        private int maxRows = 15;
        private int maxCols = 15;

        public List<IRenderable> GameObjectList; // TODO: privet!!!

        public GameObjectCreator(int maxNumberOfObjects)
        {
            int objectSwitcer = 0;

            int[] listOfObjectsCount = new int[NumberOfGameObjectsType];

            for (int currentObject = 0; currentObject < NumberOfGameObjectsType; currentObject++)
            {
                listOfObjectsCount[currentObject] = maxNumberOfObjects;
            }

            GameObjectList = new List<IRenderable>();

            bool createOneMore = true;
            
            while (createOneMore)
            {
                int countOfObjectsToBeCreated = 0;

                switch (objectSwitcer % NumberOfGameObjectsType)
                {
                    case 0:
                        if (listOfObjectsCount[0] > 0)
                        {
                            GameObjectList.Add(new House("House " + objectSwitcer,
                                                          new MatrixCoords(GameObject.Randomiser.Next(maxRows),
                                                                           GameObject.Randomiser.Next(maxCols)),
                                                          GameObject.Randomiser.Next(Enum.GetNames(typeof(Song)).Length)));
                            listOfObjectsCount[0]--;
                            Console.WriteLine("Object Home Created!");
                        }
                        break;

                    case 1:
                        if (listOfObjectsCount[1] > 0)
                        {
                            GameObjectList.Add(new MarketPlace("Market Place " + objectSwitcer,
                                                                new MatrixCoords(GameObject.Randomiser.Next(maxRows),
                                                                                 GameObject.Randomiser.Next(maxCols))));
                            listOfObjectsCount[1]--;
                            Console.WriteLine("Object Market Place Created!");
                        }
                        break;
                    case 2:
                        if (listOfObjectsCount[2] > 0)
                        {
                            GameObjectList.Add(new Pub(new MatrixCoords(GameObject.Randomiser.Next(maxRows),
                                                                        GameObject.Randomiser.Next(maxCols))));
                            listOfObjectsCount[2]--;
                            Console.WriteLine("Object Pub Created!");
                        }
                        break;

                    case 3:
                        if (listOfObjectsCount[3] > 0)
                        {
                            GameObjectList.Add(new Tree(new MatrixCoords(GameObject.Randomiser.Next(maxRows),
                                                                         GameObject.Randomiser.Next(maxCols))));
                            listOfObjectsCount[3]--;
                            Console.WriteLine("Object Tree Created!");
                        }
                        break;

                    case 4:
                        if (listOfObjectsCount[4] > 0)
                        {
                            GameObjectList.Add(new Grandmother("Baba " + objectSwitcer, Sex.Female,
                                                                new MatrixCoords(GameObject.Randomiser.Next(maxRows),
                                                                                 GameObject.Randomiser.Next(maxCols))));
                            listOfObjectsCount[4]--;
                            Console.WriteLine("Object Baba Created!");
                        }
                        break;

                    default:
                        break;
                }

                


                foreach (var item in listOfObjectsCount)
                {
                    countOfObjectsToBeCreated += item;
                }


                Console.Write("Obj to be created: {0}", countOfObjectsToBeCreated); 
                
                createOneMore = countOfObjectsToBeCreated != 0;
                

                Console.Write("Obj switch: ");
                Console.WriteLine(objectSwitcer % NumberOfGameObjectsType);
                objectSwitcer++;

            }
            GameObjectList.Add(new TownHall(new MatrixCoords(GameObject.Randomiser.Next(maxRows), GameObject.Randomiser.Next(maxCols))));

        }
    }
}
