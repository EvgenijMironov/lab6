using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6 {
    public class product {
        protected string name;
        protected float price;
        public product (string name, float price) {
            this.name = name;
            this.price = price;
        }
        public string Name {
            get { return name; }
        }
        public virtual void search() {
            Console.WriteLine("Class Parent");
        }
    }

    class Food : product {
        private DateTime sellDate; //Дата реализации
        public Food (string name, float price, DateTime sellDate) : base (name, price) {
            this.sellDate = sellDate;
        }
        public override void search() {
            Console.WriteLine($"Название: {name}, цена: {price}, дата реализации: {sellDate}");
        }
    }

    class Household : product {
        private Boolean special; //Особые условия хранения
        private DateTime wPeriod; //Гарантийный срок
        public Household (string name, float price, Boolean special, DateTime wPeriod) : base(name, price) {
            this.special = special;
            this.wPeriod = wPeriod;
        }
        public override void search() {
            Console.WriteLine($"Название: {name}, цена: {price}, особые условия хранения: {special}, Срок годности: {wPeriod}");         
        }
    }

    class Program {
        static void search(List <product>temp, string name) {
            foreach (product t in temp)
                if (name == t.Name) t.search();
        }
        static DateTime getDate() {
            int d, m, y;
            do {
                Console.Write("День: ");
                d = Convert.ToInt32(Console.ReadLine());
            } while (d < 1 || d > 31);
            do {
                Console.Write("Месяц: ");
                m = Convert.ToInt32(Console.ReadLine());
            } while (m < 1 || m > 12);
            do {
                Console.Write("Год: ");
                y = Convert.ToInt32(Console.ReadLine());
            } while (y < 1 || y > 2019);
            return DateTime.Parse($"{d}.{m}.{y}");
        }
        static void Main(string[] args) {
            List<product> products = new List<product>();
            Console.Write("Введите количество товаров: "); int n = Convert.ToInt16(Console.ReadLine());
            for (int  i = 0;  i < n;  i++) {
                Console.Write("Хозяйсвтенный или продуктовый товар? (х/п): "); string t = Console.ReadLine();
                if (t == "х") {
                    Console.Write("Название: ");
                    string name = Console.ReadLine();
                    Console.Write("Цена: ");
                    float price = Convert.ToSingle(Console.ReadLine());
                    Console.Write("Условия хранения: ");
                    bool special = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine("Срок годности");
                    products.Add(new Household(name,price, special, getDate()));            
                } else if (t == "п") {
                    Console.Write("Название: ");
                    string name = Console.ReadLine();
                    Console.Write("Цена: ");
                    float price = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Дата реализации");
                    products.Add(new Food(name, price, getDate()));
                } else {
                    Console.WriteLine("ОШИБКА");
                    i--;
                } Console.WriteLine();
            }
            Console.WriteLine("ТОВАРЫ ВНЕСЕНЫ");

            Console.Write("Введите название искомого товара: ");
            string temp = Console.ReadLine();
            search(products, temp);

            Console.ReadKey();
        }
    }
}
