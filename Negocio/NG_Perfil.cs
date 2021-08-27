using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ProyectoFinal.Negocio
{
    public class NG_Perfil
    {
        AccesoDatos.AD_Perfil objPerfil = new AccesoDatos.AD_Perfil();

        public DataTable seleccionarPerfil(ref DataTable consulta, string codigoUsuario)

        {
            return objPerfil.seleccionarPerfil(ref consulta, codigoUsuario);
        }

        public int ActualizarPerfil(string correo, string telefono, string pass, string usuario)
        {
            try
            {
                return objPerfil.ActualizarPerfil(correo,telefono,pass,usuario);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}