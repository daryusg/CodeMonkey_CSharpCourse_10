using System.Numerics;

namespace Constants__readonly
{
    //Constants, readonly

    internal class Program
    {
        private const float PLAYER_SPEED = 5; //by nature, consts are static. they don't belong to the class and not the instance. they're set at compile time
                                              //private float PLAYER_SPEED = 5;

        //private const Player player = new(77); //CS0133 The expression being assigned to 'Program.player' must be constant.
        //constructing the new Player occurs at run time. consts must be set at compile time

        private readonly Player player = new(55); //once set, cannot be changed

        static void Main(string[] args)
        {
            int age;
            age = 5;
            age = 7;
            //Math.PI = 3; //CS0131 The left-hand side of an assignment must be a variable, property or indexer
            double x = Math.PI; //const double Math.PI

            float y = PLAYER_SPEED; //PLAYER_SPEED: inaccessible as private float. accessible as private const float

            //player = new Player(); //CS0120 An object reference is required for the non-static field, method, or property 'Program.player'
        }

        public class Player
        {
            private readonly int healthMax;

            public Player(int healthMax)
            {
                this.healthMax = healthMax;
            }
        }

        //WORKAROUND: static property
        public static Vector3 One
        {
            get => new Vector3(1.0f);
        }
    }
}
