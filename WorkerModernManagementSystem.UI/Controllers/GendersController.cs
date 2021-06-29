using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using WorkerModernManagementSystem.UI.Services.IRepository;

namespace WorkerModernManagementSystem.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public GendersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var listOfGenders = _unitOfWork.Gender.GetEntityTypeAll().ToList();
         
            if (listOfGenders == null)
            {
                return BadRequest();
            }
            return Json(new { data = listOfGenders });
            
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
          
            var obj = _unitOfWork.Gender.GetFirstOrDefaultEntityType(e => e.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error why deleting." });
            }
           
            _unitOfWork.Gender.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });

        }

    }

}
