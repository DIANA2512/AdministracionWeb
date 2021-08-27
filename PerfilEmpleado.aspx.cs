using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ProyectoFinal
{
    public partial class PerfilEmpleado : System.Web.UI.Page
    {
        Negocio.NG_AdmAdministracionEmpleado negocioObj = new Negocio.NG_AdmAdministracionEmpleado();
        DataSet consulta = new DataSet();
        Negocio.NG_Perfil objPerfil = new Negocio.NG_Perfil();

        protected void Page_Load(object sender, EventArgs e)
        {
                if (string.IsNullOrEmpty(Session["nombreUsuario"].ToString()))
                {
                    Response.Redirect("Index.aspx");
                }

                if (Session["rol"].ToString() != "3")
                {
                    Response.Redirect("Index.aspx");
                }
                mostrarDatos();
        }

        public void mostrarDatos()
        {
            string[] modu;

            List<string> Listamodulo = new List<string>();
            foreach (DataRow row in negocioObj.buscarEmpleado(ref consulta, Session["nombreUsuario"].ToString()).Tables[0].Rows)
            {

                Listamodulo.Add(row["USUARIO"].ToString());
                Listamodulo.Add(row["NOMBRE"].ToString());
                Listamodulo.Add(row["CEDULA"].ToString());
                Listamodulo.Add(row["CORREO"].ToString());
                Listamodulo.Add(row["TELEFONO"].ToString());
                Listamodulo.Add(row["PASS"].ToString());
            }
            modu = Listamodulo.ToArray();

            //mostrar en txt
            txtusuario.Text = modu[0].ToString();
            txtnombre.Text = modu[1].ToString();
            txtcedula.Text = modu[2].ToString();
            txtcorreo.Text = modu[3].ToString();
            txttelefono.Text = modu[4].ToString();
            txtpass.Text = modu[5].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (objPerfil.ActualizarPerfil(txtcorreo.Text, txttelefono.Text, txtpass.Text, txtusuario.Text) > 0)

            {
                ClientScript.RegisterStartupScript(this.GetType(), "Registro Perfil", "alert('La actualizacion de datos fue exitosa.');", true);
            }
            else
            {
                //Response.Write("ERROR AL GUADAR EL PRODUCTO");
                ClientScript.RegisterStartupScript(this.GetType(), "Registro Perfil", "alert('La actualizacion de datos no fue exitosa.');", true);
            }
        }

    }
}