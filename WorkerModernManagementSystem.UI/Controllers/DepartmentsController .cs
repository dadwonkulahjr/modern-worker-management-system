using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using WorkerModernManagementSystem.UI.Services.IRepository;

namespace WorkerModernManagementSystem.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var listOfDepartments = _unitOfWork.Department.GetEntityTypeAll().ToList();
         
            if (listOfDepartments == null)
            {
                return BadRequest();
            }
            return Json(new { data = listOfDepartments });
            
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
          
            var obj = _unitOfWork.Department.GetFirstOrDefaultEntityType(e => e.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error why deleting." });
            }
           
            _unitOfWork.Department.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });

        }

    }

}
