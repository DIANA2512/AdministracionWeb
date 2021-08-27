<%@ Page Title="" Language="C#" MasterPageFile="~/General.Master" AutoEventWireup="true" CodeBehind="PerfilCajero.aspx.cs" Inherits="ProyectoFinal.PerfilCajero" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <body background="../images/pan.jpg"; background-repeat: no-repeat; background-attachment: fixed">
    <div class="wrapper ">
<%--    <div>

    
   <img src="images/logo.jpg" width="150" height="115" align="bottom"/>
    </div>
   <h1 style="text-align:center"> PAN DE LA SUCRE </h1> --%>
    <br/>

       <h1 style=" font-family:Lucida Calligraphy; color:white; text-align:center " >
        <img src="images/logo.jpg" width="150" height="115"> <b>PANADERÍA Y CAFETERÍA </b><img src="images/logo_cliente2.png" width="150" height="115">
       </h1>
        <br />
          <h1 style=" font-family:Lucida Calligraphy; color:white; text-align:center " >
         <b>PIEDAD LÓPEZ</b>
       </h1>
    <br />
        <div class="container" width="80%" style="center">
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
  <a class="navbar-brand" href="CajMenu.aspx" Font-Bold="true">Inicio</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>

  <div class="collapse navbar-collapse" id="navbarSupportedContent">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item active">
        <a class="nav-link" href="PerfilCajero.aspx" Font-Bold="true">Mi Perfil <span class="sr-only">(current)</span></a>
      </li>
     
    </ul>
  </div>
      <ul class="navbar-nav">
          <li class="nav-item dropdown">
              <a class="nav-link" href="javascript:;" id="navbarDropdownProfile" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                  <i class="material-icons">person</i>
                  <p class="d-lg-none d-md-block">
                            Account </p>
               </a>
              <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownProfile">
                  <a class="dropdown-item" href="PerfilCajero.aspx">Perfil</a>
                  <div class="dropdown-divider">
                  </div>
                  <a class="dropdown-item" href="Index.aspx">Salir</a>
              </div>
           </li>
        </ul>
</nav>
            </div>
     <div class="limiter">
         <center>
     <table class="col-md-6">
  <thead>
    <tr>
      <th scope="col"></th>
      <th scope="col">

 <div class="card" >
  <div class="card-body">
    <h5 class="card-title" ><b>Datos Informativos</b></h5>
    <table class="table" style="width: 100%">
  <thead>
    <tr style="align-items:center">
      <th scope="col">
          <asp:Label ID="lblnombre" runat="server" Text="Nombre y Apellido:" CssClass="col-form-label-sm" Font-Bold="true"></asp:Label>
          <asp:TextBox ID="txtnombre" runat="server" Enabled="false" CssClass="form-control input-group"></asp:TextBox>
      </th>
     <%-- <th scope="col"><asp:Label ID="Label6" runat="server" Text="Sánchez" CssClass="col-form-label-sm" ></asp:Label></th>--%>
    <div align="center">
        <img src="images/usuario.png" width="180" height="165">
     </div>
    </tr>
      <tr>
          <th scope="col">
              <asp:Label ID="lblusuario" runat="server" Text="Usuario:" CssClass="col-form-label-sm" Font-Bold="true"></asp:Label>
              <asp:TextBox ID="txtusuario" runat="server" Enabled="false" CssClass="form-control input-group"></asp:TextBox>
          </th>
      </tr>
     <tr>
      <th scope="col">
          <asp:Label ID="lblcedula" runat="server" Text="Número de Cédula:" CssClass="col-form-label-sm" Font-Bold="true"></asp:Label>
          <asp:TextBox ID="txtcedula" runat="server" Enabled="false" CssClass="form-control input-group"></asp:TextBox>
      </th>
     </tr>
      <tr>
          <th scope="col">
              <asp:Label ID="lblcorreo" runat="server" Text="Correo Electrónico:" CssClass="col-form-label-sm" Font-Bold="true"></asp:Label>
              <asp:TextBox ID="txtcorreo" runat="server" CssClass="form-control input-group" type="email" MaxLength="100" required ></asp:TextBox>
              
          </th>
      </tr>
      <tr>
          <th scope="col">
              <asp:Label ID="lbltelefono" runat="server" Text="Número de teléfono:" CssClass="col-form-label-sm" Font-Bold="true"></asp:Label>
              <asp:TextBox ID="txttelefono" onkeypress="return justNumbers(event);" runat="server" CssClass="form-control input-group" MinLength="9" MaxLength="10"  required ></asp:TextBox>
              
          </th>
      </tr>
      
      <tr>
          <th scope="col">
              <asp:Label ID="lblpass" runat="server" Text="Contraseña:" CssClass="col-form-label-sm" Font-Bold="true"></asp:Label>
              <asp:TextBox ID="txtpass" MinLength="7" MaxLength="100" runat="server"  CssClass="form-control input-group" type="password" required ></asp:TextBox>
               
          </th>
       </tr>

      <tr>
          <th>
              <center>
              <asp:Button ID="Button1" runat="server" CssClass="btn btn-success align-content-center" Text="GUARDAR" OnClick="Button1_Click"/>
                  <asp:LinkButton ID="btncancelar" runat="server" Text="Cancelar" class="btn btn-danger" href="PerfilCajero.aspx"/>
              </center>
          </th>
      </tr>

              </table>
  
      
 
  </div>
</div>
            
          
             </th>
      <th scope="col"></th>
    </tr>
  </thead>
       
  <tbody>
  </tbody>

</table>
</center>
				<br />
			    

			</div>
     </div>
               
            </div>
        </div>
    </body>
</asp:Content>
