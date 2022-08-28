using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_03
{
    class Program
    {
        //Задание 1. Дан однонаправленный список с петлей. Его последний элемент содержит указатель на один из элементов этого списка.
        //Найдите начальный узел петли
        static void FindLoop()
        {
            LinkList list = new LinkList();
            Random rand = new Random();
            for (int y = 0; y < 8; y++)
            {
                list.Add(rand.Next(1, 20));
            }
            Console.WriteLine("Список: ");
            Console.WriteLine(list.ToString());
            list.head.Next.Next.Next.Next.Next = list.head.Next.Next;
            Console.WriteLine("Начало петли - узел со значением: " + list.FindBegining(list.head).info);
            Console.WriteLine();
        }
        //Задание 2. Дан  список с двумя указателями. Скопируйте список за O(n) без использования доп. памяти.
        static void Copy()
        {
            LinkedList<int> list = new LinkedList<int>();
            Random rand = new Random();
            for (int y = 0; y < 8; y++)//заполняем список
            {
                list.AddLast(rand.Next(1, 20));
            }

            Console.WriteLine("Начальный список: ");
            foreach (int i in list)
            {
                Console.Write(" " + i);
            }
            Console.WriteLine();

            LinkedList<int> copiedList = new LinkedList<int>();
            LinkedListNode<int> p = list.First;

            while (p != null)//заполняем новый список копиями из начального списка
            {
                copiedList.AddLast(p.Value);
                p = p.Next;
            }

            Console.WriteLine("Скопированный список: ");
            foreach (int i in copiedList)
            {
                Console.Write(" " + i);
            }
            Console.WriteLine("\n");
        }

        //Задание 3. Удалите дубликаты из несортированного связного списка. Память константна
        static void Delete()
        {
            LinkList list = new LinkList();
            Random rand = new Random();
            for (int y = 0; y < 6; y++)
            {
                list.Add(rand.Next(1, 20));
            }
            Console.WriteLine("Начальный список: \n" + list.ToString());
            list.deleteDups2(list.head);
            Console.WriteLine("Список без дубликатов: \n" + list.ToString());
            Console.WriteLine();
        }
        //Задание 4. Разбейте связный список вокруг некоторого значения так, чтобы все меньше узлы оказались перед узлами,
        //большими или равными этому значению
        static void Partition()
        {
            LinkList list = new LinkList();
            Random rand = new Random();
            for (int y = 0; y < 6; y++)
            {
                list.Add(rand.Next(1, 20));
            }
            Console.WriteLine("Начальный список: \n" + list.ToString());
            Console.Write("Относительно какого элемента отсортировать список? ");
            int k = Int32.Parse(Console.ReadLine());
            list.head = list.partition(list.head, k);
            Console.WriteLine("Отсортированный список: \n" + list.ToString());
            Console.WriteLine();
        }
        //Задание 5. Найдите в односвязном списке к-ый с конца элемент. Есть только операция получения следующего элемента
        //и указатель на первый элемент. Алгоритм должен быть оптимален по времени и памяти
        static void kElement()
        {
            LinkList list = new LinkList();
            Random rand = new Random();
            for (int y = 0; y < 8; y++)
            {
                list.Add(rand.Next(1, 20));
            }
            Console.WriteLine("Начальный список: \n" + list.ToString());
            Console.Write("Какой элемент с конца вы хотите получить?  ");
            int k = Int32.Parse(Console.ReadLine());
            int p = list.findK(list.head, k);
            Console.WriteLine("k-ый с конца элемент: " + p);
            Console.WriteLine();
        }
        //Задание 6. Есть однонаправленный список из структур. В нем random указывает на какой-то элемент списка. Напишите функцию,
        //которая копирует этот список с сохранением структуры. Сложность O(n),константная доп. память + память под элементы нового списка
        static void RandomNode()
        {
            LinkList list = new LinkList();
            Random rand = new Random();
            for (int y = 0; y < 8; y++)
            {
                list.Add(rand.Next(1, 20));
            }
            Console.WriteLine("Начальный список: " + list.ToString());
            list.head = list.copyList(list.head);
            Console.WriteLine("Скопированный список: " + list.ToString());
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №3." +
                "\n Выполнила: Андреева Анна. Группа: 6213-020302D");
            while (true)
            {
                Console.WriteLine("Выберите задание: \n 0)Выход \n 1) Нахождение начала петли \n 2)Копирование двусвязного списка " +
                    "\n 3)Удаление дубликатов \n 4)Сортировка относительно элемента \n 5)Нахождение k-того элемента " +
                    "\n 6)Копирование списка с рандомными связями ");
                Console.Write("Ваш выбор: ");
                string selected = Console.ReadLine();
                Console.WriteLine();
                switch (selected)
                {
                    case "0": return;
                    case "1": FindLoop(); break;
                    case "2": Copy(); break;
                    case "3": Delete(); break;
                    case "4": Partition(); break;
                    case "5": kElement(); break;
                    case "6": RandomNode(); break;
                    default: Console.WriteLine("Введено не то"); break;
                }
                Console.WriteLine("\r\nДля возврата в меню нажмите Enter. Для выхода нажмите 0.");
                Console.Write("Ваш выбор: ");
                string pnt = Console.ReadLine();
                if (pnt == "0")
                    return;
                else
                    Console.Clear();
            }
        }
    }
}
