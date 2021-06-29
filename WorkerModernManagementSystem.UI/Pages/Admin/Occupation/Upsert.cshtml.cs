using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using WorkerModernManagementSystem.UI.Services.IRepository;

namespace WorkerModernManagementSystem.UI.Pages.Admin.Occupation
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Models.Occupation OccupationObj { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult OnGet(int? id)
        {
            OccupationObj = new();
            if (id != null)
            {
                OccupationObj = _unitOfWork.Occupation.GetFirstOrDefaultEntityType(e => e.Id == id);
                if (OccupationObj != null)
                {
                    return Page();
                }
            }

            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            if (OccupationObj.Id == 0)
            {
                //Add NEw Department
                _unitOfWork.Occupation.AddNewEntityType(OccupationObj);
                _unitOfWork.Save();
                return RedirectToPage("./Index");
            }
            else
            {
                _unitOfWork.Occupation.Update(OccupationObj);
                return RedirectToPage("./Index");
            }

        }
    }

}
