using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace lab12
{
    class DisciplineCRUD
    {
        public static void AddDiscipline(DisciplineContext db, Discipline spam)
        {
            db.Disciplines.Add(spam);
            db.SaveChanges();  
        }

        public static void ReadactDiscipline(DisciplineContext db, Discipline spam, string name, int CountOfLabs)
        {
            if (spam != null)
            {
                spam.NameOfTheDiscipline = name;
                spam.CountOfLabs = CountOfLabs;
                db.SaveChanges();
            }
        }
        public static void DeleteDiscipline(DisciplineContext db, Discipline spam)
        {
            if (spam != null)
            {
                db.Disciplines.Remove(spam);
                db.SaveChanges();
            }
        }
        public static void ShowDisciplines(DisciplineContext db)
        {
            var users = db.Disciplines;
            Console.WriteLine("\n\n\nСписок Дисциплин:\n");
            var Disciplines = db.Disciplines.Include(a => a.Lectors).ToList();
            foreach (var t in Disciplines)
            {
            Console.WriteLine("{0} {1} {2} {3}  {4} {5} {6} {7}", t.DisciplineId, t.NameOfTheDiscipline, t.Semestr, t.Course, t.Specialty, t.TypeOfControl, t.CountOfLabs, t.CountOfLections);

            foreach (var p in t.Lectors)
                Console.WriteLine($"{p.Name}");
            }
        }

        public static void SqlCommand(DisciplineContext db, int countOfLabs)
        {
            string str = countOfLabs.ToString();
            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@CountOfLabs", str);
            var disciplines = db.Database.SqlQuery<Discipline>("SELECT * FROM Disciplines WHERE CountOfLabs = @CountOfLabs", param);
            Console.WriteLine(String.Format("\n\n\nСписок Дисциплин с количеством лаб {0}:\n", str));
            foreach (var phone in disciplines)
                Console.WriteLine(phone.NameOfTheDiscipline);
        }

        public static void Sort(DisciplineContext db)
        {
            var Disciplines = db.Disciplines.OrderBy(pp => pp.NameOfTheDiscipline).Select(p => p);
            Console.WriteLine("\n\nРезультат сортировки");
            foreach (var t in Disciplines)
            {
                Console.WriteLine("{0} {1} {2} {3}  {4} {5} {6} {7}", t.DisciplineId, t.NameOfTheDiscipline, t.Semestr, t.Course, t.Specialty, t.TypeOfControl, t.CountOfLabs, t.CountOfLections);
            }
        }

        public static void Search1(DisciplineContext db, string name)
        {
            Console.WriteLine("\n\nРезультат поиска по имени");
            var Disciplines = db.Disciplines.Where(p => p.NameOfTheDiscipline == name);
            foreach (var t in Disciplines)
            {
                Console.WriteLine("{0} {1} {2} {3}  {4} {5} {6} {7}", t.DisciplineId, t.NameOfTheDiscipline, t.Semestr, t.Course, t.Specialty, t.TypeOfControl, t.CountOfLabs, t.CountOfLections);
            }
        }

        public static void Search2(DisciplineContext db, string name, int countoflabs)
        {
            Console.WriteLine("\n\nРезультат поиска по имени и количеству лаб");
            var Disciplines = db.Disciplines.Where(p => p.NameOfTheDiscipline == name).Where(p => p.CountOfLabs == countoflabs);
            foreach (var t in Disciplines)
            {
                Console.WriteLine("{0} {1} {2} {3}  {4} {5} {6} {7}", t.DisciplineId, t.NameOfTheDiscipline, t.Semestr, t.Course, t.Specialty, t.TypeOfControl, t.CountOfLabs, t.CountOfLections);
            }
        }
    }
}
