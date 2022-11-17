using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalcLib
{
    public static class MyCalcWrapper
    {
        internal static List<string> exprList = new();

        //Method for execute ready postfix list
        public static double GetResult(List<string> postfixExpr)
        {
            double result = PostfixMather.GetResult(postfixExpr);
            postfixExpr.Clear();
            return result;
        }

        //Method for convert valid string to postfix and execute
        public static double GetResult(string validExpr)
        {
            StringToPostfix.ToPostfixList(validExpr, exprList);
            return GetResult(exprList);
        }

        //Method for validation, convert and execute
        public static bool TryGetResult(ref string? inputExpr, out double succesfulExecute)
        {
            if (StringValidation.Validation(ref inputExpr))
            {
                succesfulExecute = 0;
                return false;
            }
            succesfulExecute = GetResult(inputExpr);
            return true;
        }

        //Console output method
        public static void PrintResult(string? inputExpr, bool needValid = true)
        {
            if (needValid)
            {
                if (!TryGetResult(ref inputExpr, out double result)) Console.WriteLine("Ошибка выполнения " + inputExpr);
                else Console.WriteLine($"Результат вычисления:\n{inputExpr} = {result}");
            }
            else Console.WriteLine($"Результат вычисления:\n{inputExpr} = {GetResult(inputExpr)}");

        }
    }
}
