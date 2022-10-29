using System.ComponentModel;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Runtime.Intrinsics.X86;

namespace MyCalc
{
    class PostfixMather
    {
        internal List<string> Expr = new();

        public PostfixMather() {}

        //Traversing postfix list
        internal double GetResult()
        {
            double b2, a1 = 0;
            for (int i = 0; i < Expr.Count; i++)
            {
                if (!double.TryParse(Expr[i], out b2))
                {
                    if (i < 2)
                    {
                        i--;
                        a1 = Convert.ToDouble(Expr[i]);
                        a1 = DoMath(0, a1, Expr[i + 1]);
                        Expr.RemoveRange(i, 2);
                        Expr.Insert(i, $"{a1}");
                        i--;
                        continue;
                    }
                    i -= 2;
                    a1 = Convert.ToDouble(Expr[i]);
                    b2 = Convert.ToDouble(Expr[i + 1]);
                    a1 = DoMath(a1, b2, Expr[i + 2]);
                    Expr.RemoveRange(i, 3);
                    Expr.Insert(i, $"{a1}");
                    i--;
                }
            }
            return a1;
        }

        //Execute method
        private double DoMath(double a1, double b2, string op) => op switch
        {
            "+" => a1 + b2,
            "-" => a1 - b2,
            "*" => a1 * b2,
            "/" => a1 / b2,
            "^" => Math.Pow(a1, b2),
            "~" => a1 - b2,
            _ => 0
         };
    }
}
