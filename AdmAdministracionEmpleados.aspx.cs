using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ProyectoFinal
{
    public partial class AdmAdministracionEmpleados : System.Web.UI.Page
    {
        Negocio.NG_AdmAdministracionEmpleado negocioObj = new Negocio.NG_AdmAdministracionEmpleado();
        DataSet consulta = new DataSet();
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
    }
}