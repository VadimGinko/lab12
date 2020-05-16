using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    interface IRepository<T> : IDisposable
            where T : class
    {
        IEnumerable<T> GetBookList(); // получение всех объектов
        T GetBook(int id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item, int spam); // обновление объекта
        void Delete(T item); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}
