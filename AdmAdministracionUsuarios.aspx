<%@ Page Title="" Language="C#" MasterPageFile="~/General.Master" AutoEventWireup="true" CodeBehind="AdmAdministracionUsuarios.aspx.cs" Inherits="ProyectoFinal.AdmAdministracionUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <div class="wrapper ">
            <div class="sidebar" data-color="purple" data-background-color="white" data-image="assets/img/sidebar-1.jpg">
              <!--
                Tip 1: You can change the color of the sidebar using: data-color="purple | azure | green | orange | danger"

                Tip 2: you can also add an image using data-image tag
            -->
              <div class="logo"><a href="AdmMenu.aspx" class="simple-text logo-normal">
                 MENÚ ADMINISTRADOR
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
                    <a class="nav-link" href="AdmAdministracionRoles.aspx">
                      <i class="material-icons">people</i>
                      <p>Roles</p>
                    </a>
                  </li>
                  <li class="nav-item active">
                    <a class="nav-link" href="AdmAdministracionUsuarios.aspx">
                      <i class="material-icons">person</i>
                      <p>Usuarios</p>
                    </a>
                  </li>
                  <li class="nav-item ">
                    <a class="nav-link" href="AdmAdministracionCategorias.aspx">
                      <i class="material-icons">event_note</i>
                      <p>Categoria</p>
                    </a>
                  </li>
                  <li class="nav-item ">
                    <a class="nav-link" href="AdmAdministracionProductos.aspx">
                      <i class="material-icons">shopping_cart</i>
                      <p>Producto</p>
                    </a>
                  </li>
                     <li class="nav-item ">
                    <a class="nav-link" href="AdministracionClientes.aspx">
                      <i class="material-icons">face</i>
                      <p>Clientes</p>
                    </a>
                  </li>
                    <li class="nav-item">
                    <a class="nav-link" href="AdministracionProveedores.aspx">
                      <i class="material-icons">info</i>
                      <p>Proveedor</p>
                    </a>
                  </li>
                  <li class="nav-item ">
                    <a class="nav-link" href="ReporteVentas.aspx">
                      <i class="material-icons">call_made</i>
                      <p>Ventas</p>
                    </a>
                  </li>
                  <li class="nav-item ">
                    <a class="nav-link" href="AdmAdministracionCompras.aspx">
                      <i class="material-icons">call_received</i>
                      <p>Compras</p>
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
                    <a class="navbar-brand" href="javascript:;">ADMINISTRACIÓN USUARIOS</a>
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
                          <a class="dropdown-item" href="Perfil.aspx">Perfil</a>
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
                    <asp:TextBox ID="txtbuscarUsuario"  runat="server" ></asp:TextBox>
                    <asp:ImageButton ID="ImgBtnBuscarUsuario" AlternateText="Buscar" ImageUrl="images/buscar.png" runat="server" Height="50px" Width="50px" OnClick="ImgBtnBuscarUsuario_Click"/>

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
                  <h4 class="card-title ">USUARIOS</h4>
                  <p class="card-category">Activos-Inactivos</p>
                </div>
                <div class="card-body">
                  <div class="table-responsive">
                      <asp:GridView ID="grvusuarios" runat="server" 
                          CssClass=" table" 
                          AutoGenerateColumns="false" 
                          RowStyle-HorizontalAlign="Center" 
                          HeaderStyle-HorizontalAlign="Center"
                          HorizontalAlign="Center"
                          
                          DataKeyNames="CODIGO"
                          OnRowCommand="grvusuarios_RowCommand"
                          AllowPaging="true"
                          CellPadding="5"
                          PageSize="5"
                          OnPageIndexChanging="grvusuarios_PageIndexChanging"
                          >
                          <Columns >
                          <asp:ButtonField Text="Editar" CommandName="Editar" />
                          <asp:BoundField DataField="CODIGO" HeaderText="Código" />
                          <asp:BoundField DataField="USUARIO" HeaderText="Usuario" />
                          <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                          <asp:BoundField DataField="CEDULA" HeaderText="Cédula" />
                          <asp:BoundField DataField="CORREO" HeaderText="Correo" />
                          <asp:BoundField DataField="TELEFONO" HeaderText="Teléfono" />
                          <asp:BoundField DataField="PASS" HeaderText="Contraseña" Visible="false"/>
                          <asp:BoundField DataField="FECHA" HeaderText="Fecha de ingreso" />
                          <asp:BoundField DataField="ROL" HeaderText="Rol" />
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
                          <p class="card-category">Usuarios</p>
                        </div>
                        <div class="card-body">
                            <br />
                            <div class="row">
                                <div class="col-md-2">
                                  <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Codigo-Usuario</label>
                                 <%-- <input type="text" class="form-control" disabled="disabled">--%>
                                    <asp:TextBox ID="txtcodigoUsuario" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                              </div>
                              <div class="col-md-4">
                                  <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Usuario-nick</label>
                                  <%--<input type="text" class="form-control">--%>
                                    <asp:TextBox ID="txtusuario" CssClass="form-control" runat="server" MaxLength="60" required></asp:TextBox>
                                </div>
                              </div>
                              <div class="col-md-3">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Estado</label>
                                    <div class="dropdown">
                                    <asp:DropDownList ID="ddrestadosUsuario" runat="server" CssClass="btn btn-success dropdown ">
                                        <asp:ListItem Value="0">Inactivo</asp:ListItem>
                                        <asp:ListItem Value="1">Activo</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                </div>

                              </div>

                                <div class="col-md-3">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Rol</label>
                                    <div class="dropdown">
                                    <asp:DropDownList ID="ddrRol" runat="server" CssClass="btn btn-success dropdown "/>
                                </div>
                                </div>

                              </div>

                            <div class="col-md-5">
                                  <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Nombre y Apellido-Usuario</label>
                                  <%--<input type="text" class="form-control">--%>
                                    <asp:TextBox ID="txtnombreUsuario" CssClass="form-control" onkeypress="return soloLetras(event);" runat="server" MaxLength="60" required></asp:TextBox>
                                </div>
                              </div>
                             <div class="col-md-5">
                                  <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Cedula-Usuario</label>
                                  <%--<input type="text" class="form-control">--%>
                                    <asp:TextBox ID="txtcedulausuario" onkeypress="return justNumbers(event);" CssClass="form-control" runat="server" MinLength="10" MaxLength="13" required ></asp:TextBox>
                                   </div>
                              </div>

                             <div class="col-md-5">
                                  <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Correo-Usuario</label>
                                  <%--<input type="text" class="form-control">--%>
                                    <asp:TextBox ID="txtcorreousuario"  CssClass="form-control" type="email" runat="server" MaxLength="100" required></asp:TextBox>
                                </div>
                              </div>

                            <div class="col-md-5">
                                  <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Telefono-Usuario</label>
                                  <%--<input type="text" class="form-control">--%>
                                    <asp:TextBox ID="txttelefonousuario" onkeypress="return justNumbers(event);" CssClass="form-control" runat="server" MinLength="9" MaxLength="10"  required></asp:TextBox>
                                </div>
                              </div>
                            <div class="col-md-5">
                                  <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Contraseña-Usuario</label>
                                  <%--<input type="text" class="form-control">--%>
                                    <asp:TextBox ID="txtcontrasena" CssClass="form-control" runat="server" Enabled="false" MinLength="7" MaxLength="100" Visible="false" required></asp:TextBox>
                                </div>
                              </div>                                                         

                            </div>
                            <asp:Button ID="btnguardar" runat="server" Text="Guardar" class="btn btn-danger pull-right" OnClick="btnguardar_Click"/>
                            <asp:LinkButton ID="btncancelar" runat="server" Text="Cancelar" class="btn btn-success pull-right" href="AdmAdministracionUsuarios.aspx"/>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
            </div>
        </div>
        
</asp:Content>
