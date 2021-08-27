using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal.AccesoDatos
{
    public class AD_AdministracionNotasdeVenta
    {
        private Conexion.Conexion conexionesObj;
        private SqlConnection _conexionSQL;
        private SqlCommand _cadenaCmd;

        public int guardarNotadeVenta(int codigoPedido)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "CREAR_NOTA";
                _cadenaCmd.Parameters.AddWithValue("@ou_codidoPedido", codigoPedido);
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

        public int PagarAnularPedido(string tipoBusqueda,int codigoPedido)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "PAGAR_PEDIDO";
                _cadenaCmd.Parameters.AddWithValue("@tipoBusqueda", tipoBusqueda);
                _cadenaCmd.Parameters.AddWithValue("@codigoPedido", codigoPedido);
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
        public DataTable buscarPedido (ref DataTable consulta, int codigoPedido, string fechadesde, string fechahasta)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "CREAR_NOTA";
                _cadenaCmd.Parameters.AddWithValue("@ou_codidoPedido", codigoPedido);
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

        public string TotalNota(ref DataTable consulta, int codigoPedido, string fechadesde, string fechahasta)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "SP_TOTAL_NOTAVENTA";
                _cadenaCmd.Parameters.AddWithValue("@ou_codidoPedido", codigoPedido);
                _cadenaCmd.Parameters.AddWithValue("@ou_Fechadesde", fechadesde);
                _cadenaCmd.Parameters.AddWithValue("@ou_Fechahasta", fechahasta);
                _cadenaCmd.CommandTimeout = 60;

                SqlDataAdapter da = new SqlDataAdapter(_cadenaCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string resultado = dt.Rows[0]["TOTAL"].ToString();
                return resultado;


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

        public DataTable filtroBuscarNotas(ref DataTable consulta, string fechadesde, string fechahasta)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "FILTRO_BUSQUEDA_NOTA_DE_VENTA";
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
  