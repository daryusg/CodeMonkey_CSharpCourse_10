namespace default_;

//default

internal class Program
{
    static void Main(string[] args)
    {
        int i = 1;

        switch(i)
        {
            default:
            case 1:
                break;

            case 2:
                break;
        }
        //Note: returns the 0 equivalent
        //value types always return a value.
        //reference types always return null.
        Console.WriteLine(default(int)); //0
        Console.WriteLine(default(bool)); //false
        Console.WriteLine(default(Player)); //nothing (null)

        float f = default;
        Console.WriteLine(f); //0

        int x = default;
        int y = default(int);
        Console.WriteLine($"{nameof(x)}: {x}, {nameof(y)}: {y}");

        Console.WriteLine(f);

        Console.WriteLine(new Box<int>().GetDefault()); //0
        Console.WriteLine(new Box<bool>().GetDefault()); //false
        Console.WriteLine(new Box<Player>().GetDefault()); //nothing (null)
    }

    public class Box<T>
    {
        public T GetDefault()
        {
            return default; //shorthand
            //or
            //return default(T); //longhand
        }
    }

    public class Player
    {
        public int speed;

        public bool IsGrounded()
        {
            return true;
        }

        public void SetSpeed(out bool isSet, int speed = default) //isSet must be returned and be listed prior to optional params 
        {
            this.speed = speed;
            isSet = default;
        }
    }
}
