using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    public class Student:Client
    {
        public int studentNumber { get; set; }
       

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
