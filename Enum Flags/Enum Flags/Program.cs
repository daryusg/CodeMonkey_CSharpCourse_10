namespace Enum_Flags
{
    //Enum Flags

    internal class Program
    {
        //[Flags]
        public enum Ability : byte //memory efficiency
        {
            None = 0 << 0, //0,
            Jump = 1 << 0, //1,
            Sprint = 1 << 1, //2,
            Shoot = 1 << 2, //4,
            Fly = 1 << 3, //8
            ShootAndFly = Shoot | Fly,
        }

        static void Main(string[] args)
        {
            Ability playerAbilities = Ability.Jump | Ability.Shoot;
            Console.WriteLine($"{nameof(playerAbilities)}: {playerAbilities}"); //playerAbilities: Jump, Shoot

            Console.WriteLine($"{nameof(playerAbilities)} can {Ability.Jump}?: {playerAbilities.HasFlag(Ability.Jump)}");
            //or
            Console.WriteLine($"{nameof(playerAbilities)} can {Ability.Jump}?: {(Ability.Jump & playerAbilities) == Ability.Jump}");

            /*
            with [Flags] attribute:
                playerAbilities: Jump, Shoot
                playerAbilities can Jump?: True
                playerAbilities can Jump?: True

            without [Flags] attribute:
                playerAbilities: 5
                playerAbilities can Jump?: True
                playerAbilities can Jump?: True
            */
        }
    }
}
