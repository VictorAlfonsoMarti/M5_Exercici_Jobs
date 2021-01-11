using System;
using System.Collections.Generic;
using System.Text;

namespace M5_Exercici_Jobs
{
    public class EmployeeType : Employee
    {
        private string experiencia;
        private int reduccio;

        public EmployeeType(string experiencia)
        {
            this.experiencia = experiencia;
            if (this.experiencia == "Junior")
            {
                this.reduccio = 15;
            }
            else if (this.experiencia == "Mid")
            {
                this.reduccio = 10;
            }
            else
            {
                this.reduccio = 5;
            }
        }
        public EmployeeType() { }

        public string Experiencia { get => experiencia; set => experiencia = value; }
        public int Reduccio { get => reduccio; }

        public override string ToString()
        {
            return Experiencia;
        }


    }
}
