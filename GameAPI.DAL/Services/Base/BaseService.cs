using GameAPI.DAL.Interfaces;
using GameAPI.DAL.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Services.Base
{
    public class BaseService<TModel> : RepositoryAccess<TModel> where TModel : IModelDAL
    {
        protected readonly ICreator<TModel>? _creator;
        protected readonly IReador<TModel>? _reador;
        protected readonly IUpdator<TModel>? _updator;
        protected readonly IDeletor<TModel>? _deletor;

        public BaseService(IBaseRepository<TModel> repository) : base(repository) { }

        public BaseService(IBaseRepository<TModel> repository, ICreator<TModel> creator) : this(repository) { _creator = creator; }
        public BaseService(IBaseRepository<TModel> repository, IReador<TModel> reador) : this(repository) { _reador = reador; }
        public BaseService(IBaseRepository<TModel> repository, IUpdator<TModel> updator) : this(repository) { _updator = updator; }
        public BaseService(IBaseRepository<TModel> repository, IDeletor<TModel> deletor) : this(repository) { _deletor = deletor; }

        public BaseService(IBaseRepository<TModel> repository, ICreator<TModel> creator, IReador<TModel> reador) : this(repository, creator) { _reador = reador; }
        public BaseService(IBaseRepository<TModel> repository, ICreator<TModel> creator, IUpdator<TModel> updator) : this(repository, creator) { _updator = updator; }
        public BaseService(IBaseRepository<TModel> repository, ICreator<TModel> creator, IDeletor<TModel> deletor) : this(repository, creator) { _deletor = deletor; }

        public BaseService(IBaseRepository<TModel> repository, IReador<TModel> reador, IUpdator<TModel> updator) : this(repository, reador) {  _updator = updator; }
        public BaseService(IBaseRepository<TModel> repository, IReador<TModel> reador, IDeletor<TModel> deletor) : this(repository, reador) { _deletor = deletor; }

        public BaseService(IBaseRepository<TModel> repository, IUpdator<TModel> updator, IDeletor<TModel> deletor) : this(repository, updator) { _deletor = deletor; }

        public BaseService(IBaseRepository<TModel> repository, ICreator<TModel> creator, IReador<TModel> reador, IUpdator<TModel> updator) : this(repository, creator, reador) { _updator = updator; }
        public BaseService(IBaseRepository<TModel> repository, ICreator<TModel> creator, IReador<TModel> reador, IDeletor<TModel> deletor) : this(repository, creator, reador) { _deletor = deletor; }

        public BaseService(IBaseRepository<TModel> repository, IReador<TModel> reador, IUpdator<TModel> updator, IDeletor<TModel> deletor) : this(repository, reador, updator) { _deletor = deletor; }

        public BaseService(IBaseRepository<TModel> repository, ICreator<TModel> creator, IReador<TModel> reador, IUpdator<TModel> updator, IDeletor<TModel> deletor) : this(repository, creator, reador, updator) { _deletor = deletor; }
    }
}
