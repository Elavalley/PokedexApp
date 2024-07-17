

namespace PokedexApp
{
    
    public partial class SimulatorPage : ContentPage
    {
        public string[] imageNames2 = {"one.png","two.png","three.png","four.png","five.png","six.png","seven.png","eight.png"};
        public bool isconstruct = false;
        public int currentImageIndex1 = 0;
        public SimulatorPage()
        {
            InitializeComponent();
            construct();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Battle();
        }

        private void Battle()
        {
            
        }
        public async void construct()
        {
        isconstruct = true;
        while (isconstruct)
            {
            Construct.Source = imageNames2[currentImageIndex1];
            currentImageIndex1 = (currentImageIndex1 + 1) % imageNames2.Length;
            await Task.Delay(1000); // Delay between image changes (in miliseconds)
            }
        }
    }
}