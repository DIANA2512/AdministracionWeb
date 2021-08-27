using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Agregadas
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using ProyectoFinal.Conexion;

namespace ProyectoFinal.AccesoDatos
{
    public class AD_AdmAdministracionUsuarios
    {
        private Conexion.Conexion conexionesObj;
        private SqlConnection _conexionSQL;
        private SqlCommand _cadenaCmd;

        public DataTable buscarUsuarios(ref DataTable consulta)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "BUSQUEDA_USUARIO";
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
        public DataTable buscarUsuarioModificar(ref DataTable consulta, int codigoUsuario)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "BUSQUEDA_USUARIO_MODIFICAR";
                _cadenaCmd.Parameters.AddWithValue("@ou_codigoUsuario", codigoUsuario);
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
        public int guardarActualizarUsuario(string tipoBusqueda, int codigoUsu, string usuario, string nombreUsu, string cedulaUsuario, string correoUsuario, string telefonoUsuario, string contrsenaUsu, int rol, int estadoUsu)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "CREAR_ACTUALIZAR_USUARIO";
                _cadenaCmd.Parameters.AddWithValue("@ou_tipobusqueda", tipoBusqueda);
                _cadenaCmd.Parameters.AddWithValue("@ou_usuarioCodigo", codigoUsu);
                _cadenaCmd.Parameters.AddWithValue("@ou_usuario", usuario);
                _cadenaCmd.Parameters.AddWithValue("@ou_usuarioNombre", nombreUsu);
                _cadenaCmd.Parameters.AddWithValue("@ou_usuarioCedula", cedulaUsuario);
                _cadenaCmd.Parameters.AddWithValue("@ou_usuarioCorreo", correoUsuario);
                _cadenaCmd.Parameters.AddWithValue("@ou_usuarioTelefono", telefonoUsuario);
                _cadenaCmd.Parameters.AddWithValue("@ou_usuarioContrasena", contrsenaUsu);
                _cadenaCmd.Parameters.AddWithValue("@ou_rolCodigo", rol);
                _cadenaCmd.Parameters.AddWithValue("@ou_usuarioEstado", estadoUsu);
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

        public DataTable filtroBuscarUsuario(ref DataTable consulta, string cedulaUsuario)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "FILTRO_BUSQUEDA_USUARIO";
                _cadenaCmd.Parameters.AddWithValue("@ou_cedulaUsuario", cedulaUsuario);
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