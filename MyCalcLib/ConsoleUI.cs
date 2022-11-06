using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalc
{
    public class ConsoleUI
    {
        public ConsoleUI() { }

        public void DoUI()
        {
            Console.Title = "Calculator";
            bool check = true;
            while (check)
            {
                Console.Clear();
                Console.WriteLine("Доступные операции: +, -, *, /, ^.");
                Console.Write("Введите выражение: ");
                StringValidation currentString = new(Console.ReadLine());
                currentString.PrintResult();
                Console.WriteLine("Повторить операцию?\nДА(1)\tНЕТ(2)");
                check = Menu();
            }
        }

        private bool Menu()
        {
            int i = 0;
            while (true)
            {
                if (i > 1)
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
                }
                char keyCheck = Console.ReadKey(true).KeyChar;
                if (keyCheck == '2') return false;
                else if (keyCheck != '1')
                {
                    i++;
                    Console.WriteLine("Нажата некорректная клавиша.");
                }
                else return true;
            }
        }
     }
}
