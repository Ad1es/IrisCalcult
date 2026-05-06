using IrisCraftCalc.Services;

namespace IrisCraftCalc
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void LoginBtn_Clicked(object sender, EventArgs e)
        {
            // Здесь в будущем будет логика проверки логина/пароля
            string login = LoginEntry.Text;
            string password = PasswordEntry.Text;

            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                // Прячем экран авторизации
                LoginOverlay.IsVisible = false;

                // Обновляем шапку приложения
                CharStatusLabel.Text = $"👤 Аккаунт: {login} | Инвентарь ожидает синхронизации";
            }
            else
            {
                DisplayAlert("Ошибка", "Пожалуйста, введите логин и пароль.", "ОК");
            }
            // Пример: Железный слиток делается из 3 руды
            var ironOre = new GameItem { Name = "Железная руда" };
            var ironIngot = new GameItem
            {
                Name = "Железный слиток",
                Recipe = new CraftRecipe
                {
                    RequiredItems = new List<Ingredient> {
            new Ingredient { Item = ironOre, Quantity = 3 }
        }
                }
            };

            // Считаем, сколько руды нужно для 10 слитков
            var service = new CraftService();
            var result = service.CalculateTotalResources(ironIngot, 10);
            // Результат: Железная руда = 30 шт.
        }
        // Внутри MainPage.xaml.cs
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var dataService = new DataService();
            // Предположим, ты создал файл в Resources/Raw/blacksmith.json
            var recipes = await dataService.LoadRecipesAsync("recipes_blacksmith.json");

            // Привязываем список к нашему CollectionView
            RecipesList.ItemsSource = recipes;
        }
    }
}
