using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class CtgAccount
    {
        public CtgAccount()
        {
            SeatDetails = new HashSet<SeatDetail>();
        }

        public Guid CtgAccountId { get; set; }
        public string Code { get; set; } = null!;
        public string CtgAccountName { get; set; } = null!;
        public byte CtgAccountLevel { get; set; }
        public string? SubCode { get; set; }
        public bool? IsActive { get; set; }
        public Guid? BusinessId { get; set; }

        public virtual Business? Business { get; set; }
        public virtual ICollection<SeatDetail> SeatDetails { get; set; }
    }
}
