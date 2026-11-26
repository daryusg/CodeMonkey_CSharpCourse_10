namespace Data_Boxing
{
    //Data Boxing
    //Converting to an object type (and back (unboxing)). It's done via the object type. This is possible because object is the base type for every C# type.
    //object (C# type): The universal base type from which all C# types derive.

    internal class Program
    {
        private static event EventHandler OnSomethingHappened;

        static void Main(string[] args)
        {
            int i = 56; //value type, on the stack, fast
            object o = i; //(<---this copies the value type onto the heap and then references that entry) reference type, on the heap, slow (boxed)
            //modifying o will not modify i and visa versa modifying i will not modify o. 
            i = (int)o; //unboxed
            //try...catch below
            bool b = (bool)o; //no compiler error, however, runtime error: System.InvalidCastException: 'Unable to cast object of type 'System.Int32' to type 'System.Boolean'.'

            List<object> objectList = new() //ill-advised
            {
                12,
                false,
                "Code Monkey",
            };

            OnSomethingHappened += Program_OnSomethingHappened;
        }

        private static void Program_OnSomethingHappened(object? sender, EventArgs e)
        {
            Console.WriteLine("Program_OnSomethingHappened");
        }
    }
}
