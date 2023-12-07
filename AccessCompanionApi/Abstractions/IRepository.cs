using AccessCompanionApi.Domain;

namespace AccessCompanionApi.Abstractions
{
    public interface IRepository<T> where T : EntityBase
    {
#region C
        void Create(T entity);
#endregion
#region R
        IQueryable<T> ReadAll();
        IQueryable<T> Read(Func<T, bool> predicate);
        T ReadById(int id);
#endregion
#region U
        void Update(T entity);
#endregion
#region D
        void Delete(T entity);
#endregion
    }
}