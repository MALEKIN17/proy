using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepositorioEmpleado:Archivo
    {
        public RepositorioEmpleado(string fileName) : base(fileName)
        {
        }

        public List<Empleado> ConsultarTodos()
        {
            try
            {
                List<Empleado> lista = new List<Empleado>();

                StreamReader sr = new StreamReader(fileName);
                while (!sr.EndOfStream)
                {
                    lista.Add(Mapear(sr.ReadLine()));
                }
                sr.Close();
                return lista;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Empleado BuscarId(string id)
        {
            var lista= ConsultarTodos();
            foreach (var item in lista)
            {
                if (item.Empleadoid==id)
                {
                    return item;
                }

            }
            return null;
        }

        private Empleado Mapear(string datos)
        {
            var linea = datos.Split(';');
            Empleado empleado = new Empleado

            {

                Empleadoid = linea[0],
                Empleadonombre = linea[1],
                Empleadosalario = linea[2],
                Empleadoestado = linea[3],

            };
            return empleado;
        }
    }
}
