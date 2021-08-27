using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;

namespace ProyectoFinal
{
    public partial class AdmAdministracionCategorias : System.Web.UI.Page
    {
        //variables globales
        Negocio.NG_AdmAdministracionCategorias negocioObj = new Negocio.NG_AdmAdministracionCategorias();
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
            }
           
        }

        public void mostrarTabla(ref DataTable consulta)
        {
            try
            {
                grvcategorias.DataSource = negocioObj.buscarCategoria(ref consulta);
                grvcategorias.DataBind();
                consulta.Clear();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void grvcategorias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells[3].Text == "Inactivo")
            {
                e.Row.BackColor = Color.BlueViolet;
                e.Row.ForeColor = Color.White;
            }
        }

        protected void grvcategorias_RowDataBound (object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Editar")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int codigoCategoria = int.Parse(grvcategorias.DataKeys[index].Value.ToString());
                consulta = negocioObj.buscarCategoriaModificar(ref consulta, codigoCategoria);
                txtcodigoCategoria.Text = consulta.Rows[0]["CODIGO"].ToString();
                txtdescripcionCategoria.Text = consulta.Rows[0]["DESCRIPCION"].ToString();
                ddrestadocategoria.SelectedValue = consulta.Rows[0]["ESTADO"].ToString();
                divTable.Visible = false;
                divModificar.Visible = true;
                txttipoBusqueda.Text = "";
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            divModificar.Visible = false;
            divTable.Visible = true;
            if (negocioObj.guardarActualizarCategoria(txttipoBusqueda.Text, int.Parse(txtcodigoCategoria.Text)
                , txtdescripcionCategoria.Text, int.Parse(ddrestadocategoria.SelectedValue.ToString())) > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Registro Categoria", "alert('Registro existoso');", true);
                //Response.Write("CATEGORIA GUARDADO CON EXITO");
                //mostrarTabla(ref consulta);
                grvcategorias.DataSource = negocioObj.filtroBuscarCategoria(ref consulta, txtcategoria.Text);
                grvcategorias.DataBind();
            }
            else
            {
                //Response.Write("ERROR AL GUADAR LA CATEGORIA");
                ClientScript.RegisterStartupScript(this.GetType(), "Registro Categorías", "alert('Categoria en uso o existente');", true);
                //mostrarTabla(ref consulta);
                grvcategorias.DataSource = negocioObj.filtroBuscarCategoria(ref consulta, txtcategoria.Text);
                grvcategorias.DataBind();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            divTable.Visible = false;
            divModificar.Visible = true;
            txtcodigoCategoria.Text = "0";
            txtdescripcionCategoria.Text = "";
            txttipoBusqueda.Text = "GUARDAR";
            ddrestadocategoria.SelectedValue = "1";
           
        }

        protected void ImgBtnBuscarCategoria_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                grvcategorias.DataSource = negocioObj.filtroBuscarCategoria(ref consulta, txtcategoria.Text);
                grvcategorias.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void btnexcel_Click(object sender, EventArgs e)
        {
            ExporttoExcel(negocioObj.filtroBuscarCategoria(ref consulta, txtcategoria.Text), "Listado_Categorias");
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
                ws.Cells["B7:I8"].Merge = true;

                ws.Cells["B7:I8"].Value = "LISTADO CATEGORIAS";
                ws.Cells["B7:I8"].Style.Font.Bold = true;
                ws.Cells["B7:I8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["B7:I8"].Style.Font.Size = 20;

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

                ws.Cells["E9"].LoadFromDataTable(table, true);
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