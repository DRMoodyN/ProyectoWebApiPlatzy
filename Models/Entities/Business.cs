using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class Business
    {
        public Business()
        {
            CtgAccounts = new HashSet<CtgAccount>();
            SeatDetails = new HashSet<SeatDetail>();
            SeatHeaders = new HashSet<SeatHeader>();
            TypeBooks = new HashSet<TypeBook>();
            TypeDocuments = new HashSet<TypeDocument>();
            TypeFuentes = new HashSet<TypeFuente>();
        }

        public Guid BusinessId { get; set; }
        public string? BusinessName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<CtgAccount> CtgAccounts { get; set; }
        public virtual ICollection<SeatDetail> SeatDetails { get; set; }
        public virtual ICollection<SeatHeader> SeatHeaders { get; set; }
        public virtual ICollection<TypeBook> TypeBooks { get; set; }
        public virtual ICollection<TypeDocument> TypeDocuments { get; set; }
        public virtual ICollection<TypeFuente> TypeFuentes { get; set; }
    }
}
