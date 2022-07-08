using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class SeatDetail
    {
        public Guid SeatDetailId { get; set; }
        public Guid CtgAccountId { get; set; }
        public Guid SeatHeaderId { get; set; }
        public string? SeatDetailDescription { get; set; }
        public bool DebitoOcredito { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModific { get; set; }
        public bool? IsActive { get; set; }
        public Guid? BusinessId { get; set; }

        public virtual Business? Business { get; set; }
        public virtual CtgAccount CtgAccount { get; set; } = null!;
        public virtual SeatHeader SeatHeader { get; set; } = null!;
    }
}
