<%@ Page Title="" Language="C#" MasterPageFile="~/General.Master" AutoEventWireup="true" CodeBehind="AdministracionClientesEmpleado.aspx.cs" Inherits="ProyectoFinal.AdministracionClientesEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <div class="wrapper ">
            <div class="sidebar" data-color="purple" data-background-color="white" data-image="assets/img/sidebar-1.jpg">
              <!--
                Tip 1: You can change the color of the sidebar using: data-color="purple | azure | green | orange | danger"

                Tip 2: you can also add an image using data-image tag
            -->
              <div class="logo"><a href="EmpMenu.aspx" class="simple-text logo-normal">
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
                 
                  <li class="nav-item">
                    <a class="nav-link" href="AdministracionProductoEmpleado.aspx">
                      <i class="material-icons">shopping_cart</i>
                      <p>Producto</p>
                    </a>
                  </li>
                <li class="nav-item active active">
                    <a class="nav-link" href="AdministracionClientesEmpleado.aspx">
                      <i class="material-icons">face</i>
                      <p>Clientes</p>
                    </a>
                  </li>
                <li class="nav-item">
                    <a class="nav-link" href="AdministracionProveedorEmpleado.aspx">
                      <i class="material-icons">info</i>
                      <p>Proveedor</p>
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
                    <a class="navbar-brand" href="javascript:;">ADMINISTRACIÓN CLIENTES</a>
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
                          <a class="dropdown-item" href="PerfilEmpleado.aspx">Perfil</a>
                          <div class="dropdown-divider"></div>
                          <a class="dropdown-item" href="Index.aspx">Salir</a>
                        </div>
                      </li>
                    </ul>
                  </div>                     
                </div>
              </nav>

              <!-- End Navbar -->
                  <br />
                <br />

                <br />

                <div style ="float:left; padding:30px ">
                    <label style="font-family:'Times New Roman', Times, serif; color:black; font-size:medium">N° de cédula:</label>
                    <asp:TextBox ID="txtbuscarCliente"  runat="server" ></asp:TextBox>
                    <asp:ImageButton ID="ImgBtnBuscarCliente" AlternateText="Buscar" ImageUrl="images/buscar.png" runat="server" Height="50px" Width="50px" OnClick="ImgBtnBuscarCliente_Click"/>

                </div>
                
                <br />
                <br />
                    <div style="float:right">
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-danger" OnClick="btnNuevo_Click"/>
                        <asp:Button ID="btnexcel" runat="server" Text="Exportar" CssClass="btn btn-info" OnClick="btnexcel_Click"/>
                        <asp:TextBox ID="txttipoBusqueda" runat="server" Text="" Visible="false"></asp:TextBox>
                    </div>
                <div class="content" id="divTable" runat="server">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="card">
                         <div class="card-header card-header-primary">
                  <h4 class="card-title ">CLIENTES</h4>
                  <p class="card-category">Activos-Inactivos</p>
                </div>
                <div class="card-body">
                  <div class="table-responsive">
                      <asp:GridView ID="grvroles" runat="server" 
                          CssClass=" table" 
                          AutoGenerateColumns="false" 
                          RowStyle-HorizontalAlign="Center" 
                          HeaderStyle-HorizontalAlign="Center"
                          HorizontalAlign="Center"
                          OnRowDataBound="grvroles_RowDataBound"
                          DataKeyNames="CODIGO"
                          OnRowCommand="grvroles_RowCommand"
                          >
                          <Columns >
                          <asp:ButtonField Text="Editar" CommandName="Editar" />
                          <asp:BoundField DataField="CODIGO" HeaderText="Código" />
                          <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                          <asp:BoundField DataField="APELLIDO" HeaderText="Apellido" />
                          <asp:BoundField DataField="CEDULA" HeaderText="Cédula" />
                          <asp:BoundField DataField="CORREO" HeaderText="Correo" />
                          <asp:BoundField DataField="DIRECCION" HeaderText="Dirección" />
                          <asp:BoundField DataField="ESTADO" HeaderText="Estado" />
                            </Columns>
                      </asp:GridView>
                  </div>
                </div>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="content"  id="divModificar" runat="server" visible="false">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="card">
                        <div class="card-header card-header-success btn-outline-primary" >
                          <h4 class="card-title">Crear-Actualizar</h4>
                          <p class="card-category">Clientes</p>
                        </div>
                        <div class="card-body">
                            <br />
                            <div class="row">
                                <div class="col-md-2">
                                  <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Codigo-Cliente</label>
                                 <%-- <input type="text" class="form-control" disabled="disabled">--%>
                                    <asp:TextBox ID="txtcodigoCliente" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                              </div>
                              <div class="col-md-5">
                                  <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Nombre-Cliente</label>
                                  <%--<input type="text" class="form-control">--%>
                                    <asp:TextBox ID="txtnombreCliente" CssClass="form-control" onkeypress="return soloLetras(event);" MaxLength="80" runat="server" required></asp:TextBox>
                                </div>
                              </div>
                                <div class="col-md-5">
                                  <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Apellido-cliente</label>
                                  <%--<input type="text" class="form-control">--%>
                                    <asp:TextBox ID="txtapellidoCliente" CssClass="form-control" onkeypress="return soloLetras(event);" MaxLength="80" runat="server" required></asp:TextBox>
                                </div>
                              </div>
                              <div class="col-md-3">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Estado</label>
                                    <div class="dropdown">
                                    <asp:DropDownList ID="ddrestadosroles" runat="server" CssClass="btn btn-success dropdown ">
                                        <asp:ListItem Value="0">Inactivo</asp:ListItem>
                                        <asp:ListItem Value="1">Activo</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                </div>
                              </div>

                            <div class="col-md-3">
                                  <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Cédula-Cliente</label>
                                  <%--<input type="text" class="form-control">--%>
                                    <asp:TextBox ID="txtcedulaCliente" CssClass="form-control" onkeypress="return justNumbers(event);" runat="server" MinLength="10" MaxLength="13" required></asp:TextBox>
                                </div>
                              </div>
                                <div class="col-md-5">
                                  <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Correo-Cliente</label>
                                  <%--<input type="text" class="form-control">--%>
                                    <asp:TextBox ID="txtcorreoCliente" CssClass="form-control" type="email"  MaxLength="200" runat="server" required></asp:TextBox>
                                </div>
                              </div>

                                 <div class="col-md-5">
                                  <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Dirección-cliente</label>
                                  <%--<input type="text" class="form-control">--%>
                                    <asp:TextBox ID="txtdireccionCliente" CssClass="form-control" runat="server" MaxLength="300" required></asp:TextBox>
                                </div>
                              </div>


                            </div>
                            <asp:Button ID="btnguardar" runat="server" Text="Guardar" class="btn btn-danger pull-right" OnClick="btnguardar_Click"/>
                            <asp:LinkButton ID="btncancelar" runat="server" Text="Cancelar" class="btn btn-success pull-right" href="AdministracionClientesEmpleado.aspx"/>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
            </div>
        </div>
</asp:Content>
