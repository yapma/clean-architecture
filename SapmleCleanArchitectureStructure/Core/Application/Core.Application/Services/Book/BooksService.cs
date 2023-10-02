using Ardalis.Result;
using Core.Domain.Contracts.Repositories;
using Core.Domain.Contracts.Services;
using Core.Domain.Dtos.Books;
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
        public async Task<Result<List<GeneralBookResponseDto>>> GetGeneralBooks(GeneralBookRequestDto model)
        {
            var books = await _booksRepository.Get(model);
            if (books == null || books.Count == 0)
                return Result.NotFound("No books found.");
            var resultDto = books.Where(x => x.UseageType == Domain.Entities.Book.Type.General)
                .Select(x => x.Adapt<GeneralBookResponseDto>())
                .ToList();
            return Result.Success(resultDto);
        }
    }
}
