using System;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
	public class MapVisitor : ViewComponent
	{
        public IViewComponentResult Invoke()
        {
            
            return View();
        }
    }
}

