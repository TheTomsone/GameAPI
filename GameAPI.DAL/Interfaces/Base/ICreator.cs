using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Interfaces.Base
{
    public interface ICreator<TModel> where TModel : IModelDAL
    {
        bool Create(TModel newModel);
    }
}
