using System;
using System.Linq.Expressions;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repository
{
	public class GenericRepository<T> : IGenericDal<T> where T : class

	{

		public GenericRepository()
		{
		}

        public void Delete(T t)
        {
            using var context = new Context();
            context.Remove(t);
            context.SaveChanges();
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            using var c = new Context();
            return c.Set<T>().Where(filter).ToList();
        }

        public T GetByID(int id)

        {
            using var context = new Context();
            return context.Set<T>().Find(id);

        }

        public List<T> GetList()
        {
            using var context = new Context();
            return context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using var context = new Context();
            context.Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            using var context = new Context();
            context.Update(t);
            context.SaveChanges();
        }
    }
}

