using CustomExtensions;

namespace Function_Extensions
{
    //Function Extensions
    //Note: code monkey did this lesson in unity so i'm using the ms doc...
    //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-implement-and-call-a-custom-extension-method

    //Beginning with C# 14, there are two syntaxes you can use to define extension methods

    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "The quick brown fox jumped over the lazy dog.";
            // Call the method as if it were an
            // instance method on the type. Note that the first
            // parameter is not specified by the calling code.
            int i = s.WordCount();
            System.Console.WriteLine($"Word count of s is {i}");
        }
    }
}

namespace CustomExtensions
{
    // Extension methods must be defined in a static class.
    public static class StringExtension
    {
        //before C# 14
        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type to be extended.

        //public static int WordCount(this string str)
        //{
        //    return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        //}




        //C# 14+
        extension(string str)
        {
            // This is the extension member.
            // The `str` parameter is declared on the extension declaration.
            public int WordCount()
            {
                //string[] strArray = str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries);
                //Console.Write(string.Join(", ", strArray));
                //Console.WriteLine();

                //for (int i = 0; i < strArray.Length; i++)
                //    Console.Write($"({i + 1}) {strArray[i]} ");
                //Console.WriteLine();

                //return strArray.Length;

                return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
            }
        }
    }
}