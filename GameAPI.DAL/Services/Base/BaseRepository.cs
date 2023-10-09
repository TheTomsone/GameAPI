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
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : IModelDAL
    {
        private readonly string? _connString;
        private readonly SqlConnection _connection;

        public string Prefix => RegexConverter.DeleteLowerChar(typeof(TModel).Name);
        public string TableName => RegexConverter.UnderscoreBetweenLowerUpper(typeof(TModel).Name).ToUpper();
        public string FullTableName => Prefix + "_" + TableName;
        public SqlConnection Connection => _connection;

        public BaseRepository(IConfiguration config)
        {
            _connString = config.GetConnectionString("default");
            _connection = new SqlConnection(_connString);
        }
    }
}
