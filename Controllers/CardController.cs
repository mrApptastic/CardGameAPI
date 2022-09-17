using Microsoft.AspNetCore.Mvc;
using CardGameAPI.Models;
using CardGameAPI.Stores;

namespace CardGameAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private readonly ILogger<CardController> _logger;
    private readonly ICardStore _store;

    public CardController(ILogger<CardController> logger, ICardStore store)
    {
        _logger = logger;
        _store = store;
    }

    [HttpGet]
    public Card GetRandom()
    {
        return _store.GetRandom();
    }
}
