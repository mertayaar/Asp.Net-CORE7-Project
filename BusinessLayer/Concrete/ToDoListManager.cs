using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class ToDoListManager : IToDoListService
	{

        IToDoListDal _toDoListDal;
		public ToDoListManager(IToDoListDal toDoListDal)
		{
            _toDoListDal = toDoListDal;

        }

        public void TAdd(ToDoList t)
        {
            _toDoListDal.Insert(t);
        }

        public void TDelete(ToDoList t)
        {
            _toDoListDal.Delete(t);
        }

        public ToDoList TGetByID(int id)
        {
            return _toDoListDal.GetByID(id);
        }

        public List<ToDoList> TGetList()
        {
            return _toDoListDal.GetList();
        }

        public List<ToDoList> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(ToDoList t)
        {
            _toDoListDal.Update(t);
        }
    }
}

