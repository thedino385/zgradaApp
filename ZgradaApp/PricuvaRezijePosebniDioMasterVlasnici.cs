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
    
    public partial class PricuvaRezijePosebniDioMasterVlasnici
    {
        public int Id { get; set; }
        public int PricuvaRezijePosebniDioMasterId { get; set; }
        public Nullable<int> PeriodId { get; set; }
        public Nullable<int> VlasnikId { get; set; }
        public Nullable<decimal> Udio { get; set; }
    
        public virtual PricuvaRezijePosebniDioMasteri PricuvaRezijePosebniDioMasteri { get; set; }
    }
}
