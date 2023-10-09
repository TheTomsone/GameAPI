using GameAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Models
{
    public class GameGenre : IModelDAL
    {
        public int GameId { get; set; }
        public int GenreId { get; set; }
    }
}
