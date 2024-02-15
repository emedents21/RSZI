using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSZ1
{
    public class Solution
    {
        public double x;
        public double y;
        public double b;
        public double a;
        public Solution(double x, double y, double b, double a)
        {
            this.x = x;
            this.y = y;
            this.b = b;
            this.a = a;
        }

        public static double Factorial(double n)
        {
            if (n == 0)
            {
                return 1;
            }
            else if (n > 0)
            {
                return n * Factorial(n - 1);
            }
            else
            {
                throw new ArgumentException("Number must be non-negative");
            }
        }
        public double Calcucate(double x, double y, double b, double a)
        {
            double sum = 0;
            for (int i = 1; i <= 30; i++)
            {
                sum += ((-1) ^ i) * Math.Pow((Math.Tan(x) + Math.Cos(a) - Math.Tan(b)), y) / Factorial(i) * x;
            }
            return sum;
        }
    }
}
