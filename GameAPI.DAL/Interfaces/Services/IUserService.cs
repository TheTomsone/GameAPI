using GameAPI.DAL.Interfaces.Base;
using GameAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Interfaces.Services
{
    public interface IUserService : IReador<User>, IDeletor<User>
    {
        User UserLogin(string email, string pwd);
        bool UserRegister(string email, string pwd, string username);
    }
}
