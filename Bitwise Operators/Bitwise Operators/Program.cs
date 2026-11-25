namespace Bitwise_Operators
{
    //Bitwise Operators

    internal class Program
    {
        static void Main(string[] args)
        {
            //AND &
            //OR |
            //XOR ^
            //NEG ~

            //00000010
            //AND
            //00000011
            //========
            //00000010
            int a = 2, b = 3;
            Console.WriteLine($"{nameof(a)}({a}) AND {nameof(b)}({b}): {a & b}");

            //00000101
            //OR
            //00000011
            //========
            //00000111
            a = 5; b = 3;
            Console.WriteLine($"{nameof(a)}({a}) OR {nameof(b)}({b}): {a | b}");

            //00000101
            //XOR
            //00000011
            //========
            //00000110
            Console.WriteLine($"{nameof(a)}({a}) XOR {nameof(b)}({b}): {a ^ b}");

            //00000101
            //NEG
            //11111010
            Console.WriteLine($"NEG {nameof(a)}({a}): {~a}"); //-6
                                                              //see https://en.wikipedia.org/wiki/Two's_complement
                                                              //and https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
                                                              //signed: left-most bit is negative or positive

            //shifting bits
            Console.WriteLine($"1 << 2: {1 << 2}");
            Console.WriteLine($"8 >> 2: {8 >> 2}");
        }
    }
}
