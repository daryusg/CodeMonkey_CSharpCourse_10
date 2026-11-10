namespace Generics
{
    //Generics

    internal class Program
    {
        static void Main(string[] args)
        {
            //MyList<int> myIntList = new();
            //myIntList.field = 5;
            //Console.WriteLine($"Default: {myIntList.Function_ReturnDefault()}");

            //MyList<bool> myBoolList = new();
            //myBoolList.field = true;
            //Console.WriteLine($"Default: {myBoolList.Function_ReturnDefault()}");

            TestFunction("5");
            TestFunction('a');
            TestFunction("This is a test");
            TestFunction(false);

            MyList<Player> myPlayer = new();
            TestFunction(myPlayer);
            Console.WriteLine($"Default: {myPlayer.Function_ReturnDefault()}");

            Inventory<Gold> goldInventory = new();
            Inventory<Wood> woodInventory = new();

            //goldInventory.Add(new Wood()); //CS1503 Argument 1: cannot convert from 'Generics.Program.Wood' to 'Generics.Program.Gold'
            goldInventory.Add(new Gold());
        }

        private class Gold
        {
        }

        private class Wood
        {
        }

        private class Inventory<T>
        {
            public void Add(T t)
            {
            }
        }

        private static void GetAttackWinner<TAttackable, TDefendable>(TAttackable attackable, TDefendable defendable) where TAttackable : IAttackable where TDefendable : IDefendable
        {
            attackable.GetAttackPoints();
            defendable.GetDefencePoints();

        }

        private interface IAttackable
        {
            public int GetAttackPoints();
        }

        private interface IDefendable
        {
            public int GetDefencePoints();
        }

        private class Player
        {

        }

        private static void TestFunction<T>(T t)
        //private static void TestFunction<T>(T t) where T : class
        {
            Console.WriteLine($"TestFunction (t): {t}");
            //Console.WriteLine($"TestFunction (default): {default}");
        }

        //private class MyList<T> where T : class //T must be a class
        //private class MyList<T, T2, TKey, TValue, TUnit>
        //private struct MyList<T>
        private class MyList<T> where T : class, new() //T must be a class with a parameterless constructor
                                                       //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
        {
            public T field;
            //public T2 field_T2;
            //public TKey field_TKey;
            //public TValue field_TValue;
            //public TUnit field_TUnit;

            public T Function_ReturnDefault()
            {
                //return null; //CS0403 Cannot convert null to type parameter 'T' because it could be a non-nullable value type. Consider using 'default(T)' instead.
                //return null; //can return null with: where T : class
                return new T();
                //return default;
            }
        }

        private interface MyInterface<T>
        {
            T MyFunction();
        }
    }

}
