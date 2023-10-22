using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Empleado
    {
        public string Empleadoid { get; set; }
        public string Empleadonombre { get; set; }
        public string Empleadosalario { get; set; }
        public string Empleadoestado { get; set; }
        
        
        public Empleado(string codigo, string nombre, string salario, string estado )
        {
            this.Empleadoid = codigo;
            this.Empleadonombre = nombre;
            this.Empleadosalario = salario;
            this.Empleadoestado = estado;
            
        }

        public override string ToString()
        {
            return $"Codigo: {Empleadoid} Nombre: {Empleadonombre} Salario: {Empleadosalario} Estado: {Empleadoestado}";
        }
        
    }
}
