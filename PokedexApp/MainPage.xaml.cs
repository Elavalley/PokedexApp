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
	}

	private void OnPokedexClicked(object sender, EventArgs e)
	{
		Pokedex.Text = "Searching For Pokemon?";
		StartAnimation();
	}
	private async void OnBattleClicked(object sender, EventArgs e)
	{
		StopAnimation();
		await Navigation.PushAsync(new PokedexApp.SimulatorPage());

	}
	private void OnMovesClicked(object sender, EventArgs e)
	{
		Moves.Text = "Time to Battle!";
		StopAnimation();

	}
	private void OnTypingClicked(object sender, EventArgs e)
	{
		Typing.Text = "View Typing Chart";
		StopAnimation();
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
}

