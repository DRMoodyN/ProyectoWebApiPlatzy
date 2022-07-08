using System;

namespace Repository.DTO
{
    public class CtgAccountDTO
    {
        public Guid CtgAccountId { get; set; }
        public string Code { get; set; } = null!;
        public string CtgAccountName { get; set; } = null!;
        public byte CtgAccountLevel { get; set; }
        public string? SubCode { get; set; }
        
        public Guid? BusinessId { get; set; }
    }
}
