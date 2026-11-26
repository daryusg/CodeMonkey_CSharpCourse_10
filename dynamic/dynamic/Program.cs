using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using static dynamic.Program;
using static System.Net.Mime.MediaTypeNames;

namespace dynamic
{
    //dynamic

    internal class Program
    {
        private static string json = """
            {
                "phoneNumbers": [
                    { "type": "mobile", "number": "07722823829" },
                    { "type": "home", "number": "01245582340" },
                    { "type": "work", "number": "01206272300" }
                ]
            }
            """;

        //Note: with JSON data, to get away from dynamic, i can create a class, or classes, from the JSON data by copying it "Edit" "Paste Special" "Paste JSON As Classes
        //Note ChatGPT: recommended changing to PascalCase. 
        public class RootObject
        {
            public PhoneNumber[] PhoneNumbers { get; set; }
        }

        public class PhoneNumber
        {
            public string Type { get; set; }
            public string Number { get; set; }
        }


        static void Main(string[] args)
        {
            dynamic d1; //evaluated at runtime
            //similar to...
            var v = 54; //evaluated at compile time. at which time var becomes a System.Int32 (int).

            dynamic d2 = new object();
            Console.WriteLine(d2.ToString()); //runs ok
            //d2.Test(); //no error at compile time. error's runtime
            //d2.asdf = "asdf"; //no error at compile time

            //Note: the compiler assumes that the dynamic variables/objects are being used correctly
            //useful when dealing with JSON data from a website
            //i installed the NuGet NewtonSoft.JSON Latest stable 13.0.4 package
            dynamic jsonDynamic = JObject.Parse(json);

            var props = jsonDynamic.GetType().GetProperties(); //see lesson: Reflection (??)
            //Console.WriteLine(props);
            //foreach (var prop in props)
            //    Console.WriteLine(prop);

            Console.WriteLine(jsonDynamic.phoneNumbers[1].type); //Note: no auto-completion because dynamic doesn't know which type this is

            dynamic d3 = Test();
            Console.WriteLine(d3.note); //Note: no auto-completion because dynamic doesn't know which type this is

            //----------------------------------------------------------------------------------------------

            //Because the JSON uses camelCase, you can tell System.Text.Json to match it automatically:
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            
            RootObject result = JsonSerializer.Deserialize<RootObject>(json, options)!; //copy JSON into classes. ! suppresses null warning
            //alternatively...
            RootObject person = JsonSerializer.Deserialize<RootObject>(json, options) ?? throw new Exception("Deserialization failed");

            Console.WriteLine("Deserialised (foreach)");
            foreach (PhoneNumber phoneNumber in result.PhoneNumbers)
                Console.WriteLine($"\t{phoneNumber.Type}: {phoneNumber.Number}");

            Console.WriteLine("Deserialised (for)");
            for (int x = 0; x < result.PhoneNumbers.Length; x++)
                Console.WriteLine($"\t{result.PhoneNumbers[x].Type}: {result.PhoneNumbers[x].Number}");
        }

        private static dynamic Test()
        {
            //return 12;
            //return false;
            return new { name = "Code Monkey", health = 100, note = "Return type dynamic means that anything (compile time) can be returned" };
            //return "Return type dynamic means that anything (compile time) can be returned";
        }
    }
}
