using Core.Domain.Contracts.Repositories;
using Core.Domain.Dtos.Books;
using Core.Domain.Entities;
using Infrastructure.Persistence.Contexts;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Infrastructure.Persistence.Mocks
{
    internal static class ApplicationDbContextMock
    {
        public static Mock<ApplicationDbContext> Context;
        static ApplicationDbContextMock()
        {
            var books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    Title = "Book 1",
                    UseageType = Book.Type.General,
                    Writers = new List<Writer>()
                    {
                        new Writer()
                        {
                            Id = 1,
                            FullName = "Ali Akbari",
                        }
                    }
                },
                new Book()
                {
                    Id = 2,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    Title = "Book 2",
                    UseageType = Book.Type.General,
                    Writers = new List<Writer>()
                    {
                        new Writer()
                        {
                            Id = 2,
                            FullName = "Yashar Mohajer",
                        }
                    }
                }
            };
            var booksDbSetMock = books.BuildMock().BuildMockDbSet();
            var appDbContextMock = new Mock<ApplicationDbContext>();
            appDbContextMock.Setup(x => x.Books).Returns(booksDbSetMock.Object);
            appDbContextMock.Setup(x => x.Books.Add(It.IsAny<Book>()))
                .Callback((Book model) => { books.Add(model); });

            Context = appDbContextMock;
        }
    }
}
