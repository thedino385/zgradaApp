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
    
    public partial class PricuvaRezijeMjesec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PricuvaRezijeMjesec()
        {
            this.PricuvaRezijePosebniDioMasteri = new HashSet<PricuvaRezijePosebniDioMasteri>();
            this.PricuvaRezijeMjesec_Uplatnice = new HashSet<PricuvaRezijeMjesec_Uplatnice>();
        }
    
        public int Id { get; set; }
        public int PrivuvaRezijeGodId { get; set; }
        public Nullable<int> Mjesec { get; set; }
        public Nullable<byte> NacinObracunaPricuva { get; set; }
        public Nullable<byte> NacinObracunaRezije { get; set; }
        public Nullable<bool> SaKoef { get; set; }
        public Nullable<decimal> ObracunPricuvaCijenaM2 { get; set; }
        public Nullable<decimal> ObracunPricuvaCijenaUkupno { get; set; }
        public Nullable<decimal> ObracunRezijeCijenaUkupno { get; set; }
        public Nullable<decimal> ObracunRezijaCijenaUkupnoPoBrojuClanova { get; set; }
        public Nullable<decimal> OrocenaSredstva { get; set; }
        public Nullable<decimal> ObracunPricuvaCijenaUkupnoZaPostotak { get; set; }
    
        public virtual PricuvaRezijeGodina PricuvaRezijeGodina { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PricuvaRezijePosebniDioMasteri> PricuvaRezijePosebniDioMasteri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PricuvaRezijeMjesec_Uplatnice> PricuvaRezijeMjesec_Uplatnice { get; set; }
    }
}
