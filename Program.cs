using System;
using NorthWaveConsole.Models;
using NorthWaveConsole.Services;

namespace NorthWaveConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new OrderService();

            

            var order1 = new Order(
                "Ahmed Fathy",
                "VIP"
            );

            order1.AddItem(
                new OrderItem(
                    "Server Rack Unit",
                    450.00m,
                    2
                )
            );

            order1.AddItem(
                new OrderItem(
                    "Network Switch",
                    120.00m,
                    1
                )
            );

            OrderService.Customer customer1 = new OrderService.VipCustomer();


            
            var order2 = new Order(
                "",
                "Wholesale"
            );

            OrderService.Customer customer2 = new OrderService.WholesaleCustomer();


            bool order1Ok = service.ProcessOrder(order1, customer1);

            bool order2Ok = service.ProcessOrder(order2, customer2);



            Console.WriteLine(
                order1Ok
                    ? $"Order 1: SUCCESS (Id={order1.Id}, Total={order1.Total:C})"
                    : $"Order 1: FAILED - {order1.FailureReason}"
            );

            Console.WriteLine(
                order2Ok
                    ? $"Order 2: SUCCESS (Id={order2.Id}, Total={order2.Total:C})"
                    : $"Order 2: FAILED - {order2.FailureReason}"
            );

            Console.WriteLine(
                "Done. Check orders.txt and app.log in the output folder."
            );
        }
    }
}