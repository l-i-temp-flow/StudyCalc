using System.ComponentModel;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Runtime.Intrinsics.X86;

namespace MyCalc
{
    public class PostfixMather
    {
        internal List<string> expression = new();

        public PostfixMather() {}

        //Traversing postfix list
        internal double GetResult()
        {
            double b2, a1 = 0;
            for (int i = 0; i < expression.Count; i++)
            {
                if (!double.TryParse(expression[i], out b2))
                {
                    if (expression[i] == "~")
                    {
                        i--;
                        a1 = Convert.ToDouble(expression[i]);
                        a1 = DoMath(0, a1, expression[i + 1]);
                        expression.RemoveRange(i, 2);
                        expression.Insert(i, $"{a1}");
                        i--;
                        continue;
                    }
                    i -= 2;
                    a1 = Convert.ToDouble(expression[i]);
                    b2 = Convert.ToDouble(expression[i + 1]);
                    a1 = DoMath(a1, b2, expression[i + 2]);
                    expression.RemoveRange(i, 3);
                    expression.Insert(i, $"{a1}");
                    i--;
                }
            }
            return Convert.ToDouble(expression[0]);
        }

        //Execute method
        private double DoMath(double a1, double b2, string op) => op switch
        {
            "+" => a1 + b2,
            "-" => a1 - b2,
            "*" => a1 * b2,
            "/" => a1 / b2,
            "^" => Math.Pow(a1, b2),
            "~" => 0 - b2,
            _ => 0
         };
    }
}
