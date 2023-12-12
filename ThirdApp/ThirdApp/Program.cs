
using System.Numerics;

namespace ThirdApp
{
    internal class Program
    {
        public static void FormatData(string message, Severity severity, IDictionary<string, int> data)
        {
            switch (severity)
            {
                case Severity.Error:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case Severity.Warning:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case Severity.OverFlow:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Можно вводить значение в диапазоне −2 147 483 648 до 2 147 483 647");
                    Console.WriteLine();
                    break;
            }
            Console.Write(new string('-', 50));
            Console.WriteLine();
            Console.WriteLine(message);
            Console.Write(new string('-', 50));
            Console.WriteLine();
            foreach (var item in data)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public static Dictionary<string, int> InputProcess()
        {
            var data = new Dictionary<string, int>();
            var enteredValues = new Dictionary<string, string>();

            Console.WriteLine("Введите числовое значение переменной a, не равное 0");
            enteredValues["a"] = Console.ReadLine();
            Console.WriteLine("Введите числовое значение переменной b");
            enteredValues["b"] = Console.ReadLine();
            Console.WriteLine("Введите числовое значение переменной c");
            enteredValues["c"] = Console.ReadLine();

            foreach (var value in enteredValues)
            {
                Console.WriteLine($"{value.Key} = {value.Value}");
            }

            var checkA = BigInteger.TryParse(enteredValues["a"], out var valueA);
            if (valueA > int.MaxValue)
            {
                throw new InputException("Неверное значение переменной а", Severity.OverFlow, data);
            }
            int.Parse(enteredValues["a"]);
            var checkB = BigInteger.TryParse(enteredValues["b"], out var valueB);
            if (valueB > int.MaxValue)
            {
                throw new InputException("Неверное значение переменной а", Severity.OverFlow, data);
            }
            int.Parse(enteredValues["b"]);
            var checkC = BigInteger.TryParse(enteredValues["c"], out var valueC);
            if (valueC > int.MaxValue)
            {
                throw new InputException("Неверное значение переменной а", Severity.OverFlow, data);
            }
            int.Parse(enteredValues["c"]);

            if (!checkA || valueA == 0)
            {
               
                throw new InputException("Неверное значение переменной а", Severity.Error, data);
            }
            if (!checkB)
            {             
                throw new InputException("Неверное значение переменной b", Severity.Error, data);
            }
            if (!checkC)
            {
                throw new InputException("Неверное значение переменной c", Severity.Error, data);
            }

            data["a"] = (int)valueA;
            data["b"] = (int)valueB;
            data["c"] = (int)valueC;
            return data;
        }
        static void SolvingQuadraticEquation(Dictionary<string, int> data)
        {
            var a = data["a"];
            var b = data["b"];
            var c = data["c"];

            double d = (b * b) - (4 * a * c);
            var x1 = 0.0;
            var x2 = 0.0;

            if (d < 0)
            {
                throw new QuadraticEquationException("Вещественных значений не найдено", Severity.Warning, data);
            }
            if (d == 0)
            {
                x1 = -b / (2 * (double)a);
                Console.WriteLine($"Квадратное уравнение имеет один корень {x1}");
            }
            if (d > 0)
            {
                x1 = (-b + Math.Sqrt(d)) / (2 * a);
                x2 = (-b - Math.Sqrt(d)) / (2 * a);
                Console.WriteLine($"Квадратное уравнение имеет два корня x1 = {x1}, x1 = {x2}");
            }
        }
        static void Main()
        {
            Console.WriteLine("Необходимо решить квадратное уравнение вида: a * x ^ 2 + b * x + c = 0");
            Dictionary<string, string> dt = new Dictionary<string, string>();
            while (true)
            {
                try
                {
                    SolvingQuadraticEquation(InputProcess());
                }
                catch (InputException e)
                {
                    FormatData(e.Message, e.Severity, e.Data);
                }
                catch (QuadraticEquationException f)
                {
                    FormatData(f.Message, f.Severity, f.Data);
                }

            }
        }
    }
}

