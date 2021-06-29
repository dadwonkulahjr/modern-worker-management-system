using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkerModernManagementSystem.UI.Models;
using WorkerModernManagementSystem.UI.Services.IRepository;
using WorkerModernManagementSystem.UI.ViewModels;

namespace WorkerModernManagementSystem.UI.Pages.Admin.MenuItem
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public MenuItemVM MenuItemVM { get; set; } = new();
        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult OnGet(int id)
        {
            MenuItemVM.EmployeeDropdownList = _unitOfWork.Employee.GetDropdownSelectListItemEmployees();
            MenuItemVM.GenderDropdownList = _unitOfWork.Gender.GetDropdownSelectListItemGenders();
            MenuItemVM.DepartmentDropdownList = _unitOfWork.Department.GetDropdownSelectListItemDepartments();
            MenuItemVM.OccupationDropdownList = _unitOfWork.Occupation.GetDropdownSelectListItemOccupations();


            MenuItemVM.MenuItem = _unitOfWork.MenuItem.GetFirstOrDefaultEntityType(m => m.Id == id);
            //Retrived Employee Details base on the MenuItem Id
            MenuItemVM.MenuItem.Employee = _unitOfWork.Employee.GetFirstOrDefaultEntityType(e => e.Id == MenuItemVM.MenuItem.EmployeeId);




            if (MenuItemVM.MenuItem == null)
            {
                return NotFound();
            }


            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            if (MenuItemVM.MenuItem.Employee != null)
            {
                //found
                //Retrived Employee Details base on the MenuItem Id
                _unitOfWork.Employee.Update(MenuItemVM.MenuItem.Employee);
                _unitOfWork.MenuItem.Update(MenuItemVM.MenuItem);
                return RedirectToPage("./Index");
            }



            return Page();
        }
    }
}
