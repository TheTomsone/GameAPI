using GameAPI.Interfaces;

namespace GameAPI.Models
{
    public class UserDTO : IModelDTO
    {
        public int Id { get; }
        public string Email { get; set; } = "DTO : DATA TRANSFER ERROR";
        public string Name { get; set; } = "DTO : DATA TRANSFER ERROR";
        public int RoleId { get; set; } = 1;
        public IEnumerable<GameDTO> Games { get; set; } = Enumerable.Empty<GameDTO>();

    }
}
