using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_05
{
    class Backpack
    {
        public double bestPrice;//общая стоимость предметов лучшего набора

        //с повторений
        public double withRepeats(List<Item> items, int maxWeight)
        {
            double[] A = new double[maxWeight + 1];
            for (int w = 1; w <= maxWeight; w++)
            {
                A[w] = A[w - 1];
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].weigth <= w)
                    {
                        A[w] = Math.Max(A[w], A[w - items[i].weigth] + items[i].price);
                    }
                }
            }
            return bestPrice = A[maxWeight];
        }

        public double withoutRepeats(List<Item> items, int maxWeight)
        {
            int n = items.Count;
            double[,] A = new double[maxWeight + 1, n];

            for (int w = 0; w <= maxWeight; w++)
            {
                A[w, 0] = 0;
            }

            for (int j = 0; j < n; j++)
            {
                A[0, j] = 0;
            }

            for (int j = 1; j < n; j++)
            {
                for (int w = 1; w <= maxWeight; w++)
                {
                    if (items[j].weigth > w)
                    {
                        A[w, j] = A[w, j -1];
                    }
                    else {
                        A[w, j] = Math.Max(A[w, j-1], A[w - items[j].weigth, j - 1] + items[j].price);
                    }
                }
            }
            return bestPrice = A[maxWeight, n-1];
        }
    }
}
