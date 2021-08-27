using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ProyectoFinal.AccesoDatos
{
    public class AD_AdmAdministracionCompras
    {
        private Conexion.Conexion conexionesObj;
        private SqlConnection _conexionSQL;
        private SqlCommand _cadenaCmd;

        public DataTable buscarCompras(ref DataTable consulta)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "BUSQUEDA_COMPRA";
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

        public DataTable buscarCompraModificar(ref DataTable consulta, int codigoCompra)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "BUSQUEDA_COMPRA_MODIFICAR";
                _cadenaCmd.Parameters.AddWithValue("@ou_codigoCompra", codigoCompra);
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

        public int guardarActualizarCompra(string tipoBusqueda, int codigoComp, string descripcionComp, int codigoPro,
            string unidadPro, decimal valorcompraPro, int cantidadPro, int codigoProv,decimal valorCompraProducto,
            string numeroFacturaComp,string fechafactura)


        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "CREAR_ACTUALIZAR_COMPRA";
                _cadenaCmd.Parameters.AddWithValue("@ou_tipobusqueda", tipoBusqueda);
                _cadenaCmd.Parameters.AddWithValue("@ou_codigoCompra", codigoComp);
                _cadenaCmd.Parameters.AddWithValue("@ou_compraDescripcion", descripcionComp);
                _cadenaCmd.Parameters.AddWithValue("@ou_productoCodigo", codigoPro);
                _cadenaCmd.Parameters.AddWithValue("@ou_productoUnidad", unidadPro);
                _cadenaCmd.Parameters.AddWithValue("@ou_valorcompraProducto", valorcompraPro);
                _cadenaCmd.Parameters.AddWithValue("@ou_cantidadProducto", cantidadPro);
                _cadenaCmd.Parameters.AddWithValue("@ou_codigoProveedor", codigoProv);
                _cadenaCmd.Parameters.AddWithValue("@ou_totalCompra", valorCompraProducto);
                _cadenaCmd.Parameters.AddWithValue("@ou_numeroFacturaCompra", numeroFacturaComp);
                _cadenaCmd.Parameters.AddWithValue("@ou_fecha", fechafactura);
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

        public DataTable filtroBuscarCompras(ref DataTable consulta, string fechadesde, string fechahasta)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "FILTRO_BUSQUEDA_COMPRAS";
                _cadenaCmd.Parameters.AddWithValue("@ou_Fechadesde", fechadesde);
                _cadenaCmd.Parameters.AddWithValue("@ou_Fechahasta", fechahasta);
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