using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Contracts.Services
{
    public interface IBooksService
    {
        Task<List<Book>> GetBooks(int id = 0, string title = "");
    }
}
