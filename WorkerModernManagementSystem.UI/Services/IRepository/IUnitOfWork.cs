using System;

namespace WorkerModernManagementSystem.UI.Services.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        public IEmployeeRepository Employee { get; }
        public IDepartmentRepository Department { get; }
        public IGenderRepository Gender { get; }
        public IOccupationRepository Occupation { get; }
        public IMenuItemRepository MenuItem { get; }
        void Save();
    }
}
