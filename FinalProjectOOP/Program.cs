using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static FinalProjectOOP.Program;

namespace FinalProjectOOP
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(" Введите адрес: ");
            string address = Console.ReadLine();

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
            public Courier(string name = "Иван", string phoneNum = "8(988)456-43-65")
            {
                Name = name;
                PhoneNum = phoneNum;
            }
        }
        class HomeDelivery : Delivery
        {
            Courier courier = new Courier();
            public HomeDelivery(string address) : base(address) { }
            public override void ShowDelivery()
            {
                Console.WriteLine($"К вам выдвигается курьер: {courier.Name} по адресу: {Address}");
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
                Console.WriteLine("Ваша посылка ожидает вас на пункте забора: {0}", Point);
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

        class Order<TDelivery,
        TStruct> where TDelivery : Delivery
        {
            public TDelivery Delivery;

            public int Number;

            public string Description;

            public Order(TDelivery delivery, int number = 01, string description = " ")
            {
                Delivery = delivery;
                Number = number;
                Description = description;
                Console.WriteLine("Ваша корзина собрана:");
                Products.ShowBasket();
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
                for(int i = 0; i < products.Length; i++) 
                {
                    Console.WriteLine(products[i]);
                }
            }
        }
    }
}
