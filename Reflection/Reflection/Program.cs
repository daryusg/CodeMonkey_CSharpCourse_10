using System.Reflection;
using System.Reflection.Metadata;

namespace Reflection
{
    //Reflection

    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine($"typeof(Program).Assembly: {typeof(Program).Assembly}");
            Console.WriteLine("foreach (Type type in typeof(Program).Assembly).GetTypes():");
            foreach (Type type1 in typeof(Program).Assembly.GetTypes())
                Console.WriteLine($"\t{type1}");

            Console.WriteLine();

            Type type2 = typeof(Program).Assembly.GetType("Reflection.Program+Exercise+Player"); //<---name MUST be (fully) exact
            Console.WriteLine($"type: {type2}");

            Console.WriteLine();

            Exercise exercise = new();
            exercise.MyFunction();

            MethodInfo? myFunctionMethodInfo = typeof(Exercise).GetMethod("MyFunction");
            if(myFunctionMethodInfo!=null)
                myFunctionMethodInfo.Invoke(exercise, new object[] { });

            Type playerType = typeof(Exercise).GetNestedType("Player");
            Console.WriteLine($"PlayerType: {playerType}");

            Console.WriteLine();

            Console.WriteLine("foreach (Type type in typeof(Exercise).GetNestedTypes()):");
            foreach (Type type in typeof(Exercise).GetNestedTypes())
                Console.WriteLine($"\t{type}");

            Console.WriteLine();

            Console.WriteLine("foreach (Type type in typeof(Exercise).GetNestedTypes(BindingFlags.NonPublic | BindingFlags.Static)):");
            foreach (Type type in typeof(Exercise).GetNestedTypes(BindingFlags.NonPublic | BindingFlags.Static))
                Console.WriteLine($"\t{type}");

            Console.WriteLine();

            MethodInfo? myFunctionMethodInfo2 = playerType.GetMethod("MyFunction1");
            if (myFunctionMethodInfo2 != null)
                myFunctionMethodInfo2.Invoke(new Exercise.Player(), new object[] { });

            MethodInfo? myFunctionMethodInfo3 = playerType.GetMethod("MyFunction2");
            myFunctionMethodInfo3.Invoke(new Exercise.Player(), new object[] { "", "This is a test1!" }); //Note: parameter type(s) needs to match otherwise (possible) runtime error.

            object playerObject = Activator.CreateInstance(playerType);
            MethodInfo? myFunctionMethodInfo4;
            //if (playerObject != null)
            {
                //myFunctionMethodInfo4 = myFunctionMethodInfo4 = playerObject.GetMethod("MyFunction2"); //<---doesn't work
                myFunctionMethodInfo4 = myFunctionMethodInfo4 = playerType.GetMethod("MyFunction2");
                myFunctionMethodInfo4.Invoke(playerObject, new object[] { "This is a test2!", "" }); //Note: parameter type(s) needs to match otherwise (possible) runtime error.

                myFunctionMethodInfo4 = myFunctionMethodInfo4 = playerType.GetMethod("MyFunction3", BindingFlags.NonPublic | BindingFlags.Instance); //<--an Instance function
                myFunctionMethodInfo4.Invoke(playerObject, null); //Note: parameter type(s) needs to match otherwise (possible) runtime error.
            }

            Console.WriteLine();

            ParameterInfo[] parameterInfo = myFunctionMethodInfo3.GetParameters();
            foreach(ParameterInfo paramInfo in parameterInfo)
            {
                Console.WriteLine($"Name: {paramInfo.Name}, Type: {paramInfo.ParameterType}");
            }

            //-----------------------------------------------------------------------------
            Console.WriteLine();
            bool test = null == new object[] { };
            Console.WriteLine($"Bool test: {test}");
            if (myFunctionMethodInfo != null)
                myFunctionMethodInfo.Invoke(exercise, null); //this also works
            //-----------------------------------------------------------------------------
        }

        public class Exercise
        {
            public void MyFunction()
            {
                Console.WriteLine("MyFunction 0");
            }

            public class Player
            {
                public void MyFunction1()
                //Note: reflection usage means that this usage isn't found by <right-click> Find All References 
                {
                    Console.WriteLine("MyFunction 1");
                }

                public void MyFunction2(string msg1, string msg2)
                {
                    if (msg1.Length > 0)
                        Console.WriteLine($"MyFunction2 Msg 1: {msg1}");
                    if (msg2.Length>0)
                        Console.WriteLine($"MyFunction2 Msg 2: {msg2}");
                }

                private void MyFunction3() //note: accessible via reflection
                {
                    Console.WriteLine("MyFunction 3");
                }
            }

            private class Unit
            {
            }

            private class Enemy
            {
            }
        }
    }
}
