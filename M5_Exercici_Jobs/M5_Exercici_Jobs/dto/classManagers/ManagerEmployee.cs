using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace M5_Exercici_Jobs
{
    class ManagerEmployee : Connexion
    {
        /*
         * Clase que contiene los metodos para añadir, modificar, eliminar y mostrar el objeto Employee
         * 
         * Usa la clase abstracta Connexion para buscar la ruta del archivo employee.xml, que es donde se guardan
         * los objetos Employee utilizados en los metodos de esta clase
         * 
         */

        public static void showEmployee(List<Employee> lista)
        {
            // metode per mostrar treballadors,
            //utilitza el metodo toPrint() en la clase Employee per printar-los.

            foreach (Employee x in lista)
            {
                x.ToString();
            }
        }

        public static List<Employee> addEmployee(List<Employee> lista)
        {
            // metode per crear un nou Employeer i afegir-lo a la llista pasada per parametre
            
            // variables para crear objeto Employee
            string nom;
            string tipusTreballador;
            Boolean correcto = false;
            string esCorrecto;
            

            while (correcto == false) // mientras no indiquemos por pantalla que el trabajador es correcto
            {
                AñadirNuevo: // si queremos añadir un usuario nuevo, volvemos aqui
                Console.WriteLine("Añadir un nuevo empleado:");
                Console.WriteLine("Escribe el nombre:");
                nom = Console.ReadLine();
                Console.WriteLine("Escribe el tipo de empleado: Manager || Boss || Employee || Volunteer");
                tipusTreballador = Console.ReadLine();

                Employee empleadoNuevo = new Employee(lista.Count+1,nom, tipusTreballador); // creamos el objeto con las variables que nos han dado
                
                // mostramos el empleado por pantalla
                Console.WriteLine("Nuevo empleado creado: ");
                empleadoNuevo.ToString();
                
                // preguntamos si es correcto, si es, lo añadimos al archivo employee.txt, si no, volvemos al principio del while
                Console.WriteLine();
                Console.WriteLine("Es correcto? si || no");
                siNoErronea1: // si printan algo que no es 'si' o 'no' al decir si es correcto el empleado nos devuelve a esta linea 
                esCorrecto = Console.ReadLine();

                if (esCorrecto == "si") // si nos printan si
                {
                    // llamamos a la funcion para serializar el objeto Employee e1 en el fichero employee.xml
                    lista.Add(empleadoNuevo); // añadimos el objeto Employee a la lista de empleados pasada por parametro

                    // preguntamos si quiere añadir otro empleado
                    Console.WriteLine("Empleado creado, quiere crear otro empleado? si || no");
                    siNoErronea2: // si printa algo que no es 'si' o 'no' al decir si quiere crear otro empleado
                    esCorrecto = Console.ReadLine();

                    if (esCorrecto == "si")
                    {
                        goto AñadirNuevo; // vamos al principio del while
                    }
                    else if (esCorrecto != "no") //si no es si, ni no, ha introducido algo erroneo
                    {
                        Console.WriteLine("ERROR: Por favor, escribe 'si' o 'no'");
                        goto siNoErronea2; // vamos antes de los if donde nos lee otra vez por pantalla
                    }
                    else
                    {
                        correcto = true; // indicamos que todo es correcto para salir del while
                    }
                }
                else if (esCorrecto != "no") // si es diferente a no, y tambien a si - han escrito algo erroneo
                {
                    Console.WriteLine("ERROR: Por favor, escribe 'si' o 'no'");
                    goto siNoErronea1; // vamos antes de los if donde nos lee otra vez por pantalla
                }
                else // printamos borrando y pedimos que quiere hacer, crear otro nuevo o salir. si es salir, no haremos nada y si quiere añadir, volvemos al principio 
                {
                    Console.WriteLine("Borrando nuevo empleado creado... Quiere añadir un nuevo empleado o salir? añadir || salir");
                    añadirSalirErroneo: // si printan algo que no sea 'añadir' o salir, volvemos aqui
                    esCorrecto = Console.ReadLine();
                    
                    if (esCorrecto == "añadir")
                    {
                        goto AñadirNuevo; // vamos al principio del while para añadir otro usuario.
                    }
                    else if (esCorrecto != "salir")
                    {
                        Console.WriteLine("ERROR: Por favor, escribe 'añadir' o 'salir'");
                        goto añadirSalirErroneo;
                    }
                    else
                    {
                        Console.WriteLine("Saliendo de añadir un empleado");
                        correcto = true; // asignamos true para salir del while sin hacer ningun cambio.
                    }
                }
            }
            // devolvemos la lista de empleados
            return lista;
        }

        public static void removeEmployee(List<Employee> lista)
        {
            // busca coincidencia del id pasat per parametre en la llista pasada per parametre i els borra.
            string id = "";

            principioBorrar: // si borramos un empleado, volvemos aquí para printar la lista de empleados y ver que se ha borrado
            Console.WriteLine("Lista de trabajadores:");
            Console.WriteLine();
            ManagerEmployee.showEmployee(lista); //mostramos la lista de trabajadores
            Console.WriteLine();
            idErroneo: //punto de retorno por si el id es erroneo
            Console.WriteLine("Indica el ID del trabajador que quieres eliminiar o escribe 'salir':");
            id = Console.ReadLine(); //guardamos el id introducido

            if (id != "salir") //si no quieren salir
            {
                try
                {
                    for (int i = 0; i < lista.Count; i++) //recorremos la lista de empleados
                    {
                        if (lista[i]._ID.Equals(Convert.ToInt32(id))) //si encontramos coincidencia || PUNTO DEL TRY, COGE LA EXEPCION DE UNABLE CONVERT TO INT
                        {
                            entradaErronea: //punto de retorno por si no han escrito si o no en la pregunta de estas seguro
                            Console.WriteLine("Emplado a eliminar: {0}", lista[i].ToString()); //mostramos empleado
                            Console.WriteLine("¿Está seguro que quiere borrarlo? si || no"); 
                            string seguro = Console.ReadLine(); 
                            if (seguro == "si") //si han puesto que estan seguros
                            {
                                lista.Remove(lista[i]); //borramos empleado de la lista
                                Console.WriteLine("Empleado Borrado");
                                goto principioBorrar;
                            }
                            else if (seguro != "no") //si no han puesto que si, i tampoco no 
                            {
                                Console.WriteLine("ERROR: Entrada no reconocida."); 
                                goto entradaErronea; // volvemos a pedir que nos digan si estan seguros
                            }
                            else // si dicen que no estan seguros
                            {
                                Console.WriteLine("Deseleccionando empleado");
                                goto idErroneo; //volvemos a pedir que nos digan un id o que salgamos
                            }
                        }

                    }
                    // si no existe el id introducido ejecutará este codigo al no haber entrado en el if ni haber salido por ningut goto;
                        Console.WriteLine("ERROR: ID NO ENCONTRADO");
                        goto idErroneo;// volvemos a pedir otro id
                }
                catch (System.FormatException ex)
                {
                    Console.WriteLine("ERROR: ID NO RECONOCIDA");
                    goto idErroneo;
                }
            }
        }
    }
}
