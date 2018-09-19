using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Empleador;
using Core.Esquemas;


namespace Core.Mapping
{
    public static class MappingEmpleador
    {
        /// <summary>
        /// Mapea los datos recibidos en una tabla con los campos de un objeto de tipo Empleador
        /// </summary>
        /// <param name="dtEmp"></param>
        /// <param name="row"></param>
        /// <returns>Empleador</returns>
        public static Empleador.Empleador ToEmpleador(this dtsEmpleadores.EmpleadoresDataTable dtEmp, int row = 0)
        {
            Empleador.Empleador emp = new Empleador.Empleador();
            emp.Id = Convert.ToInt32(dtEmp.Rows[row][dtEmp.IdColumn.ColumnName]);
            emp.IdUsuario = Convert.ToInt32(dtEmp.Rows[row][dtEmp.IdUsuarioColumn.ColumnName]);
            emp.NombreEmpresa = dtEmp.Rows[row][dtEmp.NombreEmpresaColumn.ColumnName].ToString();
            emp.Direccion = dtEmp.Rows[row][dtEmp.DireccionColumn.ColumnName].ToString();
            emp.Telefono = dtEmp.Rows[row][dtEmp.TelefonoColumn.ColumnName].ToString();
            emp.Email = dtEmp.Rows[row][dtEmp.EmailColumn.ColumnName].ToString();
            emp.LogoEmpresa = (byte[])dtEmp.Rows[row][dtEmp.LogoEmpresaColumn.ColumnName];
            emp.TipoIndustria = Convert.ToInt32(dtEmp.Rows[row][dtEmp.TipoIndustriaColumn.ColumnName]);
            emp.NumeroEmpleados = Convert.ToInt32(dtEmp.Rows[row][dtEmp.NumeroEmpleadosColumn.ColumnName]);

            return emp;
        }

        /// <summary>
        /// Mapea los datos recibidos en un objeto de tipo Empleador y los introduce un una fila de  una tabla
        /// de tipo dtsEmpleadores.EmpleadoresRow
        /// </summary>
        /// <param name="emp"></param>
        /// <returns>dtsEmpleadores</returns>
        public static dtsEmpleadores ToDtsEmpleadores(this Empleador.Empleador emp)
        {

            dtsEmpleadores dts = new dtsEmpleadores();
            dtsEmpleadores.EmpleadoresRow dtsRow = dts.Empleadores.NewEmpleadoresRow();

            dtsRow.IdUsuario = emp.IdUsuario;
            dtsRow.NombreEmpresa = emp.NombreEmpresa;
            dtsRow.Direccion = emp.Direccion;
            dtsRow.Telefono = emp.Telefono;
            dtsRow.Email = emp.Email;
            dtsRow.NumeroEmpleados = emp.NumeroEmpleados;
            dtsRow.LogoEmpresa = emp.LogoEmpresa; ;
            dtsRow.TipoIndustria = (short)emp.TipoIndustria;
            dts.Empleadores.AddEmpleadoresRow(dtsRow);

            return dts;
        }
    }
}
