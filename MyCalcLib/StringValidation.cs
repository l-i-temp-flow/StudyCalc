using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyCalcLib
{
    internal static class StringValidation
    {
        private static bool isError;
        private const string divideByZero = @"/0?,?0*(\+|-|\*|/|\^).*$";
        private const string invalidCharacters = @"[^\d|\+|\-|\*|/|\^|\(|\)|,]";
        private const string invalidBracketsCont = @"\(\D*\)";
        private const string invalidCourseAction = @"(\+|\-|\*|/|\^){2,}|(\((\+|\*|/|\^)+)|(\)\()|(\d\()|(\)\d)";
        private const string invalidDecSeparator = @"(\d+\,\D)|(\D\,\d+)";

        //Validation method
        internal static bool Validation (ref string? typeExpr)
        {
            isError = true;
            if (string.IsNullOrEmpty(typeExpr)) typeExpr = "Введена пустая строка";
            else
            {
                typeExpr = typeExpr.Replace(" ", "");
                typeExpr = typeExpr.Replace(".", ",");
                if (Regex.IsMatch(typeExpr, divideByZero)) typeExpr = "Деление на \"0\"";
                else if (Regex.IsMatch(typeExpr, invalidCharacters)) typeExpr = "Введены некорректные символы";
                else if (Regex.IsMatch(typeExpr, invalidBracketsCont)) typeExpr = "Некорретное содержимое скобок";
                else if (Regex.IsMatch(typeExpr, invalidCourseAction)) typeExpr = "Некорректный порядок симолов операций";
                else if (Regex.IsMatch(typeExpr, invalidDecSeparator)) typeExpr = "Некорректный десятичный разделитель";
                else if (CheckBrackets(typeExpr)) typeExpr = "Некорректная расстановка скобок";
                else isError = false;
            }
            return isError;
        }

        //Checking the correct placement of brackets
        private static bool CheckBrackets (string expr)
        {
            Stack<char> brackets = new();
            int i = 0;
            foreach (char b in expr)
            {
                if (b == '(')
                {
                    brackets.Push(b);
                    i++;
                }
                else if (b == ')' && brackets.Count > 0) brackets.Pop();
                else if (b == ')' && brackets.Count == 0) return true;
            }
            if (i > 0 && brackets.Count > 0) return true;
            return false;
        }
    }
}
