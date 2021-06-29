using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WorkerModernManagementSystem.UI.Models;

namespace WorkerModernManagementSystem.UI.Services.IRepository
{
    public interface IOccupationRepository : IDefaultRepository<Occupation>
    {
        IEnumerable<SelectListItem> GetDropdownSelectListItemOccupations();
        void Update(Occupation occupationToUpdate);
      
    }
}
