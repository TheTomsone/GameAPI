using GameAPI.DAL.Interfaces.Base;
using GameAPI.DAL.Interfaces.Services;
using GameAPI.DAL.Models;
using GameAPI.DAL.Services.Base;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IBaseRepository<User> repository, IReador<User> reador, IDeletor<User> deletor) : base(repository, reador, deletor)
        {
        }

        public User Map(IDataReader reader)
        {
            return _reador.Map(reader);
        }
        public IEnumerable<User> GetAll()
        {
            return _reador.GetAll();
        }
        public User GetById(int id)
        {
            return _reador.GetById(id);
        }
        public bool Delete(int id)
        {
            return _deletor.Delete(id);
        }
        public User UserLogin(string email, string pwd)
        {
            using SqlCommand cmd = _repository.Connection.CreateCommand();

            cmd.CommandText = "SP_USER_LOGIN";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("email", email);
            cmd.Parameters.AddWithValue("pwd", pwd);

            _repository.Connection.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.Read()) return Map(reader);
                throw new Exception("Connexion Error : Email or Password invalid");
            }
            catch (SqlException e) { throw e; }
            finally {  _repository.Connection.Close(); }
        }
        public bool UserRegister(string email, string pwd, string username)
        {
            using SqlCommand cmd = _repository.Connection.CreateCommand();

            cmd.CommandText = "SP_USER_REGISTER";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("email", email);
            cmd.Parameters.AddWithValue("pwd", pwd);
            cmd.Parameters.AddWithValue("username", username);

            _repository.Connection.Open();
            try { return cmd.ExecuteNonQuery() > 0; }
            finally { _repository.Connection.Close(); }
        }

    }
}
