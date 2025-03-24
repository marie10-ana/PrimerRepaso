using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerRepaso
{
    public partial class FormReporte : Form
    {
        List<Empleado> empleados = new List<Empleado>();
        List<Asistencia> asistencias = new List<Asistencia>();
        List<ReporteSueldo> reportes = new List<ReporteSueldo>();

        public FormReporte()
        {
            InitializeComponent();
        }
         
        public void CargarEmpleados ()
        {
            EmpleadoPersistencia empleadoPersistencia = new EmpleadoPersistencia();
            empleados = empleadoPersistencia.Leer(@"../../Empleados.txt");
        }

        public void CargarAsistencias ()
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormReporte_Load(object sender, EventArgs e)
        {

        }

        private void buttonMostrarReporte_Click(object sender, EventArgs e)
        {
            foreach (var empleado in empleados)
            {
                foreach (var asistencia in asistencias)
                {
                    if (empleado.NoEmpleado == asistencia.NoEmpleado)
                    {
                        ReporteSueldo reporte = new ReporteSueldo();
                        reporte.Nombre = empleado.Nombre;
                        reporte.Mes = asistencia.Mes.ToString();
                        reporte.SueldoTotal = empleado.SueldoHora * asistencia.HoraMes;

                        reportes.Add(reporte);
                    }
                }
                
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reportes;
            dataGridView1.Refresh();    
        }
    }
}
