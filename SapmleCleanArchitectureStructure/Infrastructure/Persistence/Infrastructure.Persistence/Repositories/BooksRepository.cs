using Core.Domain.Contracts.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly ApplicationDbContext _context;

        public BooksRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> Get(int id = 0, string title = "")
        {
            return await _context.Books.Where(x => (x.Id == 0 || x.Id == id)
                && (string.IsNullOrEmpty(title) || x.Title.Contains(title)))
                .Select(x => x)
                .ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            var books = await Get(id);
            if(books != null && books.Count != 0)
                return books[0];
            return null;
        }
    }
}
