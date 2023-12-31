using System;
using System.Linq.Expressions;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repository
{
	public class SkillRepository : IGenericDal<Skill>
	{
		public SkillRepository()
		{
		}

        public void Delete(Skill t)
        {
            throw new NotImplementedException();
        }

        public List<Skill> GetByFilter(Expression<Func<Skill, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Skill GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Skill> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert(Skill t)
        {
            throw new NotImplementedException();
        }

        public void Update(Skill t)
        {
            throw new NotImplementedException();
        }
    }
}

