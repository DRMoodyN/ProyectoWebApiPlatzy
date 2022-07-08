using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class TypeDocument
    {
        public TypeDocument()
        {
            SeatHeaders = new HashSet<SeatHeader>();
        }

        public Guid TypeDocumentId { get; set; }
        public string TypeDocumentCode { get; set; } = null!;
        public string TypeDocumentName { get; set; } = null!;
        public bool? IsActive { get; set; }
        public Guid? BusinessId { get; set; }

        public virtual Business? Business { get; set; }
        public virtual ICollection<SeatHeader> SeatHeaders { get; set; }
    }
}
