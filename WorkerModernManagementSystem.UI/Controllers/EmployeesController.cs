using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using WorkerModernManagementSystem.UI.Models;
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
            string imageStringLen = obj.Image[23..];

            string combinedPath = Path.Combine(webRootPath, @"images\iamtuse_upload");

            string fullPath = Path.Combine(combinedPath, imageStringLen);

           
            _unitOfWork.Employee.Remove(obj);
            _unitOfWork.Save();

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            return Json(new { success = true, message = "Delete successful" });

        }
       
    }
        
}
