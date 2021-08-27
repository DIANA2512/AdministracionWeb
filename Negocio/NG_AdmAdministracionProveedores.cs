using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ProyectoFinal.Negocio
{
    public class NG_AdmAdministracionProveedores
    {
        AccesoDatos.AD_AdmAdministracionProveedores datosObj = new AccesoDatos.AD_AdmAdministracionProveedores();

        public DataTable buscarProveedor(ref DataTable consulta)
        {
            try
            {
                return datosObj.buscarProveedor(ref consulta);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable buscarProveedorModifcar(ref DataTable consulta, int codigoProveedor)
        {
            try
            {
                return datosObj.buscarProveedorModifcar(ref consulta, codigoProveedor);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int guardarActualizarProveedor(string tipoBusqueda, int codigoProveedor, string nombreProveedor
            , string apellidoProveedor, string cedulaProveedor, string correoProveedor, string empresaProveedor, string direccionProveedor, int estadoProvedor)
        {
            try
            {
                return datosObj.guardarActualizarProveedor(tipoBusqueda, codigoProveedor, nombreProveedor
            , apellidoProveedor, cedulaProveedor, correoProveedor, empresaProveedor, direccionProveedor, estadoProvedor);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataTable filtroBuscarProveedor(ref DataTable consulta, string empresaProveedor)
        {
            try
            {
                return datosObj.filtroBuscarProveedor(ref consulta, empresaProveedor);
            }
            catch (Exception ex)
            {
                return null;
            }
        }



    }
}
