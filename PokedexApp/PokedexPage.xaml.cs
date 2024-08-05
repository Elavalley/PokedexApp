namespace PokedexApp
{
    public partial class PokedexPage : ContentPage
    {
        private static string userInput = "";
        public static string GetUserInput() { return userInput; }
        
        public PokedexPage()
        {
            InitializeComponent();
        }

        private async void OnSearchPressed(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userInput))
            {
                await Navigation.PushAsync(new PokemonPage(userInput));
            }
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            userInput = e.NewTextValue;
        }

        private async void OnStartClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PokemonPage("Bulbasaur"));  
        }
    }
}
