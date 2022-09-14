using System;

namespace PilaEmpleados
{
    // Se crea clase " empleado " con propiedades auto implementadas - get y set
    public class Empleado
    {
        // método para realizar el cálculo del devengado - Producto del salario día x los días laborados 
        // toda la información se va a registrar y mostrarse en el DataGridView
        public string Identificacion { get; set;}
        public string Nombre { get; set;}
        public decimal SalarioDia { get; set;}
        public int DiasLaborados { get; set;}
        //public decimal Devengado { get { return SalarioDia * DiasLaborados;}}
        public decimal Devengado { get; set; }
        public DateTime Fecha { get; set;}

        // se crea el método de ámbito público que va a retornar un valor de tipo decimal "CalcularDevengado"
        public decimal CalcularDevengado (decimal salarioDia, int diasTrabajados)
            //Se reciben como parametros el salario día y los días laborados
        {
           //"operación"
            Devengado = (salarioDia * diasTrabajados);
            // regresa el devengado 
            return Devengado;
        }      
            
            
      }
}
