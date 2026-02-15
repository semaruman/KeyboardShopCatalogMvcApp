using KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.Models;

namespace KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.ViewModels
{
    public class IndexViewModel
    {
        public List<KeyboardViewModel> Keyboards { get; set; }
        public List<string> Brands { get; set; } = new List<string>() { 
            "Все",
            "A4Tech", "ARDOR GAMING", "Logitech", "RedSquare",
            "Дарк Проджект", "Apple", "Defender"
        };
        public List<string> Types { get; set; } = new List<string>()
        {
             "Все", "Мембранная", "Механическая", "Ножничная"
        };

        public string SelectedBrand { get; set; } = "Все";
        public string SelectedType { get; set; } = "Все";

        public string SortType { get; set; } = "None";

        public IndexViewModel()
        {
            KeyboardDb db = new KeyboardDb();
            Keyboards = db.GetKeyboardViewModels();
        }
    }
}
