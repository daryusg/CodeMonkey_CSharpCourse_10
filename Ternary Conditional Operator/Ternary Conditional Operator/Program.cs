namespace Ternary_Conditional_Operator
{
    //Ternary Conditional Operator

    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new();
            player.health = 0;

            Console.WriteLine(player.GetPlayerStateString());
        }

        private class Player
        {
            const string ALIVE = "Alive";
            const string DEAD = "Dead";

            public int health;

            public string GetPlayerStateString()
            {
                int i = health > 0 ? HandlePlayerLogic() : DoNothing();

                //if (health > 0)
                //    return "Alive";
                //else
                //    return "Dead";
                return health > 0 ? ALIVE : DEAD;
            }

            private int HandlePlayerLogic()
            {
                return 0;
            }

            private int DoNothing()
            {
                return 0;
            }
        }
    }
}
