using System;

namespace lab6._2 {
    class Provider {
        private string providerName;
        private string[] productName;
        private float[] productPrice;
        public Provider(string providerName) {
            this.providerName = providerName;
            Console.Write("Количество продуктов: "); 
            int productCount = Convert.ToInt32(Console.ReadLine());
            productName = new string[productCount];
            productPrice = new float[productCount];
            for (int i = 0; i < productCount; i++) {
                Console.Write($"Введите название {i+1} продукта: "); productName[i] = Console.ReadLine();
                Console.Write($"Введите цену {i+1} продукта: "); productPrice[i] = Convert.ToSingle(Console.ReadLine());
            } Console.WriteLine($"Поставщик {this.providerName} создан");
        }
        public float this[string name] {
            get {
                int index = Array.IndexOf(productName, name);
                while (index == -1) {
                    Console.WriteLine("Нет такого товара!");
                    Console.Write("Цену какого товара вы хотели бы узнать: ");
                    name = Console.ReadLine();
                    index = Array.IndexOf(productName, name);
                }
                return productPrice[index];
            }
        }
    }
    class Program {
        static void Main(string[] args) {
            Console.Write("Введите имя поставщика: "); string pName = Console.ReadLine();
            Provider A = new Provider(pName);
            Console.Write("Цену какого товара вы хотели бы узнать: ");
            string searchName = Console.ReadLine();
            Console.WriteLine($"Цена = {A[searchName]}");
            Console.ReadKey();
        }
    }
}
