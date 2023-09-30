using Core.Domain.Contracts.Services;
using Core.Domain.Dtos;
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
        [ProducesResponseType(typeof(List<GeneralBookResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGeneralBooks(int id = 0, string title = "")
        {
            var generalBooks = await _booksService.GetGeneralBooks(id, title);
            return Ok(generalBooks);
        }
    }
}
