namespace Attributes
{
    //Attributes

    internal class Program
    {
        //[IsObjectType(ObjectType.Unit)] CS0592 Attribute 'IsObjectType' is not valid on this declaration type. It is only valid on 'class, struct' declarations.
        static void Main(string[] args)
        {
            //object[] attributeObjectArray = typeof(Player).GetCustomAttributes(typeof(IsObjectTypeAttribute), false);
            //IsObjectTypeAttribute isObjectTypeAttribute = (IsObjectTypeAttribute)attributeObjectArray[0];
            object[] attributeObjectArray = typeof(Player).GetCustomAttributes(false);
            foreach(object obj in attributeObjectArray)
            {
                try
                {
                    var x = (IsObjectTypeAttribute)obj;
                    Console.WriteLine($"{obj.ToString()}: {x.GetObjectType()}");
                }
                catch{ }
            }
        }
    }

    [IsObjectType(ObjectType.Unit)]
    public class Player
    {
    }

    public enum ObjectType
    {
        Unit,
        Object,
        Prop,
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class IsObjectTypeAttribute : System.Attribute
    {
        private ObjectType objectType;

        public IsObjectTypeAttribute(ObjectType objectType)
        {
            this.objectType = objectType;
        }

        public ObjectType GetObjectType()
        {
            return objectType;
        }
    }
}
