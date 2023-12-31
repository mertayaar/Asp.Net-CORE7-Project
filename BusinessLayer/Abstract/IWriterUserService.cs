using System;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
	public interface IWriterUserService : IGenericService<WriterUser>
    {
        List<WriterUser> GetAdminProfile(string p);
    }
}

