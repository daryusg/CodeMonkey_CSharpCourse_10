namespace Records
{
    //Records

    //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record

    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new("Code", "Monkey");
            //person.FirstName = "asdf"; //CS8852 Init-only property or indexer 'Program.Person.FirstName' can only be assigned in an object initializer, or on 'this' or 'base' in an instance constructor or an 'init' accessor.
            Person person3 = new("Code", "Monkey");
            Console.WriteLine(person); //Person { FirstName = Code, LastName = Monkey }

            Console.WriteLine($"{nameof(person)} = {nameof(person3)}: {person == person3}"); //True. if this was a normal class, this would return false as they're different objects. but, similar to structs, it checks the value

            Person person2 = person with { LastName = "Gorilla" }; //Note: Non-Destructive Mutation
            Console.WriteLine(person2); //Person { FirstName = Code, LastName = Gorilla }

            Player player = new("Testing", 321);
            Console.WriteLine($"{nameof(player)}: {player}");
            Console.WriteLine($"{nameof(player)}: {player.PlayerName}");
            Unit unit = player;
            Console.WriteLine($"{nameof(unit)}: {unit}"); //displays same info as player, however,...
            //Console.WriteLine($"{nameof(unit)}: {unit.PlayerName}"); //CS1061 'Program.Unit' does not contain a definition for 'PlayerName' and no accessible extension method 'PlayerName' accepting a first argument of type 'Program.Unit' could be found (are you missing a using directive or an assembly reference?)
        }

        public record Person(string FirstName, string LastName); //1. underlying properties 2. immutable (get, no set) 3. must be initialised
        //public record class Person(string FirstName, string LastName); //longhand
        //public record struct Person(string FirstName, string LastName);

        //when kept immutable, Records eliminate multithreading issues

        //public record Person(string FirstName, string LastName) //however, i can make mutable...
        //{
        //    public string FirstName { get; set; } = FirstName;
        //}
        //or
        //public class Person
        //{
        //    public string FirstName { get; init; }
        //    public string LastName { get; init; }

        //    public Person(string firstName, string lastName)
        //    {
        //        FirstName = firstName;
        //        LastName = lastName;
        //    }
        //}

        public record Unit(float Speed);
        public record Player(string PlayerName, float Speed) : Unit(Speed);
    }
}
