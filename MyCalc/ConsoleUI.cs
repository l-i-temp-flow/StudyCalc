using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalc
{
    class ConsoleUI
    {
        internal ConsoleUI() { }

        internal void DoUI()
        {
            for (bool check = true; check != false;)
            {
                Console.Clear();
                Console.WriteLine("Доступные операции: +, -, *, /, ^.");
                Console.Write("Введите выражение: ");
                StringValidation currentString = new(Console.ReadLine());
                currentString.PrintResult();
                Console.WriteLine("Повторить операцию?\nДА(1)\tНЕТ(2)");
                if (Console.ReadLine() == "2") check = false;
            }
        }
     }
}
