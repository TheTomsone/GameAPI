using GameAPI.DAL.Interfaces;
using GameAPI.DAL.Interfaces.Base;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Services.Base
{
    public class Reador<TModel> : RepositoryAccess<TModel>, IReador<TModel>, IGenericMapper<TModel> where TModel : IModelDAL
    {
        private readonly GenericMapper<TModel> _mapper;
        public GenericMapper<TModel> Mapper { get { return _mapper; } }
        public Reador(IBaseRepository<TModel> repository) : base(repository) => _mapper = new GenericMapper<TModel>(_repository.Prefix.ToLower());

        public TModel Map(IDataReader reader)
        {
            return _mapper.Map(reader);
        }
        public IEnumerable<TModel> GetAll()
        {
            List<TModel> list = new();
            string sql = $"SELECT * FROM [dbo].[{_repository.FullTableName}]";
            using SqlCommand cmd = _repository.Connection.CreateCommand();

            cmd.CommandText = sql;

            _repository.Connection.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(Map(reader));
            }
            _repository.Connection.Close();

            return list;
        }
        public TModel GetById(int id)
        {
            string sql = $"SELECT * FROM [dbo].[{_repository.FullTableName}] WHERE [{_repository.Prefix.ToLower()}_id] = @id";
            using SqlCommand cmd = _repository.Connection.CreateCommand();

            cmd.Parameters.AddWithValue("id", id);
            cmd.CommandText = sql;

            _repository.Connection.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            try { return Map(reader); }
            finally { _repository.Connection.Close(); }
        }

    }
}
