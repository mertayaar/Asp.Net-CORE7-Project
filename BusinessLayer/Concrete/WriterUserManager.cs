using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class WriterUserManager : IWriterUserService
	{
		IWriterUserDal _writerUserDal;
		public WriterUserManager(IWriterUserDal writerUserDal)
		{
			_writerUserDal = writerUserDal;

        }

        public List<WriterUser> GetAdminProfile(string p)
        {
            return _writerUserDal.GetByFilter(x => x.Email == p);
        }

        public void TAdd(WriterUser t)
        {
            _writerUserDal.Insert(t);
        }

        public void TDelete(WriterUser t)
        {
            _writerUserDal.Delete(t);
        }

        public WriterUser TGetByID(int id)
        {
            return _writerUserDal.GetByID(id);
        }

        public List<WriterUser> TGetList()
        {
            return _writerUserDal.GetList();
        }

        public List<WriterUser> TGetListByFilter()
        {

            throw new NotImplementedException();
        }



        public void TUpdate(WriterUser t)
        {
            _writerUserDal.Update(t);
        }
    }
}

