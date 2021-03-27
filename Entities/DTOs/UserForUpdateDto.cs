using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class UserForUpdateDto : UserForRegisterDto, IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}