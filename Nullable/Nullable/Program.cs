namespace Nullable
{
    //Nullable

    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = null;
            //int i = null; //CS0037 Cannot convert null to 'int' because it is a non-nullable value type

            //Data data = null; //CS0037 Cannot convert null to 'Data' because it is a non-nullable value type
            Data? data = null;

            //int? i = null;
            //or
            Nullable<int> i = null;

            Console.WriteLine($"{nameof(i)}: {i.GetValueOrDefault(12)}");
            int attackDamage;
            //if (i != null)
            //or
            if (i.HasValue)
                //attackDamage = (int)i;
                //or
                attackDamage = i.Value;

            int? a = null;
            int b = a ?? 56;
        }
    }

    internal struct Data
    {

    }

    internal class Player
    {
        //public int attackDamage = 56;
        public int? attackDamage = null; //ie if the player has no weapon

        public void Setup(int? startingHealth = null) //allows eg keeping of existing health
        {

        }
    }
}
