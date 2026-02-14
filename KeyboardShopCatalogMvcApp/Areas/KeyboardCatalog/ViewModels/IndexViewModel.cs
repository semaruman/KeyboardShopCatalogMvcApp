namespace KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.ViewModels
{
    public class IndexViewModel
    {
        List<KeyboardViewModel> Keyboards { get; set; }
        List<string> Brands { get; set; } = new List<string>() { 
            "Все",
            "A4Tech", "ARDOR GAMING", "Logitech", "RedSquare",
            "Дарк Проджект", "Apple", "Defender"
        };
        List<string> Types { get; set; } = new List<string>()
         {
             "Мембранная", "Механическая", "Ножничная"
         };
    }
}
