var app = angular.module("app", ['ui.bootstrap']);

function validarDatos() {

    var user = document.getElementById("user").value;
    var password = document.getElementById("password").value;

    if (user == null || user.length <= 0)
        return alert("Debes introducir un nombre de usuario.");

    if (password == null || password.length <= 0)
        return alert("Debes introducir una contraseña.");
      
    if (password.length < 5 || password.length > 20)             
        return alert("La contraseña debe tener entre 5 y 20 caracteres.");

        
        
    var postData = JSON.stringify({
        "usuario": user,
        "contrasena": password
    });

    alert(postData);
    $.ajax({
        type: "POST",
        url: '/Login/IniciarSesion',
        data: postData,
        cache: false,
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            if (result === false) {
                //alert("Error");
                window.location.href = "/Login/ErrorLogin";
            } else {
                //alert("Exito");
                window.location.href = "/Login/PaginaInicial";
            }

        },
        error: function (result) {

        }
    });


}
