using System;

namespace GenericsSpecialCases
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // we have here 2 instances of container of string, 1 instances of container of int and 3 instance of containerBase.
            _ = new Container<string>();
            _ = new Container<string>();
            var container = new Container<int>();

            Console.WriteLine($"Container<string>: {Container<string>.InstanceCount}");
            Console.WriteLine($"Container<int>: {Container<int>.InstanceCount}");
            Console.WriteLine($"Container<bool>: {Container<bool>.InstanceCount}");
            Console.WriteLine($"ContainerBase: {ContainerBase.InstanceCountBase}");

            container.PrintItem("This is a message from generic method in generic class.");

            Console.ReadLine();
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

        //parameter type TItem uses Generic type parameter of generic method.
        public void PrintItem<TItem>(TItem item)
        {
            Console.WriteLine($"item: {item}");
        }
    }
}
