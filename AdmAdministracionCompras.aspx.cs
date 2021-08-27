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
    public partial class AdmAdministracionCompras : System.Web.UI.Page
    {
        Negocio.NG_AdmAdministracionCompras negocioObj = new Negocio.NG_AdmAdministracionCompras();
        Negocio.NG_AdmAdministracionProductos negocioObj1 = new Negocio.NG_AdmAdministracionProductos();

        DataTable consulta = new DataTable();
        DataTable consulta2 = new DataTable();
        DataTable consulta3 = new DataTable();
        DataTable consulta4 = new DataTable();
        Negocio.NG_Login negocioObj2 = new Negocio.NG_Login();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Session["nombreUsuario"].ToString()))
            {
                Response.Redirect("Index.aspx");
            }

            //validacion
            if (Session["rol"].ToString() != "1")
            {
                Response.Redirect("Index.aspx");
            }

            if (!IsPostBack)
            {

               
                cargaProveedores(ref consulta3);
                cargaProductos(ref consulta4);
                    
            }

           mostrarTabla(ref consulta);
        }

        public void mostrarTabla(ref DataTable consulta)
        {
            try
            {
                grvcompras.DataSource = negocioObj.buscarCompra(ref consulta);

                grvcompras.DataBind();

                consulta.Clear();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

    

        protected void grvcompras_RowCommand(object sender, GridViewCommandEventArgs e)

        {
            if (e.CommandName == "Editar")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int codigoCompra = int.Parse(grvcompras.DataKeys[index].Value.ToString());
                consulta = negocioObj.buscarCompraModificar(ref consulta, codigoCompra);
                txtcodigoCompra.Text = consulta.Rows[0]["CODIGO"].ToString();
                txtdescripcionCompra.Text = consulta.Rows[0]["DESCRIPCION"].ToString();
               // ddrproducto.SelectedValue = consulta.Rows[0]["PRODUCTO"].ToString();
                ddrunidadProducto2.SelectedItem.Text = consulta.Rows[0]["UNIDAD"].ToString();
                txtValorCompraProducto.Text = consulta.Rows[0]["VALOR_DE_COMPRA"].ToString();
                txtcantidadProducto.Text = consulta.Rows[0]["CANTIDAD"].ToString();
                ddrproveedor.SelectedValue = consulta.Rows[0]["PROVEEDOR"].ToString();
                txttotalcompra.Text = consulta.Rows[0]["TOTAL_COMPRA"].ToString();
                txtfechacompra.Text = consulta.Rows[0]["FECHA"].ToString();
                txtnumerofactura.Text = consulta.Rows[0]["NUMERO_FACTURA"].ToString();
                divTable.Visible = false;
                divModificar.Visible = true;
                txttipoBusqueda.Text = "";
            }
        }





        protected void btnguardar_Click(object sender, EventArgs e)
        {
            decimal valorCompra;
            decimal cantidad;
            valorCompra = Convert.ToDecimal(txtValorCompraProducto.Text);
            cantidad = Convert.ToDecimal(txtcantidadProducto.Text);

            if (valorCompra == 0 || cantidad == 0 )
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Registro Producto", "alert('Ingrese valores superiores a cero pára continuar');", true);

            }
            else
            {
                if (Convert.ToDateTime(txtfechacompra.Text) > DateTime.Now)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Registro Compras", "alert('No puede ingresar una fecha mayor a la actual');", true);
                }
                else
                {
                    if (negocioObj.guardarActualizarCompra(txttipoBusqueda.Text, int.Parse(txtcodigoCompra.Text),
                    txtdescripcionCompra.Text,
                    int.Parse(ddrproducto.SelectedValue.ToString()),
                    ddrunidadProducto2.SelectedItem.Text,
                    decimal.Parse(txtValorCompraProducto.Text),
                    int.Parse(txtcantidadProducto.Text),
                    int.Parse(ddrproveedor.SelectedValue.ToString()),
                    decimal.Parse(txttotalcompra.Text),
                    txtnumerofactura.Text, txtfechacompra.Text) > 0)

                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Registro Compras", "alert('Registro existoso');", true);
                        //Response.Write("COMPRA GUARDADA CON EXITO");
                        consulta.Clear();
                        mostrarTabla(ref consulta);

                        divModificar.Visible = false;
                        divTable.Visible = true;

                    }
                    else
                    {
                        //Response.Write("ERROR AL GUADAR LA COMPRA");
                        ClientScript.RegisterStartupScript(this.GetType(), "Registro Compras", "alert('Error al guardar la compra');", true);
                    }
                }
            }


           
            
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            divTable.Visible = false;
            divModificar.Visible = true;

            txtcodigoCompra.Text = "0";
            txtdescripcionCompra.Text = "";
            ddrproducto.SelectedValue = "1";
            //ddrunidadProducto2.SelectedItem.Text = "";
            txtValorCompraProducto.Text = "";
            ddrproveedor.SelectedValue = "1";
            txttipoBusqueda.Text = "GUARDAR";
            txttotalcompra.Text = "0";
            txtnumerofactura.Text = "";

            //ddrcategoria.SelectedValue = "1";
        }

        public void cargaProveedores(ref DataTable consulta3)
        {
            //cargando los dataos hacia el ddrol
            ddrproveedor.DataSource = negocioObj1.buscarProveeorProductos(ref consulta3);

            ddrproveedor.DataTextField = "DESCRIPCION";
            ddrproveedor.DataValueField = "CODIGO";
            ddrproveedor.DataBind();

        }

        public void cargaProductos(ref DataTable consulta4)
        {
            //cargando los dataos hacia el ddproducto
            ddrproducto.DataSource = negocioObj1.buscarProductoDDR(ref consulta4);
            ddrproducto.DataTextField = "DESCRIPCION";
            ddrproducto.DataValueField = "CODIGO";
            ddrproducto.DataBind();

        }

        protected void btnexcel_Click(object sender, EventArgs e)
        {
            ExporttoExcel(negocioObj.filtroBuscarCompras(ref consulta, txtfechadesde.Text, txtfechahasta.Text), "Listado_Compras");
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
                ws.Cells["B7:L8"].Merge = true;

                ws.Cells["B7:L8"].Value = "LISTADO COMPRAS";
                ws.Cells["B7:L8"].Style.Font.Bold = true;
                ws.Cells["B7:L8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["B7:L8"].Style.Font.Size = 20;

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

                ws.Cells["B9:L9"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["B9:L9"].Style.Font.Bold = true;
                //ws.Cells["B10"].Style.Fill.BackgroundColor.SetColor(Color.AliceBlue);
                ws.Cells["J10:J1220"].Style.Numberformat.Format = "mm/dd/yyyy";
                ws.Cells["B9"].LoadFromDataTable(table, true);
                //AJUSTAR COLUMNAS
                ws.Cells["B9:L17"].AutoFitColumns();
                var ms = new System.IO.MemoryStream();
                pack.SaveAs(ms);
                ms.WriteTo(HttpContext.Current.Response.OutputStream);
            }

            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();

        }

        protected void ImgBtnBuscarCompra_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                grvcompras.DataSource = negocioObj.filtroBuscarCompras(ref consulta, txtfechadesde.Text, txtfechahasta.Text);
                grvcompras.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void txtValorCompraProducto_TextChanged(object sender, EventArgs e)
        {
            decimal valorcompra;
            decimal cantidad;

            if (txtValorCompraProducto.Text == "")
            {
                valorcompra = 0;
                txtValorCompraProducto.Text = "0";
            }
            else 
            {
                valorcompra = Convert.ToDecimal(txtValorCompraProducto.Text);
            }

            
            cantidad = Convert.ToDecimal(txtcantidadProducto.Text);

            txttotalcompra.Text = Convert.ToString(valorcompra*cantidad);
        }

        protected void txtcantidadProducto_TextChanged(object sender, EventArgs e)
        {
            decimal valorcompra;
            decimal cantidad;

            if (txtcantidadProducto.Text == "")
            {
                cantidad = 0;
                txtcantidadProducto.Text = "0";
            }
            else 
            {
                cantidad = Convert.ToDecimal(txtcantidadProducto.Text);
            }

            valorcompra = Convert.ToDecimal(txtValorCompraProducto.Text);
            txttotalcompra.Text = Convert.ToString(valorcompra * cantidad);
        }
    }
}
