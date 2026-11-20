//namespace @nameof; //when nameof used in the code, it errored ('nameof' is a namespace but is used like a variable) so i added  _
namespace nameof_;

//nameof

internal class Program
{
    static void Main(string[] args)
    {
        //nameof - use to avoid using strings
        string playerClassName = "Player";
        Console.WriteLine($"playerClassName (\"Player\"): {playerClassName}");

        playerClassName = nameof(Player);
        Console.WriteLine($"playerClassName (nameof({nameof(Player)})): {playerClassName}");
        Console.WriteLine($"playerClassName (nameof({nameof(Player.speed)})): {nameof(Player.speed)}"); //note: displays speed
        Console.WriteLine($"playerClassName (nameof({nameof(Player.IsGrounded)})): {nameof(Player.IsGrounded)}"); //note: displays IsGrounded

        Player player = new();
        player.SetSpeed(0);

        Console.WriteLine($"{nameof(player)}.GetType().Name: {player.GetType().Name}");
        //Note: speed to speed_test (see SetSpeed), Player to Player_test, and player to player_test tested ok
        //GetType is runtime
        //nameof is compiletime
    }

    public class Player //if i rename then all the relevant nameof's will be renamed
    {
        public int speed;

        public bool IsGrounded()
        {
            return true;
        }

        public void SetSpeed(int speed)
        {
            if (speed == 0) //can be used for debugging
                Console.WriteLine($"ERROR: {nameof(speed)} must not be 0");
            this.speed = speed;
        }
    }
}
