namespace PokedexApp;

public partial class PokemonPage : ContentPage
{
    
    public PokemonPage(int PokeDexNum)
    {
        InitializeComponent();
        var viewModel = new PokemonDetailViewModel();
        BindingContext = viewModel;
        viewModel.LoadPokemonDataAsync(PokeDexNum);
    }
    public class PokemonDetailViewModel
    {
    private double _hp;
    public double HP
    {
        get => _hp;
        set
        {
            _hp = value;
            OnPropertyChanged();
        }
    }
    private double _atk;
    public double Attack
    {
        get => _atk;
        set
        {
            _atk = value;
            OnPropertyChanged();
        }
    }
    private double _def;
    public double Defense
    {
        get => _def;
        set
        {
            _def = value;
            OnPropertyChanged();
        }
    }
    private double _spatk;
    public double SpAtk
    {
        get => _spatk;
        set
        {
            _spatk = value;
            OnPropertyChanged();
        }
    }
    private double _spdef;
    public double SpDef
    {
        get => _spdef;
        set
        {
            _spdef = value;
            OnPropertyChanged();
        }
    }
    private double _spd;
    public double Speed
    {
        get => _spd;
        set
        {
            _spd = value;
            OnPropertyChanged();
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public async Task LoadPokemonDataAsync(int pokemonId)
    {
        var pokemonData = await ;
        HP = pokemonData.HP;
        Attack = pokemonData.Attack;
        Defense = pokemonData.Defense;
        SpAtk = pokemonData.SpAtk;
        SpDef = pokemonData.SpDef;
        Speed = pokemonData.Speed;
    }
}

}