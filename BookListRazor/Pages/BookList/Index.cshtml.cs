using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> Books { get; set; }

        [BindProperty]
        public Book Book { get; set; }

        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete1()
        {
            var BookFromDB = await _db.Book.FindAsync(Book.Id);

            if (BookFromDB == null)
            {
                return NotFound();
            }
            else
            {
                _db.Book.Remove(BookFromDB);
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
        }
    }
}