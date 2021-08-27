<%@ Page Title="" Language="C#" MasterPageFile="~/General.Master" AutoEventWireup="true" CodeBehind="CajMenu.aspx.cs" Inherits="ProyectoFinal.CajMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <div class="wrapper ">
            <div class="sidebar" data-color="purple" data-background-color="white" data-image="assets/img/sidebar-1.jpg">
              <!--
                Tip 1: You can change the color of the sidebar using: data-color="purple | azure | green | orange | danger"

                Tip 2: you can also add an image using data-image tag
            -->
              <div class="logo"><a href="CajMenu.aspx" class="simple-text logo-normal">
                 MENÚ CAJERO

                </a></div>
              <div class="sidebar-wrapper">
                <ul class="nav">
                  <li class="nav-item">
                    <a class="nav-link" href="AdministracionNotasdeVenta.aspx">
                      <i class="material-icons">request_quote</i>
                      <p>Notas de Venta</p>
                    </a>
                  </li>
                     <li class="nav-item">
                    <a class="nav-link" href="ReporteVentasCajero.aspx">
                      <i class="material-icons">assessment</i>
                      <p>Reporte de Ventas</p>
                    </a>
                  </li>
                  <li class="nav-item ">
                    <a class="nav-link" href="AdministracionCajeroProductos.aspx">
                      <i class="material-icons">shopping_cart</i>
                      <p>Productos</p>
                    </a>
                  </li>
                </ul>
              </div>
            </div>
            <div class="main-panel">
              <!-- Navbar -->
              <nav class="navbar navbar-expand-lg navbar-transparent navbar-absolute fixed-top ">
                  
                <div class="container-fluid">
                  <div class="navbar-wrapper">
                    <a class="navbar-brand" href="javascript:;">PANADERÍA Y CAFETERÍA "PIEDAD LÓPEZ"</a>
                  </div>
                  <button class="navbar-toggler" type="button" data-toggle="collapse" aria-controls="navigation-index" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="navbar-toggler-icon icon-bar"></span>
                    <span class="navbar-toggler-icon icon-bar"></span>
                    <span class="navbar-toggler-icon icon-bar"></span>
                  </button>
                  <div class="collapse navbar-collapse justify-content-end">
                  
                    <ul class="navbar-nav">
                  
                      <li class="nav-item dropdown">
                        <a class="nav-link" href="javascript:;" id="navbarDropdownProfile" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                          <i class="material-icons">person</i>
                          <p class="d-lg-none d-md-block">
                            Account
                          </p>
                        </a>
                      <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownProfile">
                          <a class="dropdown-item" href="PerfilCajero.aspx">Perfil</a>
                          <div class="dropdown-divider"></div>
                          <a class="dropdown-item" href="Index.aspx">Salir</a>
                        </div>
                          </li>
                          </ul>
                        </div>
                    
                     
                  </div> 
                  </nav>
                
       
                <br />
                <br />
                <br />
             
            
              <!-- End Navbar -->
        
            <div align="center"><img src="images/portada.jpg" width="1000" height="550" alt="IMG"></div>
            </div>
    </div>
   
</asp:Content>
