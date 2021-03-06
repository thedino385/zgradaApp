﻿angularApp.controller('zgradeCtrl', ['$scope', '$location', '$routeParams', '$rootScope', 'DataService',
    function ($scope, $location, $routeParams, $rootScope, DataService) {

        
        $rootScope.loaderActive = true;
        //var zgrade = [];
        DataService.getZgrade().then(
            function (result) {
                // on success
                $scope.zgrade = result.data;
                //zgradaNaziv = result.data.Zgrada;
                $rootScope.loaderActive = false;
                $scope.selZgradaId = DataService.selZgradaId;
                console.log('DataService.selZgradaId: ' + DataService.selZgradaId);
            },
            function (result) {
                // on errr
                $rootScope.errMsg = result.Message;
            }
        );

        $scope.novaZgrada = function () {
            $location.path('/zgrada/0');
        };

        $scope.edit = function (obj) {
            $('#topNavApp').text(obj.Naziv);
            $location.path('/zgrada/' + obj.Id);
        }

        $scope.goToPosebniDjeloviChild = function (zgradaId) {
            $location.path('/posebniDijeloviMasterList/' + zgradaId);
        }

        $scope.goToPrihodiRashodi = function (zgradaId) {
            $location.path('/prihodiRashodi/' + zgradaId);

        }

        $scope.selectZgrada = function (zgrada) {
            $('.navigation').fadeIn('slow');
            $('#topNavSelectedZgrada').text(zgrada.Naziv);
            $('#topNavSelectedZgrada').attr('href', '#!/zgrada/' + zgrada.Id);
            DataService.selZgradaId = zgrada.Id;

            //$rootScope.loaderActive = true;
            //DataService.getZgrada(zgrada.Id, false, false).then(
            //    function (result) {
            //        // on success
            //        $rootScope.loaderActive = false;
            //        DataService.zgradaUseri = result.data.Useri;
            //        DataService.userId = result.data.userId;
            //        $('.navigation').fadeIn('slow');
            //        $('#topNavSelectedZgrada').text(zgrada.Naziv);
            //        $('#topNavSelectedZgrada').attr('href', '#!/zgrada/' + zgrada.Id);
            //        DataService.selZgradaId = zgrada.Id;
            //        $scope.selZgradaId = zgrada.Id;
            //    },
            //    function (result) {
            //        // on errr
            //        $rootScope.loaderActive = false;
            //    }
            //);
        }

        $scope.popisStanara = function (zgrada) {
            $location.path('/popisStanara/' + zgrada.Id);
        }


        //$scope.goToPregled = function (zgradaId) {
        //    $location.path('/pregled/' + zgradaId);
        //}

        //$scope.goToZaduzivanje = function (zgradaId) {
        //    $location.path('/zaduzivanje/' + zgradaId);
        //}

    }]);
