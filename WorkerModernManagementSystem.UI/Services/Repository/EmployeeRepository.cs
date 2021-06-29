using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WorkerModernManagementSystem.UI.Data;
using WorkerModernManagementSystem.UI.Models;
using WorkerModernManagementSystem.UI.Services.IRepository;

namespace WorkerModernManagementSystem.UI.Services.Repository
{
    public class EmployeeRepository : DefaultRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EmployeeRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<SelectListItem> GetDropdownSelectListItemEmployees()
        {
            return _applicationDbContext.Employee.Select(s => new SelectListItem
            {
                Text = s.FirstName,
                Value = s.Id.ToString()
            });
        }
        public void Update(Employee employeeToUpdate)
        {
            var findEmpFromDb = _applicationDbContext.Employee.Find(employeeToUpdate.Id);
            if (findEmpFromDb != null)
            {
                findEmpFromDb.FirstName = employeeToUpdate.FirstName;
                findEmpFromDb.LastName = employeeToUpdate.LastName;
                findEmpFromDb.Email = employeeToUpdate.Email;
                findEmpFromDb.Salary = employeeToUpdate.Salary;
                if (employeeToUpdate.PhotoPath != null)
                {
                    findEmpFromDb.PhotoPath = employeeToUpdate.PhotoPath;
                }
                findEmpFromDb.DateHire = employeeToUpdate.DateHire;
                _applicationDbContext.SaveChanges();

            }
        }
    }
}
