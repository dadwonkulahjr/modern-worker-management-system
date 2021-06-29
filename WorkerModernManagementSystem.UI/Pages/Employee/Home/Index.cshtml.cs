using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkerModernManagementSystem.UI.Services.IRepository;
using WorkerModernManagementSystem.UI.ViewModels;

namespace WorkerModernManagementSystem.UI.Pages.Employee.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeVM EmployeeVM { get; set; } = new();
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {

            //var claimsIdentity = (ClaimsIdentity)User.Identity;
            //var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            EmployeeVM.ListOfMainMenuItems = _unitOfWork.MenuItem.GetEntityTypeAll(entityNavigationProperties: "Employee,Department,Occupation,Gender");
            EmployeeVM.ListOfEmployeeItems = _unitOfWork.Employee.GetEntityTypeAll(sortEntityType: c => c.OrderBy(c => c.FirstName), fiterEntityType: null, entityNavigationProperties: null);

        }
    }
}
