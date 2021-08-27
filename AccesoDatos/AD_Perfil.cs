using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ProyectoFinal.AccesoDatos
{
    public class AD_Perfil
    {
        private Conexion.Conexion conexionesObj;
        private SqlConnection _conexionSQL;
        private SqlCommand _cadenaCmd;

        public DataTable seleccionarPerfil (ref DataTable consulta, string codigoUsuario)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "SELECCIONAR_DATOS_USUARIO";
                _cadenaCmd.CommandTimeout = 60;
                _cadenaCmd.Parameters.AddWithValue("@ou_codigoUsuario", codigoUsuario);

                SqlDataAdapter da = new SqlDataAdapter(_cadenaCmd);
                da.Fill(consulta);
                return consulta;

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
                _conexionSQL = null;
            }
        }

        public int ActualizarPerfil(string correo, string telefono, string pass, string usuario)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "SP_UPDATE_PERFIL";
                _cadenaCmd.Parameters.AddWithValue("@correo", correo);
                _cadenaCmd.Parameters.AddWithValue("@telefono", telefono);
                _cadenaCmd.Parameters.AddWithValue("@pass", pass);
                _cadenaCmd.Parameters.AddWithValue("@usuario", usuario);
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

    }
}