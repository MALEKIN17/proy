using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DAL
{
    public class Archivo
    {
        protected string fileName;
        public Archivo(string fileName)
        {
            this.fileName = fileName;
        }

        public String Guardar(string datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fileName, true);
                sw.WriteLine(datos);
                sw.Close();
                return "datos guardados";
        }
            catch (Exception)
            {

                return "error al guardar";
            }
}

    }
}
