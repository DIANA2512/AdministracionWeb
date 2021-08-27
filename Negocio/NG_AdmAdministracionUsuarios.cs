using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ProyectoFinal.Negocio
{
    public class NG_AdmAdministracionUsuarios
    {
        AccesoDatos.AD_AdmAdministracionUsuarios datosObj = new AccesoDatos.AD_AdmAdministracionUsuarios();
      
        public DataTable buscarUsuario(ref DataTable consulta)
        {
            try
            {
                return datosObj.buscarUsuarios(ref consulta);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable buscarUsuarioModifcar(ref DataTable consulta, int codigoUsuario)
        {
            try
            {
                return datosObj.buscarUsuarioModificar(ref consulta, codigoUsuario);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int guardarActualizarUsuario(string tipoBusqueda, int codigoUsu, string usuario,string nombreUsu, string cedulaUsuario, string correoUsuario, string telefonoUsuario, string contrsenaUsu, int rol, int estadoUsu)
        {
            try
            {
                return datosObj.guardarActualizarUsuario(tipoBusqueda,codigoUsu,usuario, nombreUsu, cedulaUsuario,correoUsuario,telefonoUsuario, contrsenaUsu, rol,estadoUsu);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataTable filtroBuscarUsuario(ref DataTable consulta, string cedulaUsuario)
        {
            try
            {
                return datosObj.filtroBuscarUsuario(ref consulta, cedulaUsuario);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
