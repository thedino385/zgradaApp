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
    
    public partial class Stanovi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stanovi()
        {
            this.Stanovi_Pripadci = new HashSet<Stanovi_Pripadci>();
            this.Stanovi_Stanari = new HashSet<Stanovi_Stanari>();
            this.Stanovi_PosebniDijelovi = new HashSet<Stanovi_PosebniDijelovi>();
        }
    
        public int Id { get; set; }
        public int ZgradaId { get; set; }
        public string BrojStana { get; set; }
        public string Kat { get; set; }
        public string Naziv { get; set; }
        public string Oznaka { get; set; }
        public Nullable<decimal> PovrsinaM2 { get; set; }
        public Nullable<decimal> PovrsinaPosto { get; set; }
        public Nullable<decimal> SumaPovrsinaM2 { get; set; }
        public Nullable<decimal> SumaPovrsinaPosto { get; set; }
        public string Napomena { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stanovi_Pripadci> Stanovi_Pripadci { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stanovi_Stanari> Stanovi_Stanari { get; set; }
        public virtual Zgrade Zgrade { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stanovi_PosebniDijelovi> Stanovi_PosebniDijelovi { get; set; }
    }
}
