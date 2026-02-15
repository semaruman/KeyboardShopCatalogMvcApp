using Microsoft.AspNetCore.Mvc;
using KeyboardShopCatalogMvcApp.Areas.Admin.Models;
using KeyboardShopCatalogMvcApp.Areas.Admin.ViewModels;
using KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.Models;
using KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.ViewModels;

namespace KeyboardShopCatalogMvcApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        static AdminModel adminModel = new AdminModel();

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

        [HttpGet]
        public IActionResult AddKeyboard()
        {
            if (adminModel.IsAvtorizate)
            {
                return View(new KeyboardModel());
            }
            else
            {
                return RedirectToAction("ErrorAuthorization");
            }
        }

        [HttpPost]
        public IActionResult AddKeyboard(KeyboardModel keyboard)
        {
            if (ModelState.IsValid)
            {
                KeyboardDb db = new KeyboardDb();
                db.AddKeyboardModel(keyboard);
                return RedirectToAction("AddKeyboardSuccess");
            }
            else
            {
                return View(keyboard);
            }
        }

        [HttpGet]
        public IActionResult RemoveKeyboard()
        {
            if (adminModel.IsAvtorizate)
            {
                return View(new KeyboardViewModel());
            }
            else
            {
                return RedirectToAction("ErrorAuthorization");
            }
        }

        [HttpPost]
        public IActionResult RemoveKeyboard(KeyboardViewModel keyboard)
        {
            if (ModelState.IsValid)
            {
                KeyboardDb db = new KeyboardDb();
                db.RemoveKeyboardModel(keyboard.Brand, keyboard.Name, keyboard.KeyboardType);
                return RedirectToAction("RemoveKeyboardSuccess");
            }
            else
            {
                return View(keyboard);
            }
        }

        public IActionResult AddKeyboardSuccess()
        {
            return View();
        }

        public IActionResult RemoveKeyboardSuccess()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChangeKeyboardPrice()
        {
            if (adminModel.IsAvtorizate)
            {
                return View(new KeyboardViewModel());
            }
            else
            {
                return RedirectToAction("ErrorAuthorization");
            }
        }

        [HttpPost]
        public IActionResult ChangeKeyboardPrice(KeyboardViewModel keyboard)
        {
            if (ModelState.IsValid)
            {
                KeyboardDb db = new KeyboardDb();
                if (db.ChangeKeyboardModel(keyboard.Brand, keyboard.Name, keyboard.KeyboardType, keyboard.Price))
                {
                    return RedirectToAction("ChangeKeyboardPriceSuccess");
                }
                else
                {
                    return RedirectToAction("ChangeKeyboardPriceError");
                }
            }
            else
            {
                return View(keyboard);
            }
        }

        public IActionResult ChangeKeyboardPriceSuccess()
        {
            return View();
        }
        public IActionResult ChangeKeyboardPriceError()
        {
            return View();
        }
    }
}
