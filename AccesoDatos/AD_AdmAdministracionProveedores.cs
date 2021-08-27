using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal.AccesoDatos
{
    public class AD_AdmAdministracionProveedores
    {
        private Conexion.Conexion conexionesObj;
        private SqlConnection _conexionSQL;
        private SqlCommand _cadenaCmd;

        public DataTable buscarProveedor(ref DataTable consulta)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "BUSQUEDA_PROVEEDOR";
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

        public DataTable buscarProveedorModifcar(ref DataTable consulta, int codigoProveedor)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "BUSQUEDA_PROVEEDOR_MODIFICAR";
                _cadenaCmd.Parameters.AddWithValue("@ou_codigoProveedor", codigoProveedor);
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

        public int guardarActualizarProveedor(string tipoBusqueda, int codigoProveedor, string nombreProveedor
            , string apellidoProveedor, string cedulaProveedor, string correoProveedor, string empresaProveedor, string direccionProveedor,int estadoProvedor)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "CREAR_ACTUALIZAR_PROVEEDOR";
                _cadenaCmd.Parameters.AddWithValue("@ou_tipobusqueda", tipoBusqueda);
                _cadenaCmd.Parameters.AddWithValue("@ou_proveedorCodigo", codigoProveedor);
                _cadenaCmd.Parameters.AddWithValue("@ou_proveedorNombre", nombreProveedor);
                _cadenaCmd.Parameters.AddWithValue("@ou_proveedorApellido", apellidoProveedor);
                _cadenaCmd.Parameters.AddWithValue("@ou_proveedorCedula", cedulaProveedor);
                _cadenaCmd.Parameters.AddWithValue("@ou_proveedorCorreo", correoProveedor);
                _cadenaCmd.Parameters.AddWithValue("@ou_proveedorEmpresa", empresaProveedor);
                _cadenaCmd.Parameters.AddWithValue("@ou_proveedorDireccion", direccionProveedor);
                _cadenaCmd.Parameters.AddWithValue("@ou_proveedorEstado", estadoProvedor);

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

        public DataTable filtroBuscarProveedor(ref DataTable consulta, string empresaProveedor)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "FILTRO_BUSQUEDA_PROVEEDOR";
                _cadenaCmd.Parameters.AddWithValue("@ou_empresaProveedor", empresaProveedor);
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
