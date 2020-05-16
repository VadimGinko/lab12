using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DisciplineContext db = new DisciplineContext())
            {
                Discipline discipline1 = new Discipline { NameOfTheDiscipline = "ООП", Course = 2, Semestr = 2, CountOfLections = 16, CountOfLabs = 16, Specialty = "ПОИТ", TypeOfControl = "экзамен" };
                Discipline discipline2 = new Discipline { NameOfTheDiscipline = "ОАИП", Course = 1, Semestr = 1, CountOfLections = 16, CountOfLabs = 16, Specialty = "ПОИТ", TypeOfControl = "экзамен" };
                Discipline discipline3 = new Discipline { NameOfTheDiscipline = "КЯР", Course = 1, Semestr = 2, CountOfLections = 16, CountOfLabs = 27, Specialty = "ПОИТ", TypeOfControl = "экзамен" };
                Discipline discipline4 = new Discipline { NameOfTheDiscipline = "АЛОЦВМ", Course = 1, Semestr = 1, CountOfLections = 16, CountOfLabs = 8, Specialty = "ПОИТ", TypeOfControl = "экзамен" };

                Lector lector1 = new Lector { Name = "Белодед", Auditorium = 100, Department = "qqq", Dist = discipline2 };
                Lector lector2 = new Lector { Name = "Пацей", Auditorium = 200, Department = "www", Dist = discipline1 };
                Lector lector3 = new Lector { Name = "Жиляк", Auditorium = 300, Department = "rrr", Dist = discipline3 };
                Lector lector4 = new Lector { Name = "Гринюк", Auditorium = 400, Department = "ttt", Dist = discipline4 };
                Lector lector5 = new Lector { Name = "Пустовалова", Auditorium = 500, Department = "yyy", Dist = discipline2 };
                Lector lector6 = new Lector { Name = "Смелов", Auditorium = 600, Department = "uuu", Dist = discipline1 };
                //DisciplineCRUD.AddDiscipline(db, discipline1);
                //DisciplineCRUD.AddDiscipline(db, discipline2);
                //DisciplineCRUD.AddDiscipline(db, discipline3);
                //DisciplineCRUD.AddDiscipline(db, discipline4);

                //LectorCRUD.AddLector(db, lector1);
                //LectorCRUD.AddLector(db, lector2);
                //LectorCRUD.AddLector(db, lector3);
                //LectorCRUD.AddLector(db, lector4);
                //LectorCRUD.AddLector(db, lector5);
                //LectorCRUD.AddLector(db, lector6);

                Discipline discipline5 = new Discipline { NameOfTheDiscipline = "БД", Course = 1, Semestr = 1, CountOfLections = 16, CountOfLabs = 8, Specialty = "ПОИТ", TypeOfControl = "экзамен" };

                //delete example
                //DisciplineCRUD.AddDiscipline(db, discipline5);
                //Discipline q = db.Disciplines.FirstOrDefault(p=> p.NameOfTheDiscipline == "БД");
                //isciplineCRUD.DeleteDiscipline(db, q);

                //redact example
                //Discipline q1 = db.Disciplines.FirstOrDefault(p=> p.NameOfTheDiscipline == "АЛОЦВМ");
                //DisciplineCRUD.ReadactDiscipline(db, q1, "АЛОШКА", 222);

                DisciplineCRUD.ShowDisciplines(db);
                LectorCRUD.ShowLector(db);
                Console.WriteLine("Объекты успешно сохранены");

                #region tranzaction


                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        //DisciplineCRUD.AddDiscipline(db, discipline5);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
                DisciplineCRUD.ShowDisciplines(db);
                #endregion tranzaction

                DisciplineCRUD.SqlCommand(db, 16);

                DisciplineCRUD.Sort(db);

                DisciplineCRUD.Search1(db, "ООП");
                DisciplineCRUD.Search2(db, "КЯР", 27);
                Console.Read();
            }
        }
    }
}
