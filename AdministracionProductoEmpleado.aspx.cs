using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;

namespace ProyectoFinal
{
    public partial class AdministracionProductoEmpleado : System.Web.UI.Page
    {
        Negocio.NG_AdmAdministracionProductos negocioObj = new Negocio.NG_AdmAdministracionProductos();


        DataTable consulta = new DataTable();
        DataTable consulta2 = new DataTable();
        DataTable consulta3 = new DataTable();
        Negocio.NG_Login negocioObj2 = new Negocio.NG_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["nombreUsuario"].ToString()))
            {
                Response.Redirect("Index.aspx");
            }

            //validacion
            if (Session["rol"].ToString() != "3")
            {
                Response.Redirect("Index.aspx");
            }

            if (!IsPostBack)
            {
                cargaCategorias(ref consulta2);
                cargaProveedores(ref consulta3);
                mostrarTabla(ref consulta);
            }
            ImgBtnBuscarProducto.Focus();

        }

        public void mostrarTabla(ref DataTable consulta)
        {
            try
            {
                consulta.Clear();

                grvproductos.DataSource = negocioObj.buscarProducto(ref consulta);

                grvproductos.DataBind();

                consulta.Clear();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void grvproductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells[12].Text == "Inactivo")
            {
                e.Row.BackColor = Color.BlueViolet;
                e.Row.ForeColor = Color.White;
            }
        }

        protected void grvproductos_RowCommand(object sender, GridViewCommandEventArgs e)

        {
            if (e.CommandName == "Editar")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int codigoProducto = int.Parse(grvproductos.DataKeys[index].Value.ToString());
                consulta = negocioObj.buscarProductoModificar(ref consulta, codigoProducto);
                txtcodigoProducto.Text = consulta.Rows[0]["Código"].ToString();
                txtnombreProducto.Text = consulta.Rows[0]["Nombre"].ToString();
                txtValorCompraProducto.Text = consulta.Rows[0]["Valor Compra"].ToString();
                txtValorVentaProducto.Text = consulta.Rows[0]["Valor Venta"].ToString();
                ddrestadoProducto.SelectedValue = consulta.Rows[0]["Estado"].ToString();
                txtloteProducto.Text = consulta.Rows[0]["Lote"].ToString();
                txtfechaingresoProducto.Text = consulta.Rows[0]["Fecha Ingreso"].ToString();
                txtfechavencimientoProducto.Text = consulta.Rows[0]["Fecha Vencimiento"].ToString();
                txtcantidadProducto.Text = consulta.Rows[0]["Cantidad"].ToString();
                ddrproveedor.SelectedValue = consulta.Rows[0]["Proveedor"].ToString();
                ddrcategoria.SelectedValue = consulta.Rows[0]["Categoría"].ToString();
                divTable.Visible = false;
                divModificar.Visible = true;
                txttipoBusqueda.Text = "";
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {

            decimal valorCompra;
            decimal valorVenta;
            decimal cantidad;
            valorCompra = Convert.ToDecimal(txtValorCompraProducto.Text);
            valorVenta = Convert.ToDecimal(txtValorVentaProducto.Text);
            cantidad = Convert.ToDecimal(txtcantidadProducto.Text);

            if (valorCompra == 0 || valorVenta == 0 || cantidad == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Registro Producto", "alert('Ingrese valores superiores a cero pára continuar');", true);

            }
            else
            {
                if (valorCompra >= valorVenta)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Registro Producto", "alert('El valor de compra no puede ser mayor o igual al valor venta');", true);
                }
                else
                {
                    if (Convert.ToDateTime(txtfechaingresoProducto.Text) >= Convert.ToDateTime(txtfechavencimientoProducto.Text))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Registro Producto", "alert('La fecha de ingreso del producto no puede ser mayor o igual a la de vencimiento.');", true);
                    }
                    else
                    {
                        if (negocioObj.guardarActualizarProducto(txttipoBusqueda.Text, int.Parse(txtcodigoProducto.Text)
                            , txtnombreProducto.Text, ddrunidadProducto.SelectedItem.Text, decimal.Parse(txtValorCompraProducto.Text), decimal.Parse(txtValorVentaProducto.Text), int.Parse(ddrcategoria.SelectedValue.ToString())
                            , int.Parse(ddrestadoProducto.SelectedValue.ToString()), txtloteProducto.Text, txtfechaingresoProducto.Text, txtfechavencimientoProducto.Text, int.Parse(txtcantidadProducto.Text), int.Parse(ddrproveedor.SelectedValue.ToString())) > 0)

                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Registro Producto", "alert('Registro existoso');", true);
                            //Response.Write("PRODUCTO GUARDADO CON EXITO");
                            consulta.Clear();
                            //mostrarTabla(ref consulta);
                            grvproductos.DataSource = negocioObj.filtroBuscarProductos(ref consulta, txtproducto.Text);
                            grvproductos.DataBind();
                        }
                        else
                        {
                            //Response.Write("ERROR AL GUADAR EL PRODUCTO");
                            ClientScript.RegisterStartupScript(this.GetType(), "Registro Producto", "alert('Producto en uso o existente');", true);
                            //mostrarTabla(ref consulta);
                            grvproductos.DataSource = negocioObj.filtroBuscarProductos(ref consulta, txtproducto.Text);
                            grvproductos.DataBind();
                        }

                        divModificar.Visible = false;
                        divTable.Visible = true;
                    }


                }


            }



        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            divTable.Visible = false;
            divModificar.Visible = true;


            txtcodigoProducto.Text = "0";
            txtnombreProducto.Text = "";
            txtValorCompraProducto.Text = "";
            txtValorVentaProducto.Text = "";
            txtloteProducto.Text = "";
            txtcantidadProducto.Text = "";
            txtfechaingresoProducto.Text = "";
            txtfechavencimientoProducto.Text = "";
            txttipoBusqueda.Text = "GUARDAR";
            ddrestadoProducto.SelectedValue = "1";
            //ddrcategoria.SelectedValue = "1";
        }

        protected void ImgBtnBuscarProducto_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                grvproductos.DataSource = negocioObj.filtroBuscarProductos(ref consulta, txtproducto.Text);
                grvproductos.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        public void cargaCategorias(ref DataTable consulta)
        {
            //cargando los dataos hacia el ddrol
            ddrcategoria.DataSource = negocioObj.buscarCategoriasProductos(ref consulta);

            ddrcategoria.DataTextField = "DESCRIPCION";
            ddrcategoria.DataValueField = "CODIGO";
            ddrcategoria.DataBind();

        }

        public void cargaProveedores(ref DataTable consulta3)
        {
            //cargando los dataos hacia el ddrol
            ddrproveedor.DataSource = negocioObj.buscarProveeorProductos(ref consulta3);

            ddrproveedor.DataTextField = "DESCRIPCION";
            ddrproveedor.DataValueField = "CODIGO";
            ddrproveedor.DataBind();

        }
        protected void btnexcel_Click(object sender, EventArgs e)
        {
            ExporttoExcel(negocioObj.filtroBuscarProductos(ref consulta, txtproducto.Text), "Listado_Productos");
        }

        public void ExporttoExcel(DataTable table, string filename)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xlsx");


            using (ExcelPackage pack = new ExcelPackage())
            {
                //IMAGEN

                string nombreImagen = "logo_cliente2.png";
                string rutaImagen = System.Web.HttpRuntime.AppDomainAppPath.ToString() + "\\images\\" + nombreImagen;

                ExcelWorksheet ws = pack.Workbook.Worksheets.Add(filename);

                System.Drawing.Image img = System.Drawing.Image.FromFile(rutaImagen);
                ExcelPicture pic = ws.Drawings.AddPicture("Sample", img);
                pic.SetPosition(0, 1, 1, 1);
                pic.SetSize(150, 90);

                string nombreImagen2 = "logo.jpg";
                string rutaImagen2 = System.Web.HttpRuntime.AppDomainAppPath.ToString() + "\\images\\" + nombreImagen2;



                System.Drawing.Image img2 = System.Drawing.Image.FromFile(rutaImagen2);
                ExcelPicture pic2 = ws.Drawings.AddPicture("Sample2", img2);
                pic2.SetPosition(0, 8, 8, 1);
                pic2.SetSize(150, 90);

                /*Combina las celdas*/
                ws.Cells["D1:H1"].Merge = true;
                ws.Cells["D3:H3"].Merge = true;
                ws.Cells["D4:H4"].Merge = true;
                ws.Cells["D5:H5"].Merge = true;
                ws.Cells["B7:M8"].Merge = true;

                ws.Cells["B7:M8"].Value = "LISTADO PRODUCTOS";
                ws.Cells["B7:M8"].Style.Font.Bold = true;
                ws.Cells["B7:M8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["B7:M8"].Style.Font.Size = 20;

                ws.Cells["D1:H1"].Value = "El legítimo de Ambato";
                ws.Cells["D1:H1"].Style.Font.Bold = true;
                ws.Cells["D1:H1"].Style.Font.Italic = true;
                ws.Cells["D1:H1"].Style.Font.Color.SetColor(Color.Brown);
                ws.Cells["D1:H1"].Style.Font.Name = "Imprint MT Shadow";
                ws.Cells["D1:H1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["D1:H1"].Style.Font.Size = 11;

                ws.Cells["D3:H3"].Value = "Piedad López";
                ws.Cells["D3:H3"].Style.Font.Bold = true;
                ws.Cells["D3:H3"].Style.Font.Italic = true;
                ws.Cells["D3:H3"].Style.Font.Color.SetColor(Color.Brown);
                ws.Cells["D3:H3"].Style.Font.Name = "Imprint MT Shadow";
                ws.Cells["D3:H3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["D3:H3"].Style.Font.Size = 11;

                ws.Cells["D4:H4"].Value = "Cafetería";
                ws.Cells["D4:H4"].Style.Font.Bold = true;
                ws.Cells["D4:H4"].Style.Font.Italic = true;
                ws.Cells["D4:H4"].Style.Font.Color.SetColor(Color.Brown);
                ws.Cells["D4:H4"].Style.Font.Name = "Imprint MT Shadow";
                ws.Cells["D4:H4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["D4:H4"].Style.Font.Size = 11;

                ws.Cells["D5:H5"].Value = "A su servicio desde 1980";
                ws.Cells["D5:H5"].Style.Font.Bold = true;
                ws.Cells["D5:H5"].Style.Font.Italic = true;
                ws.Cells["D5:H5"].Style.Font.Color.SetColor(Color.Brown);
                ws.Cells["D5:H5"].Style.Font.Name = "Imprint MT Shadow";
                ws.Cells["D5:H5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["D5:H5"].Style.Font.Size = 11;

                ws.Cells["B9:M9"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["B9:M9"].Style.Font.Bold = true;
                //ws.Cells["B10"].Style.Fill.BackgroundColor.SetColor(Color.AliceBlue);

                ws.Cells["B9"].LoadFromDataTable(table, true);
                //AJUSTAR COLUMNAS
                ws.Cells["B9:M17"].AutoFitColumns();
                var ms = new System.IO.MemoryStream();
                pack.SaveAs(ms);
                ms.WriteTo(HttpContext.Current.Response.OutputStream);
            }

            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();

        }

        protected void grvproductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvproductos.PageIndex = e.NewPageIndex;
            mostrarTabla(ref consulta);
        }
    }
}