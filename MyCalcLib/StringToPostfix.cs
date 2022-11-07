using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalc
{
    public class StringToPostfix : PostfixMather
    {
        private Stack<char> operators = new Stack<char>();
        private static Dictionary<char, byte> operationWeights = new()
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
                        base.expression.Add(tempdigit);
                        tempdigit = "";
                    }
                    if (op[i] == '(') operators.Push(op[i]);
                    else if (op[i] == ')')
                    {
                        while (operators.Count > 0 && operators.Peek() != '(') base.expression.Add(Convert.ToString(operators.Pop()));
                        operators.Pop();
                    }
                    else
                    {
                        char tempop = op[i];
                        if (tempop == '-' && (i == 0 || op[i - 1] == '(')) tempop = '~';
                        while (operators.Count > 0 && operationWeights[operators.Peek()] >= operationWeights[tempop]) base.expression.Add(Convert.ToString(operators.Pop()));
                        operators.Push(tempop);
                    }
                }
            }
            if (!string.IsNullOrEmpty(tempdigit)) base.expression.Add(tempdigit);
            while (operators.Count > 0) base.expression.Add(Convert.ToString(operators.Pop()));
        }
    }
}
