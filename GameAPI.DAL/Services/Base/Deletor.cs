using GameAPI.DAL.Interfaces;
using GameAPI.DAL.Interfaces.Base;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Services.Base
{
    public class Deletor<TModel> : RepositoryAccess<TModel>, IDeletor<TModel> where TModel : IModelDAL
    {
        public Deletor(IBaseRepository<TModel> repository) : base(repository)
        {
        }

        public bool Delete(int id)
        {
            using SqlCommand cmd = _repository.Connection.CreateCommand();

            string sql = $"DELETE FROM [dbo].[{_repository.FullTableName}] WHERE [{_repository.Prefix.ToLower()}_id] = @id";
            cmd.Parameters.AddWithValue("id", id);
            cmd.CommandText = sql;

            _repository.Connection.Open();
            try { return cmd.ExecuteNonQuery() > 0; }
            finally { _repository.Connection.Close(); }
        }
    }
}
