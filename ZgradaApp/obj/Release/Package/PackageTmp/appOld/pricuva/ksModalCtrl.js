﻿// https://angular-ui.github.io/bootstrap/

angularApp.controller('ksModalCtrl', ['$scope', '$uibModalInstance', 'DataService', 'pricuveZaZgraduGodina', 'zgrada', 'godina', 'stanarId',
    function ($scope, $uibModalInstance, DataService, pricuveZaZgraduGodina, zgrada, godina, stanarId) {

        // prosljedjena je pricuva, KS je child
        // pricuveZaZgraduGodina je object za zgradu, za godinu

        // pricuveZaZgraduGodina
        //          |-----> PricuvaMj
        //          |-----> KS


        // kod otvaranja, preracunati Zaduzenje i Stanje
        // Zaduzenje = pricuvaMj[Zaduzenje] (to se generira cijena/m2 ili ukupnaCijenaZaZgradu po stanu)
        // Stanje = Uplata - Zaduzenje

        $scope.pricuveZaZgraduGodina = pricuveZaZgraduGodina;
        $scope.zgrada = zgrada;
        $scope.stanarId = parseInt(stanarId);
        $scope.godina = parseInt(godina);
        $scope.snimanjeOk = false;
        $scope.dodavanjeOk = true;

        $scope.uplataTotal = 0;
        $scope.zaduzenjeTotal = 0;
        $scope.stanjeTotal = 0;

        var changes = [];

        console.log($scope.stanarId + " " + $scope.godina);

        $scope.dodajRecord = function () {
            var maxId = 0;
            pricuveZaZgraduGodina.KS.forEach(function (ks) {
                maxId = ks.Id;
            });
            var newDate = new Date().getDate() + '. ' + new Date().getMonth() + 1 + '. ' + godina;
            var noviRecord = {
                Id: maxId + 1, PricuvaGodId: pricuveZaZgraduGodina.Id, StanarId: stanarId,
                Mjesec: null, Godina: godina, Datum: newDate,
                Uplata: 0, Status: 'a'
            };
            $scope.pricuveZaZgraduGodina.KS.push(noviRecord);
            OkZaSnimanje();
            console.log(pricuveZaZgraduGodina.PricuvaMj);
            changes.push(noviRecord.Id);
        }

        $scope.delete = function (Id) {
            // ako je obj.Id == 0, obrisi zadnji rec u kolekciji (nije u bazi)
            if ($scope.pricuveZaZgraduGodina.Id == 0) {
                $scope.pricuveZaZgraduGodina.KS.forEach(function (rec) {
                    console.log(rec);
                    if (rec.Id == Id) {
                        var index = $scope.pricuveZaZgraduGodina.KS.indexOf(rec);
                        $scope.pricuveZaZgraduGodina.KS.splice(index, 1);
                    }
                });
            }
            // ako nije, u bazi je, stavi status na 'd'
            else {
                $scope.pricuveZaZgraduGodina.KS.forEach(function (rec) {
                    if (rec.Id == Id)
                        rec.Status = 'd';
                });
                console.log($scope.pricuveZaZgraduGodina.KS);
            }
            changes.push(Id);
            OkZaSnimanje();
        }

        function OkZaSnimanje() {
            $scope.snimanjeOk = false;
            $scope.pricuveZaZgraduGodina.KS.forEach(function (rec) {
                if (rec.Status != 'd') {
                    if (isFinite(rec.Uplata) && rec.Mjesec != null && parseInt(rec.Mjesec) > 0 && parseInt(rec.Mjesec) < 13 && isFinite(rec.Mjesec))
                        $scope.snimanjeOk = true;
                }
            });
            $scope.dodavanjeOk = $scope.snimanjeOk;
        }

        $scope.uplataChanged = function (ksId) {
            console.log('uplata changet at KS.Id: ' + ksId);
            changes.push(ksId);
            sumaUplata();
            OkZaSnimanje();
        }

        $scope.ksChanged = function (ksId) {
            $scope.pricuveZaZgraduGodina.KS.forEach(function (ks) {
                if (ksId == ks.Id && !isFinite(ks.Mjesec)) {
                    ks.Mjesec = null;
                    $scope.snimanjeOk = false;
                    $scope.dodavanjeOk = false;
                }
            });
            changes.push(ksId);
            OkZaSnimanje();
        }

        // watch for changes - mjesec, uplata
        // ako je promjenjen mjesec ili uplata, markiraj ovaj mjesec u PricuviMj kao dirty,
        // obojaj ga u tablici godisnje pricuve u crvenu, ako se klikne save

        $scope.save = function () {
            console.log('save');
            changes.forEach(function (ksId) {
                // ako ima promjena, nadji mjesec i markiraj pricuvuMj[mjesec]
                pricuveZaZgraduGodina.KS.forEach(function (ksObj) {
                    // nadji objekt koji je promjenjen
                    if (ksId == ksObj.Id) {
                        // sad markiraj mjesec iz mjesecne pricuve, mjesec je ksObj.Mjesec
                        pricuveZaZgraduGodina.PricuvaMj.forEach(function (prMj) {
                            if (prMj.Mjesec == ksObj.Mjesec)
                                prMj.Dirty = true;
                        });
                    }
                });
            });
            $uibModalInstance.close(pricuveZaZgraduGodina);
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }

        function sumaUplata() {
            var totalUplata = 0;
            var totalZaduzenje = 0;
            $scope.pricuveZaZgraduGodina.KS.forEach(function (ks) {
                if ($scope.stanarId == ks.StanarId) {
                    totalUplata += parseFloat(ks.Uplata)
                }

                $scope.pricuveZaZgraduGodina.PricuvaMj.forEach(function (prMj) {
                    if ($scope.stanarId == prMj.VlasnikId && ks.Mjesec == prMj.Mjesec)
                        totalZaduzenje += parseFloat(prMj.Zaduzenje)
                });
                
                
            });
            $scope.uplataTotal = totalUplata;
            $scope.zaduzenjeTotal = totalZaduzenje;
            $scope.stanjeTotal = totalUplata + totalZaduzenje;
        }

    }])
   