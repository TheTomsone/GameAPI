using GameAPI.DAL.Interfaces.Base;
using GameAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Interfaces.Services
{
    public interface IGenreService : ICreator<Genre>, IReador<Genre>, IDeletor<Genre>
    {
    }
}
