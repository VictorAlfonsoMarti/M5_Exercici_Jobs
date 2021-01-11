﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace M5_Exercici_Jobs
{
    public class Check
    {
        /*
         *  Clase donde se encuentran los comprobantes de las entradas de linea.
         *  Comprueba los nombres, los salarios y que el tipo de empleado sea correcto
         * 
         *  SÓLO CONTIENE MÉTODOS 
         * 
         */

        public static string checkName(string nombre)
        {
            // Comprobador de que el nombre no esté vacio ni tenga números ni simbolos.

            var permitido = new Regex("^[a-zA-Z ]*$"); // variable para revisar que no tenga simbolos especiales ni numeros
            string nombreCorrecto = nombre;

            while ((nombreCorrecto.Length <= 0) || ((permitido.IsMatch(nombreCorrecto)) == false)) //si esta vacio y si encuentra algun caracter que no este en el string permitido
            {
                Console.Clear();
                Console.WriteLine("ERROR: El nombre {0} no puede estar vacio o contener números ni simbolos", nombreCorrecto);
                Console.WriteLine("Introduzca otra vez el nombre: ");
                nombreCorrecto = Console.ReadLine();
            }
            return nombreCorrecto;
        }

        public static string checkEmployeeType(string tipusTreballador)
        {
            // Comprobador para que el tipo de empleado insertado esté entre las opciones posibles

            Salary salarios = new Salary(); // llamamos a la clase salarios
            string[] tipusPosibles = salarios._TipusPosibles; // coge un array con los tipos posibles de trabajador de la clase principal
            string treballador = tipusTreballador; // asignamos el string para hacer comprobaciones y modificaciones
            while (true) // bucle infinito para ejecutar la comprobación hasta que sea correcta y salga del método
            {
                for (int x = 0; x < tipusPosibles.Length; x++) // recorremos el array antiguitatPosible
                {
                    if (tipusPosibles[x].Equals(treballador)) //si el string tipusTreballador se encuentra dentro de los posibles
                    {
                        return treballador; // devolvemos el string antiguitat
                    }
                }
                // mientras no se encuentre (entrada errónea) le pedimos una nueva entrada y volvemos a ejecutar la comprobación
                Console.Clear();
                Console.WriteLine("ERROR: - TIPO DE EMPLEADO ERRÓNEO - ");
                Console.WriteLine("{0} no se encuentra entre los tipos habilitados de empleado.", treballador);
                Console.WriteLine("Introduzca otra vez el tipo de trabajador entre las siguientes opciones: ");
                Console.WriteLine("Manager || Boss || Employee || Volunteer");
                treballador = Console.ReadLine();
            }
        }


        public static double checkBaseSalary(string tipoTrabajador, string experiencia)
        {
            // Comprobador para que el salario base introducido esté dentro del rango y no sea un string ni contenga simbolos
            /*
             * También modifica los salarios base dependiendo del tipo de trabajador: 
             * - Manager: cobren un 10% més del seu salari mensual.
             * - Boss: cobren un 50% més del seu salari mensual.
             * - Employee: cobren el sou mensual aplicant una reducció del 15%
             * - Volunteer: no cobren
             */

            // ASIGNAMOS SALARIO
            double salarioFinal = 0; // inicializamos el salario a 0 y segun el caso modificamos
            Salary salario = Connexion.ReadSalaryFromXmlFile(Connexion.getPathSalary()); // le asignamos de contenido el objeto guardado en el archivo salary.xml


            switch (tipoTrabajador)
            {
                case "Manager":
                    salarioFinal = salario._SalarioBaseManager;
                    salarioFinal = salarioFinal + ((10 * salario._SalarioBaseManager) / 100); // añadimos el bono del 10%
                    break;
                case "Boss":
                    salarioFinal = salario._SalarioBaseBoss;
                    salarioFinal = salarioFinal + ((50 * salario._SalarioBaseBoss) / 100); // añadimos el bono del 50%
                    break;
                case "Employee":
                    salarioFinal = salario._SalarioBaseEmployee;
                    salarioFinal = salarioFinal - ((15 * salario._SalarioBaseEmployee) / 100); // restamos la reducción del 15%
                    switch (experiencia)
                    {
                        case "Junior":
                            salarioFinal = salarioFinal + ((5 * salario._SalarioBaseBoss) / 100);
                            break;
                        case "Mid":
                            salarioFinal = salarioFinal + ((10 * salario._SalarioBaseBoss) / 100);
                            break;
                        case "Senior":
                            salarioFinal = salarioFinal + ((15 * salario._SalarioBaseBoss) / 100);
                            break;
                    }
                    break;
                case "Volunteer":
                    salarioFinal = salario._SalarioBaseVolunteer; // asignamos el salario del Voluntario, que tiene que ser 0
                    break;

            }
            SalarioInvalido:
            Console.WriteLine("El salario del trabajador sera de {0}. Quieres modificarlo?", salarioFinal);
            string modificar = Console.ReadLine();
            if (modificar == "si")
            {
                Console.WriteLine("Introduce el nuevo salario");
                salarioFinal = Convert.ToDouble(Console.ReadLine());
            }
            switch (tipoTrabajador)
            {
                case "Manager":
                    if (salarioFinal < 3000)
                    {
                        Console.WriteLine("Salario Invalido.");
                        goto SalarioInvalido;
                    }
                    else if (salarioFinal > 5000)
                    {
                        Console.WriteLine("Salario Invalido.");
                        goto SalarioInvalido;
                    }
                    break;
                case "Boss":
                    if (salarioFinal < 8000)
                    {
                        Console.WriteLine("Salario Invalido.");
                        goto SalarioInvalido;
                    }
                    break;
                case "Employee":
                    switch (experiencia)
                    {
                        case "Senior":
                            if (salarioFinal < 2700)
                            {
                                Console.WriteLine("Salario Invalido.");
                                goto SalarioInvalido;
                            }
                            else if (salarioFinal > 4000)
                            {
                                Console.WriteLine("Salario Invalido.");
                                goto SalarioInvalido;
                            }
                            break;
                        case "Mid":
                            if (salarioFinal < 1800)
                            {
                                Console.WriteLine("Salario Invalido.");
                                goto SalarioInvalido;
                            }
                            else if (salarioFinal > 2500)
                            {
                                Console.WriteLine("Salario Invalido.");
                                goto SalarioInvalido;
                            }
                            break;
                        case "Junior":
                            if (salarioFinal < 900)
                            {
                                Console.WriteLine("Salario Invalido.");
                                goto SalarioInvalido;
                            }
                            else if (salarioFinal > 1600)
                            {
                                Console.WriteLine("Salario Invalido.");
                                goto SalarioInvalido;
                            }
                            break;
                    }
                    break;
                case "Volunteer":
                    if (salarioFinal > 0)
                    {
                        Console.WriteLine("Salario Invalido.");
                        goto SalarioInvalido;
                    }

                    break;
            }


            /*FALTA AÑADIR COMPROBADOR MILESTONE 2
             * 
             *  FALTA AÑADIR COMPROBADOR MILESTONE 2
             * FALTA AÑADIR COMPROBADOR MILESTONE 2
             * FALTA AÑADIR COMPROBADOR MILESTONE 2
             * FALTA AÑADIR COMPROBADOR MILESTONE 2
             * FALTA AÑADIR COMPROBADOR MILESTONE 2
             * FALTA AÑADIR COMPROBADOR MILESTONE 2
             * FALTA AÑADIR COMPROBADOR MILESTONE 2
             * FALTA AÑADIR COMPROBADOR MILESTONE 2
             * FALTA AÑADIR COMPROBADOR MILESTONE 2
             * FALTA AÑADIR COMPROBADOR MILESTONE 2
             * FALTA AÑADIR COMPROBADOR MILESTONE 2
             * 
             * */








            return salarioFinal;
        }
    }
}
