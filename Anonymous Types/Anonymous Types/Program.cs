namespace Anonymous_Types
{
    //Anonymous Types

    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new()
            {
                playerName = "Code Monkey",
                id = 54
            };
            //anonymous types are read-only
            var playerData1_a = new { Name = "Code Monkey", id = 1 };
            Console.WriteLine($"{nameof(playerData1_a)}: {playerData1_a}");
            //playerData.Name = "test"; //CS0200 Property or indexer '<anonymous type: string Name, int id>.Name' cannot be assigned to -- it is read only
            //Name is a property with just a get defined (see PlayerData class below)

            Console.WriteLine($"{nameof(playerData1_a)}.GetType(): {playerData1_a.GetType()}"); //playerData.GetType(): <>f__AnonymousType0`2[System.String,System.Int32]

            var message = new { Message = "Hello World!" };
            var playerData1_b = new { Name = "Code Monkey", id = 2, Message = message };
            Console.WriteLine($"{nameof(playerData1_b)}.Message: {playerData1_b.Message}");
            //or
            var playerData1_c = new { Name = "Code Monkey", id = 3, message };
            Console.WriteLine($"{nameof(playerData1_c)}.Message: {playerData1_c.message}");

            var playerData2 = playerData1_c with { Name = "Iron Man" };
            Console.WriteLine($"{nameof(playerData2)}: {playerData2}");

            var playerDataArray1 = new[]
            {
                new { Name = "Code Monkey", Team = "Red"},
                new { Name = "Iron Man", Team = "Blue"},
                new { Name = "Black Widow", Team = "Red"},
                new { Name = "Captain America", Team = "Blue"},
            }; //each entry must have the same number of components and be in the same order

            var playerDataArray2 = new object[]
            {
                new { Name = "Code Monkey", Team = "Red"},
                new { Name = "Iron Man", Team = "Blue"},
                new { Name = "Black Widow", Team = "Red"},
                new { Team = "Blue", Name = "Captain America"},
            }; //fixes CS0826 No best type found for implicitly-typed array

            var redTeamArray = playerDataArray1.Where(playerData => playerData.Team == "Red").Select(playerData => new {playerData.Name});
            foreach(var redTeam in redTeamArray)
                Console.WriteLine($"{nameof(redTeam)}: {redTeam}");
        }

        public class Player
        {
            public string playerName;
            public int id;
        }

        //in the background, the anonymous type is doing something like...
        public class PlayerData
        {
            public string Name { get; }
            public int Id { get; }
        }
    }
}
