namespace Custom_Generic_Class_with_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database<int, string> db = new Database<int, string>();

            db.Add(1, "One");
            db.Add(2, "Two");
            db.Add(3, "Three");
            db.Add(4, "Four");

            Console.WriteLine("Before remove.");
            Console.WriteLine($"Count {db.Count}");

            string value;
            if (db.TryGetValue(1, out value))
            {
                Console.WriteLine($"Value for key 2: {value}");
            }

            db.Remove(1);

            Console.WriteLine("After remove.");
            Console.WriteLine($"Count {db.Count}");

            int a = 1, b = 2;
            Swap(ref a, ref b);
            Console.WriteLine($"a = {a}, b = {b}");

            MyClass c1 = new MyClass(1, 10), c2 = new MyClass(2, 20);

            Swap(ref c1, ref c2);

            System.Console.WriteLine($"c1.Value = {c1.Id} c2.Value = {c2.Id}");

        }

        static void Swap<T>(ref T a, ref T b)
        {
            T Temp = a;
            a = b;
            b = Temp;
        }

        class MyClass
        {
            public int Value { get; set; }
            public int Id { get; set; }

            public MyClass(int value, int id)
            {
                Value = value;
                Id = id;
            }
        }

    }
}
