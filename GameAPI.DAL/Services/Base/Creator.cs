using GameAPI.DAL.Interfaces;
using GameAPI.DAL.Interfaces.Base;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Services.Base
{
    public class Creator<TModel> : RepositoryAccess<TModel>, ICreator<TModel> where TModel : IModelDAL
    {
        public Creator(IBaseRepository<TModel> repository) : base(repository)
        {
        }

        public bool Create(TModel newModel)
        {
            StringBuilder sb = new();
            PropertyInfo[] properties = typeof(TModel).GetProperties();
            using SqlCommand cmd = _repository.Connection.CreateCommand();

            sb.Append($"INSERT INTO [dbo].[{_repository.FullTableName}] (");
            foreach (PropertyInfo property in properties)
                if (property.Name != "Id") sb.Append($"[{_repository.Prefix.ToLower()}_{property.Name.ToLower()}],");
            sb.Append(") VALUES (");
            foreach (PropertyInfo property in properties)
                if (property.Name != "Id") sb.Append($"@{property.Name.ToLower()},");
            sb.Append(')');
            cmd.CommandText = sb.ToString();
            foreach (PropertyInfo property in properties)
                if (property.Name != "Id") cmd.Parameters.AddWithValue(property.Name.ToLower(), property.GetValue(newModel));

            _repository.Connection.Open();
            try { return cmd.ExecuteNonQuery() > 0; }
            finally { _repository.Connection.Close(); }
        }
    }
}
