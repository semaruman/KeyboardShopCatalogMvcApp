using System.ComponentModel.DataAnnotations;
using KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.Models;

namespace KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.ViewModels
{
    public class KeyboardViewModel
    {
        [Required(ErrorMessage = "Введите бренд клавиатуры")]
        public string Brand { get; set; } // Бренд

        [Required(ErrorMessage = "Введите название клавиатуры")]
        public string Name { get; set; } // Название

        [Required(ErrorMessage = "Введите цену клавиатуры")]
        public double Price { get; set; } // Цена

        [Required(ErrorMessage = "Выберите тип клавиатуры")]
        public string KeyboardType { get; set; } // Тип клавиатуры (механическая, мембранная)

        public KeyboardViewModel()
        {

        }
        public KeyboardViewModel(KeyboardModel keyboard)
        {
            Brand = keyboard.Brand;
            Name = keyboard.Name;
            Price = keyboard.Price;
            KeyboardType = keyboard.KeyboardType;
        }
    }
}
