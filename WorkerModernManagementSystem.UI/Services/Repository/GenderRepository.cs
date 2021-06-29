using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WorkerModernManagementSystem.UI.Data;
using WorkerModernManagementSystem.UI.Models;
using WorkerModernManagementSystem.UI.Services.IRepository;

namespace WorkerModernManagementSystem.UI.Services.Repository
{
    public class GenderRepository : DefaultRepository<Gender>, IGenderRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GenderRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<SelectListItem> GetDropdownSelectListItemGenders()
        {
            return _applicationDbContext.Gender.Select(g => new SelectListItem
            {
                Text = g.Name,
                Value = g.Id.ToString()
            });
        }
        public void Update(Gender genderToUpdate)
        {
            var findEmpFromDb = _applicationDbContext.Gender.Find(genderToUpdate.Id);
            if (findEmpFromDb != null)
            {
                findEmpFromDb.Name = genderToUpdate.Name;
                _applicationDbContext.SaveChanges();

            }
        }
    }
}
