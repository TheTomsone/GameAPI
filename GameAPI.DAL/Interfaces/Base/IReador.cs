using GameAPI.DAL.Services.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Interfaces.Base
{
    public interface IReador<TModel> where TModel : IModelDAL
    {
        TModel Map(IDataReader reader);
        TModel GetById(int id);
        IEnumerable<TModel> GetAll();
    }
}
