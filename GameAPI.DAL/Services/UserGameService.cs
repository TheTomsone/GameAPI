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
    public class UserGameService : BaseService<UserGame>, IUserGameService
    {
        public UserGameService(IBaseRepository<UserGame> repository, ICreator<UserGame> creator, IDeletor<UserGame> deletor) : base(repository, creator, deletor)
        {
        }

        public bool Create(UserGame newModel)
        {
            return _creator.Create(newModel);
        }

        public bool Delete(int id)
        {
            return _deletor.Delete(id);
        }

        public IEnumerable<Game> GetGamesFromUser(int userId, IGameService gameService)
        {
            List<Game> list = new();
            using SqlCommand cmd = _repository.Connection.CreateCommand();

            cmd.CommandText = "SP_GET_GAMES_FROM_USER";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("userId", userId);

            _repository.Connection.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) list.Add(gameService.Map(reader));
            _repository.Connection.Close();

            return list;
        }
    }
}
