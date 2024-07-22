namespace PokedexApp;
public partial class PokedexPage : ContentPage 
    {
        public PokedexPage()
        {        
            InitializeComponent();
        }
        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private async void OnStartClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PokemonPage());  
        }

}
