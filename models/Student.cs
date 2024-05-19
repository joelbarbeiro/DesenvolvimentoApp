using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace iCantine.models
{
    public class Student:Client
    {
        public int studentNumber { get; set; }
        public override string DisplayName => $"{name}, Nº {studentNumber}, Saldo: {Balance}€ (Estudante)";



        public Student()
        {
        }

        public Student(int studentNumber, string name, int nif) : base( name, nif)
        {
            
            this.studentNumber = studentNumber;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
