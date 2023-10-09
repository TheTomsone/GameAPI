using GameAPI.DAL.Interfaces.Base;
using GameAPI.DAL.Interfaces.Services;
using GameAPI.DAL.Models;
using GameAPI.DAL.Services.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Services
{
    public class GenreService : BaseService<Genre>, IGenreService
    {
        public GenreService(IBaseRepository<Genre> repository, ICreator<Genre> creator, IReador<Genre> reador, IDeletor<Genre> deletor) : base(repository, creator, reador, deletor)
        {
        }

        public Genre Map(IDataReader reader)
        {
            return _reador.Map(reader);
        }
        public bool Create(Genre newModel)
        {
            return _creator.Create(newModel);
        }
        public IEnumerable<Genre> GetAll()
        {
            return _reador.GetAll();
        }
        public Genre GetById(int id)
        {
            return _reador.GetById(id);
        }
        public bool Delete(int id)
        {
            return _deletor.Delete(id);
        }
    }
}
