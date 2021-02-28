using Core.Entities.Abstract;
using System;

namespace Entities.DTOs
{
    public class RentDetailDto : IDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string CustomerName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}