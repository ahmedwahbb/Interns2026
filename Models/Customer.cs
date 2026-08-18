namespace NorthWaveConsole.Models
{
    public class Customer
    {
        public string Name { get; private set; }

        public string Type { get; private set; }

        public Customer(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public virtual decimal GetDiscountMultiplier()
        {
            return 1.0m;
        }
    }


    public class VipCustomer : Customer
    {
        public VipCustomer(string name)
            : base(name, "VIP")
        {
        }

        public override decimal GetDiscountMultiplier()
        {
            return 0.8m;
        }
    }


    public class WholesaleCustomer : Customer
    {
        public WholesaleCustomer(string name)
            : base(name, "Wholesale")
        {
        }

        public override decimal GetDiscountMultiplier()
        {
            return 0.85m;
        }
    }


    public class EmployeeCustomer : Customer
    {
        public EmployeeCustomer(string name)
            : base(name, "Employee")
        {
        }

        public override decimal GetDiscountMultiplier()
        {
            return 0.5m;
        }
    }
}