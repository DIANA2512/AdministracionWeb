using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Negocio
{
    public class NG_AdmAdministracionCategorias
    {
        AccesoDatos.AD_AdmAdministracionCategorias datosObj = new AccesoDatos.AD_AdmAdministracionCategorias();
        
        public DataTable buscarCategoria (ref DataTable consulta)
        {
            try
            {
                return datosObj.buscarCategorias(ref consulta);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable buscarCategoriaModificar(ref DataTable consulta, int codigoCategoria)
        {
            try
            {
                return datosObj.buscarCategoriaModificar(ref consulta, codigoCategoria);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int guardarActualizarCategoria(string tipobusqueda, int codigoCat, string descripcionCat, int estadoCat)
        {
            try
            {
                return datosObj.guardarActualizarCategoria(tipobusqueda, codigoCat, descripcionCat, estadoCat);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataTable filtroBuscarCategoria(ref DataTable consulta, string descripcionCategoria)
        {
            try
            {
                return datosObj.filtroBuscarCategoria(ref consulta, descripcionCategoria);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}