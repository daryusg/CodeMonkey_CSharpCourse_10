using System.Runtime.InteropServices;

namespace sizeof__Marshal.SizeOf__
{
    //sizeof, Marshal.SizeOf()

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine($"sizeof(int): {sizeof(int)}"); //4
            Console.WriteLine($"sizeof(bool): {sizeof(bool)}"); //1
            Console.WriteLine($"sizeof(ushort): {sizeof(ushort)}"); //2
            Console.WriteLine($"sizeof(long): {sizeof(long)}"); //8

            //Note: sizeof() can't be used on classes
            //...unless used in the unsafe context
            //unsafe //CS0227 Unsafe code may only appear if compiling with /unsafe
            //{
            //    Console.WriteLine($"sizeof(Player): {sizeof(Player)}"); //CS0233 'Player' does not have a predefined size, therefore sizeof can only be used in an unsafe context
            //}
            Console.WriteLine(Marshal.SizeOf(new Player())); //4
            /*
             Note (throws the following without the attribute ([StructLayout(LayoutKind.Sequential)])), however, even with the attribute
             adding "List<int> intList;" to the class also causes the error:
                System.ArgumentException
                  HResult=0x80070057
                  Message=Type 'sizeof__Marshal.SizeOf__.Player' cannot be marshaled as an unmanaged structure; no meaningful size or offset can be computed.
                  Source=System.Private.CoreLib
                  StackTrace:
                   at System.Runtime.InteropServices.Marshal.SizeOf[T](T structure)
                   at sizeof__Marshal.SizeOf__.Program.Main(String[] args) in C:\Users\kev\source\repos\CodeMonkey_CSharpCourse_10\sizeof, Marshal.SizeOf()\sizeof, Marshal.SizeOf()\Program.cs:line 22
             
             */

            Console.WriteLine(Marshal.SizeOf(typeof(Point))); //8
        }
    }

    public struct Point
    {
        public int x;
        public int y;
    }

    [StructLayout(LayoutKind.Sequential)] //<---needed for marshaling
    public class Player
    {
        public int speed;

        //[MarshalAs(UnmanagedType.)] <---he thinks that (the below line) it might need another attrib here
        //List<int> intList;

        public bool IsGrounded()
        {
            return true;
        }
    }
}
