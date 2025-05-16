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
            public int[] SortArray() 
            {
                var n = NumArray.Length;

                for (int i = 0; i < n - 1; i++)
                    for (int j = 0; j < n - i - 1; j++)
                        if (NumArray[j] > NumArray[j + 1])
                        {
                            var tempVar = NumArray[j];
                            NumArray[j] = NumArray[j + 1];
                            NumArray[j + 1] = tempVar;
                        }

                return NumArray;
            }
        }
        static void BubbleSort(int[] a)
{
    for (int i = 0; i < a.Length - 1; i++)
        for (int j = 0; j < a.Length - i - 1; j++)
            if (a[j] > a[j + 1])
                (a[j], a[j + 1]) = (a[j + 1], a[j]);
}

static void Print(int[] a)
{
    Console.WriteLine(string.Join(" ", a));
}


    } // class HelloWorld

} // namespace MyApp
