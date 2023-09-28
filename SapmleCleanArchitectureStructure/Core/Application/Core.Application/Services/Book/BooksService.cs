using Core.Domain.Contracts.Repositories;
using Core.Domain.Contracts.Services;
using Core.Domain.Dtos;
using Mapster;
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
        public async Task<List<GeneralBookResponseDto>> GetGeneralBooks(int id = 0, string title = "")
        {
            var books = await _booksRepository.Get(id, title);
            return books.Where(x => x.UseageType == Domain.Entities.Book.Type.General)
                .Select(x => x.Adapt<GeneralBookResponseDto>())
                .ToList();
        }
    }
}
