using System;
namespace BusinessLayer.Abstract
{
	public interface IGenericService<T> where T: class
	{

		void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> TGetList();
        T TGetByID(int id);

        List<T> TGetListByFilter();



    }
}

