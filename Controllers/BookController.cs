using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly HttpClient _http;

    public BookController(IHttpClientFactory factory)
    {
        _http = factory.CreateClient();
    }

    [HttpGet("want-to-read")]
    public async Task<IActionResult> GetWantToRead()
    {
        var response = await _http.GetStringAsync("https://openlibrary.org/people/mekBot/books/want-to-read.json");
        return Content(response, "application/json");
    }
}
