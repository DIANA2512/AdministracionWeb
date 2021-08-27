using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Negocio
{
    public class NG_ReporteVentas
    {
        AccesoDatos.AD_ReporteVentas datosObj = new AccesoDatos.AD_ReporteVentas();

        public DataTable buscarVentas(ref DataTable consulta)
        {
            try
            {
                return datosObj.buscarVentas(ref consulta);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable filtroBuscarVentas(ref DataTable consulta, string nombreCliente, string fechadesde, string fechahasta)
        {
            try
            {
                return datosObj.filtroBuscarVentas(ref consulta, nombreCliente, fechadesde, fechahasta);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable filtroBuscarVentasCliente(ref DataTable consulta, string nombreCliente)
        {
            try
            {
                return datosObj.filtroBuscarVentasCliente(ref consulta, nombreCliente);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}