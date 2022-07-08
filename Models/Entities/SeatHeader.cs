using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class SeatHeader
    {
        public SeatHeader()
        {
            SeatDetails = new HashSet<SeatDetail>();
        }

        public Guid SeatHeaderId { get; set; }
        public Guid TypeDocumentId { get; set; }
        public Guid TypeBookId { get; set; }
        public Guid TypeFuenteId { get; set; }
        public string SeatHeaderCode { get; set; } = null!;
        public string SeatHeaderDescription { get; set; } = null!;
        public DateTime DateCreation { get; set; }
        public DateTime DateModific { get; set; }
        public bool? IsActive { get; set; }
        public Guid? BusinessId { get; set; }

        public virtual Business? Business { get; set; }
        public virtual TypeBook TypeBook { get; set; } = null!;
        public virtual TypeDocument TypeDocument { get; set; } = null!;
        public virtual TypeFuente TypeFuente { get; set; } = null!;
        public virtual ICollection<SeatDetail> SeatDetails { get; set; }
    }
}
