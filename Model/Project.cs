using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPKPApp.Model
{
    class Project
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public int Type { get; set; }
        public int ProjectFile { get; set; }
        public int UploadDate { get; set; }
        public int Status { get; set; }
        public int Grade { get; set; }
        public int Student { get; set; }
        public int Teacher { get; set; }
    }
}
