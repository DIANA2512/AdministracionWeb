<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ProyectoFinal.Index2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <meta http-equiv="X-UA-Compatible" content="ie=edge" />
  <title>Inicio</title>
  <link href="https://fonts.googleapis.com/css?family=Karla:400,700&display=swap" rel="stylesheet" />
  <link rel="stylesheet" href="https://cdn.materialdesignicons.com/4.8.95/css/materialdesignicons.min.css" />
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
  <link rel="stylesheet" href="assets/css/login.css" />

</head>
<body>
   
    <form id="form1" runat="server" >
        <div class="card" style="background-color:blueviolet">
             <main>     
                  <div class="row">
                      <div class="col-sm-1 login-wrapper my-auto">
                        </div>
                    <div class="col-sm-5 login-section-wrapper " >
                        <center>
                          <div class="login100-pic js-tilt">
                            <img src="images/logo_cliente2.png" alt="logo" class="logo" height="100" width="150"/>
                          </div>
                            </center>
                      
                      <div class="col-sm-10 login-wrapper my-auto">
                        <h2 class="login-title">Panadería y Cafetería</h2>
                        <h2 class="login-title">"Piedad López"</h2>

                            <center>
					            <div class="dropdown">
					                <asp:DropDownList ID="ddrRol" runat="server" CssClass="btn btn-success dropdown-toggle-split table-responsive" AutoPostBack="True">
						 
					                </asp:DropDownList>
					            </div>
					      </center>
                          <br />
                          <div class="form-group">
                            <div class="wrap-input100 validate-input" data-validate = "Usuario requerido">
                            <label  style="color:black">Usuario</label>
                            <input type="text" name="usuario" id="User" class="form-control" placeholder="Usuario" onkeypress="return check(event)"/>
                            </div>
                          </div>
                          <div class="form-group mb-3">
                             <div class="wrap-input100 validate-input" data-validate = "Contraseña requerida">
                            <label for="password" style="color:black">Contraseña</label>
                            <input type="password" name="pass" id="pass" class="form-control" placeholder="Digíte su contraseña"/>
                               </div>
                             <div style="margin-top:15px;">
                                  <input style="margin-left:10px;" type="checkbox" id="mostrar_contrasena" title="clic para mostrar contraseña"/>
                                  &nbsp;&nbsp;Mostrar Contraseña

                            </div>

                          </div>
                         
                             <asp:Label ID="mensajetransaccionlbl" runat="server" CssClass="btn btn-group-lg btn-danger align-items-lg-center"
						        Text="transaccion" Visible="false" ></asp:Label>
                   
                            <asp:Button name="login" id="login" class="btn btn-block login-btn alert-info"  runat="server" Text="Inicio" onclick="btningresar_Click"/>
             
                        <a href="RecuperarPass.aspx" class="forgot-password-link">Olvidó su contraseña?</a>
                        
                      </div>
                    </div>

                    
                        <div class="col-sm-5 px-0 d-none d-sm-block">
                            <div class="card-body container-fluid" style="background-color:blueviolet">
                            <img src="images/chocolate.png" alt="login image" class="login-img" height="500"/>
                            </div>
                        </div>
                </div>
               
                     </main>
            <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
            <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
            <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
        </div>
    </form>
   
</body>

<script src="js/jquery-3.2.1.min.js" type="text/javascript"></script>

<script>
$(document).ready(function () {
  $('#mostrar_contrasena').click(function () {
    if ($('#mostrar_contrasena').is(':checked')) {
        $('#pass').attr('type', 'text');
    } else {
        $('#pass').attr('type', 'password');
    }
  });
});
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

<script src="js/jquery-3.2.1.min.js" type="text/javascript"></script>



<!--===============================================================================================-->
<script src="~/js/main.js"></script>

</html>
