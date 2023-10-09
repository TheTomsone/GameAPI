using GameAPI.DAL.Interfaces;
using GameAPI.DAL.Models;
using GameAPI.Interfaces;
using GameAPI.Models;
using System.Reflection;

namespace GameAPI.Tools
{
    public interface ILogicExecuter
    {
        void Execute<TModelDTO>(ref TModelDTO dto, ref PropertyInfo[] dtoProps, int increment);
    }
    public static class GenericTransferMapper
    {
        public static TModelDAL ToDAL<TModelDTO, TModelDAL>(this TModelDTO dto)
        where TModelDAL : IModelDAL, new()
        where TModelDTO : IModelDTO
        {
            TModelDAL dal = new();
            PropertyInfo[] dtoProps = typeof(TModelDTO).GetProperties();
            PropertyInfo[] dalProps = typeof(TModelDAL).GetProperties();

            for(int i = 0; i < dalProps.Length; i++)
            {
                object? value = dtoProps[i].GetValue(dto);
                if (value is not null) dalProps[i].SetValue(dal, value);
            }

            return dal;
        }
        private static TModelDTO LogicToDTO<TModelDAL, TModelDTO>(this TModelDAL dal, ILogicExecuter? logicExecuter = null)
        where TModelDTO : IModelDTO, new()
        where TModelDAL : IModelDAL
        {
            TModelDTO dto = new();
            PropertyInfo[] dalProps = typeof(TModelDAL).GetProperties();
            PropertyInfo[] dtoProps = typeof(TModelDTO).GetProperties();

            for (int i = 0; i <= dalProps.Length; i++)
            {
                if(i < dalProps.Length)
                {
                    object? value = dalProps[i].GetValue(dal);
                    if (value is not null) dtoProps[i].SetValue(dto, value);
                    continue;
                }
                if (i == dalProps.Length) logicExecuter?.Execute(ref dto, ref dtoProps, i);
            }
            
            return dto;
        }
        public static TModelDTO ToDTO<TModelDAL, TModelDTO>(this TModelDAL dal)
        where TModelDTO : IModelDTO, new()
        where TModelDAL : IModelDAL
        {
            return LogicToDTO<TModelDAL, TModelDTO>(dal);
        }
        public static UserDTO ToDTO(this User dal, ILogicExecuter logicExecuter)
        {
            return dal.LogicToDTO<User, UserDTO>(logicExecuter);
        }
        public static GameDTO ToDTO(this Game dal, ILogicExecuter logicExecuter)
        {
            return dal.LogicToDTO<Game, GameDTO>(logicExecuter);
        }
    }
}
