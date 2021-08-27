<%@ Page Title="" Language="C#" MasterPageFile="~/General.Master" AutoEventWireup="true" CodeBehind="AdministracionCajeroProductos.aspx.cs" Inherits="ProyectoFinal.AdministracionCajeroProductos" %>
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
            <%--      <li class="nav-item active  " >
                    <a class="nav-link" href="./dashboard.html">
                      <i class="material-icons">dashboard</i>
                      <p>Estadísticas</p>
                    </a>
                  </li>--%>
                  
                  
                  <li class="nav-item ">
                    <a class="nav-link" href="AdministracionNotasdeVenta.aspx">
                      <i class="material-icons">event_note</i>
                      <p>Notas de Venta</p>
                    </a>
                  </li>
                  <li class="nav-item ">
                    <a class="nav-link" href="ReporteVentasCajero.aspx">
                      <i class="material-icons">assessment</i>
                      <p>Reporte de Ventas</p>
                    </a>
                  </li>
                  <li class="nav-item active">
                    <a class="nav-link" href="AdministracionCajeroProductos.aspx">
                      <i class="material-icons">shopping_cart</i>
                      <p>Producto</p>
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
                    <a class="navbar-brand" href="javascript:;">ADMINISTRACIÓN PRODUCTOS</a>
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

              <!-- End Navbar -->
               <br />
                <br />

                <br />

                <div style ="float:left; padding:30px ">
                    <label style="font-family:'Times New Roman', Times, serif; color:black; font-size:medium">Producto/Categoría</label>
                    <asp:TextBox ID="txtproducto" runat="server" ></asp:TextBox>
                    <asp:ImageButton ID="ImgBtnBuscarProducto" AlternateText="Buscar" ImageUrl="images/buscar.png" runat="server" Height="50px" Width="50px" OnClick="ImgBtnBuscarProducto_Click"/>

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
                        <div class="card-header card-header-primary" >
                          <h4 class="card-title">PRODUCTOS</h4>
                          <p class="card-category">Activos-Inactivos</p>
                        </div>
                        <div class="card-body">
                           <div class="table-responsive">
                             <asp:GridView ID="grvproductos" runat="server" 
                                  CssClass=" table"
                                 RowStyle-HorizontalAlign="Center" 
                                  HeaderStyle-HorizontalAlign="Center"
                                  HorizontalAlign="Center"           
                                  DataKeyNames="Código"
                                  OnRowCommand="grvproductos_RowCommand"
                                 AllowPaging="true"
                                  CellPadding="5"
                                 PageSize="5"
                                 OnPageIndexChanging="grvproductos_PageIndexChanging"
                                  >
                                  <Columns >
                                  <asp:ButtonField Text="Editar" CommandName="Editar" />
                                  <asp:BoundField DataField="Código" HeaderText="Código" Visible="false"/>
                                  <asp:BoundField DataField="Nombre" HeaderText="Nombre" Visible="false"/>
                                  <asp:BoundField DataField="Unidad" HeaderText="Unidad" Visible="false"/>
                                  <asp:BoundField DataField="Valor Compra" HeaderText="Valor de Compra" Visible="false"/>
                                  <asp:BoundField DataField="Valor Venta" HeaderText="Valor de Venta" Visible="false"/>
                                  <asp:BoundField DataField="Categoría" HeaderText="Categoría" Visible="false"/>
                                  <asp:BoundField DataField="Lote" HeaderText="Lote" Visible="false"/>
                                  <asp:BoundField DataField="Fecha Ingreso" HeaderText="Fecha Ingreso" Visible="false"/>
                                  <asp:BoundField DataField="Fecha Vencimiento" HeaderText="Fecha vencimiento" Visible="false"/>
                                  <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" Visible="false"/>
                                  <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" Visible="false"/>
                                  <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="false"/>

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
                                      <p class="card-category">Productos</p>
                                    </div>
                                     <div class="card-body">
                                        <br />
                                        <div class="row">
                                            <div class="col-md-2">
                                  <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Codigo-Producto</label>
                                  <%--<input type="text" class="form-control" disabled="disabled">--%>
                                     <asp:TextBox ID="txtcodigoProducto" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                              </div>
                              <div class="col-md-5">
                                  <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Nombre-Producto</label>
                                 <%--< <input type="text" class="form-control">--%>
                                    <asp:TextBox ID="txtnombreProducto" CssClass="form-control"  runat="server" MaxLength="150" required></asp:TextBox>
                                </div>
                              </div>

                              <div class="col-md-1">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Unidad</label>
                                    <div class="dropdown">
                                    <asp:DropDownList ID="ddrunidadProducto" runat="server" CssClass="btn btn-success dropdown ">
                                        <asp:ListItem Value="0">U</asp:ListItem>
                                        <asp:ListItem Value="1">Lb</asp:ListItem>
                                        <asp:ListItem Value="2">g</asp:ListItem>
                                        <asp:ListItem Value="3">Kg</asp:ListItem>
                                        <asp:ListItem Value="4">Qq</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                                </div>
                              </div>

                              <div class="col-md-2">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Categoría</label>
                                    <div class="dropdown">
					                    <asp:DropDownList ID="ddrcategoria" runat="server" CssClass="btn btn-info dropdown" AutoPostBack="True"  >
						 
					                    </asp:DropDownList>
					                </div>
                                </div>
                              </div>

                             <div class="col-md-2">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Estado</label>
                                    <div class="dropdown">
                                    <asp:DropDownList ID="ddrestadoProducto" runat="server" CssClass="btn btn-success dropdown ">
                                        <asp:ListItem Value="1">Activo</asp:ListItem>
                                        <asp:ListItem Value="0">Inactivo</asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                                </div>
                              </div>

                            </div>
                            <div class="row">
                                <div class="col-md-5">
                                  <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Valor de Compra</label>
                                 <%--<input type="number" class="form-control" >--%>
                                    <asp:TextBox ID="txtValorCompraProducto"  CssClass="form-control" onkeypress="return filterFloat(event,this);" runat="server"  required></asp:TextBox>
                                </div>
                              </div>

                            <div class="col-md-5">
                                  <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Valor de Venta</label>
                                  <%--<input type="number" class="form-control" >--%>
                                     <asp:TextBox ID="txtValorVentaProducto" CssClass="form-control" onkeypress="return filterFloat(event,this);" runat="server" required></asp:TextBox>
                                </div>
                              </div>
                              </div>
                            <br/>
                            <div class="row">
                            <div class="col-md-5">
                                  <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Lote-Producto</label>
                                 <%--< <input type="text" class="form-control">--%>
                                    <asp:TextBox ID="txtloteProducto" CssClass="form-control" runat="server" MaxLength= "50" required></asp:TextBox>
                                </div>
                              </div>
                               <div class="col-md-2">
                                    
                                <div class="form-group">
                                 <br />
                                  <label class="bmd-label-floating">Cantidad-Producto</label>
                                 <%--< <input type="text" class="form-control">--%>
                                    <asp:TextBox ID="txtcantidadProducto"  CssClass="form-control" onkeypress="return justNumbers(event);" runat="server" required  MaxLength="3"></asp:TextBox>
                                </div>
                                </div>
                                <div class="col-md-2">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Proveedor</label>
                                    <div class="dropdown">
					                    <asp:DropDownList ID="ddrproveedor" runat="server" CssClass="btn btn-info dropdown" AutoPostBack="True"  >
						 
					                    </asp:DropDownList>
					                </div>
                                </div>
                              </div>
                                </div>
                               <br />
                              <div class="row">

                            <div class="col-md-5">
                                  <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Fecha Ingreso-Producto</label>
                                    <br />
                                 <%--< <input type="text" class="form-control">--%>
                                    <asp:TextBox ID="txtfechaingresoProducto" type="date" CssClass="form-control" runat="server" required></asp:TextBox>
                                </div>
                              </div>
                                  <div class="col-md-5">
                                      <br />
                                <div class="form-group">
                                  <label class="bmd-label-floating">Fecha Vencimiento-Producto</label>
                                    <br />
                                 <%--< <input type="text" class="form-control">--%>
                                    <asp:TextBox ID="txtfechavencimientoProducto" type="date" CssClass="form-control" runat="server" required></asp:TextBox>
                                </div>
                                 </div>
                                  </div>
                             
                             <br />
                                
                              </div>

                             
                            
                        </div>
                             <asp:Button ID="btnguardar" runat="server" Text="Guardar" class="btn btn-danger pull-right" OnClick="btnguardar_Click"/>
                            <asp:LinkButton ID="btncancelar" runat="server" Text="Cancelar" class="btn btn-success pull-right" href="AdministracionCajeroProductos.aspx"/>
                      </div>
                    </div>
                  </div>
                </div>
            </div>    
</asp:Content>
