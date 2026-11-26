namespace Preprocessor_Directives
{
    internal class NewClass
    {
        public void Run()
        {
#if TESTING //the following lines grayed out, or included, acordingly
            Console.WriteLine("Testing");
#elif TESTING2
            Console.WriteLine("Testing 2");
#else
            Console.WriteLine("Not testing");
#endif

#if DEBUG
            Console.WriteLine("Debugging");
#endif
        }
    }
}
