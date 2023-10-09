using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Tools
{
    public enum QueryType
    {
        SELECT, INSERT, UPDATE, DELETE
    }
    public class SqlCommandBuilder
    {
        private readonly Dictionary<QueryType, string> _commandsList;
        public SqlCommandBuilder()
        {
            _commandsList = new Dictionary<QueryType, string>
            {
                { QueryType.SELECT, "SELECT " },
                { QueryType.INSERT, "INSERT INTO" },
                { QueryType.UPDATE, "UPDATE " },
                { QueryType.DELETE, "DELETE " },
            };
        }
    }
}
