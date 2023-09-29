using Core.Domain.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            this._booksService = booksService;
        }

        [HttpGet("GetGeneralBooks")]
        public async Task<IActionResult> GetGeneralBooks()
        {
            var generalBooks = await _booksService.GetGeneralBooks();
            return Ok("hello yapma");
        }
    }
}
