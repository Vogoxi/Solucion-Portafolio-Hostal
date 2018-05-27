$(document).ready(function() {
    $("#ContentPlaceHolder1_txtRepPassword").change(function(){
        var original = $("#ContentPlaceHolder1_txtPassword").val();
        var verif = $(this).val();
        if (verif.trim() != "") {
            if (original != verif) {
                alert("Las contraseñas deben ser iguales");
                $(this).css("borderColor","red");
                $("#ContentPlaceHolder1_txtPassword").css("borderColor","red");
            }else{
                $(this).css("borderColor","green");
                $("#ContentPlaceHolder1_txtPassword").css("borderColor","green");
            }    
        }else{
            $(this).css("borderColor","#d8dde2");
        }    
    });

    $("#ContentPlaceHolder1_txtUsuario").focusout(function(){
        var user = $(this).val();
        
        if (user.trim() != "") {
            $.ajax({
                url: 'SignUp.aspx/VerificarUser',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                type: 'POST',
                data:JSON.stringify({ "user": user}),
                success: function(response){
                    if (response.d != 1) {
                        $("#ContentPlaceHolder1_txtUsuario").css("borderColor","green");
                    }else{
                        alert("El nombre de usuario ya existe");
                        $("#ContentPlaceHolder1_txtUsuario").css("borderColor","red");
                    }
                }
            });
        }else{
            $("#ContentPlaceHolder1_txtUsuario").css("borderColor","#d8dde2");
        }
    });

    $("#ContentPlaceHolder1_txtRut").focusout(function(){
        var rut = $(this).val();
        
        if (rut.trim() != "") {
            $.ajax({
                url: 'SignUp.aspx/VerificarRut',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                type: 'POST',
                data:JSON.stringify({ "rut": rut}),
                success: function(response){
                    if (response.d != 1) {
                        $("#ContentPlaceHolder1_txtRut").css("borderColor","green");
                    }else{
                        alert("El rut ingresado ya existe");
                        $("#ContentPlaceHolder1_txtRut").css("borderColor","red");
                    }
                }
            });
        }else{
            $("#ContentPlaceHolder1_txtRut").css("borderColor","#d8dde2");
        }
    });


});

function soloNumeros(e){
    var key = window.Event ? e.which : e.keyCode
    return (key >= 48 && key <= 57)
}