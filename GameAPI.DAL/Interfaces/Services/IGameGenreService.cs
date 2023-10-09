using GameAPI.DAL.Interfaces.Base;
using GameAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Interfaces.Services
{
    public interface IGameGenreService : ICreator<GameGenre>, IDeletor<GameGenre>
    {
        IEnumerable<Genre> GetGenresFromGame(int movieId, IGenreService genreService);
        IEnumerable<Game> GetGamesFromGenre(int genreId, IGameService gameService);
    }
}
