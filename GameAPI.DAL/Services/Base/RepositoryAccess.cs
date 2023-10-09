using GameAPI.DAL.Interfaces;
using GameAPI.DAL.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Services.Base
{
    public abstract class RepositoryAccess<TModel> where TModel : IModelDAL
    {
        protected readonly IBaseRepository<TModel> _repository;
        public RepositoryAccess(IBaseRepository<TModel> repository)
        {
            _repository = repository;
        }
    }
}
