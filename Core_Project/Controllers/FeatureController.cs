using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
      
        [HttpGet]

        public IActionResult Index()
        {
            var values = featureManager.TGetByID(1);
            return View(values);
        }

        [HttpPost]

        public IActionResult Index(Feature feature)
        {

            featureManager.TUpdate(feature);
            return RedirectToAction("Index","Feature");
        }



    }
}