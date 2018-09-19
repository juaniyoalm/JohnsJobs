var app = angular.module("app", []);

app.controller('DemandanteController', ['$scope', '$http', '$element', '$interval', 'myHttp', function ($scope, $http, $element, $interval, myHttp) {

    $scope.dem = {};

    $scope.demLoad = {};
    $scope.demLoadEditar = {};
    $scope.nivelesEstudios = {};
    $scope.listOfertas = [];
    $scope.listOfertasDemandante = [];
    $scope.ofer = {};
    $scope.inscripcion = {}

    $scope.section = 0;
    $scope.ofertas = 0;


    $scope.editar = 0;

    $scope.cargarNiveles = function () {
        var url = "/Demandante/CargarNiveles";
        $http({
            method: 'POST',
            url: url,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Los niveles no se han cargado correctamente.")
            } else {
                $scope.nivelesEstudios = result;
            }
        }).error(function () {
            alert("Error en la función.")
        });
    };

    $scope.guardarDatosDemandante = function () {
        var url = "/Demandante/GuardarDemandante";
        $http({
            method: 'POST',
            url: url,
            data: $scope.dem,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("El registro de los datos es erróneo")
            } else {
                window.location.href = "/Demandante/Inicio";
            }
        }).error(function () {
        });
    };


    $scope.obtenerDatosDemandante = function () {
        var url = "/Demandante/CargarDatosDemandanteModel";
        $http({
            method: 'POST',
            url: url,
            contentType: "application/json; charset=utf-8",
        }).success(function (result) {
            if (result === false) {
                alert("Los datos del empleador no se han cargado correctamente.")
            } else {
                $scope.demLoad = result;
                $scope.cargarTotalOfertasSinSuscribir();
            }
        }).error(function () {
            alert("Error en la función.")
        });
    };

    $scope.modificarDemandante = function () {
        if ($scope.demLoad != $scope.demLoadEditar) {
            myHttp.postData("/Demandante/ModificarDemandante", $scope.demLoadEditar)
                .then(function (data) {
                    alert("DemandanteModificado");
                    window.location.href = "/Demandante/Inicio";
                })
                .catch(function (err) {
                    alert("Error al modificar demandante");
                })
        } else {
            alert("No se ha modificado ningún campo");
        }

    };


    $scope.cargarTotalOfertasSinSuscribir = function () {
        myHttp.postData("/Demandante/CargarTotalOfertasSinSuscribir", { idDemandante:$scope.demLoad.Id })
            .then(function (data) {
                $scope.listOfertas = data;
                $scope.cargarOfertasDemandante();
            })
            .catch(function (err) {
                alert("Error de la promesa");
            })
    };

    $scope.cargarOfertasDemandante = function () {
        myHttp.postData("/Demandante/CargarTotalOfertasDemandante", { idDemandante:$scope.demLoad.Id })
            .then(function (data) {
                $scope.listOfertasDemandante = data;
            })
            .catch(function (err) {
                alert("Error de la promesa");
            })
    }

    $scope.inscribirseOferta = function (oferta) {

        $scope.inscripcion.IdOferta = oferta.Id;
        $scope.inscripcion.IdDemandante = $scope.demLoad.Id;

        myHttp.postData("/Demandante/InscribirseOferta", $scope.inscripcion)
            .then(function (data) {

                window.location.href = "/Demandante/Inicio";
            })
            .catch(function (err) {
                alert("Error al subscribirse a la oferta");
            })
    }

    $scope.anularInscripcion = function (ofertaD) {
        $scope.inscripcion.IdOferta = ofertaD.Id;
        $scope.inscripcion.IdDemandante = $scope.demLoad.Id;

        myHttp.postData("/Demandante/AnularInscripcion", $scope.inscripcion)
            .then(function (data) {

                window.location.href = "/Demandante/Inicio";
            })
            .catch(function (err) {
                alert("Error al anular inscripción");
            })
    }

    $scope.modoEditar = function () {

        
        $scope.demLoadEditar.ImagenB64 = $scope.demLoad.ImagenB64;
        $scope.demLoadEditar.Usuario = $scope.demLoad.Usuario;
        $scope.demLoadEditar.Id = $scope.demLoad.Id;
        $scope.demLoadEditar.IdUsuario = $scope.demLoad.IdUsuario;
        $scope.demLoadEditar.Nombre = $scope.demLoad.Nombre;
        $scope.demLoadEditar.Apellido1 = $scope.demLoad.Apellido1;
        $scope.demLoadEditar.Apellido2 = $scope.demLoad.Apellido2;
        $scope.demLoadEditar.Telefono = $scope.demLoad.Telefono;
        $scope.demLoadEditar.Email = $scope.demLoad.Email;
        $scope.demLoadEditar.PerfilLinkedin = $scope.demLoad.PerfilLinkedin;
        $scope.demLoadEditar.NivelEstudiosNombre = $scope.demLoad.NivelEstudiosNombre;
        $scope.demLoadEditar.NivelEstudios = $scope.demLoad.NivelEstudios;
        $scope.demLoadEditar.Contrasena = $scope.demLoad.Contrasena;
        $scope.demLoadEditar.FotoPerfil = $scope.demLoad.FotoPerfil;
        $scope.demLoadEditar.Edad = $scope.demLoad.Edad;
        $scope.demLoadEditar.ExperienciaLaboral = $scope.demLoad.ExperienciaLaboral;
        $scope.demLoadEditar.TipoUsuario = $scope.demLoad.TipoUsuario;

        $scope.editar = 1;
    }

    $scope.modoEditarDesactivado = function () {

        $scope.demLoadEditar.ImagenB64 = $scope.demLoad.ImagenB64;
        $scope.demLoadEditar.Usuario = $scope.demLoad.Usuario;
        $scope.demLoadEditar.Id = $scope.demLoad.Id;
        $scope.demLoadEditar.IdUsuario = $scope.demLoad.IdUsuario;
        $scope.demLoadEditar.Nombre = $scope.demLoad.Nombre;
        $scope.demLoadEditar.Apellido1 = $scope.demLoad.Apellido1;
        $scope.demLoadEditar.Apellido2 = $scope.demLoad.Apellido2;
        $scope.demLoadEditar.Telefono = $scope.demLoad.Telefono;
        $scope.demLoadEditar.Email = $scope.demLoad.Email;
        $scope.demLoadEditar.PerfilLinkedin = $scope.demLoad.PerfilLinkedin;
        $scope.demLoadEditar.NivelEstudiosNombre = $scope.demLoad.NivelEstudiosNombre;
        $scope.demLoadEditar.NivelEstudios = $scope.demLoad.NivelEstudios;
        $scope.demLoadEditar.Contrasena = $scope.demLoad.Contrasena;
        $scope.demLoadEditar.FotoPerfil = $scope.demLoad.FotoPerfil;
        $scope.demLoadEditar.Edad = $scope.demLoad.Edad;
        $scope.demLoadEditar.ExperienciaLaboral = $scope.demLoad.ExperienciaLaboral;
        $scope.demLoadEditar.TipoUsuario = $scope.demLoad.TipoUsuario;

        $scope.editar = 0;
    }
   
    $scope.mostrarMiPerfil = function () {
        $scope.section = 1;
        $scope.ofertas = 0;
    };


    $scope.mostrarOfertas = function () {
        $scope.section = 0;
        $scope.ofertas = 1;
    };

    $scope.verOferta = function (o) {
        $scope.ofer = o;
        $('#modalPageOferta').modal('show');
    }

    $scope.verOfertaD = function (o) {
        $scope.ofer = o;
        $('#modalPageOfertaD').modal('show');
    }

}]);


/**
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

        post: function (baseUrl) {

            var defered = $q.defer();
            var promise = defered.promise;

            $http({
                method: 'POST',
                url: baseUrl,
                contentType: "application/json; charset=utf-8",
            }).success(function (data, status, headers, config) {
                defered.resolve(data)
            }).error(function (data, status, headers, config) {
                defered.reject(status);
            });
            return promise;
        },

        
        postData: function (baseUrl, datos) {

            var defered = $q.defer();
            var promise = defered.promise;

            $http({
                method: 'POST',
                url: baseUrl,
                contentType: "application/json; charset=utf-8",
                data: datos,
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