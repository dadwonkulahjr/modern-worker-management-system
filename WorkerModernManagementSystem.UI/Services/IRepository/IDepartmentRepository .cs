using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WorkerModernManagementSystem.UI.Models;

namespace WorkerModernManagementSystem.UI.Services.IRepository
{
    public interface IDepartmentRepository : IDefaultRepository<Department>
    {
        IEnumerable<SelectListItem> GetDropdownSelectListItemDepartments();
        void Update(Department departmentToUpdate);
      
    }
}
