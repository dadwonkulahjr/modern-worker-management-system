using System;

namespace WorkerModernManagementSystem.UI.Services.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        public IEmployeeRepository Employee { get; }
        void Save();
    }
}
