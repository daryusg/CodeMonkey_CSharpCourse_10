using Layer1_1;
using Layer1_2;
using System.Text.Json.Serialization;
using Player_Main = Layer1_1.Layer2_1.Layer3_1.Player; //alias

namespace Namespaces
{
    //Namespaces

    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1;
            Layer1_1.Layer2_1.Player player2;

            Player_Main player_Main = new();
            //Enemy enemy; //CS0104 'Enemy' is an ambiguous reference between 'Layer1_1.Enemy' and 'Layer1_2.Enemy'
            Layer1_1.Enemy enemy1;
            Layer1_2.Enemy enemy2;

            string charType = "Player";
            Console.WriteLine($"Enter {charType} name: ");
            player_Main.name = (string)GetValue(player_Main.name);

            Console.WriteLine($"Enter {charType} strength: ");
            player_Main.strength = (int)GetValue(player_Main.strength);

            Console.WriteLine($"{charType} {player_Main}");
        }


        static object GetValue(object obj)
        {
            var ret = obj;
            bool objIsNumber = Type.GetTypeCode(obj.GetType()) switch //chatgpt
            {
                TypeCode.Byte => true,
                TypeCode.SByte => true,
                TypeCode.UInt16 => true,
                TypeCode.UInt32 => true,
                TypeCode.UInt64 => true,
                TypeCode.Int16 => true,
                TypeCode.Int32 => true,
                TypeCode.Int64 => true,
                TypeCode.Single => true,
                TypeCode.Double => true,
                TypeCode.Decimal => true,
                _ => false
            };

            bool validEntry = false;
            do
            {
                try
                {
                    ret = Console.ReadLine(); //get value from user
                    string strTemp = ret?.ToString().Trim(); //remove leading and trailing spaces
                    if (!String.IsNullOrEmpty(strTemp))
                    {
                        ret = strTemp;

                        if (objIsNumber)
                            ret = Convert.ChangeType(strTemp, obj.GetType()); //convert to the same number type (chatgpt)

                        validEntry = true;
                    }
                }
                catch { }
            }
            while (!validEntry);

            return ret;
        }
    }

    public class Player
    {
        public string name;
        public int strength;
    }
}

namespace Layer1_1
{
    public class Player
    {
    }

    public class Enemy
    {
    }

    namespace Layer2_1
    {
        public class Player
        {
        }

        namespace Layer3_1
        {
            public class Player
            {
                public string name = "";
                public int strength = 0;

                public Player()
                {
                }

                public Player(string name, int strength)
                {
                    this.name = name;
                    this.strength = strength;
                }

                public override string ToString() 
                {
                    return $"Name: {name} (Strength: {strength})";
                }
            }
        }
    }

    namespace Layer2_2
    {
        public class Enemy
        {
        }

        namespace Layer3_1
        {
            public class Player
            {
            }
        }
    }
}

namespace Layer1_2
{
    public class Player
    {
    }

    public class Enemy
    {
    }
}