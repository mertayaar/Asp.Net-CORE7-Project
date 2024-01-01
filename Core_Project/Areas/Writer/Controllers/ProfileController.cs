using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_Project.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.LastName = values.LastName;
            model.ImageUrl = values.ImageURL;
            return View(model);
        }

        
        public async Task<IActionResult> Index(UserEditViewModel userEdit)
        {
            try
            {
                var update = await _userManager.FindByNameAsync(User.Identity.Name);

                if (userEdit.Image != null)
                {
                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(userEdit.Image.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    var saveLocation = resource + "/wwwroot/images/userImage/" + imageName;
                    var stream = new FileStream(saveLocation, FileMode.Create);
                    await userEdit.Image.CopyToAsync(stream);
                    update.ImageURL = imageName;
                }

                update.Name = userEdit.Name;
                if(userEdit.Password != null)
                {
                    update.PasswordHash = _userManager.PasswordHasher.HashPassword(update, userEdit.Password);
                }
              
                ViewBag.profile = update.ImageURL;
                var results = await _userManager.UpdateAsync(update);

                if (results.Succeeded)
                {
                    
                    return RedirectToAction("Index", "Profile");
                   
                }
                return View();
            }
            catch (Exception e)
            {

                throw e;
            }

        }

    }
}
