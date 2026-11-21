using System.Diagnostics;
using System.Reflection;

namespace Null_Conditional_Operators
{
    //Null Conditional Operators

    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = null;
            Console.WriteLine(player1?.GetPlayerName()); //will not run GetPlayerName()
            Console.WriteLine("Test 1 speed: " + player1?.target?.speed);

            Player player2 = new("Code Monkey");
            Console.WriteLine(player2?.GetPlayerName()); //runs GetPlayerName()
            Console.WriteLine(player2?.playerName); //gets playerName()
            Console.WriteLine("Test 2 speed: " + player2?.target?.speed);

            Console.WriteLine();

            //List<string> playerNameList = new();
            //Console.WriteLine(playerNameList?[0]); //Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')

            //List<string> playerNameList = null; ;
            //Console.WriteLine(playerNameList?[0]);

            List<string> playerNameList = new() { "Code Monkey" };
            Console.WriteLine(playerNameList?[0]);

            Console.WriteLine();

            //List<Player> playerList = [null];
            List<Player> playerList = [new Player("Testing")];
            playerList?[0]?.TakeDamage();

            //int i = 5;
            //i?.CompareTo(); //CS8600 Operator '?' cannot be applied to operand of type 'int'

            int? i = 5;
            Console.WriteLine(i?.CompareTo(8));
        }

        internal class Player
        {
            public Player(string playerName) => PlayerName = playerName;

            //public Unit target;
            public Unit target = new();

            public string playerName = "Testing";
            public string GetPlayerName()
            {
                return PlayerName;
            }

            public string PlayerName { get; set; }

            public void TakeDamage()
            {
                string methodName = MethodBase.GetCurrentMethod().Name;
                Console.WriteLine(methodName);
            }
        }

        internal class Unit
        {
            public int speed = 543;
        }
    }
}
