using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();  
            int N = 1;
            Console.WriteLine();
            Console.WriteLine("Лабораторная работа №2..\nВыполнила: Андреева А.А., " +
                "группа 6213-020302D\n");

            Console.WriteLine("\nЗадание 1. Найти первые N чисел Фибоначчи двумя способами:\n" +
                "с помощью рекурсии и с помощью итерацииюСравните эффективность алгоритмов.");

            Console.Write("\nВведите кол-во чисел Фибоначчи N = " );
            N = Convert.ToInt32(Console.ReadLine());
            if (N <= 1) {
                Console.WriteLine("\nВведено неверное значение, N будет присвоено 10");
                N = 10;
            }

            Console.WriteLine("\nВызов функции нахождения с помощью рекурсии, N-ое число Фибоначчи:");
            sw.Start();
            Console.Write(RFib(N-1)+"  ");
            sw.Stop();
            TimeSpan tsRF = sw.Elapsed;
            string timeRF = String.Format("{0:00}.{1:00000}", tsRF.Seconds, tsRF.Milliseconds);
            Console.WriteLine("\nВремя выполнения:" + timeRF);

            Console.WriteLine("\nВызов функции нахождения с помощью итерации, последовательность Фибоначчи:");
            sw.Restart();
            int[] fib = IFib(N);
            sw.Stop();
            TimeSpan tsIF = sw.Elapsed;           
            for (int i = 0; i < N; i++) {
                Console.Write(fib[i] + "  ");
            };
            string timeIF = String.Format("{0:00}.{1:00000}", tsIF.Seconds, tsIF.Milliseconds / 10);
            Console.WriteLine("\nВремя выполнения:" + timeIF);


            Console.WriteLine("\nЗадание 2. Написать традиционную функцию умножения двух чисел и функцию,\n" +
                "использующую только операцию сложения. Сравните эффективность алгоритмов.");

            Console.Write("\nВведите число a = ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nВведите число b = ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nВызов традиционной функции умножения:");
            sw.Restart();
            Console.Write("c = "+ Mul(a,b));
            sw.Stop();
            TimeSpan tsM = sw.Elapsed;
            string timeM = String.Format("{0:00}.{1:00000}", tsM.Seconds, tsM.Milliseconds / 10);
            Console.WriteLine("\nВремя выполнения:" + timeM);


            Console.WriteLine("\nВызов функции, использующей только операцию сложения: ");
            sw.Restart();
            int c = SumMul(a, b);
            sw.Stop();
            Console.Write("c = " + c);            
            TimeSpan tsSM = sw.Elapsed;
            string timeSM = String.Format("{0:00}.{1:00000}", tsSM.Seconds, tsSM.Milliseconds / 10);
            Console.WriteLine("\nВремя выполнения:" + timeSM);

            Console.ReadLine();
        }
        static int RFib(int n)
        {
            if (n <= 1) {
                return n;
            }
            return RFib(n - 1) + RFib(n - 2);
        }

        static int[] IFib(int n)
        {
            int[] F = new int[n];
            F[0] = 0; F[1] = 1;
            for (int i = 2; i < n; i++) {
                F[i] = F[i - 1] + F[i - 2];
            }
            return F;
        }

        static int Mul(int a, int b) {
            return a * b;
        }

        static int SumMul(int a, int b)
        {
            int sum = 0;
            for (int i = Math.Abs(b); i > 0; i--)
            {
                sum += a;
            }
            if (b < 0)
            {
                sum = sum*(-1);
            }
            return sum;
        }
    }
}
