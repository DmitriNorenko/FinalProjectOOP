using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static FinalProjectOOP.Program;

namespace FinalProjectOOP
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(" Введите ваш адрес: ");
            string address = Console.ReadLine();
            bool IsWork = true;
            while (IsWork)
            {
                Console.WriteLine("Выберите вариант доставки(1-3)");
                int i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        Courier courier = new Courier();
                        courier.HaveCourier();
                        HomeDelivery homeDelivery = new HomeDelivery(address,courier);
                        Order<HomeDelivery, Courier> order1 = new Order<HomeDelivery, Courier>(homeDelivery);
                        homeDelivery.ShowDelivery();
                        IsWork = false;
                        break;
                }
            }
        }
        abstract class Delivery
        {
            public string Address;
            public Delivery(string address)
            {
                Address = address;
            }
            public virtual void ShowDelivery()
            {
                Console.WriteLine($" Ваш адрес доставки:{Address} ");
            }
        }
        public struct Courier
        {
            public string Name;
            public string PhoneNum;
            public void HaveCourier(string name = "Иван", string phoneNum = "8(988)456-43-65")
            {
                Name = name;
                PhoneNum = phoneNum;
            }
        }
        class HomeDelivery : Delivery
        {
            Courier courier;
            public HomeDelivery(string address,Courier courier) : base(address)
            {
            this.courier = courier;
            }

            public override void ShowDelivery()
            {
                Console.WriteLine($"\n К вам выдвигается курьер: {courier.Name}\n по адресу: {Address}\n Номер телефона: {courier.PhoneNum}");
            }
        }
        class PickPointDelivery : Delivery
        {
            protected string Point
            {
                get { return "Солнечная 143"; }
                private set { }
            }
            public PickPointDelivery(string address) : base(address) { }
            public override void ShowDelivery()
            {
                Console.WriteLine("Ваша посылка прибудет на пункт выдачи через {0}");
            }
        }

        class ShopDelivery : Delivery
        {
            protected string Point = "Лучезарная 29";
            ShopDelivery(string address) : base(address)
            {
                Console.WriteLine();
            }
            public override void ShowDelivery()
            {
                Console.WriteLine("Ваша посылка прибыла по нужному адресу.", Point);
            }
        }

        class Order<TDelivery, TStruct> where TDelivery : Delivery
        {
            public TDelivery Delivery;

            public int Number;

            public string Description;

            TStruct courier;
            public Order(TDelivery delivery, int number = 01, string description = " ")
            {
                Delivery = delivery;
                Number = number;
                Description = description;
                Console.WriteLine($" \n Номер вашего заказа: {Number} ");
                Console.WriteLine("\n Ваша корзина собрана:\n");
                Products.ShowBasket();

                ShowTimeDelivery(30);
            }
            public static void ShowTimeDelivery(int time)
            {
                DateDelivery date = new DateDelivery(TimeSpan.FromMinutes(time));
                Console.WriteLine($"\n Приблизительное время доставки: {date.Date}");
            }
        }
        struct DateDelivery
        {
            public DateTime Date;

            public DateDelivery(TimeSpan time)
            {
                Date = DateTime.Now + time;
            }
        }
        public class Products
        {
            public static string[] products = { "Мясо", "Хлеб", "Молоко", "Зелень" };

            public string this[int index]
            {
                get
                {
                    if (index < 0 && index > products.Length)
                    {
                        return products[index];
                    }
                    else
                    {
                        Console.WriteLine("Товара под таким индексом нет.");
                        return null;
                    }
                }
                private set { }
            }
            public static void ShowBasket()
            {
                for (int i = 0; i < products.Length; i++)
                {
                    Console.WriteLine(products[i]);
                }
            }
        }
    }
}
