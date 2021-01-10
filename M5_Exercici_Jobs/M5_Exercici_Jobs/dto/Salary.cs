using System;
using System.Collections.Generic;
using System.Text;

namespace M5_Exercici_Jobs
{
    public class Salary
    {
        /*
         * Clase donde se guarda toda la información del salario y los tipos permitidos de trabajadores.
         * 
         * retornan los salarios y los tipos permitidos de trabajadores, se usan en las
         * clases Check y asignación de salario del objecto Employee. También se llama en el programa principal
         * para devolver los salarios o modificarlos.
         * 
         */

        // ATRIBUTOS
        // variables de los salario base de cada tipo
        private double salarioBaseManager = 100;
        private double salarioBaseBoss = 200;
        private double salarioBaseEmployee = 50;
        private double salarioBaseVolunteer = 0;
        // tipos de trabajdores posibles
        private string[] tipusPosibles = new string[4] { "Manager", "Boss", "Employee", "Volunteer" };

        // GETTERS Y SETTERS 
        public double _SalarioBaseManager
        {
            get { return salarioBaseManager; }
            set { salarioBaseManager = value; }
        }
        public double _SalarioBaseBoss
        {
            get { return salarioBaseBoss; }
            set { salarioBaseBoss = value; }
        }
        public double _SalarioBaseEmployee
        {
            get { return salarioBaseEmployee; }
            set { salarioBaseEmployee = value; }
        }
        public double _SalarioBaseVolunteer
        {
            get { return salarioBaseVolunteer; }
            set { salarioBaseVolunteer = value; }
        }
        public string[] _TipusPosibles
        {
            get { return tipusPosibles; }
            set { tipusPosibles = value; }
        }

        // CONSTRUCTORES
        public Salary()
        {
            _SalarioBaseManager = salarioBaseManager;
            _SalarioBaseBoss = salarioBaseBoss;
            _SalarioBaseEmployee = salarioBaseEmployee;
            _SalarioBaseVolunteer = salarioBaseVolunteer;
            _TipusPosibles = tipusPosibles;
        }
        public Salary(double salarioBaseManager, double salarioBaseBoss, double salarioBaseEmployee)
        {
            _SalarioBaseManager = salarioBaseManager;
            _SalarioBaseBoss = salarioBaseBoss;
            _SalarioBaseEmployee = salarioBaseEmployee;
            _SalarioBaseVolunteer = salarioBaseVolunteer;
            _TipusPosibles = tipusPosibles;
        }


        //METODOS
        public override string ToString()
        {
            // metodo para printar el salario base. 
            Console.WriteLine("Manager: {0}€", _SalarioBaseManager);
            Console.WriteLine("Boss: {0}€", _SalarioBaseBoss);
            Console.WriteLine("Employee: {0}€", _SalarioBaseEmployee);
            Console.WriteLine("Volunteer: {0}€", _SalarioBaseVolunteer);
            return "";
        }

    }
}
