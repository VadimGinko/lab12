using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public class Lector
    {
        public int LectorId { get; set; }

        public string Name { get; set; }
  
        public string Department { get; set; }

        public int Auditorium { get; set; }

        public int? DisciplineDisciplineId { get; set; }
        public Discipline Dist { get; set; }
    }
}
