using System.Collections;

namespace ThirdApp
{
    internal class Program
    {
        public static IDictionary<string, string> FormatData(string message, Severity severity, IDictionary<string, string> data)
        {
            Console.WriteLine(message);

            foreach (var item in data)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }

            return data;
        }

        public static int InputProcess()
        {
            var data = new Dictionary<string, string>();

            var count = 0;

            Console.WriteLine("Введите значение переменной a, только положительное число");
            data["a"] = Console.ReadLine();

            Console.WriteLine("Введите значение переменной b");
            data["b"] = Console.ReadLine();

            Console.WriteLine("Введите значение переменной c");
            data["c"] = Console.ReadLine();

            if (!int.TryParse(data["a"], out _) || int.Parse(data["a"]) == 0)
            {
                count++;
                throw new InputException("Неверное значение переменной а", Severity.Error, data);
            }
            if (!int.TryParse(data["b"], out _))
            {
                count++;
                throw new InputException("Неверное значение переменной b", Severity.Error, data);

            }
            if (!int.TryParse(data["c"], out _))
            {
                count++;
                throw new InputException("Неверное значение переменной c", Severity.Error, data);
            }
            return count;
        }

        static void SolvingQuadraticEquation(IDictionary<string, string> data)
        {
            int.TryParse(data["a"], out var a);
            int.TryParse(data["b"], out var b);
            int.TryParse(data["c"], out var c);

            var d = b * b - 4 * a * c;

        }

        static void Main()
        {
            Console.WriteLine("Необходимо решить квадратное уравнение вида: a * x ^ 2 + b * x + c = 0");

            while (true)
            {
                try
                {
                    if (InputProcess() == 0)
                    {
                        break;
                    }
                    InputProcess();
                }
                catch (InputException e)
                {
                  var data = FormatData(e.Message, e.Severity, e.Data);

                    try
                    {
                        SolvingQuadraticEquation(data);
                    }
                    catch
                    {

                    }
                }

              
            }

            

        }
    }
}