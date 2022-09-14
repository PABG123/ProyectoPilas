using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PilaEmpleados
{
    public partial class PilaEmpleado : Form
    {
        //Se crea el objeto de la "pila empleado" de la  - constructor (clase empleado)
        Stack<Empleado> MyPilaEmpleado = new Stack<Empleado>();
        public PilaEmpleado()
        {
            InitializeComponent();
        }
        //Método del botón Salir
        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //METODO PARA INGRESAR REGISTROS A LA PILA 

        //Evento click - del botón registrar se crea el objeto 
        //Se manda la información de las cajas de texto para que se guarde en estas propiedades de la clase empleado 
        private void RegistrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empleado myEmpleado = new Empleado();  
            //My empleado en su campo identificación = a lo que se envie en la caja de texto atraves de la propiedad - TEXT
            myEmpleado.Identificacion = txtIdentificacion.Text;
            myEmpleado.Nombre = txtNombre.Text;
            //Se convierte string (parse) a decimal
            myEmpleado.SalarioDia = Decimal.Parse(txtSalarioDia.Text);
            myEmpleado.DiasLaborados = Int32.Parse(txtDiasLaborados.Text);
            //Hacer uso del método para hacer el cálculo y que muestre el cálculo en la caja de texto
            txtDevengado.Text = myEmpleado.CalcularDevengado(myEmpleado.SalarioDia, myEmpleado.DiasLaborados).ToString();
            myEmpleado.Fecha = dtpFecha.Value;

            // Método PUSH Incertar un objeto al principio de la pila (stack) 
            MyPilaEmpleado.Push(myEmpleado);
            //instrución del método DataScurse 
            dgvDatos.DataSource = null;
            //toarray copia la pila en el DataGridView y como es un método lleva parentesis
            dgvDatos.DataSource = MyPilaEmpleado.ToArray();
            // se llama al método limpiar cada que se registren - y que el cursor se fije en la identificación 
            LimpiarControles();
            txtIdentificacion.Focus();
        }

        //Método para eliminar registros de la pila 
        private void EliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Se inicia con un condicional 
            //Se indica que si la pila empleados - METODO (count)-sirve para obtener el número de elementos incluidos en la pila
            // Si la pila , pila empleados cuenta lo que  hay en la pila y si la pila es diferente de 0 
            // que pasa si es 0 , se crea la clase EMPLEADO se guarda en ese objeto lo que se va a eliminar 
            if(MyPilaEmpleado.Count != 0)
            {
                Empleado myEmpleado = new Empleado();
                // MENSAJE AL QUERER ELIMINAR UN REGISTRO DE LA PILA
                if(MessageBox.Show ("Desea eliminar el registro de a pila?","ATENCIÓN", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.Yes)
                {   
                    // METODO POP QUITA Y DEVUELBE EL OBJETO SITUADO AL PRINCIPIO DE LA PILA 
                myEmpleado = MyPilaEmpleado.Pop();txtIdentificacion.Text = myEmpleado.Identificacion;
                txtNombre.Text = myEmpleado.Nombre;
                txtSalarioDia.Text = myEmpleado.SalarioDia.ToString();
                txtDiasLaborados.Text = myEmpleado.DiasLaborados.ToString();
                txtDevengado.Text = myEmpleado.Devengado.ToString();
                dtpFecha.Value = myEmpleado.Fecha;
                dgvDatos.DataSource = MyPilaEmpleado.ToArray();
                MessageBox.Show("Se eliminó el registro que estaba en pila", "ATENCIÓN");
                }
            }
            // QUE PASA SI NO HAY ELEMENTOS 
            else
            {
                MessageBox.Show("No hay registros en pila", "ATENCIÓN");
            }           
            LimpiarControles();
        }

        //Metodo para limpiar cajas de texto
        // no retorna nada porque no van a tener ningun valor y no recibe nada como parametros 
        private void LimpiarControles()
        {
            txtIdentificacion.Clear();
            txtNombre.Clear();
            txtSalarioDia.Clear();
            txtDiasLaborados.Clear();
            txtDevengado.Clear();
        }
    }
}
