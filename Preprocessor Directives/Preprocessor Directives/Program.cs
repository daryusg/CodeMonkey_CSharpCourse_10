#define TESTING2 //they're either defined, or not on a per-file basis

namespace Preprocessor_Directives
{
    //Preprocessor Directives (PDs)

    internal class Program
    {
        static void Main(string[] args)
        {
//disable all warnings: #pragma warning disable
#pragma warning disable 0168 //or CS0168
            int i; //without the pragma, CS0168 The variable 'i' is declared but never used
#pragma warning restore 0168
            int j;

            //evaluated runtime
            bool testing = true;
            if (testing)
                Console.WriteLine("Testing");

//evaluated compile time
#if TESTING //the following lines grayed out, or included, acordingly
            Console.WriteLine("Testing");
#elif TESTING2
            Console.WriteLine("Testing 2");
#else
            Console.WriteLine("Not testing");
#endif

            //DEBUG and RELEASE are automatically defined and determined by the (Debug) dropdown at the top of vs
            //they're scoped across the entire solution
            //to add, amend, delete a PD, select "Configuration Manager..." then "<New...>"
#if DEBUG
            Console.WriteLine("Debugging");
#endif
#if RELEASE
            Console.WriteLine("Release");
#endif
            //#if <intellisense displays all available directives>
            //#if NET9_0_OR_GREATER

#if !NET10_0
//#if !NET8_0
#error some error
#endif

            //Note: right-click project "Properties". in the "Build" section, are the custom symbols. here, i can add symbols within (the) symbols
            //i added CSHARPCOURSE under Testing
#if CSHARPCOURSE
            Console.WriteLine("I'm in the TESTING.CSHARPCOURSE directive");
#endif
            //----------------------------------------------------------------------------
            //#region
            //allows categorisation of areas for easy expansion and collapse (using the arrow, on the left, next to the line number)
            #region FIELDS
            #endregion
            #region STATICS
            #endregion
            #region FUNCTIONS
            #endregion
            //----------------------------------------------------------------------------
            //#warning
#warning this is a warning
        }
    }
}
