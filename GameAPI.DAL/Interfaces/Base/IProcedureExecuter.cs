using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Interfaces.Base
{
    public interface IProcedureExecuter
    {
        TReturnType Execute<TReturnType>(string procedureName, params KeyValuePair<string, object>[] parameters);
        KeyValuePair<string, object> AddParameters(string key, object value);
    }
}
