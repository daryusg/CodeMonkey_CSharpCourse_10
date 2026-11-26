namespace ref__out__in
{
    //ref, out, in

    internal class Program
    {
        public enum State
        {
            Idle,
            Patrolling,
            Attacking,
        }

        static void Main(string[] args)
        {
            Unit unit = new();
            //int healthAmt = 45;
            //State state = unit.GetUnitState(healthAmt);
            //int healthAmt;
            //State state = unit.GetUnitState(out healthAmt); //can pass in an uninitialised variable. the out keyword forces initialisation prior to the function's return.
            //Console.WriteLine($"{nameof(healthAmt)}: {healthAmt}");

            //unit.GetUnitState(out State state, out int healthAmt, out string name);

            State state = State.Idle;
            //unit.GetUnitState(ref state, out int healthAmt, out string name);
            //unit.GetUnitState(ref state, out _, out string name); //_ = discard
            int healthAmt = 66;
            unit.GetUnitState(ref state, in healthAmt, out string name); //in passes it in as a readonly reference. use ref to enable modification


            Console.WriteLine($"{nameof(state)}: {state}, {nameof(healthAmt)}: {healthAmt}, {nameof(name)}: {name}");
        }

        public class Unit
        {
            public void Heal(ref int healthAmount, int healAmount)
            {
                healthAmount += healAmount;
            }

            public struct HugeStruct { }
            public void DoSomething(in HugeStruct hugeStruct) { } //using in means that no copy is created.

            public void GetUnitState(ref State state, in int healthAmount, out string name) //note: in params can't be set
            {
                name = "Code Monkey";
                bool b = true;
                if (b)
                {
                    state = State.Idle;
                    //healthAmount = 54; //CS8331 Cannot assign to variable 'healthAmount' or use it as the right hand side of a ref assignment because it is a readonly variable
                    return;
                }
                else
                {
                    //healthAmount = 45;
                    return;
                }
            }

            //public void GetUnitState(ref State state, out int healthAmount, out string name) //note: the ref param has already been initialised so doesn't need to be set prior to return
            //{
            //    name = "Code Monkey";
            //    bool b = true;
            //    if (b)
            //    {
            //        state = State.Idle;
            //        healthAmount = 54;
            //        return;
            //    }
            //    else
            //    {
            //        healthAmount = 45;
            //        return;
            //    }
            //}

            //public void GetUnitState(out State state, out int healthAmount, out string name)
            //{
            //    state = State.Idle;
            //    healthAmount = 56;
            //    name = "Code Monkey";
            //}

            //public State GetUnitState(out int healthAmount) //a copy would usually be passed in but out passes a reference
            //{
            //    healthAmount = 99;
            //    return State.Idle;
            //}

            //public UnitData GetUnitState()
            //{
            //    return new UnitData
            //    {
            //        state = State.Idle,
            //        healthAmount = 56,
            //        name = "Code Monkey"
            //    };
            //}

            //public class UnitData
            //{
            //    public State state;
            //    public int healthAmount;
            //    public string name;
            //}
        }
    }
}
