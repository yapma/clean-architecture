using Ardalis.Result;
using Core.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Contracts.Services
{
    public interface IBooksService
    {
        Task<Result<List<GeneralBookResponseDto>>> GetGeneralBooks(int id = 0, string title = "");
    }
}
