using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WorkerModernManagementSystem.UI.Models;

namespace WorkerModernManagementSystem.UI.Services.IRepository
{
    public interface IGenderRepository : IDefaultRepository<Gender>
    {
        IEnumerable<SelectListItem> GetDropdownSelectListItemGenders();
        void Update(Gender genderToUpdate);
      
    }
}
