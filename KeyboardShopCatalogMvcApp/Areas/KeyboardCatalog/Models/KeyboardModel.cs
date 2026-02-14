using System.ComponentModel.DataAnnotations;

namespace KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.Models
{
    public class KeyboardModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите бренд клавиатуры")]
        public string Brand { get; set; } // Бренд

        [Required(ErrorMessage = "Введите название клавиатуры")]
        public string Name {  get; set; } // Название

        [Required(ErrorMessage = "Введите цену клавиатуры")]
        public double Price { get; set; } // Цена

        [Required(ErrorMessage = "Выберите тип клавиатуры")]
        public string KeyboardType { get; set; } // Тип клавиатуры (механическая, мембранная)

        [Required(ErrorMessage = "Введите ширину клавиатуры")]
        public double Width {  get; set; } // Ширина

        [Required(ErrorMessage = "Введите высоту клавиатуры")]
        public double Height { get; set; } // Высота

        [Required(ErrorMessage = "Введите количество клавиш клавиатуры")]
        public int KeysCount {  get; set; } // Количество клавиш
    }
}
