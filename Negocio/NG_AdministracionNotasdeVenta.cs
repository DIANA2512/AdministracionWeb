using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ProyectoFinal.Negocio
{
    public class NG_AdministracionNotasdeVenta
    {
        AccesoDatos.AD_AdministracionNotasdeVenta datosObj = new AccesoDatos.AD_AdministracionNotasdeVenta();

        public int guardarNotadeVenta(int codigoPedido)
        {
            try
            {
                return datosObj.guardarNotadeVenta(codigoPedido);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int PagarAnularPedido(string tipoBusqueda, int codigoPedido)
        {
            try
            {
                return datosObj.PagarAnularPedido(tipoBusqueda,codigoPedido);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataTable buscarPedido(ref DataTable consulta, int codigoPedido, string fechadesde, string fechahasta)
        {
            try
            {
                return datosObj.buscarPedido(ref consulta, codigoPedido, fechadesde, fechahasta);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string TotalNota(ref DataTable consulta, int codigoPedido, string fechadesde, string fechahasta)
        {
            try
            {
                return datosObj.TotalNota(ref consulta, codigoPedido, fechadesde, fechahasta);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable filtroBuscarNotas(ref DataTable consulta, string fechadesde, string fechahasta)
        {
            try
            {
                return datosObj.filtroBuscarNotas(ref consulta, fechadesde, fechahasta);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
 