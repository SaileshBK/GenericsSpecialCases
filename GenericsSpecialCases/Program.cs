using System;

namespace GenericsSpecialCases
{
    class Program
    {
        static void Main(string[] args)
        {
            // we have here 2 instances of container of string, 1 instances of container of int and 3 instance of containerBase.
            _ = new Container<string>();
            _ = new Container<string>();
            var container = new Container<int>();

            // from this we know that Container<string> does not have same static member as Container<int>.
            Console.WriteLine($"Container<string>: {Container<string>.InstanceCount}");
            Console.WriteLine($"Container<int>: {Container<int>.InstanceCount}");
            Console.WriteLine($"Container<bool>: {Container<bool>.InstanceCount}");
            Console.WriteLine($"ContainerBase: {ContainerBase.InstanceCountBase}");

            container.PrintItem("This is a message from generic method in generic class.");

            var result = Add(2, 5);
            Console.WriteLine($"2 + 5 is equals to {result}");

            var result2 = Add(2.5, 5.5);
            Console.WriteLine($"2.5 + 5.5 is equals to {result2}");




            Console.ReadLine();
        }

        
        private static int Add( int x,  int y) 
        {
            
            return x + y;
        }

        //Insted of creating a Generic method. Using copy and paste approach to create a method overload 
        // creating overload of Add method to add two doubles.
        private static double Add(double x, double y)
        {

            return x + y;
        }
    }
    class ContainerBase
    {
        public ContainerBase() => InstanceCountBase++;


        public static int InstanceCountBase { get; private set; }
    }

    class Container<T> : ContainerBase
    {
        public Container() => InstanceCount++;
        

        public static int InstanceCount { get; private set; }
        // Defining a generic method in generic class is possile
        // Parameter type TItem uses Generic type parameter of generic method.
        // Make sure the type parameter is different name than type parameter that is defined in the class.
        public void PrintItem<TItem>(TItem item)
        {
            Console.WriteLine($"item: {item}");
        }
    }
}
