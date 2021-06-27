using System;
using WorkerModernManagementSystem.UI.Data;
using WorkerModernManagementSystem.UI.Services.IRepository;

namespace WorkerModernManagementSystem.UI.Services.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            Employee = new EmployeeRepository(applicationDbContext);
        }
        public IEmployeeRepository Employee { get; private set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
