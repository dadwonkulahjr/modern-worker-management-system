using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WorkerModernManagementSystem.UI.Data;
using WorkerModernManagementSystem.UI.Models;
using WorkerModernManagementSystem.UI.Services.IRepository;

namespace WorkerModernManagementSystem.UI.Services.Repository
{
    public class MenuItemRepository : DefaultRepository<MainMenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public MenuItemRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void Update(MainMenuItem menuItemToUpdate)
        {
            var findEmpFromDb = _applicationDbContext.MainMenus.Find(menuItemToUpdate.Id);
            if (findEmpFromDb != null)
            {
                findEmpFromDb.DepartmentId = menuItemToUpdate.DepartmentId;
                findEmpFromDb.EmployeeId = menuItemToUpdate.Employee.Id;
                findEmpFromDb.OccupationId = menuItemToUpdate.OccupationId;
                findEmpFromDb.GenderId = menuItemToUpdate.GenderId;
                _applicationDbContext.SaveChanges();

            }
        }
    }
}
