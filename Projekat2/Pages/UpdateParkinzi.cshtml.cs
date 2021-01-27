using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat.Models;

namespace Projekat2.Pages
{
    public class UpdateParkinziModel : PageModel
    {
        [BindProperty]
        public Parkinzi par{get;set;}
        private ParkinziContext p;
        public UpdateParkinziModel(ParkinziContext context)
        {
            p=context;
        }
        public async Task OnGetAsync( int id)
        {
          par= await p.Park.FindAsync(id);
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
          if(!ModelState.IsValid)
          {
            par=await p.Park.FindAsync(id);
            return Page();
          }
          par.ID=id;
          p.Park.Update(par);
          await p.SaveChangesAsync();
          return RedirectToPage("./SkupParkinzi");
        }
    }
}
