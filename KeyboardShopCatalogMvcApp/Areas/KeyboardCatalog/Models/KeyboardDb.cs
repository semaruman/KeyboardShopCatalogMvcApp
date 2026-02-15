using System.Text.Json;
using KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.ViewModels;
using static System.Reflection.Metadata.BlobBuilder;
namespace KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.Models
{
    public class KeyboardDb
    {
        private readonly string filepath = Path.Combine(Directory.GetCurrentDirectory(), "Areas", "KeyboardCatalog", "Data", "keyboard_db.json");

        public void AddKeyboardModel(KeyboardModel keyboard)
        {
            List<KeyboardModel> list = new List<KeyboardModel>();

            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                if (!string.IsNullOrEmpty(json))
                {
                    list = JsonSerializer.Deserialize<List<KeyboardModel>>(json) ?? new List<KeyboardModel>();
                }
            }
            list.Add(keyboard);

            string jsonWrite = JsonSerializer.Serialize(list);
            File.WriteAllText(filepath, jsonWrite);
        }

        public void RemoveKeyboardModel(string brand, string name, string type)
        {
            List<KeyboardModel> list = new List<KeyboardModel>();

            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                if (!string.IsNullOrEmpty(json))
                {
                    list = JsonSerializer.Deserialize<List<KeyboardModel>>(json) ?? new List<KeyboardModel>();
                }
            }
            list = list.Where(k => !(k.Brand == brand &&  k.Name == name && k.KeyboardType == type)).ToList();

            string jsonWrite = JsonSerializer.Serialize(list);
            File.WriteAllText(filepath, jsonWrite);
        }

        public bool ChangeKeyboardModel(string brand, string name, string type, double price)
        {
            List<KeyboardModel> list = new List<KeyboardModel>();

            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                if (!string.IsNullOrEmpty(json))
                {
                    list = JsonSerializer.Deserialize<List<KeyboardModel>>(json) ?? new List<KeyboardModel>();
                }
            }
            KeyboardModel keyboard = list.FirstOrDefault(k => k.Brand == brand && k.Name == name && k.KeyboardType == type);

            if (keyboard == null)
            {
                return false;
            }

            keyboard.Price = price;
            string jsonWrite = JsonSerializer.Serialize(list);
            File.WriteAllText(filepath, jsonWrite);

            return true;
        }

        public List<KeyboardModel> GetKeyboardModels()
        {
            List<KeyboardModel> keyboards = new List<KeyboardModel>();

            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                if (!string.IsNullOrEmpty(json))
                {
                    keyboards = JsonSerializer.Deserialize<List<KeyboardModel>>(json) ?? new List<KeyboardModel>();
                }
            }

            return keyboards;
        }

        public List<KeyboardViewModel> GetKeyboardViewModels()
        {
            return GetKeyboardModels().Select(k => new KeyboardViewModel(k)).ToList();
        }
    }
}
