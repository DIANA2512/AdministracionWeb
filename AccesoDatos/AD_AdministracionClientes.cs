using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Agregadas
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace ProyectoFinal.AccesoDatos
{
    public class AD_AdministracionClientes
    {
        private Conexion.Conexion conexionesObj;
        private SqlConnection _conexionSQL;
        private SqlCommand _cadenaCmd;

        public DataTable buscarCliente(ref DataTable consulta)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "BUSQUEDA_CLIENTE";
                _cadenaCmd.CommandTimeout = 60;

                SqlDataAdapter da = new SqlDataAdapter(_cadenaCmd);
                da.Fill(consulta);
                return consulta;
                //valido si encruentra datos

            }
            catch (SqlException errorBDD)
            {
                throw errorBDD;
            }
            catch (Exception errorCSharp)
            {
                throw errorCSharp;
            }
            finally
            {
                _conexionSQL.Close();
                _cadenaCmd = null;
            }
        }

        public DataTable buscarClienteModifcar(ref DataTable consulta, int codigoCliente)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "BUSQUEDA_CLIENTE_MODIFICAR";
                _cadenaCmd.Parameters.AddWithValue("@ou_codigoCliente", codigoCliente);
                _cadenaCmd.CommandTimeout = 60;

                SqlDataAdapter da = new SqlDataAdapter(_cadenaCmd);
                da.Fill(consulta);
                return consulta;
                //valido si encruentra datos

            }
            catch (SqlException errorBDD)
            {
                throw errorBDD;
            }
            catch (Exception errorCSharp)
            {
                throw errorCSharp;
            }
            finally
            {
                _conexionSQL.Close();
                _cadenaCmd = null;
            }
        }

        public int guardarActualizarCliente(string tipoBusqueda, int codigoCliente, string nombreCliente
            ,string apellidoCliente, string cedulaCliente,string correoCliente,string direccionCliente, int codigoEstado)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "CREAR_ACTUALIZAR_CLIENTE";
                _cadenaCmd.Parameters.AddWithValue("@ou_tipobusqueda", tipoBusqueda);
                _cadenaCmd.Parameters.AddWithValue("@ou_clienteCodigo", codigoCliente);
                _cadenaCmd.Parameters.AddWithValue("@ou_clienteNombre", nombreCliente);
                _cadenaCmd.Parameters.AddWithValue("@ou_clienteApellido", apellidoCliente);
                _cadenaCmd.Parameters.AddWithValue("@ou_clienteCedula", cedulaCliente);
                _cadenaCmd.Parameters.AddWithValue("@ou_clienteCorreo", correoCliente);
                _cadenaCmd.Parameters.AddWithValue("@ou_clienteDireccion", direccionCliente);
                _cadenaCmd.Parameters.AddWithValue("@ou_clienteEstado", codigoEstado);

                _cadenaCmd.CommandTimeout = 60;

                int respuesta = Convert.ToInt32(_cadenaCmd.ExecuteNonQuery());
                return respuesta;
                //valido si encruentra datos

            }
            catch (SqlException errorBDD)
            {
                throw errorBDD;
            }
            catch (Exception errorCSharp)
            {
                throw errorCSharp;
            }
            finally
            {
                _conexionSQL.Close();
                _cadenaCmd = null;
            }
        }

        public DataTable filtroBuscarClientes(ref DataTable consulta, string cedulaCliente)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "FILTRO_BUSQUEDA_CLIENTE";
                _cadenaCmd.Parameters.AddWithValue("@ou_cedulaCliente", cedulaCliente);
                _cadenaCmd.CommandTimeout = 60;

                SqlDataAdapter da = new SqlDataAdapter(_cadenaCmd);
                da.Fill(consulta);
                return consulta;
                //valido si encruentra datos


            }
            catch (SqlException errorBDD)
            {
                throw errorBDD;
            }
            catch (Exception errorCSharp)
            {
                throw errorCSharp;
            }
            finally
            {
                _conexionSQL.Close();
                _cadenaCmd = null;
            }
        }


    }
}