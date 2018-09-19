var app = angular.module("app", []);

app.controller('LoginController', ['$scope', '$http', '$element', '$interval', function ($scope, $http, $element, $interval) {

    $scope.user = {};

    $scope.validarDatos = function () {

        var url = "/Login/IniciarSesion";
        $http({
            method: 'POST',
            url: url,
            data: $scope.user,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                window.location.href = "/Login/ErrorLogin";
            } else if (result.TipoUsuario == 0) {
                window.location.href = "/Empleador/Index";
                //alert("Sale de empleador");
                //document.cookie("id", result.id);
            } else {
                window.location.href = "/Demandante/Index";
                //document.cookie("id", result.id);
            }
            //alert("termina js");
        }).error(function () {
            alert("Error en la función js");
        });
    };

}]);