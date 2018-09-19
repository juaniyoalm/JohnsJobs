using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Empleador;
using Core.Esquemas;

namespace Core.Mapping
{
    public static class MappingEmpleadorModel
    {
        /// <summary>
        /// Mapea los datos recibidos en una tabla con los campos de un objeto de tipo EmpleadorModel
        /// </summary>
        /// <param name="dtEmp"></param>
        /// <param name="row"></param>
        /// <returns>EmpleadorModel</returns>
        public static Empleador.EmpleadorModel ToEmpleadorModel(this dtsLecturaEmpleadores.EmpleadoresDataTable dtEmp, int row = 0)
        {
            Empleador.EmpleadorModel emp = new Empleador.EmpleadorModel();
            emp.Id = Convert.ToInt32(dtEmp.Rows[row][dtEmp.IdColumn.ColumnName]);
            emp.IdUsuario = Convert.ToInt32(dtEmp.Rows[row][dtEmp.IdUsuarioColumn.ColumnName]);
            emp.NombreEmpresa = dtEmp.Rows[row][dtEmp.NombreEmpresaColumn.ColumnName].ToString();
            emp.Direccion = dtEmp.Rows[row][dtEmp.DireccionColumn.ColumnName].ToString();
            emp.Telefono = dtEmp.Rows[row][dtEmp.TelefonoColumn.ColumnName].ToString();
            emp.Email = dtEmp.Rows[row][dtEmp.EmailColumn.ColumnName].ToString();
            emp.TipoIndustria = Convert.ToInt32(dtEmp.Rows[row][dtEmp.TipoIndustriaColumn.ColumnName]);
            emp.LogoEmpresa = ( byte[])dtEmp.Rows[row][dtEmp.LogoEmpresaColumn.ColumnName];
            emp.NumeroEmpleados = Convert.ToInt32(dtEmp.Rows[row][dtEmp.NumeroEmpleadosColumn.ColumnName]);
            emp.TipoIndustriaNombre = dtEmp.Rows[row][dtEmp.TipoIndustriaNombreColumn.ColumnName].ToString();
            emp.Nombre = dtEmp.Rows[row][dtEmp.NombreColumn.ColumnName].ToString();
            emp.Apellido1 = dtEmp.Rows[row][dtEmp.Apellido1Column.ColumnName].ToString();
            emp.Apellido2 = dtEmp.Rows[row][dtEmp.Apellido2Column.ColumnName].ToString();
            emp.TipoUsuario = Convert.ToInt32(dtEmp.Rows[row][dtEmp.TipoUsuarioColumn.ColumnName]);
            emp.Contrasena = dtEmp.Rows[row][dtEmp.ContrasenaColumn.ColumnName].ToString();

            return emp;
        }
    }
}
