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
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class AdministracionNotasdeVenta : System.Web.UI.Page
    {
        Negocio.NG_AdministracionNotasdeVenta negocioObj = new Negocio.NG_AdministracionNotasdeVenta();
        DataTable consulta = new DataTable();
        int codigoPedido;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Session["nombreUsuario"].ToString()))
            {
                Response.Redirect("Index.aspx");
            }
            //mostrarTabla(ref consulta, codigoPedido);
            //validacion
            if (Session["rol"].ToString() != "2")
            {
                Response.Redirect("Index.aspx");
            }

        }
        public void mostrarTabla (ref DataTable consulta, int codigoPedido, string fechadesde, string fechahasta)
        {
            try
            {

                txttotal.Text = "";
                grvpedidos.DataSource = negocioObj.buscarPedido(ref consulta, codigoPedido, fechadesde, fechahasta);
                grvpedidos.DataBind();
                txttotal.Text = negocioObj.TotalNota(ref consulta, Convert.ToInt32(txtpedido.Text), "", "");

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnBuscarPedido2(object sender, EventArgs e)
        {
            try
            {
                if (txtpedido.Text == "" || txtpedido.Text == "0")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Nota de Venta", "alert('Debe ingresar un valor mayor a cero');", true);
                    return;
                }
                txttotal.Text = "";
                grvpedidos.DataSource = negocioObj.buscarPedido(ref consulta, Convert.ToInt32(txtpedido.Text),"", "");
                if (negocioObj.TotalNota(ref consulta, Convert.ToInt32(txtpedido.Text), "", "")=="")
                {
                    txttotal.Text = "0";
                }
                else 
                {
                    txttotal.Text = negocioObj.TotalNota(ref consulta, Convert.ToInt32(txtpedido.Text), "", "");
                }
                
                grvpedidos.DataBind();
                //txtfechadesde.Text = "";
                //txtfechahasta.Text = "";
                //txtpedido.Text = "0";
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
            }

        }

        protected void ImgBtnBuscarNota_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                txtpedido.Text = "";
                grvpedidos.DataSource = negocioObj.filtroBuscarNotas(ref consulta, "", "");
                grvpedidos.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnexcel_Click(object sender, EventArgs e)
        {
            ExporttoExcel(negocioObj.buscarPedido(ref consulta, Convert.ToInt32(txtpedido.Text), "", ""), "Nota de venta");
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
                ws.Cells["B7:H8"].Merge = true;

                ws.Cells["B7:H8"].Value = "NOTA DE VENTA";
                ws.Cells["B7:H8"].Style.Font.Bold = true;
                ws.Cells["B7:H8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["B7:H8"].Style.Font.Size = 20;

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

                ws.Cells["B9:J9"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["B9:J9"].Style.Font.Bold = true;
                
                ws.Cells["I8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["I8"].Style.Font.Bold = true;
                ws.Cells["I8"].Style.Font.Color.SetColor(Color.Red);
                ws.Cells["I8"].Value = "TOTAL : ";

                ws.Cells["J8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                ws.Cells["J8"].Style.Font.Bold = true;
                ws.Cells["J8"].Style.Font.Color.SetColor(Color.Red);
                ws.Cells["J8"].Value = negocioObj.TotalNota(ref consulta, Convert.ToInt32(txtpedido.Text), "", "");

                ws.Cells["B9"].LoadFromDataTable(table, true);
                //AJUSTAR COLUMNAS
                ws.Cells["B9:J37"].AutoFitColumns();


                var ms = new System.IO.MemoryStream();
                pack.SaveAs(ms);
                ms.WriteTo(HttpContext.Current.Response.OutputStream);
            }

            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();

        }

        protected void btnpagar_Click(object sender, EventArgs e)
        {
            if (negocioObj.PagarAnularPedido("PAGAR",Convert.ToInt32(txtpedido.Text)) > 0)

            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pago Pedido", "alert('Pago existoso');", true);
                btnBuscarPedido2(sender, e);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pago Pedido", "alert('No se pudo pagar el pedido');", true);
            }
        }

        protected void btnAnular_Click(object sender, EventArgs e)
        {
            if (negocioObj.PagarAnularPedido("ANULAR", Convert.ToInt32(txtpedido.Text)) > 0)

            {
                ClientScript.RegisterStartupScript(this.GetType(), "Anular Pedido", "alert('Se anuló correctamente el pedido');", true);
                btnBuscarPedido2(sender, e);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Anular Pedido", "alert('No se anuló el pedido);", true);
            }
        }


        protected void grvpedidos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells[7].Text == "Pagado")
            {
                btnpagar.Visible = false;
                btnAnular.Visible = false;
            }
            else if (e.Row.Cells[7].Text == "Anulado")
            {
                btnpagar.Visible = false;
                btnAnular.Visible = false;
            }
            else if(e.Row.Cells[7].Text == "Entregado")
            {
                btnpagar.Visible = true;
                btnAnular.Visible = true;
            }

        }
    }
}