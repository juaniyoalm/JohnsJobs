var app = angular.module("app", []);
/*
 * CONTROLLER
 */
app.controller('EmpleadorController', ['$scope', '$http', '$element', '$interval','myHttp', function ($scope, $http, $element, $interval, myHttp) {

    $scope.emp = {};

    $scope.industrias = {};
    $scope.empLoad = {};
    $scope.listOfertas = [];
    $scope.ofer = {};
    $scope.listDemandantesInscritos = [];

    $scope.demInscrito = {};

    $scope.nameIndustria = {};

    var date = new Date();
    $scope.dateNow = date.getFullYear() + '-' + ('0' + (date.getMonth() + 1)).slice(-2) + '-' + ('0' + date.getDate()).slice(-2);

    $scope.section = 0;
    $scope.bussiness = 0;
    $scope.ofertas = 0;

    $scope.guardarDatosEmpleador = function () {
        var url = "/Empleador/GuardarEmpleador";
        $http({
            method: 'POST',
            url: url,
            data: $scope.emp,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("El registro de los datos es erróneo")
            } else {
                window.location.href = "/Empleador/Inicio";
            }
        }).error(function () {
        });
    };

    $scope.cargarOfertas = function () {

        /*
        var url = "/Empleador/GetOfertas";

        $http({
            method: 'POST',
            url: url,
            data: { idEmpleador: $scope.empLoad.Id },
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Ofertas no cargadas")
            } else {
                $scope.listOfertas = result;
            }
        }).error(function () {
        });
        */
        myHttp.post("/Empleador/GetOfertas", { idEmpleador: $scope.empLoad.Id })
            .then(function(data) {
                 $scope.listOfertas = data;
            })
            .catch(function(err) {
                alert("Error de la promesa");
            })
    };

    $scope.crearOferta = function () {
        var url = "/Empleador/CrearOferta";
        alert("Metodo crearOferta");
        $scope.ofer.idEmpleador = $scope.empLoad.Id;
        $http({
            method: 'POST',
            url: url,
            data: $scope.ofer,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("El registro de los datos es erróneo")
            } else {
                alert("Oferta cargada");
                $scope.listOfertas.push($scope.oferta);
            }
        }).error(function () {
            alert("Error en la función cargarOferta");
        });
    }


    $scope.cargarIndustrias = function () {
        var url = "/Empleador/CargarIndustrias";
        $http({
            method: 'POST',
            url: url,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Las industrias no se han cargado correctamente.")
            } else {
                $scope.industrias = result;
            }
        }).error(function () {
            alert("Error en la función.")
        });
    };

    $scope.obtenerDatosEmpleador = function () {
        var url = "/Empleador/CargarDatosEmpleadorModel";
        $http({
            method: 'POST',
            url: url,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Los datos del empleador no se han cargado correctamente.")
            } else {
                $scope.empLoad = result;
                $scope.cargarOfertas();
            }
        }).error(function () {
            alert("Error en la función.")
        });
    };

    $scope.cargarUsuariosInscritos = function (oferta) {
        myHttp.post("/Empleador/GetUsuariosInscritos", { idOferta: oferta.Id })
            .then(function(data) {
                $scope.listDemandantesInscritos = data;
            })
            .catch(function(err) {
                alert("Error de la promesa");
            })
    }


    $scope.cambiarEstado = function (usuario, estado) {
        $scope.demInscrito.IdDemandante = usuario.IdDemandante;
        $scope.demInscrito.IdOferta = usuario.IdOferta;
        $scope.demInscrito.Estado = estado;

        myHttp.post("/Empleador/CambiarEstado", $scope.demInscrito)
            .then(function (data) {
                window.location.href = "/Empleador/Inicio";
            })
            .catch(function (err) {
                alert("Error de la promesa");
            })
    }

    $scope.verOferta =  function(o) {
        $scope.ofer = o;
        $scope.cargarUsuariosInscritos(o);
        $('#modalPageOferta').modal('show');
    }

    $scope.mostrarMiPerfil = function () {
        $scope.section = 1;
        $scope.bussiness = 0;
        $scope.ofertas = 0;
    };

    $scope.mostrarEmpresa = function () {
        $scope.section = 0;
        $scope.bussiness = 1;
        $scope.ofertas = 0;
    };

    $scope.mostrarOfertas = function () {
        $scope.section = 0;
        $scope.bussiness = 0;
        $scope.ofertas = 1;
    };

    $scope.formatJSONDate = function(jsonDate) {
        var newDate = dateFormat(jsonDate, "mm/dd/yyyy");
        return newDate;
    }


}]);


/*
 * DIRECTIVAS
 */
app.directive("fileread", [function () {
    return {
        scope: {
            fileread: "="
        },
        link: function (scope, element, attributes) {
            element.bind("change", function (changeEvent) {
                var reader = new FileReader();
                reader.onload = function (loadEvent) {
                    scope.$apply(function () {
                        scope.fileread = loadEvent.target.result;
                    });
                }
                reader.readAsDataURL(changeEvent.target.files[0]);
            });
        }
    }
}]);





/**
 * SERVICIOS
 */

app.factory('myHttp', ['$http', '$q', function ($http, $q) {

    var httpFactory = {

        get: function (baseUrl) {
            var defered = $q.defer();
            var promise = defered.promise;

            $http({
                method: 'GET',
                url: baseUrl + '/datos.json'
            }).success(function (data, status, headers, config) {
                defered.resolve(data);
            }).error(function (data, status, headers, config) {
                defered.reject(status);
            });

            return promise;

        },

        post: function (baseUrl, dataIn) {

            var defered = $q.defer();
            var promise = defered.promise;

            $http({
                method: 'POST',
                url: baseUrl,
                data: dataIn,
                contentType: "application/json; charset=utf-8",
            }).success(function (data, status, headers, config) {
                defered.resolve(data)
            }).error(function (data, status, headers, config) {
                defered.reject(status);
            });
            return promise;
        }
    }

    return httpFactory;
}]);
