using System.ComponentModel.DataAnnotations;

namespace KeyboardShopCatalogMvcApp.Areas.Admin.ViewModels
{
    public class AdminViewModel
    {
        [Required(ErrorMessage = "Введите пароль!")]
        public string Password {  get; set; }
    }
}
