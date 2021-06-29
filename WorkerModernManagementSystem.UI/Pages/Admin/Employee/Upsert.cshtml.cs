using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkerModernManagementSystem.UI.Services.IRepository;

namespace WorkerModernManagementSystem.UI.Pages.Admin.Employee
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnv;

        [BindProperty]
        public Models.Employee EmployeeObj { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork,
            IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnv = hostEnvironment;

        }
        public IActionResult OnGet(int? id)
        {
            EmployeeObj = new();
            if (id != null)
            {
                EmployeeObj = _unitOfWork.Employee.GetFirstOrDefaultEntityType(e => e.Id == id);
                if (EmployeeObj != null)
                {
                    return Page();
                }
            }

            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            if (EmployeeObj.Id == 0)
            {
                //Add New record
                if (Photo != null)
                { 
                    EmployeeObj.PhotoPath = ProcessUploadedFile();

                    _unitOfWork.Employee.AddNewEntityType(EmployeeObj);
                    _unitOfWork.Save();
                    return RedirectToPage("./Index");
                }
                else
                {
                    if (EmployeeObj.PhotoPath != null)
                    {
                        _unitOfWork.Employee.Update(EmployeeObj);
                        return RedirectToPage("./Index");
                    }
                }
            }
            else
            {
                //Update Existing Record
                if (Photo != null)
                {
                    if (EmployeeObj.PhotoPath != null)
                    {
                        if (EmployeeObj.PhotoPath.EndsWith("jjc.jpg"))
                        {
                            EmployeeObj.PhotoPath = ProcessUploadedFile();
                        }
                        else
                        {
                            string filePath = Path.Combine(_hostingEnv.WebRootPath, "images", "iamtuse_upload", EmployeeObj.PhotoPath);
                            if (System.IO.File.Exists(filePath))
                            {
                                System.IO.File.Delete(filePath);
                            }
                        }
                        EmployeeObj.PhotoPath = ProcessUploadedFile();
                        _unitOfWork.Employee.Update(EmployeeObj);
                        return RedirectToPage("./Index");
                    }
                    else
                    {
                        EmployeeObj.PhotoPath = ProcessUploadedFile();
                        _unitOfWork.Employee.Update(EmployeeObj);
                        return RedirectToPage("./Index");
                    }

                }
                else
                {
                    if (EmployeeObj.PhotoPath == null)
                    {
                        EmployeeObj.PhotoPath = ProcessUploadedFile();
                    }
                    _unitOfWork.Employee.Update(EmployeeObj);
                    return RedirectToPage("./Index");
                }
            }

            return Page();
        }
        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {

                string uploadedFolder = Path.Combine(_hostingEnv.WebRootPath, "images", "iamtuse_upload");
                uniqueFileName = Guid.NewGuid().ToString() + " _ " + Photo.FileName;
                string filePath = Path.Combine(uploadedFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }

            }

            return uniqueFileName;
        }
    }
}
