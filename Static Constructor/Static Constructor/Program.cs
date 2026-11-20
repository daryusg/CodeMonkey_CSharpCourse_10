namespace Static_Constructor
{
    //Static Constructor

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{Player.i}");
            Player.TestFunction();
            Player player = new();

            Console.WriteLine($"{player.j}");
        }

        internal class Player
        {
            static Player() //1. runs automatically an object is used (static) or created, 2. before the object is contructed, 3. no access modifier (public, private,...)
                            //4. has the same name as the class, 5. no parameters, 6. cannot be run manually, 7. only runs once, 8. thread safe
            {
                Console.WriteLine("Player static constructor");
                i = 56; //overrides set/default value
            }

            public static int i = 67;

            public static void TestFunction()
            {
                Console.WriteLine("TestFunction");
            }
            //------------------------------------------------------------------
            public int j = 12;

            public Player()
            {
                Console.WriteLine("Player constructor");
                j = 13; //overrides set/default value
            }
        }
    }
}
