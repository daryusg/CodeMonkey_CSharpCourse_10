namespace Expression_bodied_Members
{
    //Expression-bodied Members

    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new("Test1");
            Console.WriteLine($"Player Name: {player1.GetPlayerName()}");
            player1.SetPlayerName("Test2");
            Console.WriteLine($"Player Name: {player1.GetPlayerName()}");
            player1.SetPlayerName("Test3");
            Console.WriteLine($"Player Name: {player1.PlayerName}");

            Player player2 = new("Test4");
            Console.WriteLine($"Player Name: {player2.PlayerName}");
        }
    }

    internal class Player
    {
        private string playerName;
        public string GetPlayerName() => playerName; //can only work with a single instruction
        //or
        //public string GetPlayerName()
        //{
        //    return playerName;
        //}
        //Note: can't use a codeblock with this syntax ie can only work with a single instruction
        //public string GetPlayerName() => {
        //    playerName;
        //}
        public void SetPlayerName(string playerName) => this.playerName = playerName; //again, can only work with a single instruction
        //or
        //public void SetPlayerName(string playerName)
        //{
        //    this.playerName = playerName;
        //}

        //Properties
        public string PlayerName
        {
            get => playerName;
            set => playerName = value;
        }

        //Constructors
        public Player(string playerName) => this.playerName = playerName; //again, can only work with a single instruction
        //or
        //public Player(string playerName) 
        //{
        //    this.playerName = playerName;
        //}
        
        //public Player(string playerName, int age) => this.playerName = playerName; //Note: won't work here as can only work with a single instruction
    }
}