using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WorkerModernManagementSystem.UI.Data;
using WorkerModernManagementSystem.UI.Models;
using WorkerModernManagementSystem.UI.Services.IRepository;

namespace WorkerModernManagementSystem.UI.Services.Repository
{
    public class DepartmentRepository : DefaultRepository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public DepartmentRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<SelectListItem> GetDropdownSelectListItemDepartments()
        {
            return _applicationDbContext.Department.Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            });
        }
        public void Update(Department departmentToUpdate)
        {
            var findEmpFromDb = _applicationDbContext.Department.Find(departmentToUpdate.Id);
            if (findEmpFromDb != null)
            {
                findEmpFromDb.Name = departmentToUpdate.Name;
                _applicationDbContext.SaveChanges();

            }
        }
    }
}
