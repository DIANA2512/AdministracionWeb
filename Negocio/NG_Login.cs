using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Negocio
{
    public class NG_Login
    {
        AccesoDatos.AD_Login datosObj = new AccesoDatos.AD_Login();

        public bool VerificarUsuario(string usuario, string pass, string rol)
        {
            try
            {
                return datosObj.Login(usuario, pass, rol);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable buscarRol(ref DataTable consulta, string tipobusqueda)
        {
            try
            {
                return datosObj.buscarRol(ref consulta,tipobusqueda);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string ValidarCorreo(string correo)
        {
            try
            {
                return datosObj.ValidarCorreo(correo);
            }
            catch (Exception ex)
            {
                return "0";
            }
        }

        public string GenerarContrasena(string correo)
        {
            try
            {
                return datosObj.GenerarContrasena(correo);
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
    }
}