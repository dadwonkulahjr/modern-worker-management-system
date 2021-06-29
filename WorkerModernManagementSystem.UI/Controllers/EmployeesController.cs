using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using WorkerModernManagementSystem.UI.Services.IRepository;

namespace WorkerModernManagementSystem.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnv;

        public EmployeesController(IUnitOfWork unitOfWork,
            IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnv = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var listOfEmployees = _unitOfWork.Employee.GetEntityTypeAll().ToList();
         
            if (listOfEmployees == null)
            {
                return BadRequest();
            }
            return Json(new { data = listOfEmployees });
            
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string webRootPath = _hostingEnv.WebRootPath;
            var obj = _unitOfWork.Employee.GetFirstOrDefaultEntityType(e => e.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error why deleting." });
            }

            string filePath = Path.Combine(_hostingEnv.WebRootPath, "images", "iamtuse_upload", obj.PhotoPath);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            _unitOfWork.Employee.Remove(obj);
            _unitOfWork.Save();


            return Json(new { success = true, message = "Delete successful" });

        }

    }

}
