using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace M5_Exercici_Jobs
{
    abstract class Connexion
    {
        /*
         *  clase abstracta donde guardamos todos los métodos que interaccionan con los ficheros de la carpeta data.
         *  utilizamos estos métodos en la clase principal SoftwareJobs para cargar y guardar los datos cada vez que
         *  hacemos algun cambio y al inicio y final del programa.
         * 
         * 
         */
        public static string getPathEmployee()
        {
            /* devuelve la ruta del archivo employee.xml, donde se encuentran los objetos empleados guardados
             * 
             * metodo para llamar a la ruta absoluta del archivo cogiendo la ruta actual, la que sea, y buscando el archivo en el directorio
             * 
             */
            string path = Directory.GetCurrentDirectory(); // cogemos la ruta actual del archivo
            string newPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\data\employee.xml")); //volvemos atras 3 veces y entramos en la carpeta data

            return newPath; //devolvemos un string con la ruta exacta
        }
        public static string getPathSalary()
        {
            /* devuelve la ruta del archivo salary.xml, donde se encuentran el objeto salary guardados
             * 
             * metodo para llamar a la ruta absoluta del archivo cogiendo la ruta actual, la que sea, y buscando el archivo en el directorio
             * 
             */
            string path = Directory.GetCurrentDirectory(); // cogemos la ruta actual del archivo
            string newPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\data\salary.xml")); //volvemos atras 3 veces y entramos en la carpeta data

            return newPath; //devolvemos un string con la ruta exacta
        }

        public static void WriteSalaryToXmlFile(string filePath, Salary objectToWrite, bool append = false)
        {
            /*
             * metode per guardar el contingut de un objecte Salary pasada per parametre en un fitxer .xml
             * aquest métode es l'ultim que s'executa del programa, per guardar tots els salaris que tenim
             * en aquell moment al objecte principal Salary.
             * 
             *
             * codi per trucar aquest parametre:
             * // Connexion.WriteSalaryToXmlFile(Connexion.getPath(), Salary);
             */

            TextWriter writer = null; //inicialitzem el metode TextWriter per escriure al fitxer
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Salary)); // inicialitzem el serialitzador de XML
                //asignem el fitxer que es troba a filePath i l'hi diem append=false(sobrescriu tot el contingut), si fos true, ajuntaria al final del arxiu.
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite); //serialitzem la llista i la escribim al fitxer
            }
            finally
            {
                if (writer != null)
                    writer.Close(); //per acabar tanquem el fitxer
            }
        }
        public static Salary ReadSalaryFromXmlFile(string filePath)
        {
            /*
             * metode per llegir el contingut d'un fitxer xml i guardar el contingut en un objecte
             * aquest métode es  el primer que s'execute al iniciar el programa, despres del metode que inicialitza SoftwareJobs 
             * 
             *
             * codi per trucar aquest parametre:
             * // Connexion.ReadSalaryFromXmlFile(Connexion.getPath());
             */
            TextReader reader = null; // inicialitzem el objecte TextReader
            try
            {
                //Inicialitzem el objecte XmlSerializer de tipus list<Employee> per convertir la llista en info xml
                XmlSerializer serializer = new XmlSerializer(typeof(Salary));
                // iniciem la lectura del archiu pasat per parametre
                reader = new StreamReader(filePath);
                // asignem el contingut del archiu "desserialitzantlo" en una llista  de Employee
                Salary salarios = (Salary)serializer.Deserialize(reader);
                return salarios; //retornem la llista
            }
            finally
            {
                if (reader != null)
                    reader.Close(); // tanquem el archiu
            }
        }
        public static void WriteEmployeeToXmlFile(string filePath, List<Employee> objectToWrite, bool append = false)
        {
            /*
             * metode per guardar el contingut de una llista Employee pasada per parametre en un fitxer .xml
             * aquest métode es l'ultim que s'executa del programa, per guardar tots els empleats que tenim
             * en aquell moment a la llista principal de Employee.
             * 
             *
             * codi per trucar aquest parametre:
             * // Connexion.WriteEmployeeToXmlFile(Connexion.getPath(), List<Employee>);
             */

            TextWriter writer = null; //inicialitzem el metode TextWriter per escriure al fitxer
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>)); // inicialitzem el serialitzador de XML
                //asignem el fitxer que es troba a filePath i l'hi diem append=false(sobrescriu tot el contingut), si fos true, ajuntaria al final del arxiu.
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite); //serialitzem la llista i la escribim al fitxer
            }
            finally
            {
                if (writer != null)
                    writer.Close(); //per acabar tanquem el fitxer
            }
        }
        public static List<Employee> ReadEmployeeFromXmlFile(string filePath)
        {
            /*
             * metode per llegir el contingut d'un fitxer xml i guardar el contingut en una llista de objectes
             * aquest métode es  el primer que s'execute al iniciar el programa, despres del metode que inicialitza SoftwareJobs 
             * 
             *
             * codi per trucar aquest parametre:
             * // Connexion.ReadEmployeeFromXmlFile(Connexion.getPath());
             */
            TextReader reader = null; // inicialitzem el objecte TextReader
            try
            {
                //Inicialitzem el objecte XmlSerializer de tipus list<Employee> per convertir la llista en info xml
                XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
                // iniciem la lectura del archiu pasat per parametre
                reader = new StreamReader(filePath);
                // asignem el contingut del archiu "desserialitzantlo" en una llista  de Employee
                List<Employee> lista = (List<Employee>)serializer.Deserialize(reader);
                return lista; //retornem la llista
            }
            finally
            {
                if (reader != null)
                    reader.Close(); // tanquem el archiu
            }
        }
    }
}
