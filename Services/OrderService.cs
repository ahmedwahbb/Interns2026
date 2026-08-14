using System;
using System.IO;
using NorthWaveConsole.Models;

namespace NorthWaveConsole.Services
{
    public class OrderService
    {
        private static int _nextId = 1;


        public class Customer
        {
            public virtual decimal GetDiscountMultiplier()
            {
                return 1.0m;
            }
        }

        public class VipCustomer : Customer
        {
            public override decimal GetDiscountMultiplier()
            {
                return 0.8m;
            }
        }

        public class WholesaleCustomer : Customer
        {
            public override decimal GetDiscountMultiplier()
            {
                return 0.85m;
            }
        }

        public class EmployeeCustomer : Customer
        {
            public override decimal GetDiscountMultiplier()
            {
                return 0.5m;
            }
        }



        public decimal CalculateSubtotal(Order o)
        {
            decimal total = 0;

            for (int i = 0; i < o.Items.Count; i++)
            {
                total += o.Items[i].GetSubtotal();
            }

            return total;
        }



        public decimal CalculateTotal(Order o, Customer customer)
        {
            decimal subtotal = CalculateSubtotal(o);

            decimal discountMultiplier =
                customer.GetDiscountMultiplier();

            decimal finalTotal = subtotal * discountMultiplier;

            return finalTotal;
        }

//////////////////////////////////////////////////////////////////////////////////

   public bool ProcessOrder(Order o, Customer customer)
{
    if (o.Items.Count == 0)
    {
        o.SetFailureReason("Order has no items.");
        return false;
    }

    if (string.IsNullOrWhiteSpace(o.CustomerName))
    {
        o.SetFailureReason("Customer name is required.");
        return false;
    }

    o.SetId(_nextId);
    _nextId++;

    o.SetStatus("New");

    decimal total = CalculateTotal(o, customer);
    o.SetTotal(total);

    try
    {
        SaveToFile(o, total);
        SendConfirmationEmail(o, total);
        LogToFile("Order processed: " + o.Id);

        return true;
    }
    catch (Exception ex)
    {
        o.SetFailureReason(ex.Message);
        return false;
    }
}


/////////////////////////////////////////////////////////////////////////
        private void SaveToFile(Order o, decimal total)
        {
            File.AppendAllText(
                "orders.txt",
                $"{o.Id}," +
                $"{o.CustomerName}," +
                $"{o.CustomerType}," +
                $"{total}," +
                $"{o.Status}" +
                $"{Environment.NewLine}"
            );
        }



        private void SendConfirmationEmail(Order o, decimal total)
        {
            Console.WriteLine(
                $"[EMAIL] To: {o.CustomerName} - " +
                $"Your order #{o.Id} totalling {total:C} was received."
            );
        }



        private void LogToFile(string message)
        {
            File.AppendAllText(
                "app.log",
                $"{DateTime.Now}: {message}{Environment.NewLine}"
            );
        }
    }
}