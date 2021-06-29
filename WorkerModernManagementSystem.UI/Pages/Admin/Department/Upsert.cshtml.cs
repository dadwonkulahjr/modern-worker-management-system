using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using WorkerModernManagementSystem.UI.Services.IRepository;

namespace WorkerModernManagementSystem.UI.Pages.Admin.Department
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Models.Department DepartmentObj { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult OnGet(int? id)
        {
            DepartmentObj = new();
            if (id != null)
            {
                DepartmentObj = _unitOfWork.Department.GetFirstOrDefaultEntityType(e => e.Id == id);
                if (DepartmentObj != null)
                {
                    return Page();
                }
            }

            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            if (DepartmentObj.Id == 0)
            {
                //Add NEw Department
                _unitOfWork.Department.AddNewEntityType(DepartmentObj);
                _unitOfWork.Save();
                return RedirectToPage("./Index");
            }
            else
            {
                _unitOfWork.Department.Update(DepartmentObj);
                return RedirectToPage("./Index");
            }

        }
    }

}
