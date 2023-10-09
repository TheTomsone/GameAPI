using GameAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Models
{
    public class Game : IModelDAL
    {
        public int Id { get; set; }
        public string Title { get; set; } = "DAL : DATA TRANSFER ERROR";
        public string Resume { get; set; } = "DAL : DATA TRANSFER ERROR";
    }
}
