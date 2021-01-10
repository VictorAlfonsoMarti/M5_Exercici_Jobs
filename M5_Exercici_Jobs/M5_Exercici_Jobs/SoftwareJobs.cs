using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace M5_Exercici_Jobs
{
    public class SoftwareJobs
    {
        /*
         *  Clase principal del programa: 
         *  
         *  Pregunta que es vol fer: cambiar salario base, ver el salario base, mostrar treballadors, afegir treballadors, mostar ajudes.
         * 
         *  Tiene como atributos los salarios base segun el tipo de empleado y los tipos de empleado posibles
         * 
         */

        public static void SoftwareJobsStart()
        {
            // Metodo principal del programa. Es el metodo que se ejecuta en el Main 

            // EJECUTAR SIEMPRE PRIMERO cargamos la lista de objetos Employee y los salarios que tenemos guardada en el archivo employee.xml y salary.xml
            List<Employee> lista = new List<Employee>(); // creamos la lista employe
            lista = Connexion.ReadEmployeeFromXmlFile(Connexion.getPathEmployee()); // asignamos el contenido de empoliyee.xml a la lista creada
            Console.OutputEncoding = Encoding.UTF8; // declaramos el utf8 en los Console.Write para los simbolos de €
            Salary salario = new Salary(); // creamos nuevo objeto salario
            salario = Connexion.ReadSalaryFromXmlFile(Connexion.getPathSalary()); // le asignamos de contenido el objeto guardado en el archivo salary.xml
            // EJECUTAR HASTA AQUÍ SIEMPRE PRIMERO

        Inicio:
            Console.Clear();
            Console.WriteLine("---- BIENVENIDO AL PROGRAMA SOFTWAREJOBS ---");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Qué quieres hacer?");
            Console.WriteLine();
            Console.WriteLine("   Opción 1: ver salario base");
            Console.WriteLine("   Opción 2: cambiar salario base");
            Console.WriteLine("   Opción 3: mostrar trabajadores");
            Console.WriteLine("   Opción 4: añadir trabajadores");
            Console.WriteLine("   Opción 5: eliminar trabajadores");
            Console.WriteLine("   Opción 6: dar ayuda gubernamental a los voluntarios");
            Console.WriteLine("   Opción 7: dar un bono del 10% anual a toda la empresa(excepto voluntarios)");
            Console.WriteLine("   Opción 8: cerrar el programa");
            Console.WriteLine();
            IntroducirOpcion:
            Console.WriteLine("Indica el número de la opción que quieres: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                /*
                 * Según las opciones printadas por pantalla y la opción indicada por el usuario,
                 * ejecutamos diferentes metodos. tras los casos en que es posible que se haya 
                 * modificado la información de los empleados o salarios, guardamos los datos a 
                 * los archivos xml y volvemos a cargarlos, por si el programa se cierra de forma inesperada.
                 */
                case "1":
                    Console.Clear();
                    Console.WriteLine("--- SALARIO BASE ---");
                    Console.WriteLine();
                    Console.WriteLine();
                    ManagerSalary.showSalary(salario);
                    Console.WriteLine();
                    Console.WriteLine("Pulse ENTER para volver al menú principal...");
                    Console.ReadLine();
                    goto Inicio;
                case "2":
                    Console.Clear();
                    Console.WriteLine("--- MODIFICAR SALARIO BASE ---");
                    Console.WriteLine();
                    Console.WriteLine();
                    ManagerSalary.modifySalary(salario);
                    //guardamos los datos y los volvemos a cargar sobreescribiendo salario
                    Connexion.WriteSalaryToXmlFile(Connexion.getPathSalary(), salario);
                    salario = Connexion.ReadSalaryFromXmlFile(Connexion.getPathSalary());
                    goto Inicio;
                case "3":
                    Console.Clear();
                    Console.WriteLine("--- LISTA DE EMPLEADOS ---");
                    Console.WriteLine();
                    Console.WriteLine();
                    ManagerEmployee.showEmployee(lista);
                    Console.WriteLine();
                    Console.WriteLine("Pulse ENTER para volver al menú principal...");
                    Console.ReadLine();
                    goto Inicio;
                case "4":
                    Console.Clear();
                    Console.WriteLine("--- AÑADIR EMPLEADO ---");
                    Console.WriteLine();
                    Console.WriteLine();
                    ManagerEmployee.addEmployee(lista);
                    // guardamos los datos y los volvemos a cargar sobreescribiendo lista
                    Connexion.WriteEmployeeToXmlFile(Connexion.getPathEmployee(), lista);
                    lista = Connexion.ReadEmployeeFromXmlFile(Connexion.getPathEmployee());
                    goto Inicio;
                case "5":
                    Console.Clear();
                    Console.WriteLine("--- BORRAR EMPLEADO ---");
                    Console.WriteLine();
                    Console.WriteLine();
                    ManagerEmployee.removeEmployee(lista);
                    // guardamos los datos y los volvemos a cargar sobreescribiendo lista
                    Connexion.WriteEmployeeToXmlFile(Connexion.getPathEmployee(), lista);
                    lista = Connexion.ReadEmployeeFromXmlFile(Connexion.getPathEmployee());
                    goto Inicio;
                case "6":
                    // MILESTONE 3 - borrar esto tras implementar
                    goto Inicio;
                case "7":
                    // MILESTONE 3 - borrar esto tras implementar
                    goto Inicio;
                case "8":
                    Console.WriteLine("GRACIAS POR UTILIZAR SOFTAREJOBS");
                    break;
                default:
                    Console.WriteLine("ERROR: NÚMERO NO RECONOCIDO");
                    Console.WriteLine("Por favor, introduzca una opción válida");
                    goto IntroducirOpcion;
            }

            // EJECUTAR SIEMPRE ÚLTIMO guardamos la lista de Employee y el Salary en un archivo xml
            Connexion.WriteEmployeeToXmlFile(Connexion.getPathEmployee(), lista);
            Connexion.WriteSalaryToXmlFile(Connexion.getPathSalary(), salario);
            // EJECUTAR HASTA AQUÍ SIEMPRE ÚLTIMO
        }

    }
}
