using GameAPI.DAL.Interfaces.Services;
using GameAPI.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IGenreService _genreService;

        public GameController(IGameService gameService, IGenreService genreService)
        {
            _gameService = gameService;
            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_gameService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_gameService.GetById(id).ToDTO());
        }
    }
}
