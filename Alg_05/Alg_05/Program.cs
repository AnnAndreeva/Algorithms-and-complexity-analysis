using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_05
{
    class Program
    {
        private static List<Item> items;
        private static Backpack backpack = new Backpack();
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №5. Задача о рюкзаке." +
              "\nВыполнила: Андреева Анна. Группа: 6213-020302D");
            Console.WriteLine("------------------------------------------------------------- ");
            while (true)
            {
                items = new List<Item>();

                items.Add(new Item("Книга", 1, 600));
                items.Add(new Item("Бинокль", 2, 5000));
                items.Add(new Item("Аптечка", 4, 1500));
                items.Add(new Item("Ноутбук", 2, 40000));
                items.Add(new Item("Котелок", 1, 500));
                Console.WriteLine("Список предметов: ");
                foreach (Item it in items) {
                    Console.WriteLine("Название: " + it.name + "  Вес: " + it.weigth + "  Цена:" + it.price);
                }
                Console.WriteLine("------------------------------------------------------------- ");
                Console.Write("Введите максимальный вес рюкзака: ");
                int weight = int.Parse(Console.ReadLine());
                Console.WriteLine("------------------------------------------------------------- ");
                Console.WriteLine("Выберите способ решения: \n 0) Выход \n 1) С повторениями \n 2) Без повторений");
                Console.Write("Ваш выбор: ");
                string selected = Console.ReadLine();
                Console.WriteLine("------------------------------------------------------------- ");
                Console.WriteLine();
                switch (selected)
                {
                    case "0": return;
                    case "1":
                        {                            
                            Console.WriteLine("Максимальная стоимость предметов: " + backpack.withRepeats(items, weight));
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Максимальная стоимость предметов: " + backpack.withoutRepeats(items, weight));
                            break;
                        }
                    default: Console.WriteLine("Введено не верное значение"); break;
                }
                Console.WriteLine("------------------------------------------------------------- ");
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
