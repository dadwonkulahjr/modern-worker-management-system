using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WorkerModernManagementSystem.UI.Data;
using WorkerModernManagementSystem.UI.Models;
using WorkerModernManagementSystem.UI.Services.IRepository;

namespace WorkerModernManagementSystem.UI.Services.Repository
{
    public class OccupationRepository : DefaultRepository<Occupation>, IOccupationRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public OccupationRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<SelectListItem> GetDropdownSelectListItemOccupations()
        {
            return _applicationDbContext.Occupation.Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            });
        }
        public void Update(Occupation occupationToUpdate)
        {
            var findEmpFromDb = _applicationDbContext.Occupation.Find(occupationToUpdate.Id);
            if (findEmpFromDb != null)
            {
                findEmpFromDb.Name = occupationToUpdate.Name;
                _applicationDbContext.SaveChanges();

            }
        }
    }
}
