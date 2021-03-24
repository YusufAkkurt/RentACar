using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Card : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CardNameSurname { get; set; }
        public string CardNumber { get; set; }
        public string ValidDate { get; set; }
        public string CVV { get; set; }
    }
}