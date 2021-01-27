using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat.Models;

namespace Projekat2.Pages
{
    public class DeleteParkinziModel : PageModel
    {
        private ParkinziContext p;
        public DeleteParkinziModel(ParkinziContext context)
        {
            p=context;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
          var par=await p.Park.FindAsync(id);
          p.Park.Remove(par);
          await p.SaveChangesAsync();
          return RedirectToPage("./SkupParkinzi");
        }
    }
}
