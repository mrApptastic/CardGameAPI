using Microsoft.AspNetCore.Mvc;
using CardGameAPI.Models;

namespace CardGameAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private readonly ILogger<CardController> _logger;

    public CardController(ILogger<CardController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public Card GetRandom()
    {
        return new Card();
    }
}
