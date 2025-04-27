using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPKPApp.Model
{
    public class StudentWork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfDefense { get; set; }
        public TypeOfStudentWork TypeOfWork {  get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
    }
}
