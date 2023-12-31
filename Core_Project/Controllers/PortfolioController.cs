using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using Core_Project.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());

        public IActionResult Index()
        {
            var values = portfolioManager.TGetList();
            return View(values);
        }

        [HttpGet]

        public IActionResult AddPortfolio()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddPortfolio(PortfolioViewModel p)
        {
            var project = new Portfolio();

            if (p.ProjectImage != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.ProjectImage.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/images/projectImage/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await p.ProjectImage.CopyToAsync(stream);
                project.ImageUrl = imageName;
            }

            if (p.PlatformImage != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.PlatformImage.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/images/platformImage/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await p.PlatformImage.CopyToAsync(stream);
                project.Platform = imageName;
            }

            project.Name = p.Name;
            project.Value = p.Completion;
            project.ProjectUrl = p.ProjectURL;


            if (ModelState.IsValid)
            {

                portfolioManager.TAdd(project);
                return RedirectToAction("Index");
                
            }
            else
            {
                return View(p);
            }
         

           
        }

        public IActionResult DeletePortfolio(int id)
        {
            var values = portfolioManager.TGetByID(id);
            portfolioManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult EditPortfolio(int id)
        {
            var values = portfolioManager.TGetByID(id);
            return View(values);
        }

        [HttpPost]

        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult result = validations.Validate(portfolio);
            if (result.IsValid)
            {
                portfolioManager.TUpdate(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}