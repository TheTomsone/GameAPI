using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Interfaces.Base
{
    public interface IUpdator<TModel> where TModel : IModelDAL
    {
        bool Update(TModel model);
    }
}
