using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Negocio
{
    public class NG_AdministracionClientes
    {
        AccesoDatos.AD_AdministracionClientes datosObj = new AccesoDatos.AD_AdministracionClientes();

        public DataTable buscarCliente(ref DataTable consulta)
        {
            try
            {
                return datosObj.buscarCliente(ref consulta);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable buscarClienteModifcar(ref DataTable consulta, int codigoCliente)
        {
            try
            {
                return datosObj.buscarClienteModifcar(ref consulta, codigoCliente);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int guardarActualizarCliente(string tipoBusqueda, int codigoCliente, string nombreCliente, string apellidoCliente, string cedulaCliente, string correoCliente, string direccionCliente, int codigoEstado)
        {
            try
            {
                return datosObj.guardarActualizarCliente(tipoBusqueda, codigoCliente, nombreCliente,apellidoCliente,cedulaCliente,correoCliente,direccionCliente, codigoEstado);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataTable filtroBuscarClientes(ref DataTable consulta, string cedulaCliente)
        {
            try
            {
                return datosObj.filtroBuscarClientes(ref consulta, cedulaCliente);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}