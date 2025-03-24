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
    public partial class FormEmpleado : Form
    {
        List<Empleado> empleados = new List<Empleado>();
        public FormEmpleado()
        {
            InitializeComponent();
        }

        public void Mostrar()
        {
            EmpleadoPersistencia empleadoPersistencia = new EmpleadoPersistencia();
            empleados = empleadoPersistencia.Leer(@"../../Empleados.txt");

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = empleados;
            dataGridView1.Refresh();
        }

        private void ButtonAsistencia_Click(object sender, EventArgs e)
        {
            FormAsistencia formAsistencia = new FormAsistencia();
            formAsistencia.Show();
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado();
            empleado.NoEmpleado = Convert.ToInt16(numericNoEmpleado.Value);
            empleado.Nombre = txtNombre.Text;
            empleado.SueldoHora = Convert.ToDecimal(maskedTxtSueldo);

            empleados.Add(empleado);
            EmpleadoPersistencia empleadoPersistencia = new EmpleadoPersistencia();
            empleadoPersistencia.Guardar(@"../../Empleados.txt", empleados);

            Mostrar();
        }
        
       
        private void FormEmpleado_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
    }
}
