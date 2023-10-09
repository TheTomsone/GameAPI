using GameAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Models
{
    public class Genre : IModelDAL
    {
        public int Id { get; set; }
        public string Label { get; set; } = "DAL : DATA TRANSFER ERROR";
    }
}
