using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int N = rnd.Next(10000, 100000);
            int[] arr = new int[N]; 
            Console.WriteLine();
            Console.WriteLine("Лабораторная работа №1. Алгоритмы сортировки.\nВыполнила: Андреева А.А., " +
                "группа 6213-020302D\nВариант 2. Шейкер-сортировка и сортировка слиянием.");
            Console.WriteLine("\nРазмер массива N = " + N );
            for (int i = 0; i < N; i++)
            {
                arr[i] = rnd.Next(-10, 10);
            }
            Stopwatch sw = new Stopwatch();
            int[] Sarr = arr;
            sw.Start();
            Sarr = ShakerSort(Sarr);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string timeS = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("\nВремя шейкер-сортировки:" + timeS);

            Sarr = arr;
            sw.Restart();
            Sarr = MergeSort(Sarr);
            sw.Stop();
            TimeSpan tm = sw.Elapsed;
            string timeM = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", tm.Hours, tm.Minutes, tm.Seconds, tm.Milliseconds / 10);
            Console.WriteLine("\nВремя сортировки слиянием:" + timeM);
            Console.ReadLine();
        }

        static void Swap(int[] arr, int i, int j)
        {
            int t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }
        static int[] ShakerSort(int[] arr)
        {
            int left, right;

            for (int i = 0; i < arr.Length / 2; i++)
            { 
                left = 0;
                right = arr.Length - 1;
                do
                {
                    if (arr[left] > arr[left + 1])
                        Swap(arr, left, left + 1);
                    left++;

                    if (arr[right - 1] > arr[right])
                        Swap(arr, right - 1, right);
                    right--;

                }
                while (left <= right);
            }
            return arr;            
        }

        static int[] Merge(int[] left, int[] right)
        {
            int[] Sarr = new int[left.Length + right.Length];

            int l = 0;
            int r = 0;

            for (int i = 0; i < Sarr.Length; i++)
            {
                if (r >= right.Length)
                {
                    Sarr[i] = left[l];
                    l++;
                }
                else if (l < left.Length && left[l] < right[r])
                {
                    Sarr[i] = left[l];
                    l++;
                }
                else
                {
                    Sarr[i] = right[r];
                    r++;
                }                
            }
            return Sarr;
        }

        static int[] MergeSort(int[] arr)
        {
            if (arr.Length > 1)
            {
                
                int[] left = new int[arr.Length / 2];
                int[] right = new int[arr.Length - left.Length];

                for (int i = 0; i < left.Length; i++)
                {
                    left[i] = arr[i];
                }
                for (int i = 0; i < right.Length; i++)
                {
                    right[i] = arr[left.Length + i];
                }

                if (left.Length > 1)
                    left = MergeSort(left);
                if (right.Length > 1)
                    right = MergeSort(right);

                arr = Merge(left, right);
            }
            return arr;
        }
    }
}
