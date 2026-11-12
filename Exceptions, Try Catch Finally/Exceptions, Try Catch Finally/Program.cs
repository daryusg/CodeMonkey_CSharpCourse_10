namespace Exceptions__Try_Catch_Finally
{
    //Exceptions, Try Catch Finally

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a = 0;
                //int b = 1 / a;
                Player player = new();
                player.TestFunction();

                Console.WriteLine("Hi there 1!");
            }
            //catch (DivideByZeroException dbze1)
            //{
            //    Console.WriteLine($"DivideByZeroException (1): {dbze1.Message} {dbze1.StackTrace}");
            //    throw; //throw this back up the exception chain
            //}
            catch (Exception dbze2) when (dbze2 is DivideByZeroException)
            {
                Console.WriteLine($"DivideByZeroException (2): {dbze2.Message} {dbze2.StackTrace}");
                return;
            }
            catch (Exception ex) //Exception is a catch-all so must be last in the catch list
            {
                Console.WriteLine($"Exception: {ex.Message} {ex.StackTrace}");
            }
            finally
            {
                //always runs, catch or no catch
                //try...finally also works
                Console.WriteLine("Hi there 2!");
            }
            
        }

        public class Player
        {
            public class InvalidPlayerNameException : Exception
            {

            }
            public void TestFunction()
            {
                //throw new Exception("Player exception");
                throw new InvalidPlayerNameException();
            }
        }
    }
}
