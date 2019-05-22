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
            Console.WriteLine("Введите точность е");
            double e = ReadAnswer();
            double x = method_chord(x0, x1, e);
            Console.WriteLine($"заданная точность: {e} x={x}");
            e = 1;
            for(int i=0; i<5;i++)
            {
                x = method_chord(x0, x1, e);
                Console.WriteLine($"заданная точность: {e} x={x}");
                e *= 0.01;
            }
            x = method_chord(x0, x1, 0);
            Console.WriteLine($"заданная точность: {0} x={x}");
        }

        public static double method_chord(double x_prev, double x_curr, double e)
        {
            double x_next = 0;
            double tmp;
            do
            {
                tmp = x_next;
                x_next = x_curr - f(x_curr) * (x_curr - x_prev) / (f(x_curr) - f(x_prev));
                x_prev = x_curr;
                x_curr = tmp;
            } while (Math.Abs(x_next - x_curr) > e);

            return x_next;
        }

        public static double f(double x)
        {
            return (2 * Math.Pow(Math.Sin(2 * x), 2)) / 3 - (3 * Math.Pow(Math.Cos(2 * x), 2)) / 4;
        }

        public static double ReadAnswer()
        {
            double a = 0;
            bool ok = false;
            do
            {
                try
                {
                    a = Convert.ToDouble(Console.ReadLine());
                    if (a >= 0)
                        ok = true;
                    else Console.WriteLine("e должно быть положительным числом");
                }
                catch (Exception)
                {
                    Console.WriteLine("Пожалуйста, введите действительное число.");
                    ok = false;
                }
            } while (!ok);
            return a;
        }
    }
}
