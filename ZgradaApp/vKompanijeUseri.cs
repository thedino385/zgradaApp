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
    
    public partial class vKompanijeUseri
    {
        public int Id { get; set; }
        public string Prezime { get; set; }
        public string Ime { get; set; }
        public int CompanyId { get; set; }
        public string UserGuid { get; set; }
        public Nullable<bool> MasterAcc { get; set; }
        public Nullable<int> Stanarid { get; set; }
        public Nullable<int> ZgradaId { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Email { get; set; }
        public string Expr1 { get; set; }
        public string Expr2 { get; set; }
        public string OIB { get; set; }
        public Nullable<bool> DnevnikRada { get; set; }
        public Nullable<bool> OglasnaPloca { get; set; }
    }
}
