using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Interfaces.Base
{
    public interface IDeletor<TModel> where TModel : IModelDAL
    {
        bool Delete(int id);
    }
}
