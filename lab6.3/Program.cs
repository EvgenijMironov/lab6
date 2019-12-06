using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6._3 {
    class Tour {
        protected string vName;
        protected string location;
        protected int days;
        protected float price;
        public Tour(string vName, string location, int days, float price) {
            this.vName = vName;
            this.location = location;
            this.days = days;
            this.price = price;
        }
        public string VName {
            get { return vName; }
        }
        public int Days { 
            get { return days; }
        }
        public virtual void getInfo() {
            Console.WriteLine($"Название: {vName}\n" +
                $"Страна: {location}\n" +
                $"Срок: {days} дней\n" +
                $"Цена: {price}");
        }
    }

    class TravelV : Tour {
        protected string hotelName;
        public TravelV(string vName, string location, int days, float price, string hotelName) : base(vName, location, days, price) {
            this.hotelName = hotelName;
        }
        public override void getInfo() {
            Console.WriteLine($"Название путевки: {vName}\n" +
                $"Страна: {location}\n" +
                $"Срок: {days} дней\n" +
                $"Цена: {price}\n" +
                $"Название отеля: {hotelName}");
        }
    }

    class SanatoriumV : Tour {
        protected string organisationName;
        public SanatoriumV(string vName, string location, int days, float price, string organisationName) : base(vName, location, days, price) {
            this.organisationName = organisationName;
        }
        public override void getInfo() {
            Console.WriteLine($"Название путевки: {vName}\n" +
                $"Страна: {location}\n" +
                $"Срок: {days} дней\n" +
                $"Цена: {price}\n" +
                $"Название организации: {organisationName}");
        }
    }
    class Program {
        static void search(List<Tour> temp, string vName, int days) {
            foreach (Tour t in temp)
                if (vName == t.VName && days == t.Days)
                {
                    t.getInfo(); break;
                }
                else
                {
                    Console.WriteLine("НЕ НАЙДЕНО!!!!!!!!");
                }
        }
        static void Main(string[] args) {
            List<Tour> t = new List<Tour>();
            Console.Write("Введите количество путевок: "); int n = Convert.ToInt16(Console.ReadLine());
            for (int i = 0; i < n; i++) {
                Console.Write("Туристическая или санаторная?(т/с) "); string type = Console.ReadLine();
                if (type == "т") {
                    Console.Write("Название путевки: "); string VName = Console.ReadLine();
                    Console.Write("Куда едем?: "); string Location = Console.ReadLine();
                    Console.Write("На сколько дней?: "); int Days = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Цена: "); float Price = Convert.ToSingle(Console.ReadLine());
                    Console.Write("Название отеля: "); string HotelName = Console.ReadLine();
                    t.Add(new TravelV(VName, Location, Days, Price, HotelName));
                } else if (type == "с") {
                    Console.Write("Название путевки: "); string VName = Console.ReadLine();
                    Console.Write("Куда едем?: "); string Location = Console.ReadLine();
                    Console.Write("На сколько дней?: "); int Days = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Цена: "); float Price = Convert.ToSingle(Console.ReadLine());
                    Console.Write("Название организации: "); string OrganisationName = Console.ReadLine();
                    t.Add(new SanatoriumV(VName, Location, Days, Price, OrganisationName));
                } else { Console.WriteLine("ОШИБКА!!!!!!"); i--; }
            }
            Console.WriteLine("ПОИСК");
            Console.Write("Введите название путевки: "); string vName = Console.ReadLine();
            Console.Write("Введите количество дней: "); int days = Convert.ToInt32(Console.ReadLine());
            search(t, vName, days);
            Console.ReadKey();
        }
    }
}
