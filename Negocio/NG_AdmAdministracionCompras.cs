using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Negocio
{
    public class NG_AdmAdministracionCompras
    {
        AccesoDatos.AD_AdmAdministracionCompras datosObj = new AccesoDatos.AD_AdmAdministracionCompras();

        public DataTable buscarCompra(ref DataTable consulta)
        {
            try
            {
                return datosObj.buscarCompras(ref consulta);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable buscarCompraModificar(ref DataTable consulta, int codigoCompra)
        {
            try
            {
                return datosObj.buscarCompraModificar(ref consulta, codigoCompra);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int guardarActualizarCompra(string tipoBusqueda, int codigoComp, string descripcionComp, int codigoPro,
            string unidadPro, decimal valorcompraPro, int cantidadPro, int codigoProv, decimal valorCompraProducto,
            string numeroFacturaComp, string fechafactura)
        {
            try
            {
                return datosObj.guardarActualizarCompra(tipoBusqueda, codigoComp, descripcionComp, codigoPro,
             unidadPro, valorcompraPro, cantidadPro, codigoProv, valorCompraProducto, numeroFacturaComp, fechafactura);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataTable filtroBuscarCompras(ref DataTable consulta, string fechadesde, string fechahasta)
        {
            try
            {
                return datosObj.filtroBuscarCompras(ref consulta, fechadesde, fechahasta);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}