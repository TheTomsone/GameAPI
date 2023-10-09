using GameAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Models
{
    public class User : IModelDAL
    {
        public int Id { get; set; }
        public string Email { get; set; } = "DAL : DATA TRANSFER ERROR";
        public string Name { get; set; } = "DAL : DATA TRANSFER ERROR";
        public int RoleId { get; set; }
    }
}
