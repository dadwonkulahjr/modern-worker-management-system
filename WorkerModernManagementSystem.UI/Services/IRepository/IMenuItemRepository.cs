using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WorkerModernManagementSystem.UI.Models;

namespace WorkerModernManagementSystem.UI.Services.IRepository
{
    public interface IMenuItemRepository : IDefaultRepository<MainMenuItem>
    { 
        void Update(MainMenuItem menuItemToUpdate);
      
    }
}
