using log4net;
using WPeCommerceAPI.DataLayer;

namespace WPeCommerceAPI.BusinessLogic.Repositories
{
    public class GeneralRepo<T> : IGeneralRepo<T> where T : class
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(GeneralRepo<T>));
        private readonly AppDbContext _db;
        public GeneralRepo(AppDbContext db)
        {
            _db = db;
        }
        public bool Create(T entity)
        {
            try
            {
                _db.Set<T>().Add(entity);
                return true;
            }
            catch(Exception ex)
            {
                _logger.Info(ex.Message.ToString());
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _db.Set<T>().Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Info(ex.Message.ToString());
                return false;
            }
        }

        public ICollection<T> GetAll()
        {
            var collection = _db.Set<T>().ToList();
            if(collection.Count == 0)
            {
                _logger.Info("The Collection is empty");
                return new List<T>();
            }
            else
            {
                return collection;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                _db.Set<T>().Update(entity);
                return true;
            }
            catch(Exception ex)
            {
                _logger.Info("Failed to update item");
                return false;
            }
        }
    }
}
