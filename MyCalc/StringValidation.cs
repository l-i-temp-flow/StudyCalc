﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyCalc
{
    internal class StringValidation : StringToPostfix
    {
        string TypeExpr { get; set; }
        string ErrorType;
        bool IsError;
        private static string InvalidCharacters = @"[^\d|\+|\-|\*|/|\^|\(|\)|,]";
        private static string InvalidBracketsCont = @"\(\D*\)";
        private static string InvalidCourseAction = @"(\+|\-|\*|/|\^){2,}|(\((\+|\*|/|\^)+)";
        private static string InvalidDecSeparator = @"(\d+\,\D)|(\D\,\d+)";

        internal StringValidation (string? typeExpr)
        {
            IsError = true;
            if (string.IsNullOrEmpty(typeExpr)) ErrorType = "Введена пустая строка";
            else
            {
                typeExpr = typeExpr.Replace(" ", "");
                typeExpr = typeExpr.Replace(".", ",");
                if (typeExpr.Contains("/0") && !typeExpr.Contains("/0,")) ErrorType = "Деление на \"0\"";
                else if (Regex.IsMatch(typeExpr, InvalidCharacters)) ErrorType = "Введены некорректные символы";
                else if (Regex.IsMatch(typeExpr, InvalidBracketsCont)) ErrorType = "Некорретное содержимое скобок";
                else if (Regex.IsMatch(typeExpr, InvalidCourseAction)) ErrorType = "Некорректный порядок симолов операций";
                else if (Regex.IsMatch(typeExpr, InvalidDecSeparator)) ErrorType = "Некорректный десятичный разделитель";
                else if (!CheckBrackets(typeExpr)) ErrorType = "Некорректная расстановка скобок";
                else
                {
                    IsError = false;
                    TypeExpr = typeExpr;
                }
            }
        }

        //Output method
        internal void PrintResult()
        {
            if (IsError)
            {
                Console.WriteLine("Ошибка выполнения: " + ErrorType + ".");
                return;
            }
            ToPostfixList(TypeExpr);
            Console.WriteLine($"Результат вычисления:\n{TypeExpr} = {GetResult()}");
        }

        //Checking the correct placement of brackets
        private bool CheckBrackets (string expr)
        {
            Stack<char> Brackets = new();
            int i = 0;
            foreach (char b in expr)
            {
                if (b == '(')
                {
                    Brackets.Push(b);
                    i++;
                }
                else if (b == ')' && Brackets.Count > 0) Brackets.Pop();
                else if (b == ')' && Brackets.Count == 0) return false;
            }
            if (i > 0 && Brackets.Count > 0) return false;
            return true;
        }
    }
}