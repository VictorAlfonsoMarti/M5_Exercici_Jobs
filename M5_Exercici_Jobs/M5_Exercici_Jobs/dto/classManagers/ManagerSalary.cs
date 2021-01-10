using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace M5_Exercici_Jobs
{
    class ManagerSalary : Salary
    {
        /*
         * Clase que contiene sólo métodos del objeto Salary, 
         * 
         * los siguientes metodos se llaman en SoftwareJobs según la opción que se ejecuta 
         * 
         */

        public static void showSalary(Salary salario)
        {
            // metode per mostrar salarios,
            //utilitza el metodo ToPrint() en la clase Salary per printar-los.

            salario.ToString();

        }
        public static Salary modifySalary(Salary salario)
        {
            /*
             *  metodo que entrado el objeto Salary, pregunta qué salario (de los disponibles) quiere modificar
             *  y la cantidad indicada. 
             *  primero printa los salarios
             */

            showSalary(salario); //printamos salario
            Console.WriteLine();
            string respuesta;
            double nuevoSalario = 0; // inicializamos nuevo salario a 0
            respuestaErronea: //goto por si printan opcion erronea
            Console.WriteLine("¿Qué salário qúieres modificar? Manager || Boss || Employee || salir");
            respuesta = Console.ReadLine();
            if (respuesta.Equals("Manager") || respuesta.Equals("Boss") || respuesta.Equals("Employee")) // si entran un tipo correcto
            {
                numeroErroneo:
                Console.WriteLine("Introduce el nuevo salario: "); // pedimos nuevo salario
                try
                {
                    nuevoSalario = Convert.ToDouble(Console.ReadLine()); //intentamos pasar a double, por si no es un numero
                }
                catch (System.FormatException ex) //si no es un double
                {
                    Console.WriteLine("ERROR: Indica un número entero positivo");
                    goto numeroErroneo; // pedimos otra vez que introduzca salario
                }
            }
            
            switch (respuesta) //segun respuesta inicial, comparamos y editamos salario
            {
                case "Manager":
                    salario._SalarioBaseManager = nuevoSalario;
                    break;
                case "Boss":
                    salario._SalarioBaseBoss = nuevoSalario;
                    break;
                case "Employee":
                    salario._SalarioBaseEmployee = nuevoSalario;
                    break;
                case "salir":
                    goto salir;
                default:
                    Console.WriteLine("ERROR: {0} no está entre los salarios disponibles", respuesta);
                    goto respuestaErronea; // si no esta entre los tipos posibles ni salir, printamos error y volvemos a pedir entrada
            }
            modificarOtro:
            Console.WriteLine("¿Quieres modificar otro salario? si || no"); // preguntamos si quieren modificar otro
            respuesta = Console.ReadLine();
            switch (respuesta)
            {
                case "si":
                    goto respuestaErronea; // volvemos al inicio del programa
                    break;
                case "no":
                    goto salir; // vamos al final
                    break;
                default:
                    Console.WriteLine("ERROR: escribe 'si' o 'no'");
                    goto modificarOtro; // error y volvemos a pedir si quieren modificar otro
            }
            salir:
            return salario; // devolvemos objeto Salary con salarios cambiados
        }
    }
}
