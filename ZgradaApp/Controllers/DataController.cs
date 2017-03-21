﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace ZgradaApp.Controllers
{
    [Authorize]
    public class DataController : ApiController
    {
        private readonly ZgradaDbEntities _db = new ZgradaDbEntities();

        [HttpGet]
        [Route("api/data/getzgrade")]
        public async Task<IHttpActionResult> GetZgrade()
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var companyId = Convert.ToInt32(identity.FindFirstValue("Cid"));
                var zgrade = await _db.Zgrade.Where(p => p.CompanyId == companyId).ToListAsync();
                return Ok(zgrade);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpGet]
        [Route("api/data/getzgrada")]
        public async Task<IHttpActionResult> GetZgrada(int Id)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var companyId = Convert.ToInt32(identity.FindFirstValue("Cid"));
                var pripadci = await _db.Pripadci.Where(p => p.CompanyId == companyId).ToListAsync();
                var zgrada = await _db.Zgrade.FirstOrDefaultAsync(p => p.Id == Id && p.CompanyId == companyId);
                foreach (var pripadak in zgrada.Zgrade_Pripadci)
                {
                    pripadak.VrstaNaziv = pripadci.FirstOrDefault(p => p.Id == pripadak.PripadakId).Naziv;
                }
                return Ok(zgrada);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/data/zgradaCreateUpdate")]
        public async Task<IHttpActionResult> ZgradaCreateUpdate([FromBody] Zgrade zgrada)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var companyId = Convert.ToInt32(identity.FindFirstValue("Cid"));
                zgrada.CompanyId = companyId;
                if (zgrada.Id == 0)
                {
                    _db.Zgrade.Add(zgrada);
                    await _db.SaveChangesAsync();
                    return Ok(zgrada.Id);
                }
                else
                {
                    //_db.Entry(zgrada).State = EntityState.Modified;
                    var targetZgrada = await _db.Zgrade.FirstOrDefaultAsync(p => p.Id == zgrada.Id);
                    targetZgrada.CompanyId = companyId;
                    targetZgrada.Adresa = zgrada.Adresa;
                    targetZgrada.Mjesto = zgrada.Mjesto;
                    targetZgrada.Naziv = zgrada.Naziv;
                    targetZgrada.Povrsinam2 = zgrada.Povrsinam2;
                    foreach (var pripadak in zgrada.Zgrade_Pripadci)
                    {
                        if (pripadak.Status == "d")
                        {
                            if (await _db.Stanovi_Pripadci.FirstOrDefaultAsync(p => p.Id == pripadak.Id) != null)
                                _db.Zgrade_Pripadci.Remove(pripadak);
                        }

                        else if (pripadak.Status == "a")
                            _db.Zgrade_Pripadci.Add(pripadak);
                        else
                        {
                            var target = await _db.Zgrade_Pripadci.FirstOrDefaultAsync(p => p.Id == pripadak.Id);
                            target.PripadakId = pripadak.PripadakId;
                            target.Naziv = pripadak.Naziv;
                            target.PovrsinaM2 = pripadak.PovrsinaM2;
                            target.PovrsinaPosto = pripadak.PovrsinaPosto;
                            target.Napomena = pripadak.Napomena;
                        }
                    }
                    
                    await _db.SaveChangesAsync();
                    return Ok(-1);
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/data/getpripadci")]
        public async Task<IHttpActionResult> GetPripadci()
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var companyId = Convert.ToInt32(identity.FindFirstValue("Cid"));
                return Ok(await _db.Pripadci.Where(p => p.CompanyId == companyId).ToListAsync());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/data/getpripadak")]
        public async Task<IHttpActionResult> GetPripadak(int Id)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var companyId = Convert.ToInt32(identity.FindFirstValue("Cid"));
                return Ok(await _db.Pripadci.FirstOrDefaultAsync(p => p.CompanyId == companyId && p.Id == Id));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        
            [HttpGet]
        [Route("api/data/getPosebiDijelovi")]
        public async Task<IHttpActionResult> GetPosebniDijelovi()
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var companyId = Convert.ToInt32(identity.FindFirstValue("Cid"));
                return Ok(await _db.PosedniDijelovi.Where(p => p.CompanyId == companyId).ToListAsync());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/data/pripadakCreateUpdate")]
        public async Task<IHttpActionResult> PripadakCreateUpdate([FromBody] Pripadci pripadak)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var companyId = Convert.ToInt32(identity.FindFirstValue("Cid"));
                pripadak.CompanyId = companyId;
                if (pripadak.Id == 0)
                {
                    _db.Pripadci.Add(pripadak);
                    await _db.SaveChangesAsync();
                    return Ok(pripadak.Id);
                }
                else
                {
                    _db.Entry(pripadak).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    return Ok(-1);
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        
             [HttpPost]
        [Route("api/data/posebniDioCreateUpdate")]
        public async Task<IHttpActionResult> PosebniDioCreateUpdate([FromBody] PosedniDijelovi dio)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var companyId = Convert.ToInt32(identity.FindFirstValue("Cid"));
                dio.CompanyId = companyId;
                if (dio.Id == 0)
                {
                    _db.PosedniDijelovi.Add(dio);
                    await _db.SaveChangesAsync();
                    return Ok(dio.Id);
                }
                else
                {
                    _db.Entry(dio).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    return Ok(-1);
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        //[HttpGet]
        //[Route("api/data/getstanovi")]
        //public async Task<IHttpActionResult> GetStanovi()
        //{
        //    // vuku se svi za tvrtku, na klijentu se filtrira za pojedinu zgradu
        //    try
        //    {
        //        var identity = (ClaimsIdentity)User.Identity;
        //        var companyId = Convert.ToInt32(identity.FindFirstValue("Cid"));
        //        var zgrade = await _db.Zgrade.Where(p => p.CompanyId == companyId).Select(p => p.Id).ToListAsync();
        //        var stanovi = await _db.Stanovi.Where(p => zgrade.Contains(p.ZgradaId)).ToListAsync();

        //        foreach (var stan in stanovi)
        //        {
        //            foreach (var prip in stan.Stanovi_Pripadci)
        //            {
        //                if (prip.VrijediDoMjesec < DateTime.Today.Month && prip.VrijediDoGod < DateTime.Now.Year)
        //                    prip.Active = false;
        //            }
        //        }
        //        return Ok(stanovi);
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}

        [HttpPost]
        [Route("api/data/stanCreateUpdate")]
        public async Task<IHttpActionResult> StanCreateUpdate(Stanovi stan)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var companyId = Convert.ToInt32(identity.FindFirstValue("Cid"));
                if (stan.Id == 0)
                {
                    // za sve unesene pripadtke, definiraj vrijediOd
                    foreach (var item in stan.Stanovi_Pripadci)
                    {
                        item.VrijediOdGod = DateTime.Today.Year;
                        item.VrijediOdMjesec = DateTime.Today.Month;
                    }
                    _db.Stanovi.Add(stan);
                    await _db.SaveChangesAsync();
                    return Ok(stan.Id);
                }
                else
                {
                    //_db.Entry(stan).State = EntityState.Modified;
                    var dbStan = await _db.Stanovi.FirstOrDefaultAsync(p => p.Id == stan.Id);
                    dbStan.BrojStana = stan.BrojStana;
                    dbStan.Kat = stan.Kat;
                    dbStan.Napomena = stan.Napomena;
                    dbStan.Naziv = stan.Naziv;
                    dbStan.Oznaka = stan.Oznaka;
                    dbStan.PovrsinaM2 = stan.PovrsinaM2;
                    dbStan.PovrsinaPosto = stan.PovrsinaPosto;
                    dbStan.SumaPovrsinaM2 = stan.SumaPovrsinaM2;
                    dbStan.SumaPovrsinaPosto = stan.SumaPovrsinaPosto;
                    foreach (var dio in stan.Stanovi_PosebniDijelovi)
                    {
                        if(dio.Status == "a")
                        {
                            var noviDio = new Stanovi_PosebniDijelovi { StanId = stan.Id, PosebniDioId = dio.PosebniDioId, Oznaka = dio.Oznaka,
                                Koef = dio.Koef, PovrsinaM2 = dio.PovrsinaM2, PovrsinaSaKoef = dio.PovrsinaSaKoef };
                            _db.Stanovi_PosebniDijelovi.Add(noviDio);
                        }
                        else if(dio.Status == "u")
                        {
                            var targetDio = await _db.Stanovi_PosebniDijelovi.FirstOrDefaultAsync(p => p.Id == dio.Id);
                            targetDio.PosebniDioId = dio.PosebniDioId;
                            targetDio.Oznaka = dio.Oznaka;
                            targetDio.PovrsinaM2 = dio.PovrsinaM2;
                            targetDio.Koef = dio.Koef;
                            targetDio.PovrsinaSaKoef = dio.PovrsinaSaKoef;
                        }
                        else
                        {
                            var target = await _db.Stanovi_PosebniDijelovi.FirstOrDefaultAsync(p => p.Id == dio.Id);
                            if(target != null)
                                _db.Stanovi_PosebniDijelovi.Remove(target);
                        }
                    }

                    foreach (var pripadak in stan.Stanovi_Pripadci.ToList())
                    {
                        if (pripadak.Status == "a")
                        {
                            var newPripadak = new Stanovi_Pripadci();
                            newPripadak.Koef = pripadak.Koef;
                            newPripadak.PripadakIZgradaId = pripadak.PripadakIZgradaId;
                            newPripadak.StanId = stan.Id;
                            newPripadak.PovrsinaSaKef = pripadak.PovrsinaSaKef;
                            newPripadak.VrijediOdMjesec = DateTime.Today.Month;
                            newPripadak.VrijediOdGod = DateTime.Today.Year;
                            if (stan.Stanovi_PrijenosPripadaka != null)
                            {
                                foreach (var item in stan.Stanovi_PrijenosPripadaka)
                                {
                                    if (item.PripadakIZgradaId == pripadak.PripadakIZgradaId)
                                    {
                                        // pripadak se prenosi na ovaj stan, upisi od kad vrijedi
                                        newPripadak.VrijediOdMjesec = item.VrijediOdMjesec;
                                        newPripadak.VrijediOdGod = item.VrijediOdGodina;
                                    }
                                }
                            }
                            _db.Stanovi_Pripadci.Add(newPripadak);
                        }
                        else if (pripadak.Status == "u")
                        {
                            var dbPripadak = await _db.Stanovi_Pripadci.FirstOrDefaultAsync(p => p.Id == pripadak.Id);
                            dbPripadak.Koef = pripadak.Koef;
                            dbPripadak.PovrsinaSaKef = pripadak.PovrsinaSaKef;
                        }
                        else if (pripadak.Status == "d")
                        {
                            _db.Stanovi_Pripadci.Remove(pripadak); // smije se obrisati jer se brise samo iz kolekcije na stanovima, pripadak i dalje postoji za zgradu
                        }
                    }
                    foreach (var stanar in stan.Stanovi_Stanari.ToList())
                    {
                        if (stanar.Status == "a")
                        {
                            var newStanar = new Stanovi_Stanari
                            {
                                StanId = stan.Id,
                                Email = stanar.Email,
                                Ime = stanar.Ime,
                                OIB = stanar.OIB,
                                Prezime = stanar.Prezime,
                                Udjel = stanar.Udjel
                            };
                            _db.Stanovi_Stanari.Add(newStanar);
                        }
                        else if (stanar.Status == "u")
                        {
                            var target = await _db.Stanovi_Stanari.FirstOrDefaultAsync(p => p.Id == stanar.Id);
                            target.Email = stanar.Email;
                            target.Ime = stanar.Ime;
                            target.OIB = stanar.OIB;
                            target.Prezime = stanar.Prezime;
                            target.StanId = stan.Id;
                            target.Udjel = stanar.Udjel;
                        }
                        else if (stanar.Status == "d")
                        {
                            _db.Stanovi_Stanari.Remove(stanar);
                        }
                    }

                    if (stan.Stanovi_PrijenosPripadaka != null)
                    {
                        // zatvori pripatke
                        foreach (var item in stan.Stanovi_PrijenosPripadaka.ToList())
                        {
                            var pripadak = await _db.Stanovi_Pripadci.FirstOrDefaultAsync(p => p.Id == item.IdKojiSeZatvara);
                            pripadak.VrijediDoGod = item.VrijediOdGodina;
                            pripadak.VrijediDoMjesec = item.VrijediOdMjesec;
                        }
                    }

                    await _db.SaveChangesAsync();
                    return Ok(-1);
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/data/zaduzivanjeCreateUpdate")]
        public async Task<IHttpActionResult> ZaduzivanjePoMjesecima([FromBody] List<Zgrade_ZaduzivanjePoMj> z)
        {
            try
            {
                foreach (var item in z)
                {
                    if (item.Status == "a")
                    {
                        var novoZaduzivanje = new Zgrade_ZaduzivanjePoMj
                        {
                            ZgradaId = item.ZgradaId,
                            Godina = item.Godina,
                            Mj1 = item.Mj1,
                            Mj2 = item.Mj2,
                            Mj3 = item.Mj3,
                            Mj4 = item.Mj4,
                            Mj5 = item.Mj5,
                            Mj6 = item.Mj6,
                            Mj7 = item.Mj7,
                            Mj8 = item.Mj8,
                            Mj9 = item.Mj9,
                            Mj10 = item.Mj10,
                            Mj11 = item.Mj11,
                            Mj12 = item.Mj12
                        };
                        _db.Zgrade_ZaduzivanjePoMj.Add(novoZaduzivanje);
                    }
                    else if (item.Status == "u")
                    {
                        var dbZaduzivanje = await _db.Zgrade_ZaduzivanjePoMj.FirstOrDefaultAsync(p => p.Id == item.Id);
                        dbZaduzivanje.Godina = item.Godina;
                        dbZaduzivanje.Mj1 = item.Mj1;
                        dbZaduzivanje.Mj2 = item.Mj2;
                        dbZaduzivanje.Mj3 = item.Mj3;
                        dbZaduzivanje.Mj4 = item.Mj4;
                        dbZaduzivanje.Mj5 = item.Mj5;
                        dbZaduzivanje.Mj6 = item.Mj6;
                        dbZaduzivanje.Mj7 = item.Mj7;
                        dbZaduzivanje.Mj8 = item.Mj8;
                        dbZaduzivanje.Mj9 = item.Mj9;
                        dbZaduzivanje.Mj10 = item.Mj10;
                        dbZaduzivanje.Mj11 = item.Mj11;
                        dbZaduzivanje.Mj12 = item.Mj12;
                    }
                }
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex) { return InternalServerError(); }
        }

        [HttpGet]
        [Route("api/data/getprihodirashodi")]
        public async Task<IHttpActionResult> GetPrihodiRashodi(int ZgradaId)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var companyId = Convert.ToInt32(identity.FindFirstValue("Cid"));
            var zgrada = await _db.Zgrade.FirstOrDefaultAsync(p => p.Id == ZgradaId &&  p.CompanyId == companyId);
            if(zgrada.CompanyId == companyId)
            {
                var pr = await _db.PrihodiRashodi.Where(p => p.ZgradaId == zgrada.Id).ToListAsync();
                return Ok(pr);
            }
            return InternalServerError();
        }
    }
}
