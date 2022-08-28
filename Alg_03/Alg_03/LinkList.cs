using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_03
{
    //элемент списка
    public class Node
    {
        public int info;
        public Node Next { get; set; }
        public Node Random { get; set; }
        public Node()
        { }
        public Node(int info)
        {
            this.info = info;
        }
    }
    class LinkList
    {

        public Node head;
        public int count;
        public LinkList()
        {
            head = null;
        }
        //вывод списка
        public override string ToString()
        {
            if (head == null)
                return "Список пуст!";
            Node curr = head;
            string str = head.info.ToString();
            while (curr.Next != null)
            {
                curr = curr.Next;
                str = str + ' ' + curr.info.ToString();
            }
            return str;
        }
        //добаляем элемент списка
        public void Add(int a)
        {
            if (head != null)
            {
                Node p = head;
                while (p.Next != null)
                {
                    p = p.Next;
                }
                p.Next = new Node(a);
            }
            else
            {
                head = new Node(a);
            }
            count++;
            Rand();
        }
        public void Rand()//добавляем рандомную ссылку для каждого элемента
        {
            Random rand = new Random();
            Node q = head;
            while (q != null)
            {
                Node p = head;
                int k = 1;
                int search = rand.Next(1, count);
                while (k != search)
                {
                    p = p.Next;
                    k++;
                }
                q.Random = p;
                q = q.Next;
            }
        }

        //Задание 1. Дан однонаправленный список с петлей. Его последний элемент содержит указатель на один из элементов этого списка.
        //Найдите начальный узел петли
        public Node FindBegining(Node head)//поиск начала петли, сложность O(n)
        {
            Node slow = head;
            Node fast = head;

            //Находим первую точку встречи LOOP_SIZE-k шагов по связному списку.
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;//сдвигаемм на 1 шаг
                fast = fast.Next.Next;//сдвигаемм на 2 шага
                if (slow == fast)//столкновение
                    break;
            }

            // Ошибка - нет точки встречи, следовательно, нет петли 
            if (fast == null || fast.Next == null)
                return null;

            //Перемещаем медленный бегунок в начало списка (Head). Быстрый остается в точке встречи.
			//Если указатели продолжат движение с той же скоростью, то встретятся в точке Loop Start
            slow = head;
            while (slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next;
            }

            // Возвращаем точку начала петли. 
            return fast;
        }
        //Задание 3. Удалите дубликаты из несортированного связного списка. Память константна
        public void deleteDups1(Node head)//удаление дубликатов, сложность O(n^2)
        {
            if (head == null) return; //если список пуст

            //используем 2 элемента для проверки
            Node current = head;//значение текущего элемента, работает через связный список
            while (current != null)
            {
                // Удаляем все следующие элементы с таким же значением 
                Node runner = current;//проверяет все последующие узлы на наличие дубликатов
                while (runner.Next != null)
                {
                    if (runner.Next.info == current.info)
                    {
                        runner.Next = runner.Next.Next;
                    }
                    else
                    {
                        runner = runner.Next;
                    }
                }
                current = current.Next;
            }
        }
        public void deleteDups2(Node head)//удаление дубликатов, сложность O(n)
        {
            Hashtable table = new Hashtable();
            Node previous = null;
           // выполняется проход по списку, каждый элемент которого добавляется в хэш - таблицу
            while (head != null)
            {
               // Когда обнаруживается повторяющийся элемент, он удаляется, и цикл продолжает работу
                if (table.ContainsKey(head.info))
                {
                    previous.Next = head.Next;
                }
                else
                {
                    table.Add(head.info, true);
                    previous = head;
                }
                head = head.Next;
            }
        }

        //Задание 4. Разбейте связный список вокруг некоторого значения так, чтобы все меньше узлы оказались перед узлами,
        //большими или равными этому значению
        public Node partition(Node node, int x) // сложность O(n)
        {
            Node beforeStart = null;
            Node beforeEnd = null;

            Node afterStart = null;
            Node afterEnd = null;

            // Разбиваем список 
            while (node != null)
            {
                Node next = node.Next;
                node.Next = null;
                if (node.info < x)
                {
                    // Вставляем узел в конец списка before
                    if (beforeStart == null)
                    {
                        beforeStart = node;
                        beforeEnd = beforeStart;
                    }
                    else
                    {
                        beforeEnd.Next = node;
                        beforeEnd = node;
                    }
                }
                else
                {
                    // Вставляем узел в конец списка after
                    if (afterStart == null)
                    {
                        afterStart = node;
                        afterEnd = afterStart;
                    }
                    else
                    {
                        afterEnd.Next = node;
                        afterEnd = node;
                    }
                }
                node = next;
            }

            if (beforeStart == null)
            {
                return afterStart;
            }

            // Слияние списков before и after 
            beforeEnd.Next  = afterStart;
            return beforeStart;
        }
        //Задание 5. Найдите в односвязном списке к-ый с конца элемент. Есть только операция получения следующего элемента
        //и указатель на первый элемент. Алгоритм должен быть оптимален по времени и памяти
        public int findK(Node head, int k) //сложность O(n)
        {
            if (k <= 0) return 0;

            Node p1 = head;
            Node p2 = head;

            // перемещаем p2 на k узлов вперед
            for (int i = 0; i < k - 1; i++)
            {
                if (p2 == null) return 0;
                p2 = p2.Next;
            }

            if (p2 == null) return 0;

            //Теперь мы начинаем перемещать оба указателя одновременно.Когда p2 дойдет до конца списка, p1 будет указывать на нужный нам элемент
            while (p2.Next != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }
            return p1.info;
        }

        //Задание 6. Есть однонаправленный список из структур. В нем random указывает на какой-то элемент списка. Напишите функцию,
        //которая копирует этот список с сохранением структуры. Сложность O(n),константная доп. память + память под элементы нового списка
        public Node copyList(Node head)//cложность O(n)
        {
            //Делаем обход списка, создаём дубликаты узлов и вставляем их по next, получая 2*N элементов, каждый нечётный ссылается на свой дубликат.
            for (Node cur = head; cur != null; cur = cur.Next)
            {
                Node dup = new Node();
                dup.info = cur.info;
                dup.Next = cur.Random;
                cur.Random = dup;
            }

            Node result = head.Random;

            //Делаем второй обход списка, в каждом чётном узле random = random.next.
            for (Node cur = head; cur.Next != null; cur = cur.Next)
            {
                Node dup = cur.Random;
                dup.Random = cur.Next.Random;
            }

            //Делаем третий обход списка, в каждом узле next = next.next
            for (Node cur = head; cur != null; cur = cur.Next)
            {
                Node dup = cur.Random;
                cur.Random = dup.Next;
                dup.Next = cur.Next != null ? cur.Next.Random : null;
            }
            return result;
        }
    }
}
