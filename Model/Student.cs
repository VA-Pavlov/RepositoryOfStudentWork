using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPKPApp.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string SecondName { get; set; }
        public Group GroupNumber { get; set; }
        public string FullName { 
            get
            {
                return $"{Surname} {FirstName[0]}.{SecondName[0]}.";
            } 
        }
    }
}
