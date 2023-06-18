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

        }
        public struct Courier
        {
            public string Name;
            string PhoneNumber;

            public Courier(string name = "Tom",string phoneNumber = "8(988)312-76-43") 
            {
                Name = name;
                PhoneNumber = phoneNumber;
            }
            public void ShowCourier() 
            {
                Console.WriteLine("Ваш курьер:{0}, Номер телефона:{1}",Name,PhoneNumber);
            }
        }
        abstract class Delivery
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

            }
        }
        class PickPointDelivery : Delivery
        {
            public PickPointDelivery(string text) : base(text) { }
        }
        class ShopDelivery : Delivery
        {
            public ShopDelivery(string text) : base(text) { }
        }
        class Order < TDelivery,TStruct> where TDelivery : Delivery
        {
            public TDelivery Delivery;
            public int Number;
            public string Description;

            public void DisplayAddress()
            {
                Console.WriteLine(Delivery.Address);
            }
        }
       
        class OrderCollection : Order<Delivery, Courier>
        { 
            
        }
        class Product
        {
            string[] product = new string[] { "Кукуруза", "Овсянка", "Помидор", "Минеральная вода" };
        }
    }
}
