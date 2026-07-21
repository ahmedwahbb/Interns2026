using System;

namespace NorthWaveConsole.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable // => tb leh b3mel initail create => l kokloh ??>???? 
    {
        IOrderRepository Orders { get; }

        
        int Complete();
    }
}
