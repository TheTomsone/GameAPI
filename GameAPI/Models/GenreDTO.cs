using GameAPI.Interfaces;

namespace GameAPI.Models
{
    public class GenreDTO : IModelDTO
    {
        public int Id { get; }
        public string Label { get; set; } = "DTO : DATA TRANSFER ERROR";
    }
}
