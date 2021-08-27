<%@ Page Title="" Language="C#" MasterPageFile="~/General.Master" AutoEventWireup="true" CodeBehind="AdministracionNotasdeVenta.aspx.cs" Inherits="ProyectoFinal.AdministracionNotasdeVenta" %>
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
                  <li class="nav-item active">
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


                <div style=" text-align:center" >
                        <label style="font-family:'Comic Sans MS'; color:brown;font-size:xx-large">NOTAS DE VENTA</label>
                 </div>
                <div style="text-align:right">
                    <label id="lbltotal" style="font-family:'Times New Roman', Times, serif; font-style:oblique; color:green; font-size:30px"><b>Total : </b></label>
                    <asp:TextBox ID="txttotal" runat="server" Enabled="false"></asp:TextBox>
                </div>
                
                <div class="container">
                    <label style="font-family:'Times New Roman', Times, serif; color:black; font-size:medium">Pedido:</label>
                    <asp:TextBox ID="txtpedido" runat="server" TextMode="Number" required></asp:TextBox>
                    <asp:Button ID="btnBuscarPedido" runat="server" Text="Buscar" CssClass="btn btn-danger" OnClick="btnBuscarPedido2"/>
                    <asp:Button ID="btnexcel" runat="server" Text="Exportar" CssClass="btn btn-info" OnClick="btnexcel_Click"/>
                    <asp:Button ID="btnpagar" runat="server" Text="PAGAR" CssClass="btn btn-success" OnClick="btnpagar_Click"/>
                    <asp:Button ID="btnAnular" runat="server" Text="ANULAR" CssClass="btn btn-warning" OnClick="btnAnular_Click"/>
                </div>

                <div class="content" id="divTable" runat="server">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="card">
                        <div class="card-header card-header-primary" >
                          <h4 class="card-title">NOTAS DE VENTA</h4>
                          
                        </div>
                        <div class="card-body">
                           <div class="table-responsive">
                             <asp:GridView ID="grvpedidos" runat="server"
                                  CssClass=" table" 
                          AutoGenerateColumns="false" 
                               OnRowDataBound="grvpedidos_RowDataBound"
                          RowStyle-HorizontalAlign="Center" 
                          HeaderStyle-HorizontalAlign="Center"
                          HorizontalAlign="Center">
                                  <Columns >
                                  
                                  <asp:BoundField DataField="CODIGOPEDIDO" HeaderText="Pedido" />
                                  <asp:BoundField DataField="PRODUCTO" HeaderText="Descripción"/>
                                  <asp:BoundField DataField="UNIDAD" HeaderText="Cantidad" />
                                  <asp:BoundField DataField="SUBTOTAL" HeaderText="Subtotal" />
                                  <asp:BoundField DataField="TOTAL" HeaderText="Total" Visible="false"/>
                                  <asp:BoundField DataField="CLIENTE" HeaderText="Cliente" />
                                  <asp:BoundField DataField="FECHAPEDIDO" HeaderText="Fecha" />
                                 <asp:BoundField DataField="ESTADO" HeaderText="Estado" />

                            </Columns>
                                 <emptydatarowstyle backcolor="#ffffff"
                                      forecolor="Red" Font-Bold="true"/>
                    
                                    <emptydatatemplate>                        
                                       !NO EXISTE EL PEDIDO!
                                    </emptydatatemplate> 
                      </asp:GridView>
                           </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
            </div>
    </div>
</asp:Content>
