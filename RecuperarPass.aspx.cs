using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace ProyectoFinal
{
    public partial class RecuperarPass : System.Web.UI.Page
    {
        Negocio.NG_Login negocioObj = new Negocio.NG_Login();
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }




        private void EnviarCorreoContrasena(string contrasenaNueva,string usuario, string correo)
        {
            string contrasena = "PiedadLopez2021";
            string mensaje = string.Empty;
            //Creando el correo electronico
            string destinatario = correo;
            string remitente = "panaderiapiedadlopez@gmail.com";
            string asunto = "RECUPERACIÓN DE CONTRASEÑA";
            string cuerpoDelMesaje = "Su usuario es" + " " + Convert.ToString(usuario)+"\r\n"+"Su contraseña es" + " " + Convert.ToString(contrasenaNueva);

            MailMessage ms = new MailMessage(remitente, destinatario, asunto, cuerpoDelMesaje);


            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(remitente, contrasena);

            try
            {
                Task.Run(() =>
                {

                    smtp.Send(ms);
                    ms.Dispose();
                    //Response.Write("Correo enviado, sirvase revisar su bandeja de entrada");
                }
                );
                mensajetransaccionlbl.Text = "Esta tarea puede tardar unos segundos, por favor espere...";
                mensajetransaccionlbl.Visible = true;
               // Response.Write("Esta tarea puede tardar unos segundos, por favor espere.");
            }
            catch (Exception ex)
            {
                mensajetransaccionlbl.Text = "Error al enviar correo electronico: "+ ex.Message;
                mensajetransaccionlbl.Visible = true;
                //Response.Write("Error al enviar correo electronico: " + ex.Message);
            }
        }

        protected void btnenviar_Click(object sender, EventArgs e)
        {

            //correo
            string correo = Request["email"].ToString();

            if (negocioObj.ValidarCorreo(correo).ToString() == "EXITO")
            {
                string contrasena = negocioObj.GenerarContrasena(correo);

                string[] pass = contrasena.Split('-');

                EnviarCorreoContrasena(pass[0],pass[1], correo);
            }
            else 
            {
                mensajetransaccionlbl.Text = "El correo no esta registrado! ";
                mensajetransaccionlbl.Visible = true;
                //Response.Write("El correo no esta registrado!");
            }

            
        }
    }
}