namespace KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.ViewModels
{
    public class IndexViewModel
    {
        public List<KeyboardViewModel> Keyboards { get; set; } = new List<KeyboardViewModel>();
        public List<string> Brands { get; set; } = new List<string>() { 
            "Все",
            "A4Tech", "ARDOR GAMING", "Logitech", "RedSquare",
            "Дарк Проджект", "Apple", "Defender"
        };
        public List<string> Types { get; set; } = new List<string>()
        {
             "Мембранная", "Механическая", "Ножничная"
        };
    }
}
