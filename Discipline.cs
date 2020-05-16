using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public class Discipline
    {
        public Discipline()
        {
            Lectors = new List<Lector>();
        }

        public int DisciplineId { get; set; }

        public string NameOfTheDiscipline { get; set; }

        public int Semestr { get; set; }

        public int Course { get; set; }

        public string Specialty { get; set; }

        public string TypeOfControl { get; set; }

        public int CountOfLections { get; set; }

        public int CountOfLabs { get; set; }

        public ICollection<Lector> Lectors { get; set; }
    }
}
