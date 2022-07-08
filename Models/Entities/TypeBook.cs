using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class TypeBook
    {
        public TypeBook()
        {
            SeatHeaders = new HashSet<SeatHeader>();
        }

        public Guid TypeBookId { get; set; }
        public string TypeBookCode { get; set; } = null!;
        public string TypeBookName { get; set; } = null!;
        public bool? IsActive { get; set; }
        public Guid? BusinessId { get; set; }

        public virtual Business? Business { get; set; }
        public virtual ICollection<SeatHeader> SeatHeaders { get; set; }
    }
}
