namespace Online_Exam_System.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T FindById(int id);
        void AddOne(T item);
        void UpdateOne(T entity);
        void DeleteOne(T item);
    }
}
