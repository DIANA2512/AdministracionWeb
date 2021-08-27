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
    public partial class AdministracionClientes : System.Web.UI.Page
    {
        //Variables Globales
        Negocio.NG_AdministracionClientes negocioObj = new Negocio.NG_AdministracionClientes();
        DataTable consulta = new DataTable();

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
                mostrarTabla(ref consulta);
            }
        }

        public void mostrarTabla(ref DataTable consulta)
        {
            try
            {
                grvroles.DataSource = negocioObj.buscarCliente(ref consulta);
                grvroles.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void grvroles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells[7].Text == "Inactivo")
            {
                e.Row.BackColor = Color.BlueViolet;
                e.Row.ForeColor = Color.White;
            }
        }

        protected void grvroles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int codigoCliente = int.Parse(grvroles.DataKeys[index].Value.ToString());
                consulta = negocioObj.buscarClienteModifcar(ref consulta, codigoCliente);
                txtcodigoCliente.Text = consulta.Rows[0]["CODIGO"].ToString();
                txtnombreCliente.Text = consulta.Rows[0]["NOMBRE"].ToString();
                txtapellidoCliente.Text = consulta.Rows[0]["APELLIDO"].ToString();
                txtcedulaCliente.Text = consulta.Rows[0]["CEDULA"].ToString();
                txtcorreoCliente.Text = consulta.Rows[0]["CORREO"].ToString();
                txtdireccionCliente.Text = consulta.Rows[0]["DIRECCION"].ToString();
                ddrestadosroles.SelectedValue = consulta.Rows[0]["ESTADO"].ToString();
                divTable.Visible = false;
                divModificar.Visible = true;
                txttipoBusqueda.Text = "";
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            divModificar.Visible = false;
            divTable.Visible = true;
            if (negocioObj.guardarActualizarCliente(txttipoBusqueda.Text, int.Parse(txtcodigoCliente.Text), txtnombreCliente.Text, txtapellidoCliente.Text,
                txtcedulaCliente.Text, txtcorreoCliente.Text, txtdireccionCliente.Text, Convert.ToInt32(ddrestadosroles.SelectedValue.ToString())) > 0)
            {
                //Response.Write("CLIENTE GUARDADO CON EXITO");
                ClientScript.RegisterStartupScript(this.GetType(), "Registro Clientes", "alert('Registro exitoso');", true);
                consulta.Clear();
                //mostrarTabla(ref consulta);
                grvroles.DataSource = negocioObj.filtroBuscarClientes(ref consulta, txtbuscarCliente.Text);
                grvroles.DataBind();
            }
            else
            {
                //Response.Write("ERROR AL GUADAR CLIENTE");
                ClientScript.RegisterStartupScript(this.GetType(), "Registro Clientes", "alert('Cliente en uso o existente');", true);
                //mostrarTabla(ref consulta);
                grvroles.DataSource = negocioObj.filtroBuscarClientes(ref consulta, txtbuscarCliente.Text);
                grvroles.DataBind();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            divTable.Visible = false;
            divModificar.Visible = true;
            txtcodigoCliente.Text = "0";
            txtnombreCliente.Text = "";
            txtapellidoCliente.Text = "";
            txtcedulaCliente.Text = "";
            txtcorreoCliente.Text = "";
            txtdireccionCliente.Text = "";
            txttipoBusqueda.Text = "GUARDAR";
            ddrestadosroles.SelectedValue = "1";
        }

        protected void ImgBtnBuscarCliente_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                grvroles.DataSource = negocioObj.filtroBuscarClientes(ref consulta, txtbuscarCliente.Text);
                grvroles.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void btnexcel_Click(object sender, EventArgs e)
        {
            ExporttoExcel(negocioObj.filtroBuscarClientes(ref consulta, txtbuscarCliente.Text), "Listado_Clientes");
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
                ws.Cells["B7:H7"].Merge = true;

                ws.Cells["B7:H7"].Value = "LISTADO CLIENTES";
                ws.Cells["B7:H7"].Style.Font.Bold = true;
                ws.Cells["B7:H7"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["B7:H7"].Style.Font.Size = 20;

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

                ws.Cells["B9:I9"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["B9:I9"].Style.Font.Bold = true;
                //ws.Cells["B10"].Style.Fill.BackgroundColor.SetColor(Color.AliceBlue);

                ws.Cells["B9"].LoadFromDataTable(table, true);
                //AJUSTAR COLUMNAS
                ws.Cells["B10:I17"].AutoFitColumns();
                var ms = new System.IO.MemoryStream();
                pack.SaveAs(ms);
                ms.WriteTo(HttpContext.Current.Response.OutputStream);
            }

            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();

        }
    }

}
