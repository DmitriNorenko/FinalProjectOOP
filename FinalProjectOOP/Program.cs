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

            bool IsWork = true;
            while (IsWork)
            {
                Console.WriteLine("Выберите вариант доставки(1-3)\n 1 - На дом.\n 2 - Пункт выдачи.\n 3 - Магазин.");
                int.TryParse(Console.ReadLine(), out int i);
                switch (i)
                {
                    case 1:
                        Console.WriteLine(" Введите ваш адрес: ");
                        string address = Console.ReadLine();
                        Courier courier = new Courier();
                        courier.HaveCourier();
                        HomeDelivery homeDelivery = new HomeDelivery(address, courier);
                        Order<HomeDelivery> order1 = new Order<HomeDelivery>(homeDelivery, 673254);
                        homeDelivery.ShowDelivery();
                        Order<HomeDelivery>.ShowTimeDelivery(30);
                        Console.ReadKey();
                        IsWork = false;
                        break;
                    case 2:
                        PickPointDelivery pickPointDelivery = new PickPointDelivery("");
                        Order<PickPointDelivery> order2 = new Order<PickPointDelivery>(pickPointDelivery, 223238);
                        pickPointDelivery.ShowDelivery();
                        Order<PickPointDelivery>.ShowTimeDelivery(60);
                        Console.ReadKey();
                        IsWork = false;
                        break;
                    case 3:
                        ShopDelivery shopDelivery = new ShopDelivery("");
                        Order<ShopDelivery> order3 = new Order<ShopDelivery>(shopDelivery, 332342);
                        shopDelivery.ShowDelivery();
                        Order<ShopDelivery>.ShowTimeDelivery(120);
                        Console.ReadKey();
                        IsWork = false;
                        break;
                    default:
                        Console.WriteLine("Такой доставки нет. Введите корректное значение.");
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
            public HomeDelivery(string address, Courier courier) : base(address)
            {
                this.courier = courier;
            }

            public override void ShowDelivery()
            {
                Console.WriteLine($"\n К вам выдвигается курьер: {courier.Name}.\n по адресу: {Address}.\n Номер телефона: {courier.PhoneNum}.");
            }
        }

        class PickPointDelivery : Delivery
        {
            protected string Point
            {
                get { return "Солнечная 143"; }
                private set { }
            }
            public PickPointDelivery(string address) : base(address)
            {
                Address = Point;
            }
            public override void ShowDelivery()
            {
                Console.WriteLine($"\n Ваша посылка направляется к пункту выдачи: {Address}.");
            }
        }

        class ShopDelivery : Delivery
        {
            public string Point = "Лучезарная 29";
            public ShopDelivery(string address) : base(address)
            {
                Address = Point;
            }
            public override void ShowDelivery()
            {
                Console.WriteLine("\n Ваша посылка направляется к нужному адресу: {0}.", Address);
            }
        }

        class Order<TDelivery> where TDelivery : Delivery
        {
            public TDelivery Delivery;

            public int Number;

            public string Description;

            public Order(TDelivery delivery, int number = 01, string description = " ")
            {
                Delivery = delivery;
                Number = number;
                Description = description;
                Console.WriteLine($" \n Номер вашего заказа: {Number} ");
                Console.WriteLine("\n Ваша корзина собрана:\n");
                Products.ShowBasket();
            }
            public static void ShowTimeDelivery(int time)
            {
                DateDelivery date = new DateDelivery(TimeSpan.FromMinutes(time));
                Console.WriteLine($"\n Приблизительное время доставки: {date.Date}.");
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
