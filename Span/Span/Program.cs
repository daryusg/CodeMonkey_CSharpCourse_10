namespace Span
{
    //Span

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numberArray = [5, 2, 12, 45, 0, 48, 99, 10];
            //to sort the mid-section
            //i'd copy the mid-section of the array, i'd create a new array (then copy the data over)
            int[] subArray = [numberArray.Length - 2];

            //IMPORTANT: Span is handled with pointers so doesn't allocate any extra memory
            Span<int> intSpan = new(numberArray, 1, numberArray.Length-2);
            intSpan.Sort(); //Note: this modifies the original data
            //intSpan.Fill(0); //5,0,0,0,0,0,0,10

            //Note: if req'd, use ReadOnlySpan 
            string str = "";
            foreach (int i in numberArray)
                str += i + ",";

            //remove the last comma
            if (str.Length > 1)
                str = str[..^1];

            Console.WriteLine(str); //5,0,2,12,45,48,99,10

            str = "56,12";
            //Span<char> charSpan = str; //CS0029 Cannot implicitly convert type 'string' to 'System.Span<char>'
            //however...
            ReadOnlySpan<char> charSpan = str;
            int number1 = int.Parse(charSpan.Slice(0, 2));
            int number2 = int.Parse(charSpan.Slice(3, 2));
            Console.WriteLine($"{number1} {number2}");
        }
    }
}
