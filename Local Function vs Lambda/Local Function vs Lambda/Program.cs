namespace Local_Function_vs_Lambda
{
    //Local Function vs Lambda

    internal class Program
    {
        static void Main(string[] args)
        {
            //myAction("World"); //CS0841 cannot use local variable 'myAction' before it is declared
            Print("World");
            //Note: local functions are defined at compile time whereas lambdas are defined at runtime
            //lambdas are created realtime whereas funcions are created compile time. lambdas are created in memory each traversal so are less efficient
            Action<string> myAction = (message) =>
            {
                Console.WriteLine($"Hello from Lambda!: {message}");
            };

            void Print(string message)
            {
                Console.WriteLine($"Hello from Local Function!: {message}");
            }

            Action<string> myAction2 = Print;

            myAction("World");
            myAction2("Universe");

        }
    }
}
