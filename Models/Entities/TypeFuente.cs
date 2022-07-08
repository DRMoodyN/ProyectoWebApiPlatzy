using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class TypeFuente
    {
        public TypeFuente()
        {
            SeatHeaders = new HashSet<SeatHeader>();
        }

        public Guid TypeFuenteId { get; set; }
        public string TypeFuenteCode { get; set; } = null!;
        public string TypeFuenteName { get; set; } = null!;
        public bool? IsActive { get; set; }
        public Guid? BusinessId { get; set; }

        public virtual Business? Business { get; set; }
        public virtual ICollection<SeatHeader> SeatHeaders { get; set; }
    }
}
