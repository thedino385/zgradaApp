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
    
    public partial class Zgrade_PosebniDijeloviMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zgrade_PosebniDijeloviMaster()
        {
            this.Zgrade_PosebniDijeloviMaster_VlasniciPeriod = new HashSet<Zgrade_PosebniDijeloviMaster_VlasniciPeriod>();
            this.Zgrade_PosebniDijeloviMaster_Povrsine = new HashSet<Zgrade_PosebniDijeloviMaster_Povrsine>();
            this.Zgrade_PosebniDijeloviMaster_Pripadci = new HashSet<Zgrade_PosebniDijeloviMaster_Pripadci>();
        }
    
        public int Id { get; set; }
        public int ZgradaId { get; set; }
        public string Naziv { get; set; }
        public string Napomena { get; set; }
        public Nullable<bool> Zatvoren { get; set; }
        public Nullable<int> ZatvorenGodina { get; set; }
        public Nullable<int> ZatvorenMjesec { get; set; }
        public Nullable<int> VrijediOdGodina { get; set; }
        public Nullable<int> VrijediOdMjesec { get; set; }
        public Nullable<int> UplatnicaStanarId { get; set; }
        public string OpisRacun { get; set; }
        public string NapomenaRacun { get; set; }
        public string Broj { get; set; }
    
        public virtual Zgrade Zgrade { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zgrade_PosebniDijeloviMaster_VlasniciPeriod> Zgrade_PosebniDijeloviMaster_VlasniciPeriod { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zgrade_PosebniDijeloviMaster_Povrsine> Zgrade_PosebniDijeloviMaster_Povrsine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zgrade_PosebniDijeloviMaster_Pripadci> Zgrade_PosebniDijeloviMaster_Pripadci { get; set; }
    }
}
