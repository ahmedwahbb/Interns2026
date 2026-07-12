using System;
using System.IO;
using NorthWaveConsole.Models;

namespace NorthWaveConsole.Services
{
    // ============================================================
    //  WEEK 1 REFACTORING TARGET
    // ============================================================
    // This class is intentionally bad. It is the "legacy code" the
    // whole internship starts from. Do NOT clean it up before Day 1 -
    // interns need to diagnose these smells themselves first.
    //
    // Known smells living in this one class (find them all before
    // you start typing):
    //   - SRP violation: pricing + persistence + email + logging + I/O
    //     all mixed into one method
    //   - OCP violation: adding a new customer type means editing this
    //     method instead of extending something
    //   - Magic strings everywhere ("VIP", "New", file paths...)
    //   - No dependency injection - everything is `new`-ed inline or static
    //   - Swallowed exceptions (see the empty catch block)
    //   - No guard clauses / deep nesting
    //   - No logging framework - raw Console.WriteLine / file writes
    //   - No async, even though this "sends email" and "writes files"
    // ============================================================
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

            // Discount logic buried here - adding a new customer type
            // means editing this if/else chain (OCP violation).
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
                // no discount
            }

            o.Total = total;
            return total;
        }

        public void ProcessOrder(Order o)
        {
            // No guard clauses - if 'o' or 'o.Items' is null this blows up
            // deep inside instead of failing fast at the top.
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
                            // Swallowed! If SaveToFile fails, the order total
                            // was already calculated and "confirmed" to nobody
                            // knows what state, and we never find out why.
                        }
                    }
                }
            }
        }

        private void SaveToFile(Order o)
        {
            // Pretend persistence: appends a line to a text file. In a real
            // system this would be a repository call - but that abstraction
            // doesn't exist yet here, so this method can never be swapped
            // out or unit tested without touching the real filesystem.
            File.AppendAllText("orders.txt",
                $"{o.Id},{o.CustomerName},{o.CustomerType},{o.Total},{o.Status}{Environment.NewLine}");
        }

        private void SendConfirmationEmail(Order o)
        {
            // Not a real email - but notice this is a hard-coded side effect
            // baked directly into order processing, with no interface to
            // swap it out for a test double.
            Console.WriteLine($"[EMAIL] To: {o.CustomerName} - Your order #{o.Id} totalling {o.Total:C} was received.");
        }

        private void LogToFile(string message)
        {
            // Home-grown "logging" - no levels, no structure, no way to
            // filter or redirect it, and definitely nothing you could
            // wire up to a real log aggregator later.
            File.AppendAllText("app.log", $"{DateTime.Now}: {message}{Environment.NewLine}");
        }
    }
}
