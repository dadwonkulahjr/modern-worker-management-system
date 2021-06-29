using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using WorkerModernManagementSystem.UI.Services.IRepository;

namespace WorkerModernManagementSystem.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainMenuItemsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MainMenuItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var listOfMenuItems = _unitOfWork.MenuItem.GetEntityTypeAll(entityNavigationProperties:
                "Employee,Department,Gender,Occupation");

            if (listOfMenuItems == null)
            {
                return BadRequest();
            }
            return Json(new { data = listOfMenuItems });

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var obj = _unitOfWork.MenuItem.GetFirstOrDefaultEntityType(e => e.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error why deleting." });
            }

            _unitOfWork.MenuItem.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });

        }

    }

}
