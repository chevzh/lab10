using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {

            #region ArrayList
            ArrayList arr = new ArrayList() {1,2,4,8,6};
            arr.Add("string");

            Console.WriteLine("Введите элемент, который хотите удалить");
            var x = Console.ReadLine();

            try
            {
                arr.Remove(Convert.ToInt32(x));
            }
            catch (FormatException)
            {
                arr.Remove(x);
            }
            PrintCollection(arr);

            Console.WriteLine("Введите значение элемента для поиска");
            x = Console.ReadLine();
            FindElement(x, arr);         
            #endregion


            #region Task2
            List<float> list = new List<float>() {1.2f, 3.4f, 9.5f, 5.2f, 7.1f };
            PrintCollection(list);
            list.RemoveRange(2, 2);
            PrintCollection(list);

            list.Add(4.2f);
            list.AddRange(new List<float>(){ 5.2f, 4.9f, 9.3f });
            list.Insert(0, 1.1f);
            list.InsertRange(1, new List<float>() { 99.4f, 88.4f });
            PrintCollection(list);

            Stack<float> stack = new Stack<float>(list);
            PrintCollection(stack);
            Console.WriteLine("Введите элемент для поиска в стеке");
            x = Console.ReadLine();
            FindElement(x, stack);

           
            #endregion

            void FindElement(string element, ICollection arrayList)
            {
                bool flag = false;

                foreach (var el in arrayList)
                {
                    if (el.ToString().Equals(element.ToString()))
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    Console.WriteLine("Элемент найден");
                }
                else
                {
                    Console.WriteLine("Элемент не найден");

                }
            }

            void PrintCollection(ICollection listT)
            {
                int counter = 1;

                foreach (var item in listT)
                {

                    if (counter == listT.Count)
                    {
                        Console.Write(item + ";\n");
                    }
                    else
                    {
                        Console.Write(item + ", ");
                        counter++;
                    }

                }
            }

        }
    }
}
