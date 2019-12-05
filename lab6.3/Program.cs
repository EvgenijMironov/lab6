using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6._3
{
    //TODO:
    // 1. Сделать два подкласса
    // 2. Сделать виртуальный метод
    // 3. Сделать поиск

    class Tour
    {
        private string location;
        private int days;
        private string type;
        private float priceRoad;
        private float priceFood;
        private float priceHotel;
        private float priceSum;
        private float priceAvg;

        public Tour(string location, int days, string type, float priceRoad, float priceFood, float priceHotel)
        {
            this.location = location;
            this.days = days;
            this.type = type;
            this.priceRoad = priceRoad;
            this.priceFood = priceFood;
            this.priceHotel = priceHotel;

            this.priceSum = priceRoad + ((priceFood + priceHotel) * days);
            this.priceAvg = (float)priceSum / days;
        }

        public Tour() { }

        public string Location
        {
            get { return location; }
            set
            {
                if (value != "") location = value;
                else Console.WriteLine("Input Error");
            }
        }

        public int Days
        {
            get { return days; }
            set
            {
                if (value > 0) days = value;
                else Console.WriteLine("Input Error");
            }
        }

        public string Type
        {
            get { return type; }
            set
            {
                if (value is string && (value == "туристическая" || value == "санаторная")) type = value;
                else Console.WriteLine("Input Error");
            }
        }

        public float PriceRoad
        {
            get { return priceRoad; }
            set
            {
                if (value > 0) priceRoad = value;
                else Console.WriteLine("Input Error");
            }
        }

        public float PriceFood
        {
            get { return priceFood; }
            set
            {
                if (value > 0) priceFood = value;
                else Console.WriteLine("Input Error");
            }
        }

        public float PriceHotel
        {
            get { return priceHotel; }
            set
            {
                if (value > 0) priceHotel = value;
                else Console.WriteLine("Input Error");
            }
        }

        public float PriceSum
        {
            get
            {
                priceSum = priceRoad + ((priceFood + priceHotel) * days);
                return priceSum;
            }
        }

        public float PriceAvg
        {
            get
            {
                priceAvg = (float)priceSum / days;
                return priceAvg;
            }
        }
    }

    class Program
    {
        static void search(List<Tour> temp, string name) {
            foreach (Tour t in temp) { }
        }
        static void Main(string[] args) {
            List<Tour> t = new List<Tour>();
            Console.Write("Введите количество путевок: "); int n = Convert.ToInt16(Console.ReadLine());
            for (int i = 0; i < n; i++) {
                Console.Write("Куда едем?: "); string Location = Console.ReadLine();
                Console.Write("На сколько дней?: "); int Days = Convert.ToInt32(Console.ReadLine());
                Console.Write("Туристическая или санаторная путевка?: "); string Type = Console.ReadLine();
                Console.Write("Цена дороги: "); float PriceRoad = Convert.ToSingle(Console.ReadLine());
                Console.Write("Цена еды: "); float PriceFood = Convert.ToSingle(Console.ReadLine());
                Console.Write("Цена проживания: "); float PriceHotel = Convert.ToSingle(Console.ReadLine());
                t.Add(new Tour(Location, Days, Type, PriceRoad, PriceFood, PriceHotel));
            }
            Console.ReadKey();
        }
    }
}
