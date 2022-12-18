using System.Runtime.ConstrainedExecution;
using System;
using System.Reflection;


namespace Lib
{
    interface IListQueue
    {
        public void Add(State state);
        public State? Remove();
        public void GetMassive();
    }
    public class State
    {
        private string? name = "Undefined";
        public string? Name
        {
            set
            {
                if (value != "")
                    name = value;
                else
                    throw new Exception("Это поле не может быть пустым!");
            }
            get { return name; }
        }

        private string? capital = "Undefined";
        public string? Capital
        {
            set
            {
                if (value != "")
                    capital = value;
                else
                    throw new Exception("Это поле не может быть пустым!");
            }
            get { return capital; }
        }

        private int? populationSize = 0;
        public int? PopulationSize
        {
            set
            {
                if (value > 0)
                    populationSize = value;
                else
                    throw new Exception("Это поле не может быть отрицательным!");
            }
            get { return populationSize; }
        }
        private int? square = 0;
        public int? Square
        {
            set
            {
                if (value > 0)
                    square = value;
                else
                    throw new Exception("Это поле не может быть отрицательным!");
            }
            get { return square; }
        }
        private static int? minPopulationSize { get; } = 1000000;

        public State()
        {
            this.name = "Undefined";
            this.capital = "Undefined";
            this.populationSize = 0;
            this.square = 0;
        }
        public State(string name, string capital, int populationSize, int square)
        {
            Name = name;
            Capital = capital;
            PopulationSize = populationSize;
            Square = square;
        }

        public static void CheckPopulationSize(State state)
        {
            if (state.populationSize < minPopulationSize)
                Console.WriteLine("Малое гос-во!");
            else
                Console.WriteLine("Крупное гос-во!");
        }

        public override string ToString()
        {
            return name + " " + capital + " " + populationSize + " " + square;
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
    public class Node
    {
        public State? Data { get; set; }
        public Node? Next { get; set; }
        public Node? Prev { get; set; }
        public override string? ToString()
        {
            return Data?.ToString();
        }
    }
    public class ListQueue : IListQueue
    {
        public delegate void Handler(string message);
        public event Handler? Notify;

        private Node? head = null;
        private Node? tail = null;
        int count = 0;
        public int Count
        {
            get { return count; }
            private set
            {
                if (count < 0) throw new ArgumentNullException();
                count = value;
            }
        }
        public void CountReturn()
        {
            int countt = 0;
            Node? cur = head;
            for (int i = 0; i < count; i++)
            {
                if (cur?.Data is not null)
                    countt++;
                cur = cur?.Next;
            }
            Console.WriteLine($"Количество непустых элементов: {countt}");
        }
        public State? NullData(int index)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (head is null || tail is null)
            {
                Console.WriteLine("Список пуст");
                return null;
            }
            if (index >= count)
            {
                return null;
            }

            Node? cur = head;
            for (int i = 0; i < count; i++)
            {
                if (index == i)
                {
                    State? state = cur?.Data;

                    Notify.Invoke($"Занулен элемент [{state}]");

                    cur!.Data = null;
                    return state;
                }
                cur = cur?.Next;
            }
            return null;
        }
        public void Add(State? state)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < Count; i++)
            {
                if (head is null || tail is null) break;

                if (Get(i) is null)
                {
                    Set(state, i);
                    return;
                }
            }
            Node? node = new()
            {
                Data = state
            };
            if (head is null)
                head = node;
            else if (head.Next is null)
                head.Next = node;

            if (tail is not null)
                tail.Next = node;
            node.Prev = tail;
            tail = node;

            Notify.Invoke($"Добавлен новый элемент [{state}]");

            count++;
        }
        public void Add(State?[] mas)
        {
            foreach (var state in mas)
            {
                this.Add(state);
            }
        }
        public State? Remove()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (head == null || tail == null)
            {
                Console.WriteLine("Список пуст!");
                tail = null;
                return null;
            }
            var state = head.Data;

            Notify.Invoke($"Удален элемент [{state}]");

            if (state == null)
            {
                return null;
            }
            head = head.Next;
            head!.Prev = null;


            count--;
            return state;
        }
        public State? Get(int index)
        {
            if (head is null || tail is null)
            {
                Console.WriteLine("Список пуст");
                return null;
            }
            if (index >= count)
            {
                return null;
            }

            Node? cur = head;
            for (int i = 0; i < count; i++)
            {
                if (index == i)
                {
                    return cur?.Data;
                }
                cur = cur?.Next;
            }
            return null;
        }
        public void Set(State? state, int index)
        {
            if (head is null || tail is null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            if (index >= count)
            {
                return;
            }

            Node? cur = head;
            for (int i = 0; i < count; i++)
            {
                if (index == i)
                {
                    cur!.Data = state;
                    return;
                }
                cur = cur?.Next;
            }
            return;
        }
        public void GetMassive()
        {
            Print();
        }
        public void Sort()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 1; i < count; i++)
            {
                State? cur = Get(i);

                if (cur is null)
                {
                    Console.Write("");
                }

                for (int j = i; j >= 0; j--)
                {
                    Set(Get(j - 1), j);
                    if (j == 0)
                    {
                        Set(cur, j);
                        break;
                    }
                    if (cur is null ||
                        cur.ToString()[0] >= Get(j - 1)?.ToString()[0])
                    {
                        Set(cur, j);
                        break;
                    }
                }
            }
            Notify.Invoke("Список был отсортирован");
        }
        private void Print()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Node? cur = head;
            Console.WriteLine("====================================");
            for (int i = 0; i < count; i++)
            {
                if (cur?.Data is null)
                {
                    Console.WriteLine("null");
                }
                else
                {
                    Console.WriteLine(cur?.Data?.ToString());
                }
                cur = cur?.Next;
            }
            Console.WriteLine("====================================");
            Notify.Invoke("\nБыл выведен массив");
        }
        public void Search(string str)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Node? cur = head;
            for (int i = 0; i < count; i++)
            {
                if (str == cur?.Data?.Name)
                {
                    //Console.Write("\nРезультат поиска: ");
                    //Console.Write(cur?.Data);
                    Notify.Invoke($"Был найден элемент [{cur?.Data}]");
                }
                cur = cur?.Next;
            }
        }
    }
}