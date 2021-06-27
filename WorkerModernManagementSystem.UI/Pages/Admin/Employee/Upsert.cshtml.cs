using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;
using WorkerModernManagementSystem.UI.Services.IRepository;

namespace WorkerModernManagementSystem.UI.Pages.Admin.Employee
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        [BindProperty]
        public Models.Employee EmployeeObj { get; set; }
        public UpsertModel(IUnitOfWork unitOfWork,
            IWebHostEnvironment hostingEnvirnment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvirnment;
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
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (EmployeeObj.Id == 0)
            {
                string newGuid = Guid.NewGuid().ToString();
                string upload = Path.Combine(webRootPath, @"images\iamtuse_upload");
                string extention = Path.GetExtension(files[0].FileName);
                string fileName = files[0].FileName;
                string combine = fileName + "__" + newGuid + extention;

                using (var fileStream = new FileStream(Path.Combine(upload, combine), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                EmployeeObj.Image = @"\images\iamtuse_upload\" + combine;
                _unitOfWork.Employee.AddNewEntityType(EmployeeObj);
            }
            else
            {
                var findObjFromDb = _unitOfWork.Employee.GetFirstOrDefaultEntityType(e => e.Id == EmployeeObj.Id);
                if (findObjFromDb != null)
                {
                    if (files.Count > 0)
                    {
                        string imageStringLen = findObjFromDb.Image[23..];

                        string newGuid = Guid.NewGuid().ToString();
                        string upload = Path.Combine(webRootPath, @"images\iamtuse_upload");
                        string extention = Path.GetExtension(files[0].FileName);

                        string fullPath = Path.Combine(upload, imageStringLen);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }

                        string fileName = files[0].FileName;
                        string combineNew = fileName + "__" + newGuid + extention;

                        using (var fileStream = new FileStream(Path.Combine(upload, combineNew), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }

                        EmployeeObj.Image = @"/images/iamtuse_upload/" + combineNew;

                    }
                    else
                    {
                        EmployeeObj.Image = findObjFromDb.Image;
                    }

                    _unitOfWork.Employee.Update(EmployeeObj);
                }
                else
                {

                    return RedirectToPage("./Index");
                }



            }



            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
        //public IActionResult OnPost()
        //{
        //    if (!ModelState.IsValid) return Page();


        //    if (EmployeeObj.Id == 0)
        //    {
        //        //Add Employee
        //        _unitOfWork.Employee.AddNewEntityType(EmployeeObj);
        //        _unitOfWork.Save();
        //    }
        //    else
        //    {
        //        //Update Employee
        //        EmployeeObj = _unitOfWork.Employee.GetFirstOrDefaultEntityType(e => e.Id == EmployeeObj.Id);

        //        if(EmployeeObj != null)
        //        {
        //            _unitOfWork.Employee.Update(EmployeeObj);
        //        }

        //    }
        //    return RedirectToPage("./Index");


        //}
    }
}
