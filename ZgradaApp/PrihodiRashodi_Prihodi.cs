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
    
    public partial class PrihodiRashodi_Prihodi
    {
        public int Id { get; set; }
        public int PrihodiRashodiGodId { get; set; }
        public int Mjesec { get; set; }
        public int PosebniDioMasterId { get; set; }
        public Nullable<int> VlasnikId { get; set; }
        public Nullable<decimal> Iznos { get; set; }
        public Nullable<decimal> IznosUplacen { get; set; }
        public string UplataVrsta { get; set; }
        public Nullable<decimal> Udio { get; set; }
        public Nullable<System.DateTime> DatumValute { get; set; }
        public Nullable<System.DateTime> DatumUplate { get; set; }
    
        public virtual PrihodiRashodi PrihodiRashodi { get; set; }
    }
}
