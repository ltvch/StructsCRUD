using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOnSructurs
{
    struct Student
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Bithday { get; set; }
        public int ContractNumber { get; set; }
        public int[] Grade { get; set; }

    }
    
    struct Group
    {
        public Student[] Students { get; set; }
        public string NumGroup { get; set; }
        public string Branch { get; set; }
    }
}
