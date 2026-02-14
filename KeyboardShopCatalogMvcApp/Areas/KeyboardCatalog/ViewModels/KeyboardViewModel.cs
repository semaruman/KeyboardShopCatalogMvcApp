using KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.Models;

namespace KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.ViewModels
{
    public class KeyboardViewModel
    {
        public string Brand { get; set; } // Бренд

        public string Name { get; set; } // Название

        public double Price { get; set; } // Цена

        public string KeyboardType { get; set; } // Тип клавиатуры (механическая, мембранная)

        public KeyboardViewModel(KeyboardModel keyboard)
        {
            Brand = keyboard.Brand;
            Name = keyboard.Name;
            Price = keyboard.Price;
            KeyboardType = keyboard.KeyboardType;
        }
    }
}
