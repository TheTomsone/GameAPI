using GameAPI.Interfaces;

namespace GameAPI.Models.Creators
{
    public class GameCreateDTO : IModelDTO
    {
        public string Title { get; set; } = "GAME : CREATE ERROR";
        public string Resume { get; set; } = "GAME : CREATE ERROR";
        public IEnumerable<GenreDTO> Genres { get; set; } = Enumerable.Empty<GenreDTO>();
    }
}
