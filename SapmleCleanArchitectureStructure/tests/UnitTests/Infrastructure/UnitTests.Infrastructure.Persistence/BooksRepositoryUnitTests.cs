using Core.Domain.Contracts.Repositories;
using Core.Domain.Dtos.Books;
using Core.Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Moq;
using UnitTests.Infrastructure.Persistence.Mocks;

namespace UnitTests.Infrastructure.Persistence
{
    public class BooksRepositoryUnitTests
    {
        private readonly IBooksRepository _booksRepository;

        public BooksRepositoryUnitTests()
        {
            _booksRepository = new BooksRepository(ApplicationDbContextMock.Context.Object);
        }

        [Fact]
        public async Task Get_NullModel_ReturnsAllOfBooks()
        {
            // Act
            var result = await _booksRepository.Get(null);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Get_WithValidModel_ReturnsFilteredBooks()
        {
            // Arrange
            var model = new GeneralBookRequestDto() { Id = 1 };

            // Act
            var result = await _booksRepository.Get(model);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetById_WithValidId_ReturnsBook()
        {
            // Arrange
            int id = 2;

            // Act
            var result = await _booksRepository.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task Register_WithValidModel_AddsBookToContext()
        {
            // Arrange
            int id = 5;
            var model = new Book() { Id = id, Title = "Test Book" };

            // Act
            await _booksRepository.Register(model);
            var bookObj = await _booksRepository.GetById(id);

            // Assert
            Assert.Equal(id, bookObj.Id);
        }
    }
}
