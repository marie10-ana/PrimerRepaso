using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerRepaso
{
    public partial class FormAsistencia : Form
    {
        List<Empleado> empleados = new List<Empleado>();
        List<Asistencia> asistencias = new List<Asistencia>();

        public FormAsistencia()
        {
            InitializeComponent();
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            Asistencia asistencia = new Asistencia();   
            asistencia.NoEmpleado = Convert.ToInt16(comboBoxEmpleados.SelectedValue);
            asistencia.HoraMes = ((int)numericHoraMes.Value);
            asistencia.Mes = Convert.ToInt16(numericMes.Value);

            asistencias.Add(asistencia);

            AsistenciaPersistencia asistenciaPersistencia = new AsistenciaPersistencia();
            asistenciaPersistencia.Guardar("../../Asitencias.json", asistencias);


        }

        private void FormAsistencia_Load(object sender, EventArgs e)
        {
            List<Empleado> empleados = new List<Empleado>();
            EmpleadoPersistencia empleadoPersistencia = new EmpleadoPersistencia();
            empleados = empleadoPersistencia.Leer(@"../../Empleados.json");

            comboBoxEmpleados.DisplayMember = "Nombre";
            comboBoxEmpleados.ValueMember = "NoEmpleado";
            comboBoxEmpleados.DataSource = empleados;

            AsistenciaPersistencia asistenciaArchivo = new AsistenciaPersistencia();
            asistencias = asistenciaArchivo.Leer("../../Asitencias.json");
        }
    }
}
