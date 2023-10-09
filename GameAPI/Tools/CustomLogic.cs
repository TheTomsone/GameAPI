using GameAPI.DAL.Interfaces.Services;
using GameAPI.DAL.Models;
using GameAPI.Models;
using System.Reflection;

namespace GameAPI.Tools
{
    public class CustomLogic : ILogicExecuter
    {
        private readonly IGameGenreService _gameGenreService;
        private readonly IGenreService _genreService;
        private readonly IUserGameService _userGameService;
        private readonly IGameService _gameService;

        public CustomLogic(IGameGenreService gameGenreService, IGenreService genreService, IUserGameService userGameService, IGameService gameService)
        {
            _gameGenreService = gameGenreService;
            _genreService = genreService;
            _userGameService = userGameService;
            _gameService = gameService;

        }

        public void Execute<TModelDTO>(ref TModelDTO dto, ref PropertyInfo[] dtoProps, int increment)
        {
            for (int i = increment; i < dtoProps.Length; i++)
            {
                object? value = null;
                if (dto is GameDTO dtoGame) value = _gameGenreService.GetGenresFromGame(dtoGame.Id, _genreService);
                if (dto is UserDTO dtoUser) value = _userGameService.GetGamesFromUser(dtoUser.Id, _gameService);
                if (value is not null) dtoProps[i].SetValue(dto, value);
            }
        }
    }
}
