using System.Collections.Generic;
using NorthWaveConsole.Enum;
using NorthWaveConsole.Interfaces;

namespace NorthWaveConsole.Services.Discounts
{
    // Factory pattern: بيرجعلك الاستراتيجية الصح حسب الـ Layer
    // من غير ما الـ PricingOrder يعرف تفاصيل كل خصم أو يستخدم switch
    public static class DiscountStrategyFactory
    {
        private static readonly Dictionary<Layer, IDiscountStrategy> _strategies = new()
        {
            { Layer.Normal, new NormalDiscountStrategy() },
            { Layer.Employee, new EmployeeDiscountStrategy() },
            { Layer.VIP, new VipDiscountStrategy() },
            { Layer.Wholesale, new WholesaleDiscountStrategy() }
        };

        public static IDiscountStrategy GetStrategy(Layer layer)
        {
            return _strategies.TryGetValue(layer, out var strategy)
                ? strategy
                : _strategies[Layer.Normal];
        }
    }
}
