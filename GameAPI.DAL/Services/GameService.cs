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
    public class GameService : BaseService<Game>, IGameService
    {
        public GameService(IBaseRepository<Game> repository, ICreator<Game> creator, IReador<Game> reador, IDeletor<Game> deletor) : base(repository, creator, reador, deletor)
        {
        }

        public Game Map(IDataReader reader)
        {
            return _reador.Map(reader);
        }
        public bool Create(Game newModel)
        {
            return _creator.Create(newModel);
        }
        public IEnumerable<Game> GetAll()
        {
            return _reador.GetAll();
        }
        public Game GetById(int id)
        {
            return _reador.GetById(id);
        }
        public bool Delete(int id)
        {
            return _deletor.Delete(id);
        }
        //public IEnumerable<Game> FilterByGenre(int id)
        //{
        //    List<Game> list = new();

        //    using SqlCommand cmd = _repository.Connection.CreateCommand();

        //    cmd.CommandText = "SP_FILTER_GAME_BY_TYPE";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("typeId", id);

        //    _repository.Connection.Open();
        //    using SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read()) list.Add(Map(reader));
        //    _repository.Connection.Close();

        //    return list;
        //}

    }
}
