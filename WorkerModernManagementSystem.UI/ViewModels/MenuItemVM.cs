using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WorkerModernManagementSystem.UI.Models;

namespace WorkerModernManagementSystem.UI.ViewModels
{
    public class MenuItemVM
    {
        public IEnumerable<SelectListItem> EmployeeDropdownList { get; set; }
        public IEnumerable<SelectListItem> DepartmentDropdownList { get; set; }
        public IEnumerable<SelectListItem> GenderDropdownList { get; set; }
        public IEnumerable<SelectListItem> OccupationDropdownList { get; set; }
        public MainMenuItem MenuItem { get; set; } = new();
      
    }
}
