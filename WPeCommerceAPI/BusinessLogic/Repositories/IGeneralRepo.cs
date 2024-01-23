namespace WPeCommerceAPI.BusinessLogic.Repositories
{
    public interface IGeneralRepo<T>
    {

        ICollection<T> GetAll();
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);


    }
}
