using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    internal class Student:Client
    {
        public int studentNumber { get; set; }

        public Student()
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
