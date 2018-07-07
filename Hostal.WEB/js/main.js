$(document).ready(function() {
    $("#txtRepPassword").focusout(function(){
        var original = $("#txtPassword").val();
        var verif = $(this).val();
        if (verif.trim() != "") {
            if (original != verif) {
                alert("Las contraseñas deben ser iguales");
                $(this).css("borderColor","red");
                $("#txtPassword").css("borderColor","red");
            }else{
                $(this).css("borderColor","green");
                $("#txtPassword").css("borderColor","green");
            }    
        }else{
            $(this).css("borderColor","#d8dde2");
        }    
    });

    $("#txtUsuario").focusout(function(){
        var user = $(this).val();
        user = user.trim();
        if (/\s/.test(user)) {
            alert("El nombre de usuario no puede tener espacios");
            $("#txtUsuario").css("borderColor","red");
        }else{
            if (user.trim() != "") {
                $.ajax({
                    url: 'Registro.aspx/VerificarUser',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    type: 'POST',
                    /* Se implementa "JSON.stringify" ya que sin eso, el string del usuario viene con caracteres extraños */ 
                    data:JSON.stringify({ "user": user}),
                    success: function(response){
                        if (response.d != 1) {
                            $("#txtUsuario").css("borderColor","green");
                        }else{
                            alert("El nombre de usuario ya existe");
                            $("#txtUsuario").css("borderColor","red");
                        }
                    }
                });
            }else{
                $("#txtUsuario").css("borderColor","#d8dde2");
            }
        }        
    });

    $("#txtRut").focusout(function(){
        var rut = $(this).val();
        
        if (rut.trim() != "") {
            $.ajax({
                url: 'Registro.aspx/VerificarRut',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                type: 'POST',
                /* Se implementa "JSON.stringify" ya que sin eso, el string del rut viene con caracteres extraños */ 
                data:JSON.stringify({ "rut": rut}),
                success: function(response){
                    if (response.d != 1) {
                        $("#txtRut").css("borderColor","green");
                    }else{
                        alert("El rut ingresado ya existe");
                        $("#txtRut").css("borderColor","red");
                    }
                }
            });
        }else{
            $("#txtRut").css("borderColor","#d8dde2");
        }
    });


});

function soloNumeros(e){
    var key = window.Event ? e.which : e.keyCode
    return (key >= 48 && key <= 57)
}