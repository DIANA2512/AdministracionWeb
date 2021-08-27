using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal
{
    public partial class AdmAdministracionRoles : System.Web.UI.Page
    {
        //Variables Globales
        Negocio.NG_AdministracionRoles negocioObj = new Negocio.NG_AdministracionRoles ();
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
                grvroles.DataSource = negocioObj.buscarRol(ref consulta);
                grvroles.DataBind();
            }
            catch (Exception ex) 
            {
                Response.Write(ex.Message);
            }
        }

        protected void grvroles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells[3].Text == "Inactivo")
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
                int codigoRol = int.Parse(grvroles.DataKeys[index].Value.ToString());
                consulta=negocioObj.buscarRolModifcar(ref consulta,codigoRol);
                txtcodigoRol.Text = consulta.Rows[0]["CODIGO"].ToString();
                txtnombreRol.Text = consulta.Rows[0]["NOMBRE"].ToString();
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
            if (negocioObj.guardarActualizarRol(txttipoBusqueda.Text, int.Parse(txtcodigoRol.Text), txtnombreRol.Text, int.Parse(ddrestadosroles.SelectedValue.ToString())) > 0)
            {
                Response.Write("ROL GUARDADO CON EXITO");
                mostrarTabla(ref consulta);
            }
            else 
            {
                Response.Write("ERROR AL GUADAR EL ROL");
            }
        }

       protected void btnNuevo_Click(object sender, EventArgs e)
        {
            divTable.Visible = false;
            divModificar.Visible = true;
            txtcodigoRol.Text = "0";
            txtnombreRol.Text = "";
            txttipoBusqueda.Text = "GUARDAR";
            ddrestadosroles.SelectedValue ="1";
        }

    }
}