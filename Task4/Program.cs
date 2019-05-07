using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            double x0 = 0;
            double x1 = Math.PI/4;
            double e = 0.00000000001;
            double x = method_chord(x0, x1, e);
            Console.WriteLine("{0:0.000000000000000000000}",x);
            x = method_chord(x0, x1, 5);
            Console.WriteLine(x);
            x = method_chord(x0, x1, 0.01);
            Console.WriteLine(x);
            x = method_chord(x0, x1, 0.001);
            Console.WriteLine(x);
            x = method_chord(x0, x1, 0.0001);
            Console.WriteLine(x);
            Console.ReadLine();
        }

        public static double method_chord(double x_prev, double x_curr, double e)
        {
            double x_next = 0;
            double tmp;
            do
            {
                tmp = x_next;
                x_next = x_curr - f(x_curr) * (x_prev - x_curr) / (f(x_prev) - f(x_curr));
                x_prev = x_curr;
                x_curr = tmp;
            } while (Math.Abs(x_next - x_curr) > e);

            return x_next;
        }

        public static double f(double x)
        {
            return (2 * Math.Pow(Math.Sin(2 * x), 2)) / 3 - (3 * Math.Pow(Math.Cos(2 * x), 2)) / 4;
        }
    }
}
