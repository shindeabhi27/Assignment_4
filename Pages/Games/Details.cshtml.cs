﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Games
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.Data.AppDbContext _context;

        public DetailsModel(WebApplication1.Data.AppDbContext context)
        {
            _context = context;
        }

        public Game Games { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Games = await _context.Games.FirstOrDefaultAsync(m => m.Id == id);

            if (Games == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
