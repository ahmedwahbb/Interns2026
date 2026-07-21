using System.Collections.Generic;
using NorthWaveConsole.Application.Interfaces;
using NorthWaveConsole.Domain.Enums;

namespace NorthWaveConsole.Infrastructure.Services.Discounts
{
    
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
