using System.Collections;

namespace IEnumerable__yield_return
{
    //IEnumerable, yield_return

    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = new();
            PlayerStats playerStats = new();
            foreach(Stat stat in playerStats)
            {
                //Console.WriteLine($"name: {stat.name} value: {stat.value}");
                Console.WriteLine(stat); //using Stat's ToString override
            }
        }
        public class PlayerStats : IEnumerable<Stat> //<ctrl>. Implement interface
        {
            public Stat dex = new Stat {name = "Dexterity", value = 12};
            public Stat str = new() { name = "Strength", value = 28 };
            public Stat wis = new() { name = "Wisdom", value = 35 };

            public IEnumerator<Stat> GetEnumerator()
            {
                //note: for dynamic lists
                return new PlayerStatEnumerator(this);

                //note: (shortcut) for static lists
                //yield return dex; //1st time
                //yield return str; //2nd time
                //yield return wis; //3rd time
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            //for dynamic lists
            public class PlayerStatEnumerator : IEnumerator<Stat> //<ctrl>. Implement interface
            {
                private PlayerStats playerStats;
                int index;

                public PlayerStatEnumerator(PlayerStats playerStats)
                {
                    this.playerStats = playerStats;
                    index = -1; //the foreach calls MoveNext first
                }

                //public object Current => throw new NotImplementedException();
                public Stat Current
                {
                    get
                    {
                        switch (index)
                        {
                            default:
                            case 0: return playerStats.dex;
                            case 1: return playerStats.str;
                            case 2: return playerStats.wis;
                        }
                    }
                }

                //Stat IEnumerator<Stat>.Current => throw new NotImplementedException();
                object IEnumerator.Current => Current;

                public void Dispose()
                {
                    //throw new NotImplementedException();
                }

                public bool MoveNext()
                {
                    index++;
                    if (index > 2)
                        index = -1;
                    return index != -1;
                }

                public void Reset()
                {
                    index = -1;
                }
            }
        }

        public class Stat
        {
            public string name;
            public int value;

            public override string ToString()
            {
                return $"name: {name}, value: {value}";
            }
        }
    }
}
