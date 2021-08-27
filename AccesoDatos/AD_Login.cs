using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Agregadas
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinal.AccesoDatos
{
    public class AD_Login
    {
        private Conexion.Conexion conexionesObj;
        private SqlConnection _conexionSQL;
        private SqlCommand _cadenaCmd;

        public bool Login(string usuario, string contrasena, string rol)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "VERIFICAR_USUARIO";
                _cadenaCmd.CommandTimeout = 60;
                _cadenaCmd.Parameters.AddWithValue("@ou_usuario", usuario);
                _cadenaCmd.Parameters.AddWithValue("@ou_usuarioContrasena", contrasena);
                _cadenaCmd.Parameters.AddWithValue("@ou_rolCodigo", rol);

                SqlDataAdapter da = new SqlDataAdapter(_cadenaCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //valido si encruentra datos
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    return true;
                }
                else
                    return false;

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

        public DataTable buscarRol(ref DataTable consulta, string tipobusqueda)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "BUSCAR_ROLES";
                _cadenaCmd.CommandTimeout = 60;
                _cadenaCmd.Parameters.AddWithValue("@ou_tipobusqueda", tipobusqueda);


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

        public string ValidarCorreo(string correo)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "VALIDAR_CORREO";
                _cadenaCmd.CommandTimeout = 60;
                _cadenaCmd.Parameters.AddWithValue("@correo", correo);


                SqlDataAdapter da = new SqlDataAdapter(_cadenaCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string mensaje = dt.Rows[0]["MENSAJE"].ToString();
                return mensaje;

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
        public string GenerarContrasena(string correo)
        {
            try
            {
                _conexionSQL = new SqlConnection();
                conexionesObj = new Conexion.Conexion(_conexionSQL);
                _cadenaCmd = new SqlCommand();
                _cadenaCmd.Connection = _conexionSQL;
                _cadenaCmd.CommandType = CommandType.StoredProcedure;
                _cadenaCmd.CommandText = "BUSQUEDA_CONTRASENA";
                _cadenaCmd.CommandTimeout = 60;
                _cadenaCmd.Parameters.AddWithValue("@correo", correo);

                SqlDataAdapter da = new SqlDataAdapter(_cadenaCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string pass = dt.Rows[0]["PASS"].ToString();
                return pass;

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