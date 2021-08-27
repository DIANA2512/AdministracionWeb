<%@ Page Title="" Language="C#" MasterPageFile="~/General.Master" AutoEventWireup="true" CodeBehind="AdmAdministracionEmpleados.aspx.cs" Inherits="ProyectoFinal.AdmAdministracionEmpleados" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
   
   <!--  <asp:Image runat="server" src="images/fondo.jpg" alt="IMG"></asp:Image>-->
 <body background="../images/pan.jpg"; background-repeat: no-repeat; background-attachment: fixed">
     <div class="wrapper ">
            <div class="sidebar" data-color="purple" data-background-color="white" data-image="assets/img/sidebar-1.jpg">
              <<div class="logo"><a href="EmpMenu.aspx" class="simple-text logo-normal">
                 MENÚ EMPLEADO
                </a></div>
              <div class="sidebar-wrapper">
                <ul class="nav">
            <%--      <li class="nav-item active  " >
                    <a class="nav-link" href="./dashboard.html">
                      <i class="material-icons">dashboard</i>
                      <p>Estadísticas</p>
                    </a>
                  </li>--%>
                  <li class="nav-item ">
                    <a class="nav-link" href="AdmAdministracionEmpleados.aspx">
                      <i class="material-icons">person</i>
                      <p>Perfil</p>
                    </a>
                  </li>
               
                </ul>
              </div>
            </div>
            <div class="main-panel">
              <!-- Navbar -->
              <nav class="navbar navbar-expand-lg navbar-transparent navbar-absolute fixed-top ">
                <div class="container-fluid">
                  
                  <button class="navbar-toggler" type="button" data-toggle="collapse" aria-controls="navigation-index" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="navbar-toggler-icon icon-bar"></span>
                    <span class="navbar-toggler-icon icon-bar"></span>
                    <span class="navbar-toggler-icon icon-bar"></span>
                  </button>
                                     
                </div>

                
              </nav>
           
                
             
            
              <!-- End Navbar -->
                  <br />
                
                    <nav class="navbar navbar-expand-lg navbar-light bg-light">
  <a class="navbar-brand" href="EmpMenu.aspx">Inicio</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>

  <div class="collapse navbar-collapse" id="navbarSupportedContent">
    <ul class="navbar-nav mr-auto">
      
     
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
                  <a class="dropdown-item" href="Index.aspx">Salir</a>
                  <div class="dropdown-divider">
                  </div>
                  
              </div>
           </li>
        </ul>
</nav>
                <br/>
                 <h1 style=" font-family:Lucida Calligraphy; color:white; text-align:center " >
        <img src="images/logo.jpg" width="150" height="115"> <b>PAN DE LA SUCRE</b>
       </h1>
    <br />
    
     <div class="limiter">
         <center>
     <table class="col-md-6">
  <thead>
    <tr>
      <th scope="col"></th>
      <th scope="col">

 <div class="card" >
  <div class="card-body">
    <h5 class="card-title">Datos Informativos</h5>
    <table class="table" style="width: 100%">
  <thead>
    <tr style="align-items:center">
      <th scope="col">
          <asp:Label ID="lblnombre" runat="server" Text="Nombre y Apellido:" CssClass="col-form-label-sm" ></asp:Label>
          <asp:TextBox ID="txtnombre" runat="server" Enabled="false" CssClass="input-group"></asp:TextBox>
      </th>
     <%-- <th scope="col"><asp:Label ID="Label6" runat="server" Text="Sánchez" CssClass="col-form-label-sm" ></asp:Label></th>--%>
    <div align="center">
        <img src="images/usuario.png" width="180" height="165">
     </div>
    </tr>
      <tr>
          <th scope="col">
              <asp:Label ID="lblusuario" runat="server" Text="Usuario:" CssClass="col-form-label-sm" ></asp:Label>
              <asp:TextBox ID="txtusuario" runat="server" Enabled="false" CssClass="input-group"></asp:TextBox>
          </th>
      </tr>
     <tr>
      <th scope="col">
          <asp:Label ID="lblcedula" runat="server" Text="Número de Cédula:" CssClass="col-form-label-sm" ></asp:Label>
          <asp:TextBox ID="txtcedula" runat="server" Enabled="false" CssClass="input-group"></asp:TextBox>
      </th>
     </tr>
      <tr>
          <th scope="col">
              <asp:Label ID="lblcorreo" runat="server" Text="Correo Electrónico:" CssClass="col-form-label-sm" ></asp:Label>
              <asp:TextBox ID="txtcorreo" runat="server" Enabled="false" CssClass="input-group"></asp:TextBox>
          </th>
      </tr>
      <tr>
          <th scope="col">
              <asp:Label ID="lbltelefono" runat="server" Text="Número de teléfono:" CssClass="col-form-label-sm" ></asp:Label>
              <asp:TextBox ID="txttelefono" runat="server" Enabled="false" CssClass="input-group"></asp:TextBox>
          </th>
      </tr>
      
      <tr>
          <th scope="col">
              <asp:Label ID="lblpass" runat="server" Text="Contraseña:" CssClass="col-form-label-sm" ></asp:Label>
              <asp:TextBox ID="txtpass" runat="server" Enabled="false" CssClass="input-group" type="password"></asp:TextBox>
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
     
  </body>    
</asp:Content>

