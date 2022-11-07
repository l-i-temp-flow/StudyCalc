using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyCalc
{
    internal struct ConsoleUI
    {
        public ConsoleUI() { }

        public void DoUI()
        {
            Console.Title = "Calculator";
            bool check = true;
            while (check)
            {
                Console.CursorVisible = true;
                Console.Clear();
                Console.WriteLine("Доступные операции: +, -, *, /, ^.");
                Console.Write("Введите выражение: ");
                StringValidation currentString = new(Console.ReadLine());
                currentString.PrintResult();
                Console.CursorVisible = false;
                check = Menu();
            }
        }

        private bool Menu()
        {
            string[] menuItems = new string[] { "Повторить операцию", "      Выход       " };
            int row = Console.CursorTop;
            int col = Console.CursorLeft;
            int index = 0;
            while (true)
            {
                DrawMenu(menuItems, row, col, index);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < menuItems.Length - 1)
                            index++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        break;
                    case ConsoleKey.Enter:
                        switch (index)
                        {
                            case 1:
                                return false;
                            default:
                                return true;
                        }
                }
            }
        }
        private static void DrawMenu(string[] items, int row, int col, int index)
        {
            Console.SetCursorPosition(col, row);
            for (int i = 0; i < items.Length; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(items[i]);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}
