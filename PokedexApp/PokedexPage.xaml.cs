namespace PokedexApp;
public partial class PokedexPage : ContentPage 
    {

        private static string userInput = "";
        public static string GetUserInput() { return userInput; }
        public PokedexPage()
        {        
            InitializeComponent();
        }
        private async void OnSearchPressed(object sender, TextChangedEventArgs e)
        {
            await Navigation.PushAsync(new PokemonPage(userInput));
        }
        private async void OnStartClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PokemonPage("Bulbasaur"));  
        }

}
