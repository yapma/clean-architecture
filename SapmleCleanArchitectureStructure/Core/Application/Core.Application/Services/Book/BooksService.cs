using Core.Domain.Contracts.Repositories;
using Core.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Services.Book
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        public async Task<List<Domain.Entities.Book>> GetBooks(int id = 0, string title = "")
        {
            return await _booksRepository.Get(id, title);
        }
    }
}
