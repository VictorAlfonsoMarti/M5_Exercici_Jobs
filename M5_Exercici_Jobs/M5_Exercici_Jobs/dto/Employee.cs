using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace M5_Exercici_Jobs
{
    [Serializable]
    public class Employee
    {
        /*  Clase Employee utilizadad como objeto principal del programa SoftwareJobs
         *  cada objeto es un trabajador, que se añaden, eliminan, editan y guardan del
         *  archivo employee.txt en la carpeta data. 
         * 
         *  El objeto nos asigna:
         *  - nom: nombre del objeto 
         *  - tipusTreballador: (entre las opciones: Manager, Boss, Employee, Volunteer; usa un metodo para revisarlo)
         *  - salariBase (salario del trabajador, luego se usan metodos para modificarlo segun antigüedad y bonos)
         * 
         */

        // ATRIBUTOS
        private int id;
        private string nom;
        private string tipusTreballador;
        private double salariBase;
        private EmployeeType experiencia;

        //GETTERS Y SETTERS
        public int _ID
        {
            get { return id; }
            set { id = value; }
        }
        public string _Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string _TipusTreballador
        {
            get { return tipusTreballador; }
            set { tipusTreballador = value; }
        }
        public double _SalariBase
        {
            get { return salariBase; }
            set { salariBase = value; }
        }

        public EmployeeType _Experiencia
        {
            get { return experiencia; }
            set { experiencia = value; }
        }

        // CONSTRUCTOR
        public Employee(int id, string nom, string tipusTreballador, string experiencia)
        {
            // generem el objecte comrpobant amb els metodes de check cada una de les variables
            _ID = id; // per id agafem la llargada de la llista de objectes Employee +1, la pasem al metode per crear el objecte Employee
            _Nom = Check.checkName(nom);
            _TipusTreballador = Check.checkEmployeeType(tipusTreballador);
            _SalariBase = Check.checkBaseSalary(_TipusTreballador, experiencia); 
        }
        public Employee(int id, string nom, string tipusTreballador)
        {
            // generem el objecte comrpobant amb els metodes de check cada una de les variables
            _ID = id; // per id agafem la llargada de la llista de objectes Employee +1, la pasem al metode per crear el objecte Employee
            _Nom = Check.checkName(nom);
            _TipusTreballador = Check.checkEmployeeType(tipusTreballador);
            _SalariBase = Check.checkBaseSalary(_TipusTreballador, "");
        }

        public Employee()
        {
            // constructor buit utilitzat en la lectura / escriptura del fitxer .xml
            // metodes: ManagerEmployee.ReadFromXmlFile() i MangerEmployee.WriteToXmlFile()
        }

        //METODES
        public override string ToString()
        {
            // printa por pantalla la infomacion del objeto Employee asignado
            Console.WriteLine("ID:{0} || {1} {2}, salario: {3}",_ID, _TipusTreballador, _Nom, _SalariBase);
            return "";
        }
    }
}
