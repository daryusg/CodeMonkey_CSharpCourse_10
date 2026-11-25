using System.Net;

namespace Main_and_Command_Line_Args
{
    //Main and Command Line Args

    internal class Program
    {
        //static void Main(string[] args) //program must contain Main and be static otherwise CS5001 Program does not contain a static 'Main' method suitable for an entry point
        //                                //must be static as no objects exist
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs(); //Note: can be grabbed (at any time) throughout the app

            //Console.WriteLine(args.Length); //Note: args is guaranteed to never be null

            //foreach(string arg in args)
            for (int x = 0; x < args.Length; x++)
            {
                Console.WriteLine($"args[{x}]: {args[x]}");
            }
            //Note: With static void Main() and string[] args = Environment.GetCommandLineArgs();
            //returns an extra argument. the first argument is a path to the dll
            /*
                C:\Users\kev\source\repos\CodeMonkey_CSharpCourse_10\Main and Command Line Args\Main and Command Line Args\bin\Debug\net10.0>"Main and Command Line Args.exe" 32 "Code Monkey" true
                args[0]: C:\Users\kev\source\repos\CodeMonkey_CSharpCourse_10\Main and Command Line Args\Main and Command Line Args\bin\Debug\net10.0\Main and Command Line Args.dll
                args[1]: 32
                args[2]: Code Monkey
                args[3]: true
                0
                32
                False
            */
            /*
                C:\Users\kev\source\repos\CodeMonkey_CSharpCourse_10\Main and Command Line Args\Main and Command Line Args\bin\Debug\net10.0>"Main and Command Line Args.exe" 32
                1
                args[0]: 32

                C:\Users\kev\source\repos\CodeMonkey_CSharpCourse_10\Main and Command Line Args\Main and Command Line Args\bin\Debug\net10.0>"Main and Command Line Args.exe" 32 "Code Monkey" true
                3
                args[0]: 32
                args[1]: Code Monkey
                args[2]: true
            */
            //"Main and Command Line Args.exe" -debug - start in debug mode
            //"Main and Command Line Args.exe" MyData.csv - filename for the program to open

            int.TryParse(args[0], out int argInt);
            bool.TryParse(args[2], out bool argBool);

            Console.WriteLine(argInt);
            Console.WriteLine(args[1]);
            Console.WriteLine(argBool);
            /*
                C:\Users\kev\source\repos\CodeMonkey_CSharpCourse_10\Main and Command Line Args\Main and Command Line Args\bin\Debug\net10.0>"Main and Command Line Args.exe" 32 "Code Monkey" true
                32
                Code Monkey
                True
            */
        }
        //static int Main(string[] args)
        //{
        //    Console.WriteLine("Hello World!");
        //    //return 0; //usually means success
        //    //or
        //    //return <error code>;
        //    return 999; //comand line: ...Command Line Args.exe (process 29724) exited with code 999 (0x3e7).
        //    /*
        //     * From Command Prompt (NOT PowerShell):
        //        Microsoft Windows [Version 10.0.19045.7846]
        //        (c) Microsoft Corporation. All rights reserved.

        //        C:\Users\kev>cd "C:\Users\kev\source\repos\CodeMonkey_CSharpCourse_10\Main and Command Line Args\Main and Command Line Args\bin\debug\net10.0"

        //        C:\Users\kev\source\repos\CodeMonkey_CSharpCourse_10\Main and Command Line Args\Main and Command Line Args\bin\Debug\net10.0>"Main and Command Line Args.exe"
        //        Testing...

        //        C:\Users\kev\source\repos\CodeMonkey_CSharpCourse_10\Main and Command Line Args\Main and Command Line Args\bin\Debug\net10.0>echo %ERRORLEVEL%
        //        999 <---not returned in PowerShell
        //    */
        //}
        //static Task Main(string[] args)
        ////static Task<object> Main(string[] args)
        //{

        //}
    }

    public class AnotherProgram
    {
        public static void Main() //CS0017 Program has more than one entry point defined. Compile with /main to specify the type that contains the entry point.
                                  //Note: if this occurs then i click the project and select the Application.Startup object. in this case, there's 2 items to choose from.
        {
            Console.WriteLine("The other program (AnotherProgram).");
            /*
                C:\Users\kev\source\repos\CodeMonkey_CSharpCourse_10\Main and Command Line Args\Main and Command Line Args\bin\Debug\net10.0>"Main and Command Line Args.exe" 32 "Code Monkey" true
                The other program (AnotherProgram).
            */
        }
    }
}
