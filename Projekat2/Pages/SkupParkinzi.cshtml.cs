using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekat.Models;

namespace Projekat2.Pages
{
    public class SkupParkinziModel : PageModel
    {
        public List<Parkinzi> Skup{get;set;}
        private ParkinziContext p;
        public SkupParkinziModel(ParkinziContext context)
        {
           p=context;
        }
        public async Task OnGetAsync()
        {
           Skup=await p.Park.ToListAsync();
        }
        public void OnPost()
        {

        }
    }
}
