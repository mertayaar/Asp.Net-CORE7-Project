using System;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
	public interface IWriterMessageService : IGenericService<WriterMessage>
    {
        List<WriterMessage> GetListOutbox(string p);

        List<WriterMessage> GetListInbox(string p);

    }
}

