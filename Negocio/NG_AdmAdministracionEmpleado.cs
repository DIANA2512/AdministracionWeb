using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ProyectoFinal.Negocio
{
    public class NG_AdmAdministracionEmpleado
    {
        AccesoDatos.AD_AdmAdministracionEmpleados datosObj = new AccesoDatos.AD_AdmAdministracionEmpleados();

        public DataSet buscarEmpleado(ref DataSet consulta, string usuario)
        {
            try
            {
                return datosObj.buscarEmpleado(ref consulta,  usuario);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        

    }
}