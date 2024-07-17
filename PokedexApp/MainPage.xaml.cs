namespace PokedexApp;

public partial class MainPage : ContentPage
{
	private string[] imageNames = { "closed.png", "halfopen.png", "open.png" };
	private int currentImageIndex = 0;
	private bool isAnimating = false;

	public MainPage()
	{
		InitializeComponent();
		StartAnimation();
	}

	private void OnPokedexClicked(object sender, EventArgs e)
	{
		Pokedex.Text = "Searching For Pokemon?";
	}
	private void OnCatcherClicked(object sender, EventArgs e)
	{
		StopAnimation();
		Catcher.Text = "Did you Catch it?";
	}
	private void OnBattleClicked(object sender, EventArgs e)
	{
		Battle.Text = "Time to Battle!";
	}
	private void OnAddClicked(object sender, EventArgs e)
	{
		Add.Text = "Adding a new pokemon?";
	}
	private async void StartAnimation()
	{
	isAnimating = true;
	while (isAnimating)
		{
		AnimatedPokeball.Source = imageNames[currentImageIndex];
		currentImageIndex = (currentImageIndex + 1) % imageNames.Length;
		await Task.Delay(1000); // Delay between image changes (in miliseconds)
		}
	}

	private void StopAnimation()
	{
	isAnimating = false;
	}
}

