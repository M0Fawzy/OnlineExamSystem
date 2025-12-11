using Microsoft.EntityFrameworkCore;
using Online_Exam_System.Data;
using Online_Exam_System.Repository.Base;

namespace Online_Exam_System.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public MainRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddOne(T item)
        {
            context.Set<T>().Add(item);
            context.SaveChanges();
        }

        public void DeleteOne(T item)
        {
            context.Set<T>().Remove(item);
            context.SaveChanges();
        }

        public T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public void UpdateOne(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
