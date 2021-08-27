using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ProyectoFinal.Negocio
{
    public class NG_AdmAdministracionProductos
    {
        AccesoDatos.AD_AdmAdministracionProductos datosObj = new AccesoDatos.AD_AdmAdministracionProductos();
        
        public DataTable buscarProducto (ref DataTable consulta)
        {
            try
            {
                return datosObj.buscarProductos(ref consulta);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable buscarProductoDDR(ref DataTable consulta)
        {
            try
            {
                return datosObj.buscarProductosDDR(ref consulta);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable buscarCategoriasProductos(ref DataTable consulta)
        {
            try
            {
                return datosObj.buscarCategoriasProductos(ref consulta);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable buscarProveeorProductos(ref DataTable consulta)
        {
            try
            {
                return datosObj.buscarProveedorProductos(ref consulta);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable buscarProductoModificar(ref DataTable consulta, int codigoProducto)
        {
            try 
            {
                return datosObj.buscarProductoModificar(ref consulta, codigoProducto);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int guardarActualizarProducto(string tipoBusqueda, int codigoPro, string nombrePro, string unidadPro,
            decimal valorCompraPro, decimal valorVentaPro, int categoriaPro, int estadoPro, string lotePro, string fechaIngresoPro, string fechaVencimientoPro,
            int cantidadPro, int proveedorPro)
        {
            try
            {
                return datosObj.guardarActualizarProducto(tipoBusqueda, codigoPro, nombrePro, unidadPro,
            valorCompraPro, valorVentaPro, categoriaPro, estadoPro, lotePro, fechaIngresoPro, fechaVencimientoPro,
            cantidadPro, proveedorPro);
            }
            catch (Exception ex)
            {
                return 0; 
            }
        }

        public DataTable filtroBuscarProductos(ref DataTable consulta, string nombreProducto)
        {
            try
            {
                return datosObj.filtroBuscarProductos(ref consulta, nombreProducto);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}