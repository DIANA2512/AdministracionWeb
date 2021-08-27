using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using System.IO;

namespace ProyectoFinal
{
    public partial class ReporteVentas : System.Web.UI.Page
    {
        Negocio.NG_ReporteVentas negocioObj = new Negocio.NG_ReporteVentas();
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
                grvcategorias.DataSource = negocioObj.buscarVentas(ref consulta);
                grvcategorias.DataBind();
                consulta.Clear();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void ImgBtnBusquedaVentas_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                grvcategorias.DataSource = negocioObj.filtroBuscarVentas(ref consulta, txtbuscarCliente.Text, txtfechadesde.Text, txtfechahasta.Text);
                grvcategorias.DataBind();
               

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void imgbtnBuscarCliente_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                grvcategorias.DataSource = negocioObj.filtroBuscarVentas(ref consulta, txtbuscarCliente.Text, txtfechadesde.Text, txtfechahasta.Text);
                grvcategorias.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
        protected void btnexcel_Click(object sender, EventArgs e)
        {
           
                ExporttoExcel(negocioObj.filtroBuscarVentas(ref consulta, txtbuscarCliente.Text, txtfechadesde.Text, txtfechahasta.Text), "Listado_Ventas");
           
           
            
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

                ws.Cells["B7:I8"].Value = "LISTADO VENTAS";
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
                ws.Cells["F10:F300"].Style.Numberformat.Format = "dd/mm/yyyy";
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
            Server.Transfer("ReporteVentas.aspx");
        }

        
    }
}