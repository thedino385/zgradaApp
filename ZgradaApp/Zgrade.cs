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
    
    public partial class Zgrade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zgrade()
        {
            this.PricuvaRezijeGodina = new HashSet<PricuvaRezijeGodina>();
            this.PrihodiRashodi = new HashSet<PrihodiRashodi>();
            this.Zgrade_DnevnikRada = new HashSet<Zgrade_DnevnikRada>();
            this.Zgrade_PopisUredjaja = new HashSet<Zgrade_PopisUredjaja>();
            this.Zgrade_PopisZajednickihDijelova = new HashSet<Zgrade_PopisZajednickihDijelova>();
            this.Zgrade_PosebniDijeloviMaster = new HashSet<Zgrade_PosebniDijeloviMaster>();
            this.Zgrade_Stanari = new HashSet<Zgrade_Stanari>();
            this.Zgrade_OglasnaPloca = new HashSet<Zgrade_OglasnaPloca>();
        }
    
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Mjesto { get; set; }
        public string Napomena { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PricuvaRezijeGodina> PricuvaRezijeGodina { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrihodiRashodi> PrihodiRashodi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zgrade_DnevnikRada> Zgrade_DnevnikRada { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zgrade_PopisUredjaja> Zgrade_PopisUredjaja { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zgrade_PopisZajednickihDijelova> Zgrade_PopisZajednickihDijelova { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zgrade_PosebniDijeloviMaster> Zgrade_PosebniDijeloviMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zgrade_Stanari> Zgrade_Stanari { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zgrade_OglasnaPloca> Zgrade_OglasnaPloca { get; set; }
    }
}
