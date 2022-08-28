using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_04
{
    //Задание 2. Реализуйте «вручную» стек со стандартными функциями push/pop и дополнительной функцией min, возвращающей минимальный
    //элемент стека. Все эти функции должны работать за O(1). Память должна быть оптимальна.

    public class StackWithMin : Stack<int>
    {
        Stack<int> s2;
        public StackWithMin()
        {
            s2 = new Stack<int>();//дополнительный стек, который будет отслеживать минимумы.
        }

        public void push(int value)
        {
            if (value <= min())
            {
                s2.Push(value);
            }
            this.Push(value);

        }

        public int pop()
        {
            int value = this.Pop();
            if (value == min())
            {
                s2.Pop();
            }
            return value;
        }

        public int peek()
        {            
            return this.Peek();
        }

        public int min()
        {
            if (s2.Count == 0)
            {
                return int.MaxValue;
            }
            else
            {
                return s2.Peek();
            }
        }
    }
}
