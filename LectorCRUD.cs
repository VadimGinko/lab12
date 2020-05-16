using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    class LectorCRUD
    {
        public async static void AddLector(DisciplineContext db, Lector spam)
        {
            db.Lectors.Add(spam);
            await db.SaveChangesAsync();
        }

        public async static void ReadactLector(DisciplineContext db, Lector spam, int auditorium)
        {
            if (spam != null)
            {
                spam.Auditorium = auditorium;
                await db.SaveChangesAsync();
            }
        }
        public async static void DeleteLector(DisciplineContext db, Lector spam)
        {
            if (spam != null)
            {
                db.Lectors.Remove(spam);
                await db.SaveChangesAsync();
            }
        }
        public  static void ShowLector(DisciplineContext db)
        {
            var users = db.Lectors;
            Console.WriteLine("\n\n\nСписок Лекторов:\n");
            foreach (Lector u in users)
            {
                Console.WriteLine("{0} {1} {2} {3} ", u.LectorId, u.Name, u.Dist, u.Department, u.Auditorium);
            }
        }
    }
}