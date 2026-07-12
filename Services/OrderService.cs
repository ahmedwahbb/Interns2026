using System;
using System.IO;
using NorthWaveConsole.Models;

namespace NorthWaveConsole.Services
{
   
    public class OrderService
    {
        private static int _nextId = 1;

        public decimal CalculateTotal(Order o)
        {
            decimal total = 0;
            for (int i = 0; i < o.Items.Count; i++)
            {
                total = total + (o.Items[i].Price * o.Items[i].Qty);
            }


            if (o.CustomerType == "VIP")
            {
                total = total * 0.8m;
            }
            else if (o.CustomerType == "Wholesale")
            {
                total = total * 0.85m;
            }
            else if (o.CustomerType == "Employee")
            {
                total = total * 0.5m;
            }
            else
            {
            }

            o.Total = total;
            return total;
        }

        public void ProcessOrder(Order o)
        {
            
            if (o.Items.Count > 0)
            {
                if (o.CustomerName != null)
                {
                    if (o.CustomerName != "")
                    {
                        o.Id = _nextId;
                        _nextId = _nextId + 1;
                        o.Status = "New";

                        CalculateTotal(o);

                        try
                        {
                            SaveToFile(o);
                            SendConfirmationEmail(o);
                            LogToFile("Order processed: " + o.Id);
                        }
                        catch (Exception)
                        {
                          
                        }
                    }
                }
            }
        }

        private void SaveToFile(Order o)
        {
           
            File.AppendAllText("orders.txt",
                $"{o.Id},{o.CustomerName},{o.CustomerType},{o.Total},{o.Status}{Environment.NewLine}");
        }

        private void SendConfirmationEmail(Order o)
        {
           
            Console.WriteLine($"[EMAIL] To: {o.CustomerName} - Your order #{o.Id} totalling {o.Total:C} was received.");
        }

        private void LogToFile(string message)
        {
            
            File.AppendAllText("app.log", $"{DateTime.Now}: {message}{Environment.NewLine}");
        }
    }
}
