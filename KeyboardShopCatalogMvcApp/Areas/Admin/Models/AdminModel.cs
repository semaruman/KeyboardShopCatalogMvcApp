namespace KeyboardShopCatalogMvcApp.Areas.Admin.Models
{
    public class AdminModel
    {
        private readonly string password = "adminPassword";
        private bool isAvtorizate = false;
        public bool IsAvtorizate { get { return isAvtorizate; } }

        public void Authorization(string passwordParam)
        {
            if (password != passwordParam)
            {
                throw new Exception("Неверный пароль!");
            }
            isAvtorizate = true;
        }
    }
}
