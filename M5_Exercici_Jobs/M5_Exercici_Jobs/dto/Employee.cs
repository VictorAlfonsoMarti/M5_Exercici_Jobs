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
        private double salariBase_net;
        private double salariBase_anual;
        private double salariBase_anual_net;
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
        public double _SalariBase_net
        {
            get { return salariBase_net; }
            set { salariBase_net = value; }
        }
        public double _SalariBase_anual
        {
            get { return salariBase_anual; }
            set { salariBase_anual = value; }
        }
        public double _SalariBase_anual_net
        {
            get { return salariBase_anual_net; }
            set { salariBase_anual_net = value; }
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
            if (experiencia == "Senior") { _SalariBase_net = _SalariBase * 0.76; _SalariBase_anual = _SalariBase * 14; _SalariBase_anual_net = _SalariBase_anual * 0.76; }
            if (experiencia == "Mid") { _SalariBase_net = _SalariBase * 0.85; _SalariBase_anual = _SalariBase * 14; _SalariBase_anual_net = _SalariBase_anual * 0.85; }
            if (experiencia == "Junior") { _SalariBase_net = _SalariBase * 0.98; _SalariBase_anual = _SalariBase * 14; _SalariBase_anual_net = _SalariBase_anual * 0.98; }
            _Experiencia = new EmployeeType(experiencia);
        }
        public Employee(int id, string nom, string tipusTreballador)
        {
            // generem el objecte comrpobant amb els metodes de check cada una de les variables
            _ID = id; // per id agafem la llargada de la llista de objectes Employee +1, la pasem al metode per crear el objecte Employee
            _Nom = Check.checkName(nom);
            _TipusTreballador = Check.checkEmployeeType(tipusTreballador);
            _SalariBase = Check.checkBaseSalary(_TipusTreballador, "");
            if (tipusTreballador == "Boss") { _SalariBase_net = _SalariBase * 0.68; _SalariBase_anual = _SalariBase * 14; _SalariBase_anual_net = _SalariBase_anual * 0.68; }
            if (tipusTreballador == "Manager") { _SalariBase_net = _SalariBase * 0.74; _SalariBase_anual = _SalariBase * 14; _SalariBase_anual_net = _SalariBase_anual * 0.74; }
            if (tipusTreballador == "Volunteer") { _SalariBase_net = _SalariBase * 1; _SalariBase_anual = _SalariBase * 14; _SalariBase_anual_net = _SalariBase_anual * 1; }
            _Experiencia = null;
            
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
            if (this.experiencia == null)
            {
                // Si no es un Employee, lo muestra sin la experiencia
                Console.WriteLine("ID:{0} || {1} {2}, salario: {3:0.00}", _ID, _TipusTreballador, _Nom, _SalariBase);
                Console.WriteLine("(Salario mensual neto: {0:0.00}. Salario anual bruto: {1:0.00}. Salario anual neto: {2:0.00}", _SalariBase_net, _SalariBase_anual, _SalariBase_anual_net);
                Console.WriteLine();
            }
            else
            {
                // Si es un Employee, lo muestra con la experiencia
                Console.WriteLine("ID:{0} || {1} {4} {2}, salario: {3:0.00}", _ID, _TipusTreballador, _Nom, _SalariBase, this.experiencia.ToString());
                Console.WriteLine("(Salario mensual neto: {0:0.00}. Salario anual bruto: {1:0.00}. Salario anual neto: {2:0.00}", _SalariBase_net, _SalariBase_anual, _SalariBase_anual_net);
                Console.WriteLine();
            }
            
            return "";
        }
        
    }
}
