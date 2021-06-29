using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using WorkerModernManagementSystem.UI.Services.IRepository;

namespace WorkerModernManagementSystem.UI.Pages.Admin.Gender
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Models.Gender GenderObj { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult OnGet(int? id)
        {
            GenderObj = new();
            if (id != null)
            {
                GenderObj = _unitOfWork.Gender.GetFirstOrDefaultEntityType(e => e.Id == id);
                if (GenderObj != null)
                {
                    return Page();
                }
            }

            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            if (GenderObj.Id == 0)
            {
                //Add NEw Department
                _unitOfWork.Gender.AddNewEntityType(GenderObj);
                _unitOfWork.Save();
                return RedirectToPage("./Index");
            }
            else
            {
                _unitOfWork.Gender.Update(GenderObj);
                return RedirectToPage("./Index");
            }

        }
    }

}
