using System;
using System.IO;
using NorthWaveConsole.Models;

namespace NorthWaveConsole.Services
{
    public class OrderService
    {
        private static int _nextId = 1;


        public decimal CalculateTotal(Order o, Customer customer)
        {
            decimal discountMultiplier =
                customer.GetDiscountMultiplier();

            return o.GetTotal(discountMultiplier);
        }


        public bool ProcessOrder(Order o, Customer customer)
        {
            if (o.Items.Count == 0)
            {
                o.SetFailureReason("Order has no items.");
                return false;
            }

            if (customer == null ||
                string.IsNullOrWhiteSpace(customer.Name))
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
                SaveToFile(o, total, customer);
                SendConfirmationEmail(o, total, customer);
                LogToFile("Order processed: " + o.Id);

                return true;
            }
            catch (Exception ex)
            {
                o.SetFailureReason(ex.Message);
                return false;
            }
        }


        private void SaveToFile(
            Order o,
            decimal total,
            Customer customer)
        {
            File.AppendAllText(
                "orders.txt",
                $"{o.Id}," +
                $"{customer.Name}," +
                $"{customer.Type}," +
                $"{total}," +
                $"{o.Status}" +
                $"{Environment.NewLine}"
            );
        }


        private void SendConfirmationEmail(
            Order o,
            decimal total,
            Customer customer)
        {
            Console.WriteLine(
                $"[EMAIL] To: {customer.Name} - " +
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