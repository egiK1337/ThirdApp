
namespace ThirdApp
{
    internal class Program
    {
        public static void FormatData(string message, Severity severity, IDictionary<string, string> data)
        {
            if(severity == Severity.Error)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
            }
            if(severity == Severity.Warning) 
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            for (int i = 0; i < 5; i++)
            {
                Console.Write("-----");
            }

            Console.WriteLine();
            Console.WriteLine(message);

            for (int i = 0; i < 5; i++)
            {
                Console.Write("-----");
            }

            Console.WriteLine();

            foreach (var item in data)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public static Dictionary<string, string> InputProcess()
        {
            var data = new Dictionary<string, string>();

            Console.WriteLine("Введите числовое значение переменной a, не равное 0");
            data["a"] = Console.ReadLine();

            Console.WriteLine("Введите числовое значение переменной b");
            data["b"] = Console.ReadLine();

            Console.WriteLine("Введите числовое значение переменной c");
            data["c"] = Console.ReadLine();

            if (!int.TryParse(data["a"], out _) || int.Parse(data["a"]) == 0)
            {
                throw new InputException("Неверное значение переменной а", Severity.Error, data);
            }
            if (!int.TryParse(data["b"], out _))
            {
                throw new InputException("Неверное значение переменной b", Severity.Error, data);
            }
            if (!int.TryParse(data["c"], out _))
            {
                throw new InputException("Неверное значение переменной c", Severity.Error, data);
            }
            return data;
        }

        static void SolvingQuadraticEquation(Dictionary<string, string> data)
        {
            int.TryParse(data["a"], out var a);
            int.TryParse(data["b"], out var b);
            int.TryParse(data["c"], out var c);

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
                    var inputProcess = InputProcess();

                    if (inputProcess.Count == 3)
                    {
                        foreach (var item in inputProcess)
                        {
                            dt.Add(item.Key, item.Value);
                        }
                        SolvingQuadraticEquation(dt);
                    }
                }
                catch (InputException e)
                {
                    FormatData(e.Message, e.Severity, e.Data);
                }
                catch (QuadraticEquationException f)
                {
                    FormatData(f.Message, f.Severity, f.Data);
                }
                dt.Clear();
            }
        }
    }
}

