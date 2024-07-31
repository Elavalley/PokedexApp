namespace PokedexApp;
public partial class PokedexPage : ContentPage 
    {
        public PokedexPage()
        {        
            InitializeComponent();
        }
        private async void OnSearch(object sender, EventArgs e)
        {
            string searchText = searchEntry.Text.Trim();
            if (!string.IsNullOrWhiteSpace(searchText))
                {
                    await Navigation.PushAsync(new PokemonPage(searchText));
                }
            else
            {
            await DisplayAlert("Invalid Search", "Please enter a Pokémon name", "OK");

            }
        }
        private async void OnStartClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PokemonPage("Bulbasaur"));  
        }
        private async void OnSearchButtonClicked(object sender, EventArgs e)
        {
            string searchText = searchEntry.Text?.Trim();

            if (!string.IsNullOrWhiteSpace(searchText))
                {
                    await Navigation.PushAsync(new PokemonPage(searchText));
                }
            else
            {
             await DisplayAlert("Invalid Search", "Please enter a Pokémon name", "OK");

            }        
        }


}
