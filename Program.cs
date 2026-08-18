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


            var customer1 = new VipCustomer(
                "Ahmed Fathy"
            );
            var order1 = new Order(customer1);

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


            var customer2 = new WholesaleCustomer(
                "Ahmed Fawzy"
            );

            var order2 = new Order(customer2);

            order2.AddItem(
                new OrderItem(
                    "Laptop",
                    800.00m,
                    3
                )
            );


            var customer3 = new EmployeeCustomer(
                "youssef samy"
            );

            var order3 = new Order(customer3);

            order3.AddItem(
                new OrderItem(
                    "Monitor",
                    300.00m,
                    2
                )
            );



            bool order1Ok =
                service.ProcessOrder(order1, customer1);

            bool order2Ok =
                service.ProcessOrder(order2, customer2);

            bool order3Ok =
                service.ProcessOrder(order3, customer3);



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
                order3Ok
                    ? $"Order 3: SUCCESS (Id={order3.Id}, Total={order3.Total:C})"
                    : $"Order 3: FAILED - {order3.FailureReason}"
            );


            Console.WriteLine(
                "Done. Check orders.txt and app.log in the output folder."
            );
        }
    }
}