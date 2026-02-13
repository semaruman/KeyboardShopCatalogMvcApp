namespace KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.Models
{
    public class KeyboardModel
    {
        public int Id { get; set; }

        public string Brand { get; set; } // Бренд

        public string Name {  get; set; } // Название

        public double Price { get; set; } // Цена

        public string KeyboardType { get; set; } // Тип клавиатуры (механическая, мембранная)

        public double Width {  get; set; } // Ширина

        public double Height { get; set; } // Высота

        public int KeysCount {  get; set; } // Количество клавиш
    }
}
