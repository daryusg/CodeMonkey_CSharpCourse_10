using System.Runtime.CompilerServices;

namespace Class_Indexer
{
    //Class Indexer

    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerStats playerStats = new()
            {
                strAmount = 12,
                dexAmount = 36,
                wisAmount = 56,
            };
            int strength = playerStats[0]; //prior to addiing internal int this[int index] to the class: CS0021 Cannot apply indexing with [] to an expression of type 'PlayerStats'
            Console.WriteLine($"{nameof(strength)}: {strength}");

            playerStats[0] = 99;
            Console.WriteLine($"{nameof(playerStats)}[0]: {playerStats[0]}");

            playerStats[PlayerStats.Stat.Dex] = 88;
            Console.WriteLine($"{nameof(playerStats)}[{nameof(PlayerStats.Stat.Dex)}]: {playerStats[PlayerStats.Stat.Dex]}");
        }
    }

    internal class PlayerStats
    {
        internal enum Stat
        {
            Str,
            Dex,
            Wis,
        }

        internal int strAmount;
        internal int dexAmount;
        internal int wisAmount;

        internal int this[Stat stat]
        //or
        //internal int this[Stat stat, int index] multidimensionally (??)
        {
            get
            {
                switch (stat)
                {
                    case Stat.Str: return strAmount;
                    case Stat.Dex: return dexAmount;
                    case Stat.Wis: return wisAmount;
                    default: throw new IndexOutOfRangeException();
                }
            }

            set
            {
                switch (stat)
                {
                    case Stat.Str: strAmount = value; break;
                    case Stat.Dex: dexAmount = value; break;
                    case Stat.Wis: wisAmount = value; break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

        //internal int this[int index]
        //{
        //    get
        //    {
        //        switch (index)
        //        {
        //            case 0: return strAmount;
        //            case 1: return dexAmount;
        //            case 2: return wisAmount;
        //            default: throw new IndexOutOfRangeException();
        //        }
        //    }

        //    set
        //    {
        //        switch (index)
        //        {
        //            case 0: strAmount = value; break;
        //            case 1: dexAmount = value; break;
        //            case 2: wisAmount = value; break;
        //            default: throw new IndexOutOfRangeException();
        //        }
        //    }
        //}
    }
}
