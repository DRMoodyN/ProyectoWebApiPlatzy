using System;

namespace Repository.DTO
{
    public class BusinessDTO
    {
        public Guid BusinessId { get; set; }

        public string? BusinessName { get; set; }
    }

    public class BusinessUpdateDTO
    {
        public string? BusinessName { get; set; }
    }
}