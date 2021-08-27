using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ProyectoFinal.Negocio
{
    public class NG_AdministracionRoles
    {
        AccesoDatos.AD_AdministracionRoles datosObj = new AccesoDatos.AD_AdministracionRoles();

        public DataTable buscarRol(ref DataTable consulta)
        {
            try
            {
                return datosObj.buscarRol(ref consulta);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable buscarRolModifcar(ref DataTable consulta, int codigoRol)
        {
            try
            {
                return datosObj.buscarRolModifcar(ref consulta,codigoRol);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int guardarActualizarRol(string tipoBusqueda, int codigoRol, string nombreRol, int codigoEstado)
        {
            try
            {
                return datosObj.guardarActualizarRol(tipoBusqueda,codigoRol,nombreRol,codigoEstado);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    
    }
}