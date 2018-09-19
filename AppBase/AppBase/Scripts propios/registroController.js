var app = angular.module("app", []);

app.controller('RegistroController', ['$scope', '$http', '$element', '$interval', function ($scope, $http, $element, $interval) {

    $scope.user = {};

    $scope.validarDatos = function () {

        var url = "/Registro/RegistrarUsuario";

        $http({
            method: 'POST',
            url: url,
            data: $scope.user,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                window.location.href = "/Registro/ErrorRegistro";
            } else {
                window.location.href = "/Registro/RegistroCorrecto";
            }
        }).error(function () {

        });
    };

}]);
