<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarPass.aspx.cs" Inherits="ProyectoFinal.RecuperarPass" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="~/images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="~/vendor/bootstrap/css/bootstrap.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="~/fonts/font-awesome-4.7.0/css/font-awesome.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="~/vendor/animate/animate.css"/>
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="~/vendor/css-hamburgers/hamburgers.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="~/vendor/select2/select2.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="~/css/util.css"/>
	<link rel="stylesheet" type="text/css" href="~/css/main.css"/>
<!--===============================================================================================-->
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

</head>
<body>
        <div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
				<div class="login100-pic js-tilt" >
					<img src="images/chocolate.png" alt="IMG">

                    <asp:Label ID="mensajetransaccionlbl" runat="server" CssClass="btn btn-group-lg btn-danger align-items-lg-center"
						Text="transaccion" Visible="false"></asp:Label>
				</div>

				<form class="login100-form validate-form" runat="server">
					<span class="login100-form-title">
						Ingresar un correo válido.
					</span>

					<br />
					<div class="wrap-input100 validate-input" data-validate = "Email requerido">
						<input class="input100" type="email"  name="email" placeholder="Email"  >
						<span class="focus-input100"></span>
						<span class="symbol-input100">
							<i class="fa fa-mail-forward" aria-hidden="true"></i>
						</span>
					</div>
					<br />
							<div class="row container-login100-form-btn">
							<div class="form-group">
								<asp:Button ID="btnenviar" runat="server"  Text="Enviar" class="btn btn-danger pull-right" OnClick="btnenviar_Click"/>
								
				
							</div>
								<br />
								<br />
							<div class="form-group" style="margin-left:12px">
								<asp:LinkButton ID="btncancelar" runat="server" Text="Inicio" class="btn btn-success pull-right" href="Index.aspx"/>
					
							</div>
							
						</div>
					
					
                    <asp:Label ID="lblmsg" runat="server" Text="" CssClass="col-form-label-sm" ></asp:Label>
					
					
					</div>
			</div>
		</div>
	
	
<!--===============================================================================================-->	
	<script src="~/vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="~/vendor/bootstrap/js/popper.js"></script>
	<script src="~/vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="~/vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="~/vendor/tilt/tilt.jquery.min.js"></script>
	<script >
        $('.js-tilt').tilt({
            scale: 1.1
        })
    </script>
<!--===============================================================================================-->
<!--=====================VALIDAR EN LA BDD AL MOMETO DE REGISTRAR EL USUARIO=======================-->
<script>
    function check(e) {
        tecla = (document.all) ? e.keyCode : e.which;
        //Tecla de retroceso para borrar, siempre la permite
        if (tecla == 8) {
            return true;
        }
        // Patron de entrada, en este caso solo acepta numeros y letras
        patron = /[A-Za-z0-9]/;
        tecla_final = String.fromCharCode(tecla);
        return patron.test(tecla_final);
    }
</script>
<!--===============================================================================================-->
<script src="~/js/main.js"></script>
</form>
</body>
</html>






