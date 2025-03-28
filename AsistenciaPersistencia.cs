using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
namespace PrimerRepaso
{
    internal class AsistenciaPersistencia
    {
        public void Guardar(string archivo, List<Asistencia> asistencias)
        {
            string json = JsonConvert.SerializeObject(asistencias);
            System.IO.File.WriteAllText(archivo, json);
        }

        public List<Asistencia> Leer(string archivo)
        {
            List<Asistencia> lista = new List<Asistencia>();
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();

            lista = JsonConvert.DeserializeObject<List<Asistencia>>(json);
            return lista;
        }

    }
}
