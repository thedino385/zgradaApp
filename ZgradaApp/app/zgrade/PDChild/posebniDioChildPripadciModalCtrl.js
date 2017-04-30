﻿angularApp.controller('posebniDioChildPripadciModalCtrl', ['$scope', '$mdDialog', 'posebniDioChildId', 'pripadakId', 'pdMaster',
    function ($scope, $mdDialog, posebniDioChildId, pripadakId, pdMaster) {

        // TODOOOOOOOOOOOOOO
        console.log(pdMaster);

        //$scope.zgradaObj = zgradaObj;
        var tempObj = {};
        angular.copy(pdMaster, tempObj);
        if (pripadakId == 0) {
            $scope.pripadakObj = {
                Id: 0, ZgradaPosDioChildId: pdMaster.Id, Naziv: '', Oznaka: '', Povrsina: 0, Koef: 0,
                Napomena: '', Status: '', VrijediOdGodina: new Date().getFullYear(), VrijediOdMjesec: parseInt(new Date().getMonth() + 1 )
            };
            $scope.msg = 'Novi pripadak';
        }
        else {
            pdMaster.Zgrade_PosebniDijeloviChild.forEach(function (child) {
                child.Zgrade_PosebniDijeloviChild_Pripadci.forEach(function (prip) {
                    if (pripadakId == prip.Id)
                        $scope.pripadakObj = prip;
                });
            });
            $scope.msg = 'Uredi površinu';
        }

        $scope.save = function () {
            if (pripadakId == 0) {
                maxId = 0;
                pdMaster.Zgrade_PosebniDijeloviChild.forEach(function (child) {
                    child.Zgrade_PosebniDijeloviChild_Pripadci.forEach(function (prip) {
                        if (prip.Id > maxId) {
                            maxId = prip.Id;
                        }
                    });
                });
                $scope.pripadakObj.Id = maxId + 1;
                $scope.pripadakObj.Status = 'a';
                pdMaster.Zgrade_PosebniDijeloviChild.forEach(function (child) {
                    if (child.Id == posebniDioChildId) {
                        $scope.pripadakObj.Status = 'a';
                        child.Status = 'u';
                        child.Zgrade_PosebniDijeloviChild_Pripadci.push($scope.pripadakObj);
                    }
                });
            }
            else {
                pdMaster.Zgrade_PosebniDijeloviChild.forEach(function (child) {
                    child.Zgrade_PosebniDijeloviChild_Pripadci.forEach(function (prip) {
                        if (prip.Id == pripadakId) {
                            prip.Status = 'u';
                            child.Status = 'u';
                            prip = $scope.pripadakObj;
                        }

                    });
                });
            }
            $mdDialog.hide(pdMaster);
        };

        $scope.cancel = function () {
            $mdDialog.cancel(tempObj);
        };

    }]);