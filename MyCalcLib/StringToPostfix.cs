using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalcLib
{
    internal static class StringToPostfix
    {
        private static Stack<char> operators = new();
        private static Dictionary<char, byte> operationWeights = new()
        {
            {'(', 0 },
            {'+', 1 },
            {'-', 1 },
            {'*', 2 },
            {'/', 2 },
            {'^', 3 },
            {'~', 4 },
        };

        //Tokenize and transform to postfix
        internal static void ToPostfixList(string stringExpr, List<string> listExpr)
        {
            string tempDigit = "";
            for (int i = 0; i < stringExpr.Length; i++)
            {
                if (char.IsDigit(stringExpr[i]) || stringExpr[i] == ',') tempDigit += stringExpr[i];
                else
                {
                    if (!string.IsNullOrEmpty(tempDigit))
                    {
                        listExpr.Add(tempDigit);
                        tempDigit = "";
                    }
                    if (stringExpr[i] == '(') operators.Push(stringExpr[i]);
                    else if (stringExpr[i] == ')')
                    {
                        while (operators.Count > 0 && operators.Peek() != '(') listExpr.Add(Convert.ToString(operators.Pop()));
                        operators.Pop();
                    }
                    else
                    {
                        char tempOperator = stringExpr[i];
                        if (tempOperator == '-' && (i == 0 || (i > 1 && operationWeights.ContainsKey(stringExpr[i-1]))))
                            tempOperator = '~';
                        while (operators.Count > 0 && operationWeights[operators.Peek()] >= operationWeights[tempOperator])
                            listExpr.Add(Convert.ToString(operators.Pop()));
                        operators.Push(tempOperator);
                    }
                }
            }
            if (!string.IsNullOrEmpty(tempDigit)) listExpr.Add(tempDigit);
            while (operators.Count > 0) listExpr.Add(Convert.ToString(operators.Pop()));
        }
    }
}
