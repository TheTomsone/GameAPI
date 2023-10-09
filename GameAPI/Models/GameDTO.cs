using GameAPI.Interfaces;

namespace GameAPI.Models
{
    public class GameDTO : IModelDTO
    {
        public int Id { get; }
        public string Title { get; set; } = "DTO : DATA TRANSFER ERROR";
        public string Resume { get; set; } = "DTO : DATA TRANSFER ERROR";
        public IEnumerable<GenreDTO> Genres { get; set; } = Enumerable.Empty<GenreDTO>();
    }
}
