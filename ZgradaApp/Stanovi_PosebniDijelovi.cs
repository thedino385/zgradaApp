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
    
    public partial class Stanovi_PosebniDijelovi
    {
        public int Id { get; set; }
        public int StanId { get; set; }
        public string Naziv { get; set; }
        public Nullable<decimal> DioStanaKoeficijent { get; set; }
        public Nullable<decimal> PovrsinaM2 { get; set; }
        public Nullable<decimal> PovrsinaPosto { get; set; }
    
        public virtual Stanovi Stanovi { get; set; }
    }
}
