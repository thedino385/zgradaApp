//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZgradaApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class PricuvaRezijePosebniDioMasteri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PricuvaRezijePosebniDioMasteri()
        {
            this.PricuvaRezijePosebniDioChildren = new HashSet<PricuvaRezijePosebniDioChildren>();
            this.PricuvaRezijePosebniDioMasterVlasnici = new HashSet<PricuvaRezijePosebniDioMasterVlasnici>();
        }
    
        public int Id { get; set; }
        public int PricuvaRezijeMjesecId { get; set; }
        public Nullable<int> PosebniDioMasterId { get; set; }
        public Nullable<decimal> ObracunPricuvaCijenaSlobodanUnos { get; set; }
        public Nullable<int> ObracunRezijeBrojClanova { get; set; }
        public Nullable<decimal> ObracunRezijeCijenaSlobodanUnos { get; set; }
        public Nullable<decimal> DugPretplata { get; set; }
        public Nullable<decimal> Zaduzenje { get; set; }
        public Nullable<decimal> Uplaceno { get; set; }
        public Nullable<int> PeriodId { get; set; }
        public Nullable<decimal> PocetnoStanje { get; set; }
        public Nullable<decimal> StanjeOd { get; set; }
    
        public virtual PricuvaRezijeMjesec PricuvaRezijeMjesec { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PricuvaRezijePosebniDioChildren> PricuvaRezijePosebniDioChildren { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PricuvaRezijePosebniDioMasterVlasnici> PricuvaRezijePosebniDioMasterVlasnici { get; set; }
    }
}
