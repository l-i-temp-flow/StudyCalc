using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalc
{
    class StringToPostfix : PostfixMather
    {
        private Stack<char> Operators = new Stack<char>();
        private static Dictionary<char, byte> OpWeights = new()
        {
            {'(', 0 },
            {'+', 1 },
            {'-', 2 },
            {'*', 3 },
            {'/', 4 },
            {'^', 5 },
            {'~', 6 },
        };

        internal StringToPostfix() { }

        //Tokenize and transform to postfix
        internal void ToPostfixList(string op)
        {
            string tempdigit = "";
            for (int i = 0; i < op.Length; i++)
            {
                if (char.IsDigit(op[i]) || op[i] == ',') tempdigit += op[i];
                else
                {
                    if (!string.IsNullOrEmpty(tempdigit))
                    {
                        base.Expr.Add(tempdigit);
                        tempdigit = "";
                    }
                    if (op[i] == '(') Operators.Push(op[i]);
                    else if (op[i] == ')')
                    {
                        while (Operators.Count > 0 && Operators.Peek() != '(') base.Expr.Add(Convert.ToString(Operators.Pop()));
                        Operators.Pop();
                    }
                    else
                    {
                        char tempop = op[i];
                        if (tempop == '-' && (i == 0 || op[i - 1] == '(')) tempop = '~';
                        while (Operators.Count > 0 && OpWeights[Operators.Peek()] >= OpWeights[tempop]) base.Expr.Add(Convert.ToString(Operators.Pop()));
                        Operators.Push(tempop);
                    }
                }
            }
            if (!string.IsNullOrEmpty(tempdigit)) base.Expr.Add(tempdigit);
            while (Operators.Count > 0) base.Expr.Add(Convert.ToString(Operators.Pop()));
        }
    }
}
