using GameAPI.DAL.Interfaces;
using GameAPI.DAL.Interfaces.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.DAL.Services.Base
{
    public class GenericMapper<TModel> : IGenericMapper<TModel> where TModel : IModelDAL
    {
        private readonly string _prefix;
        public GenericMapper(string prefix)
        {
            _prefix = prefix;
        }

        public TModel Map(IDataReader reader)
        {
            TModel model = Activator.CreateInstance<TModel>();
            PropertyInfo[] properties = typeof(TModel).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object value = reader[$"{_prefix}_{RegexConverter.UnderscoreBetweenLowerUpper(property.Name).ToLower()}"];
                if (value != DBNull.Value) property.SetValue(model, value);
            }
            return model;
        }
    }
}
