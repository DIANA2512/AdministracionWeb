using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoFinal.Negocio;
using System.Data;
using System.Text;

namespace ProyectoFinal
{
    public partial class Index2 : System.Web.UI.Page
    {
        //Variables Globales
        Negocio.NG_Login negocioObj = new Negocio.NG_Login();
        DataTable consulta = new DataTable();
        string codigoRol;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["nombreUsuario"] = "";
            Session["contrasena"] = "";
            Session["rol"] = "";

            if (!IsPostBack)
            {

                cargarRol(ref consulta, "TODOS");
            }

        }

        public void cargarRol(ref DataTable consulta, string tipobusqueda)
        {
            //cargando los dataos hacia el ddrol
            ddrRol.DataSource = negocioObj.buscarRol(ref consulta, tipobusqueda);

            ddrRol.DataTextField = "NOMBRE";
            ddrRol.DataValueField = "CODIGO";
            ddrRol.DataBind();

        }


        protected void btningresar_Click(object sender, EventArgs e)
        {
            bool valor = negocioObj.VerificarUsuario(Request["usuario"].ToString(), Request["pass"].ToString(), ddrRol.SelectedValue.ToString());

            if (ddrRol.SelectedValue.ToString() == "1")
            {
                if (valor == true)
                {

                    //Session.Add("nombreUsuario");
                    //Session.Add("contrasena");
                    Session["nombreUsuario"] = Request["usuario"].ToString();
                    Session["contrasena"] = Request["pass"].ToString();
                    Session["rol"] = "1";
                    limpiar();
                    Server.Transfer("AdmMenu.aspx");

                }
                else
                {
                    mensajetransaccionlbl.Text = "Usuario o contraseña incorrectos ...";
                    mensajetransaccionlbl.Visible = true;
                }
            }
            else if (ddrRol.SelectedValue.ToString() == "2")
            {
                if (valor == true)
                {
                    Session["nombreUsuario"] = Request["usuario"].ToString();
                    Session["contrasena"] = Request["pass"].ToString();
                    Session["rol"] = "2";
                    limpiar();
                    Server.Transfer("CajMenu.aspx");

                }
                else
                {
                    mensajetransaccionlbl.Text = "Usuario o contraseña incorrectos ...";
                    mensajetransaccionlbl.Visible = true;
                }
            }
            else if (ddrRol.SelectedValue.ToString() == "3")
            {
                if (valor == true)
                {
                    Session["nombreUsuario"] = Request["usuario"].ToString();
                    Session["contrasena"] = Request["pass"].ToString();
                    Session["rol"] = "3";
                    limpiar();
                    Server.Transfer("EmpMenu.aspx");

                }
                else
                {
                    mensajetransaccionlbl.Text = "Usuario o contraseña incorrectos ...";
                    mensajetransaccionlbl.Visible = true;
                }
            }
            else
            {
                mensajetransaccionlbl.Text = "Usuario o contraseña incorrectos ...";
                mensajetransaccionlbl.Visible = true;
            }

        }
        public void limpiar()
        {
            mensajetransaccionlbl.Text = "";
            mensajetransaccionlbl.Visible = false;
        }

    }
}