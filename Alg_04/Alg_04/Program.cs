using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_04
{
    class Program
    {

        //Задание 1. Дана строка со скобками. Проверьте правильность расстановки скобок за время О(n).
        //а) в строке содержатся только круглые скобки;
        //б) скобки могут быть любые.
        static bool roundBracket(string s) //сложность O(n) 
        {
            int countOpen = 0;//кол-во открывающих скобок
            int countClose = 0;//кол-во закрывающих скобок

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')//если открывающая скобка
                {
                    countOpen++;
                }
                else if ((s[i] == ')') && (countOpen >= (countClose + 1)))//если закрывающая скобка и кол-во открывающих больше чем закрывающих
                {
                    countClose++;
                }
                else { return false; }
            }
            if (countOpen != countClose)//если кол-во скобок не совпадает
            {
                return false;
            }
            return true;
        }

        static bool anyBracket(string s) //сложность O(n) 
        {
            string add = "";//строка для отслеживания закрывающих скобок для введенных открывающих
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    //для каждой открывающей скобки записываем закрывающую
                    case '(':
                        {
                            add += ')';
                            break;
                        };
                    case '[':
                        {
                            add += ']';
                            break;
                        };
                    case '{':
                        {
                            add += '}';
                            break;
                        }
                    // если последняя закрывающая скобка не соответствует нужной, то ошибка
                    //иначе правило расстановки скобок не нарушено, поэтому удаляем скобку 
                    case ')':
                        {
                            if (add[add.Length - 1] != ')')
                            {
                                return false;
                            }
                            add = add.Remove(add.Length - 1);
                            break;
                        }
                    case ']':
                        {
                            if (add[add.Length - 1] != ']')
                            {
                                return false;
                            }
                            add = add.Remove(add.Length - 1);
                            break;
                        }
                    case '}':
                        {
                            if (add[add.Length - 1] != '}')
                            {
                                return false;
                            }
                            add = add.Remove(add.Length - 1);
                            break;
                        }
                    default: return false;//если вообще не скобка
                }

            }
            if (add == "")//если открывающих скобок не было
            {
                return false;
            }
            return true;
        }

        //Задание 3. Задача «Поддержания max в окне». Дан массив размером n и счетчик k, определяющий размер окна в массиве.Окно двигается от
        //начала до конца массива.Необходимо найти максимум в окне и напечатать все их значения.Время работы алгоритма должно быть О(n) и
        //не зависеть от k.
        static int[] findMax(int[] arr, int k) //сложность O(n) 
        {
            int n = arr.Length;
            var B = new int[n]; // будем хранить максимум на промежутке от начала текущего блока до i-го элемента;
            var C = new int[n]; //будем хранить максимум на промежутке от i-го элемента до конца текущего блока.
            B[0] = arr[0];
            C[n - 1] = arr[n - 1];

            k--;

            for (int i = 1, j = n - 2; i < n; i++, j--)
            {
                // Расчитываем B
                if (i % k != 0)
                {
                    B[i] = Math.Max(arr[i], B[i - 1]);
                }
                else
                {
                    B[i] = arr[i];
                }

                // Расчитываем C
                if ((j+1) % k != 0)
                {
                    C[j] = Math.Max(arr[j], B[j + 1]);
                }
                else
                {
                    C[j] = arr[j];
                }
            }

            var maxArr = new int[n - k];//массив с максимумами
            for (int i =0; i<n-k;i++)
            {
                maxArr[i] = Math.Max(C[i], B[i+k]);
            }
            return maxArr;
        }

        //Задание 4. Дан массив размера n+1. Элементы массива числа из множества {1, 2, 3 … n}. Найдите повторяющееся число за время О(n), не
        //используя дополнительной памяти. Повторяющихся элементов может быть несколько.
        static void findDup(int[] arr)//сложность O(n) 
        {
            Console.WriteLine("\nПовторяющиеся числа: ");
            for (int i = 0; i < arr.Length; i++)//проходим по всему массиву
            {
                if (arr[Math.Abs(arr[i])] > 0)//если  значение элемента массива положительно, то переходим к другому элементу, 
                {                                                     //индексом которого является это значение и умножаем на -1
                    arr[Math.Abs(arr[i])] *= -1;
                }
                else //если элемент уже отрицательный, то это дубликат
                {
                    Console.Write(Math.Abs(arr[i]) + " ");
                }
            }
        }

        //Задание 5. Дан массив с целыми числами, в том числе и отрицательными.Найдите самое большое произведение трех чисел из этого массива.
        //Например: дан массив, содержащий числа -10, -10, 1, 3, 2. Функция, которая обрабатывает этот массив, должна вернуть 300, так как 
        //-10 * -10 * 3 = 300. Время и память должны быть оптимальны.
        static int findHighest(int[] arr)//сложность O(n) 
        {
            // Мы начнем с 3-его элемента массива (с индекса 2), так как первые 2 элемента уже 
            //сразу пойдут в highest_product_of_2 и lowest_product_of_2.
            int highest_product = Math.Max(arr[0], arr[1]);
            int lowest_product = Math.Min(arr[0], arr[1]);

            int highest_product_of_2 = arr[0] * arr[1];
            int lowest_product_of_2 = arr[0] * arr[1];

            //вычислим highest_product_of_three из первых 3 - х элементов.
            int highest_product_of_3 = arr[0] * arr[1] * arr[2];

            //Начинаем проход по массиву с индекса 2.
            for (int i = 2; i < arr.Length; i++)
            {
                //проверяем возможность увеличить highest_product_of_3 или оставляем его как есть.
                highest_product_of_3 = Math.Max(highest_product_of_3, arr[i] * highest_product_of_2);
                highest_product_of_3 = Math.Max(highest_product_of_3, arr[i] * lowest_product_of_2);

                //То же самое проверим и на максимальном произведении из двух.
                highest_product_of_2 = Math.Max(highest_product_of_2, arr[i] * highest_product);
                highest_product_of_2 = Math.Max(highest_product_of_2, arr[i] * lowest_product);

                //И на минимальном произведении из двух.
                lowest_product_of_2 = Math.Min(highest_product_of_2, arr[i] * highest_product);
                lowest_product_of_2 = Math.Min(highest_product_of_2, arr[i] * lowest_product_of_2);

                //Появилось ли новое максимальное число?
                highest_product = Math.Max(highest_product, arr[i]);

                //Появилось ли новое минимальное число?
                lowest_product = Math.Min(lowest_product, arr[i]);
            }
            return highest_product_of_3;
        }

        //Задание 6. Обнулите столбец N и строку M матрицы, если элемент в ячейке(N, M) нулевой. Затраты памяти и времени работы должны
        //быть минимизированы.
        static int[,] setZeros(int[,] matrix) //сложность O(n*m) 
        {
            bool[] row = new bool[matrix.GetLength(0)];//храним, есть ли нули в строке
            bool[] column = new bool[matrix.GetLength(1)];//храним, есть ли нули в столбце

            //ищем нули в элементах матрицы и заполняем массивы
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row[i] = true;
                        column[j] = true;
                    }
                }
            }

            //зануляем строки и столбцы согласно заполненным массивам
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (row[i] || column[j])
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            return matrix;
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            int count = 0;
            Console.WriteLine("Лабораторная работа №4." +
                "\n Выполнила: Андреева Анна. Группа: 6213-020302D");
            while (true)
            {
                Console.WriteLine("Выберите задание: \n 0) Выход \n 1) Проверка правильности расстановки скобок \n 2) Push/pop и min " +
                    "\n 3) Поддержание max в окне \n 4) Нахождение повторяющегося числа \n 5) Нахождение наибольшего произведения 3-х чисел " +
                    "\n 6) Обнуление строк матрицы ");
                Console.Write("Ваш выбор: ");
                string selected = Console.ReadLine();
                Console.WriteLine();
                switch (selected)
                {
                    case "0": return;
                    case "1":
                        {
                            Console.WriteLine("Введите строку: ");
                            string str = Console.ReadLine();
                            Console.WriteLine("Выберите тип скобок в строке: \n а)Только круглые  \n б)Любые");
                            char c = char.Parse(Console.ReadLine());
                            switch (c)
                            {
                                case 'а':
                                    {
                                        if (roundBracket(str))
                                        {
                                            Console.WriteLine("Скобки расставлены верно.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Скобки расставлены не верно.");
                                        }
                                        break;
                                    }
                                case 'б':
                                    {
                                        if (anyBracket(str))
                                        {
                                            Console.WriteLine("Скобки расставлены верно.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Скобки расставлены не верно.");
                                        }
                                        break;
                                    }
                                default: Console.WriteLine("Введено не верное значение."); break;
                            }
                            break;
                        }
                    case "2":
                        {
                            StackWithMin stack = new StackWithMin();
                            Console.WriteLine("Введите кол-во элементов, помещаемых в стек: ");
                            count = int.Parse(Console.ReadLine());
                            Console.WriteLine("Элементы стека: ");
                            for (int i = 0; i < count; i++)
                            {
                                stack.push(random.Next(-10, 10));
                                Console.WriteLine(stack.peek() + " ");
                            }
                            Console.WriteLine("Минимальный элемент в стеке: " + stack.min());
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Введите длину массива:");
                            count = int.Parse(Console.ReadLine());
                            int[] arr = new int[count];
                            Console.WriteLine("Исходный массив: ");
                            for (int i = 0; i < count; i++)
                            {
                                arr[i] = random.Next(1, count - 1);
                                Console.Write(arr[i] + " ");
                            }
                            Console.WriteLine("Введите размер окна:");
                            int k = int.Parse(Console.ReadLine());
                            arr = findMax(arr, k);
                            Console.WriteLine("Mаксимумы в окне: ");
                            for (int i = 0; i < arr.Length; i++)
                            {
                                Console.Write(arr[i] + " ");
                            }
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Введите длину массива:");
                            count = int.Parse(Console.ReadLine());
                            int[] arr = new int[count];
                            Console.WriteLine("Исходный массив: ");
                            for (int i = 0; i < count; i++)
                            {
                                arr[i] = random.Next(1, count - 1);
                                Console.Write(arr[i] + " ");
                            }
                            findDup(arr);
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Введите длину массива:");
                            count = int.Parse(Console.ReadLine());
                            if (count < 3)
                            {
                                Console.WriteLine("Длина должна быть не менее 3.");
                            }
                            else
                            {
                                int[] arr = new int[count];
                                Console.WriteLine("Исходный массив: ");
                                for (int i = 0; i < count; i++)
                                {
                                    arr[i] = random.Next(-10, 10);
                                    Console.Write(arr[i] + " ");
                                }
                                Console.WriteLine("Cамое большое произведение трех чисел: " + findHighest(arr));
                            }
                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("Введите кол-во строк в матрице: ");
                            int n = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите кол-во столбцов в матрице: ");
                            int m = int.Parse(Console.ReadLine());

                            int[,] matrix = new int[n, m];
                            Console.WriteLine("Исходная матрица: ");
                            for (int i = 0; i < n; i++)
                            {
                                for (int j = 0; j < m; j++)
                                {
                                    matrix[i,j] = random.Next(-10, 10);
                                    Console.Write("{0}\t", matrix[i, j] );
                                }
                                Console.Write("\n");
                            }
                            matrix = setZeros(matrix);
                            Console.WriteLine("Новая матрица: ");
                            for (int i = 0; i < n; i++)
                            {
                                for (int j = 0; j < m; j++)
                                {
                                    Console.Write("{0}\t", matrix[i, j] );
                                }
                                Console.Write("\n");
                            }
                            break;
                        }
                    default: Console.WriteLine("Введено не верное значение"); break;
                }
                Console.WriteLine("\r\nДля возврата в меню нажмите Enter. Для выхода нажмите 0.");
                Console.Write("Ваш выбор: ");
                string s = Console.ReadLine();
                if (s == "0")
                    return;
                else
                    Console.Clear();
            }
        }
    }
}
