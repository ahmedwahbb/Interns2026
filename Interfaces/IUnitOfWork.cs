using System;

namespace NorthWaveConsole.Interfaces
{
    // Unit of Work: بيجمع كل الـ Repositories، وبيضمن إن الـ commit (الحفظ الفعلي)
    // بيحصل مرة واحدة، كـ "transaction" واحدة، مش كل عملية لوحدها.
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }

        // بترجع عدد الـ orders اللي اتحفظت فعليًا
        int Complete();
    }
}
