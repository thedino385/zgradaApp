﻿var angularApp = angular.module('angularApp', ['ngRoute', 'ui.bootstrap', 'ngMaterial', 'ngAnimate', 'toastr']);


angularApp.config(['$routeProvider', '$locationProvider', '$httpProvider', function ($routeProvider, $locationProvider, $httpProvider) {
    $routeProvider
    .when('/index', {
        templateUrl: '../app/index.html',
        controller: 'indexCtrl'
    })
    .when('/zgrade', {
        templateUrl: '../app/Sifarnici/zgrade.html',
        controller: 'zgradeCtrl'
    })
    .when('/zgrada/:id', {
        templateUrl: '../app/Sifarnici/zgrada.html',
        controller: 'zgradaCtrl'
    })
    .when('/pripadci', {
        templateUrl: '../app/Sifarnici/pripadci.html',
        controller: 'pripadciCtrl'
    })
    .when('/pripadak/:id', {
        templateUrl: '../app/Sifarnici/pripadak.html',
        controller: 'pripadakCtrl'
    })
    .when('/prosebniDIjelovi', {
        templateUrl: '../app/Sifarnici/prosebniDIjelovi.html',
        controller: 'prosebniDIjeloviCtrl'
    })
    .when('/posebniDio/:id', {
        templateUrl: '../app/Sifarnici/posebniDio.html',
        controller: 'posebniDioCtrl'
    })
    .when('/stanovi/:id', { // zgradaId
        templateUrl: '../app/Sifarnici/stanovi.html',
        controller: 'stanoviCtrl'
    })
    .when('/stan/:id', { // stanId
        templateUrl: '../app/Sifarnici/stan.html',
        controller: 'stanCtrl'
    })
    .when('/pregled/:id', { // stanId
        templateUrl: '../app/Sifarnici/zgradaPregledPripadakaPoStanovima.html',
        controller: 'zgradaPregledPripadakaPoStanovimaCtrl'
    })
    .when('/zaduzivanje/:id', { // stanId
        templateUrl: '../app/zaduzivanja/zaduzivanjePoMj.html',
        controller: 'zaduzivanjePoMjCtrl'
    })
    .when('/prihodirashodi', { // stanId
        templateUrl: '../app/PihRas/index.html',
        controller: 'indexPrihRasCtrl'
    })
    .when('/prihrasedit', { // stanId
        templateUrl: '../app/PihRas/edit.html',
        controller: 'editPrihRasCtrl'
    })
    .otherwise({
        redirectTo: '/index'
    });
}])


