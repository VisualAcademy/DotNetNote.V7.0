﻿#nullable disable
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNetNote.Pages.CabinetTypes;

public class DetailsModel : PageModel
{
    private readonly DotNetNote.Data.ApplicationDbContext _context;

    public DetailsModel(Data.ApplicationDbContext context) => _context = context;

    public CabinetType CabinetType { get; set; }

    public async Task<IActionResult> OnGetAsync(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        CabinetType = await _context.CabinetTypes.FirstOrDefaultAsync(m => m.Id == id);

        if (CabinetType == null)
        {
            return NotFound();
        }
        return Page();
    }
}
