using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class WriterMessageManager : IWriterMessageService
	{

        IWriterMessageDal _writerMessageDal;
		public WriterMessageManager(IWriterMessageDal writerMessageDal)
		{
            _writerMessageDal = writerMessageDal;

        }

        public List<WriterMessage> GetListInbox(string p)
        {
            return _writerMessageDal.GetByFilter(x => x.Receiver == p);
        }

        public List<WriterMessage> GetListOutbox(string p)
        {
            return _writerMessageDal.GetByFilter(x => x.Sender == p);
        }

        public void TAdd(WriterMessage t)
        {
            _writerMessageDal.Insert(t);
        }

        public void TDelete(WriterMessage t)
        {
            _writerMessageDal.Delete(t);
        }

        public WriterMessage TGetByID(int id)
        {
            return _writerMessageDal.GetByID(id);
        }

        public List<WriterMessage> TGetList()
        {
            throw new NotImplementedException();
        }

     
        public List<WriterMessage> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WriterMessage t)
        {
            throw new NotImplementedException();
        }
    }
}

