// This is a .NET 5 (and earlier) console app template
// (See https://aka.ms/new-console-template for more information)

using NLog;
using NLog.Targets;
using System.Text;

namespace MyApp
{

    internal class HelloWorld
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            Logger.Info("Starting program ...");
            string LOGDIR = Environment.GetEnvironmentVariable("LOGDIR");
            Logger.Debug("LOGDIR is set to {0}", LOGDIR);

            // Just for testing:
            // Logger.Trace("Trace");
            // Logger.Debug("Debug");
            // Logger.Info("Info");
            // Logger.Warn("Warn");
            // Logger.Error("Error");
            // Logger.Fatal("Fatal");


            Console.WriteLine("Hello, World!");

            double x = 1.234;
            double y = 4.321;
            Logger.Debug("calling Library.MyMath.Add(x, y) with x={0} and y={1} ...", x, y);
            double sum = Library.MyMath.Add(x, y);
            Logger.Debug("calling Library.MyMath.Multiply(x, y) with x={0} and y={1} ...", x, y);
            double prod = Library.MyMath.Multiply(x, y);
            Console.WriteLine(String.Format("{0} plus {1} makes {2}", x, y, sum));
            Console.WriteLine(String.Format("{0} times {1} makes {2}", x, y, prod));


            Library.DataStore<int, string> myData = new Library.DataStore<int, string>();
            for (int i = 0; i < 100; i++)
            {
                string text = string.Format("This is element {0}.", i);
                myData.Add(i, text);
            }

            PrintElement(myData, 42);
            PrintElement(myData, 100);
            PrintElement(myData, 101);
            PrintElement(myData, 102);

            CalculateFactorial(10);

            Logger.Info("Terminating program ...");
        }
        public static void PrintElement(Library.DataStore<int, string> Store, int index)
        {
            Library.Pair<int, string>? element = Store.GetElementByIndex(index);
            if (element is Library.Pair<int, string> valueOfElment)
            {
                Logger.Trace("idx {0}: found element", index);
                Console.WriteLine(String.Format("idx {0}: key {1}, value {2}", index,
                    element.GetKey(), element.GetValue()));
            }
            else
            {
                Logger.Warn("idx {0}: no such element in DataStore", index);
                Console.WriteLine(String.Format("idx {0}: no such element in DataStore", index));
            }
        }
        //adding a new function for Factorial
        public static int CalculateFactorial(int n)
        {
        // Base case: factorial of 0 is 1
            if (n == 0)
            {
                return 1;
            }
    
            // Error handling: factorial is not defined for negative numbers
            if (n < 0)
            {
                throw new ArgumentException("Factorial is not defined for negative numbers.", nameof(n));
            }
    
            // Recursive step: n! = n * (n-1)!
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            Console.WriteLine("Should show result here: ");
            return result;
    }

    } // class HelloWorld

} // namespace MyApp
