using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectOOP
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите тип доставки(1-3): 1- Доставка на дом.\n 2- Доставка в пункт выдачи.\n 3- Доставка в магазин.\n");
            int num = int.Parse(Console.ReadLine());
            bool work = true;
            while (work)
            {
                switch (num)
                {
                    case 1:
                        HomeDelivery homeDelivery;
                        homeDelivery.RegistrationOfDelivery("Пушкина 18");
                        work = false;
                        break;
                    case 2:
                        PickPointDelivery pickPointDelivery = new PickPointDelivery("Ленина 46");
                        work = false;
                        break;
                    case 3:
                        ShopDelivery shopDelivery = new ShopDelivery("Лермонтова 21");
                        work = false;
                        break;
                    default:
                        Console.WriteLine("Вы ввели неправильное значение.");
                        break;
                }
            }
        }
        public struct Courier
        {
            public string Name;
            string PhoneNumber;

            public Courier(string name = "Tom", string phoneNumber = "8(988)312-76-43")
            {
                Name = name;
                PhoneNumber = phoneNumber;
            }
            public void ShowCourier()
            {
                Console.WriteLine("Ваш курьер:{0}, Номер телефона:{1}", Name, PhoneNumber);
            }
        }

        public abstract class Delivery
        {
            public string Address;

            public Delivery(string text)
            {
                Address = text;
            }
        }

        class HomeDelivery : Delivery
        {
            public HomeDelivery(string text) : base(text)
            {
                Console.WriteLine("Вы вызвали доставку на дом.");
            }
            public void RegistrationOfDelivery(string Street) 
            {
            
            }
        }

        class PickPointDelivery : Delivery
        {
            PickPointDelivery pickPointDelivery = new PickPointDelivery("Ленина 46");
            public PickPointDelivery(string text) : base(text)
            {
                Console.WriteLine("Вы выбрали доставку в пункт выдачи.");
                Order<PickPointDelivery, Courier> order2 = new Order<PickPointDelivery, Courier>(pickPointDelivery, 02);
            }
        }

        class ShopDelivery : Delivery
        {
            ShopDelivery shopDelivery = new ShopDelivery("Лермонтова 21");
            public ShopDelivery(string text) : base(text)
            {
                Console.WriteLine("Вы выбрали доставку в магазин.");
                Order<ShopDelivery, Courier> order3 = new Order<ShopDelivery, Courier>(shopDelivery, 03);
            }
        }

        class Order<TDelivery, TStruct> where TDelivery : Delivery
        {
            public TDelivery Delivery;
            public int Number;
            public string Description;

            public Order(TDelivery delivery, int number = 01, string description = " ")
            {
                Delivery = delivery;
                Number = number;
                Description = description;
                OrderCollection orderCollection = new OrderCollection();
            }
            public void DisplayAddress()
            {
                Console.WriteLine(Delivery.Address);
            }
        }

        class OrderCollection
        {
            private Product Products;

            public OrderCollection()
            {
                Products = new Product();
                Courier courier = new Courier();
                courier.ShowCourier();
            }

        }
        class Product
        {
            public Product()
            {
                Console.WriteLine("Ваша корзина с продуктами собрана и ожидает курьера.");
            }
        }
    }
}
