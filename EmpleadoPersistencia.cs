using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerRepaso
{
    internal class EmpleadoPersistencia
    {
        public void Guardar(string archibo, List<Empleado> empleados)
        {
            string json = JsonConvert.SerializeObject(empleados);
            string archivo = "Datos.json";
            System.IO.File.WriteAllText(archivo, json);
        }

        public List<Empleado> Leer(string archivo)
        {
            List<Empleado> lista = new List<Empleado>();
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();

            lista = JsonConvert.DeserializeObject<List<Empleado>>(json);
            return lista;

        }
    }
}
