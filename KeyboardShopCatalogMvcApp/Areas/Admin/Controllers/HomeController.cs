using Microsoft.AspNetCore.Mvc;
using KeyboardShopCatalogMvcApp.Areas.Admin.Models;
using KeyboardShopCatalogMvcApp.Areas.Admin.ViewModels;

namespace KeyboardShopCatalogMvcApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        AdminModel adminModel = new AdminModel();

        [Route("{area}")]
        [Route("{area}/{controller}/{action}")]
        public IActionResult Index()
        {
            return View(adminModel);
        }

        [HttpGet]
        public IActionResult Authorization()
        {
            return View(new AdminViewModel());
        }

        [HttpPost]
        public IActionResult Authorization(AdminViewModel admin)
        {
            if (ModelState.IsValid)
            {
                adminModel.Authorization(admin.Password);

                if (adminModel.IsAvtorizate)
                {
                    return RedirectToAction("SuccessAuthorization");
                }
                else
                {
                    return RedirectToAction("ErrorAuthorization");
                }
            }
            else
            {
                return View(admin);
            }
        }

        public IActionResult SuccessAuthorization()
        {
            return View();
        }
        public IActionResult ErrorAuthorization()
        {
            return View();
        }

        public IActionResult LeaveAuthorization()
        {
            adminModel = new AdminModel();
            return RedirectToAction("Index");
        }
    }
}
