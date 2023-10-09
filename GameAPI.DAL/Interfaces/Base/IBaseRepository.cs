using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Interfaces.Base
{
    public interface IBaseRepository<TModel> where TModel : IModelDAL
    {
        SqlConnection Connection { get; }
        string Prefix { get; }
        string TableName { get; }
        string FullTableName { get; }
    }
}
