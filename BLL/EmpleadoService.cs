using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.ComponentModel;

namespace BLL
{
    public class EmpleadoService
    {
        private string fileName = "empleados.txt";
        RepositorioEmpleado repositorio;

        private List<Empleado> empleados;
        public EmpleadoService()
        {
            repositorio = new RepositorioEmpleado(fileName);
            RefrescarLista();
        }
        void RefrescarLista()
        {
            empleados = repositorio.ConsultarTodos();
        }
        public string Guardar(Empleado empleado)
        {
           var msg= repositorio.Guardar(empleado.ToString());
            RefrescarLista();
            return msg;
        }
        public List<Empleado> Consultar()
        {
            return empleados;
        }

        public Empleado BuscarId(string id)
        {
            foreach (var item in empleados)
            {
                if (item.Empleadoid ==id)
                {
                    return item;
                }
            }
            return null;
        }

        
    }
}
