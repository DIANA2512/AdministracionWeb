using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;

namespace ProyectoFinal
{
    public partial class AdmAdministracionUsuarios : System.Web.UI.Page
    {
        //Variables Globales
        Negocio.NG_AdmAdministracionUsuarios negocioObj = new Negocio.NG_AdmAdministracionUsuarios();
        DataTable consulta = new DataTable();
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
                mostrarTabla(ref consulta);
                cargarRol(ref consulta, "TODOS");
            }
        }

        public void cargarRol(ref DataTable consulta, string tipobusqueda)
        {
            //cargando los datos hacia el ddrol
            ddrRol.DataSource = negocioObj2.buscarRol(ref consulta, tipobusqueda);

            ddrRol.DataTextField = "NOMBRE";
            ddrRol.DataValueField = "CODIGO";
            ddrRol.DataBind();

        }

        public void mostrarTabla(ref DataTable consulta)

        {
            try
            {
                grvusuarios.DataSource = negocioObj.buscarUsuario(ref consulta);

                grvusuarios.DataBind();

                consulta.Clear();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void grvusuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells[10].Text == "Inactivo")
            {
                e.Row.BackColor = Color.BlueViolet;
                e.Row.ForeColor = Color.White;
            }
        }

        protected void grvusuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int codigoUsuario = int.Parse(grvusuarios.DataKeys[index].Value.ToString());
                consulta = negocioObj.buscarUsuarioModifcar(ref consulta, codigoUsuario);
                txtcodigoUsuario.Text = consulta.Rows[0]["CODIGO"].ToString();
                txtusuario.Text = consulta.Rows[0]["USUARIO"].ToString();
                txtnombreUsuario.Text = consulta.Rows[0]["NOMBRE"].ToString();
                txtcedulausuario.Text = consulta.Rows[0]["CEDULA"].ToString();
                txtcorreousuario.Text = consulta.Rows[0]["CORREO"].ToString();
                txttelefonousuario.Text = consulta.Rows[0]["TELEFONO"].ToString();
                ddrestadosUsuario.SelectedValue = consulta.Rows[0]["ESTADO"].ToString();
                if (consulta.Rows[0]["ROL"].ToString() == "1")
                {
                    ddrestadosUsuario.Items.FindByValue("0").Enabled = false;
                }

                ddrRol.SelectedValue = consulta.Rows[0]["ROL"].ToString();
                txtcontrasena.Text= consulta.Rows[0]["CONTRASENA"].ToString();
                divTable.Visible = false;
                divModificar.Visible = true;
                txttipoBusqueda.Text = "";
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            divModificar.Visible = false;
            divTable.Visible = true;
            if (negocioObj.guardarActualizarUsuario(txttipoBusqueda.Text, int.Parse(txtcodigoUsuario.Text)
                , txtusuario.Text, txtnombreUsuario.Text, txtcedulausuario.Text, txtcorreousuario.Text, txttelefonousuario.Text, txtcontrasena.Text
                , int.Parse(ddrRol.SelectedValue.ToString()), int.Parse(ddrestadosUsuario.SelectedValue.ToString())) > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Registro Usuarios", "alert('Registro exitoso');", true);
                //Response.Write("USUARIO GUARDADO CON EXITO");
                //mostrarTabla(ref consulta);
                grvusuarios.DataSource = negocioObj.filtroBuscarUsuario(ref consulta, txtbuscarUsuario.Text);
                grvusuarios.DataBind();
            }
            else
            {
                //Response.Write("ERROR AL GUADAR EL USUARIO");
                ClientScript.RegisterStartupScript(this.GetType(), "Registro Usuarios", "alert('Usuario existente');", true);
                //mostrarTabla(ref consulta);
                grvusuarios.DataSource = negocioObj.filtroBuscarUsuario(ref consulta, txtbuscarUsuario.Text);
                grvusuarios.DataBind();
            }
        }
        protected void ImgBtnBuscarUsuario_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                grvusuarios.DataSource = negocioObj.filtroBuscarUsuario(ref consulta, txtbuscarUsuario.Text);
                grvusuarios.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }


        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            divTable.Visible = false;
            divModificar.Visible = true;
            txtcodigoUsuario.Text = "0";
            txtusuario.Text = "";
            txtnombreUsuario.Text = "";
            txtcedulausuario.Text = "";
            txtcorreousuario.Text = "";
            txttelefonousuario.Text = "0";
            txttipoBusqueda.Text = "GUARDAR";
            ddrestadosUsuario.SelectedValue = "1";
            ddrRol.SelectedValue = "1";
            txtcontrasena.Text = "";
            txtcontrasena.Enabled = true;
            txtcontrasena.Visible = true;

        }

        protected void btnexcel_Click(object sender, EventArgs e)
        {
            ExporttoExcel(negocioObj.filtroBuscarUsuario(ref consulta, txtbuscarUsuario.Text), "Listado_Usuarios");
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
                ws.Cells["B7:K8"].Merge = true;

                ws.Cells["B7:K8"].Value = "LISTADO USUARIOS";
                ws.Cells["B7:K8"].Style.Font.Bold = true;
                ws.Cells["B7:K8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["B7:K8"].Style.Font.Size = 20;

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

                ws.Cells["B9:K9"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["B9:K9"].Style.Font.Bold = true;
                ws.Cells["I10:I200"].Style.Numberformat.Format = "dd/mm/yyyy";
                //ws.Cells["B10"].Style.Fill.BackgroundColor.SetColor(Color.AliceBlue);

                ws.Cells["B9"].LoadFromDataTable(table, true);
                //AJUSTAR COLUMNAS
                ws.Cells["B10:K17"].AutoFitColumns();
                var ms = new System.IO.MemoryStream();
                pack.SaveAs(ms);
                ms.WriteTo(HttpContext.Current.Response.OutputStream);
            }

            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();

        }

        protected void grvusuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvusuarios.PageIndex = e.NewPageIndex;
            mostrarTabla(ref consulta);
        }
    }  
}
