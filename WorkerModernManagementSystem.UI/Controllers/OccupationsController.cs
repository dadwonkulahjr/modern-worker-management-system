using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using WorkerModernManagementSystem.UI.Services.IRepository;

namespace WorkerModernManagementSystem.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OccupationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var listOfOccupations = _unitOfWork.Occupation.GetEntityTypeAll().ToList();
         
            if (listOfOccupations == null)
            {
                return BadRequest();
            }
            return Json(new { data = listOfOccupations });
            
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
          
            var obj = _unitOfWork.Occupation.GetFirstOrDefaultEntityType(e => e.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error why deleting." });
            }
           
            _unitOfWork.Occupation.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });

        }

    }

}
