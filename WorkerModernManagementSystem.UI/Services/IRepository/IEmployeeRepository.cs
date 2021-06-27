using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WorkerModernManagementSystem.UI.Models;

namespace WorkerModernManagementSystem.UI.Services.IRepository
{
    public interface IEmployeeRepository : IDefaultRepository<Employee>
    {
        IEnumerable<SelectListItem> GetDropdownSelectListItemEmployees();
        void Update(Employee employeeToUpdate);
      
    }
}
