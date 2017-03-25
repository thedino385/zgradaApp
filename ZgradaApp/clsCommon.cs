﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZgradaApp
{
    public class clsCommon
    {
    }

    public partial class Stanovi_PosebniDijelovi
    {
        public string Status { get; set; }
    }
    public partial class Stanovi_Pripadci
    {
        public string Status { get; set; }
        public bool Active { get; set; }
    }
    public partial class Stanovi_Stanari
    {
        public string Status { get; set; }
    }

    public partial class Zgrade_Pripadci
    {
        public string VrstaNaziv { get; set; }
        public string Status { get; set; }
    }

    public partial class Stanovi
    {
        //public Stanovi()
        //{
        //    this.Stanovi_PrijenosPripadaka = new HashSet<Stanovi_PrijenosPripadaka>();
        //}
        public virtual ICollection<Stanovi_PrijenosPripadaka> Stanovi_PrijenosPripadaka { get; set; }
    }

    public partial class Stanovi_PrijenosPripadaka
    {
        public int PripadakIZgradaId { get; set; }
        public int IdKojiSeZatvara { get; set; }
        public int FromStan { get; set; }
        public int ToStan { get; set; }
        public int VrijediOdGodina { get; set; }
        public int VrijediOdMjesec { get; set; }
    }

    public partial class Zgrade_ZaduzivanjePoMj
    {
        public string Status { get; set; }
    }

    public partial class PrihodiRashodi
    {
        public string Status { get; set; }
    }

    public partial class PrihodiRashodiDetails
    {
        public string Status { get; set; }
    }

    public partial class PricuvaGod
    {
        public string Status { get; set; }
    }

    public partial class PricuvaMj
    {
        public string Status { get; set; }
    }

    public partial class KS
    {
        public decimal Zaduzenje { get; set; }
        public decimal Stanje { get; set; }
        public string Status { get; set; }
    }
}