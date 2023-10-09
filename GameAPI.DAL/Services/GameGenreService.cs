using GameAPI.DAL.Interfaces.Base;
using GameAPI.DAL.Interfaces.Services;
using GameAPI.DAL.Models;
using GameAPI.DAL.Services.Base;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Services
{
    public class GameGenreService : BaseService<GameGenre>, IGameGenreService
    {
        public GameGenreService(IBaseRepository<GameGenre> repository, ICreator<GameGenre> creator, IDeletor<GameGenre> deletor) : base(repository, creator, deletor)
        {
        }

        public bool Create(GameGenre newModel)
        {
            return _creator.Create(newModel);
        }
        public bool Delete(int id)
        {
            return _deletor.Delete(id);
        }
        public IEnumerable<Genre> GetGenresFromGame(int movieId, IGenreService genreService)
        {
            List<Genre> list = new();
            using SqlCommand cmd = _repository.Connection.CreateCommand();

            cmd.CommandText = "SP_GET_GENRES_FROM_GAME";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("movieId", movieId);

            _repository.Connection.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read()) list.Add(genreService.Map(reader));
            _repository.Connection.Close();

            return list;
        }
        public IEnumerable<Game> GetGamesFromGenre(int genreId, IGameService gameService)
        {
            List<Game> list = new();
            using SqlCommand cmd = _repository.Connection.CreateCommand();

            cmd.CommandText = "SP_GET_GAMES_FROM_GENRE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("genreId", genreId);

            _repository.Connection.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) list.Add(gameService.Map(reader));
            _repository.Connection.Close();

            return list;
        }
    }
}
