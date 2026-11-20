namespace @typeof; //reserved keyword caused problems. chatgpt recommended changing the name to eg TypeOfTutorial (or @ prefix):
/*
Code	Description
CS1513	} expected
CS1514	{ expected
CS1001	Identifier expected
*/
internal class Program
{
    //typeof

    static void Main(string[] args)
    {
        //typeof(Player) //typeof returns System.Type.
        //Note: use whenever a parameter of Type type is required.

        Player player = new();
        Type type1 = player.GetType(); //returns same as: typeof(Player)
        Type type2 = typeof(Player);
        Console.WriteLine($"type1: {type1}");
        Console.WriteLine($"type2: {type2}");
    }

    public class Player
    {

    }
}
