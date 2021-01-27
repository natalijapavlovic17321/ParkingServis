using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat.Models;

namespace Projekat2.Pages
{
    public class CreateParkinziModel : PageModel
    {
        [BindProperty]

        public Parkinzi par{get;set;}
        private ParkinziContext p;
        public CreateParkinziModel(ParkinziContext context)
        {
            p=context;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            p.Park.Add(par);
            await p.SaveChangesAsync();
            return RedirectToPage("./SkupParkinzi");
        }
    }
}
