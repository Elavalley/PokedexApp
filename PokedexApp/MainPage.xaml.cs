using AuthenticationServices;

namespace PokedexApp;

public partial class MainPage : ContentPage
{
	private string[] imageNames1 = { "closed.png", "halfopen.png", "open.png" };
	private int currentImageIndex = 0;
	private bool ispokeball = false;


	public MainPage()
	{
		InitializeComponent();
		StartAnimation();
		Icebeam.IsVisible = false;
		
	}

	private void OnPokedexClicked(object sender, EventArgs e)
	{
		Pokedex.Text = "Searching For Pokemon?";
		StartAnimation();
	}
	private async void OnBattleClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new PokedexApp.SimulatorPage());

	}
	private void OnMovesClicked(object sender, EventArgs e)
	{

	}
	private void OnTypingClicked(object sender, EventArgs e)
	{
		Typing.Text = "View Typing Chart";
	}
	public async void OnBlastClicked(object sender, EventArgs e)
	{
		await AnimateIceBeamAsync();
	}
	public async void StartAnimation()
	{
	ispokeball = true;
	while (ispokeball)
		{
		AnimatedPokeball.Source = imageNames1[currentImageIndex];
		currentImageIndex = (currentImageIndex + 1) % imageNames1.Length;
		await Task.Delay(1000); // Delay between image changes (in miliseconds)
		}
	}

	public void StopAnimation()
	{
	ispokeball = false;
	}
	private async Task AnimateIceBeamAsync()
	{
		
		Icebeam.IsVisible = true;
		Icebeam.TranslationX = 0;

		var animation = new Animation(v => Icebeam.TranslationX = v, 0, -300);

		animation.Commit(this, "IceBeamAnimation", 16, 1000, Easing.Linear, (v, c) => Icebeam.TranslationX = 0);
		await Task.Delay(1000);
		Icebeam.IsVisible = false;
	}
}

