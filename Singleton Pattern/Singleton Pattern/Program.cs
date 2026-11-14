namespace Singleton_Pattern
{
    //Singleton Pattern

    //The (GameManager) class is private so no matter how many times the instance is used, only one instance created.
    //Usage in Unity may vary.
    //Singleton's are, by definition, global data. Overuse results in a ton of dependencies. Ideally the code should be as decoupled as possible. Problematic with multithreaded code.
    //ToDo: Investigate further in the paid version.

    internal class Program
    {
        static void Main(string[] args)
        {
            //new GameManager(); //CS0122 'Program.GameManager.GameManager()' is inaccessible due to its protection level
            Console.WriteLine($"{GameManager.Instance}");
            GameManager.Instance.TestFunction();
        }

        public class GameManager
        {
            private static GameManager instance;
            public static GameManager Instance
            {
                get
                {
                    if (instance == null)
                        instance = new GameManager();
                    return instance;
                }
                //private set unneeded as can only be set in the get
                //{
                //    instance = value;
                //}
            }

            private GameManager()
            {

            }
            //or
            //public GameManager()
            //{
            //    if (instance == null)
            //        instance = this;
            //}

            public void TestFunction()
            {
                //...
            }
        }
    }
}
