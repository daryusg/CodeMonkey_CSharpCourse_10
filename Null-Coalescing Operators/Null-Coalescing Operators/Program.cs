namespace Null_Coalescing_Operators
{
    //Null-Coalescing Operators
    internal class Program
    {
        private static string playerName;

        static void Main(string[] args)
        {
            //playerName = "Code Monkey";

            string defaultPlayerName = "DEFAULT";

            int playerNameLength;
            playerNameLength = GetStringLength(playerName ?? ""); //if left side of ?? is null then use right side of ??
            playerNameLength = GetStringLength(playerName ?? defaultPlayerName ?? ""); //7 ...and can be chained. tests for null left to right.
            //playerNameLength = GetStringLength(playerName ?? throw new Exception($"{nameof(playerName)} is null!")); //...and can run a statement eg if null throw an exception
            //or
            //if (playerName == null)
            //    playerNameLength = GetStringLength("");
            //else
            //    playerNameLength = GetStringLength(playerName);

            Console.WriteLine($"{nameof(playerNameLength)}: {playerNameLength}");

            Console.WriteLine();

            Player player = null;
            player ??= new(); //if player is null then create a new player

            Console.WriteLine($"{player}");
            //or
            //Console.WriteLine($"{player.ToString()}");

            Console.WriteLine();

            const string UNKNOWN_PLAYER = "Unknown Player";
            //player = null;
            Console.WriteLine(player?.GetPlayerName() ?? UNKNOWN_PLAYER); //if player is, or GetPlayerName() returns, null then display UNKNOWN_PLAYER

            Console.WriteLine();

            //int? i = 56; //works
            int? i = null; //works
            //int i = 56; //doesn't work
            int b = i ?? 20; //left side needs to be a nullable type
            Console.WriteLine($"{nameof(b)}: {b}");
        }

        private static int GetStringLength(string str)
        {
            return str.Length; //if str unassigned: Object reference not set to an instance of an object.
        }

        private class Player
        {
            private List<Player> playerTargetList;

            public void AddTargetList(Player targetPlayer)
            {
                playerTargetList ??= []; //if playerTargetList is null then create a new List<Player>
                playerTargetList.Add(targetPlayer);
            }

            public string GetPlayerName()
            {
                return "Testing";
                //return null;
            }
        }
    }
}
