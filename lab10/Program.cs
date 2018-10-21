using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

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

            #region Task3
            List<Flower> listFlower = new List<Flower>() { new Flower("Rose", "Red"), new Flower("Rose", "White"), new Flower("Gladiolus", "Yellow")};
            PrintCollection(list);
            list.RemoveRange(2, 2);
            PrintCollection(listFlower);

            listFlower.Add(new Flower("Cactus", "Green"));
            listFlower.AddRange(new List<Flower>() { new Flower("123"), new Flower("123")});
            listFlower.Insert(0, new Flower("Second flower"));
            listFlower.InsertRange(1, new List<Flower>() { new Flower("kek"), new Flower("lol")});
            PrintCollection(listFlower);

            Stack<Flower> stackFlower = new Stack<Flower>(listFlower);
            PrintCollection(stackFlower);
            Console.WriteLine("Введите элемент для поиска в стеке");
            x = Console.ReadLine();
            FindElement(x, stackFlower);


            #endregion

            #region Task 4

            ObservableCollection<Flower> obs = new ObservableCollection<Flower>(listFlower);

            obs.CollectionChanged += Obs_CollectionChanged;
            obs.Add(new Flower("Red Rose", "Red"));
            obs.RemoveAt(1);

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

        private static void Obs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {

                case NotifyCollectionChangedAction.Add:
                    Flower newFlower = e.NewItems[0] as Flower;
                    Console.WriteLine("Добавлен новый цветок:\n {0}", newFlower.ToString());
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Flower oldFlower = e.OldItems[0] as Flower;
                    Console.WriteLine("-----------------------Цветок удалён----------------------\n" + oldFlower.ToString() );
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
            }
        }
    }
}