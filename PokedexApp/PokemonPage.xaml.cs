using System.Runtime.CompilerServices;
using System.ComponentModel;
using MongoDB.Driver;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PokedexApp;

public partial class PokemonPage : ContentPage
{
    int PokedexNum = 1; 
    public PokemonPage()
    {
        InitializeComponent();
        var viewModel = new PokemonDetailViewModel();
        BindingContext = viewModel;
        viewModel.LoadPokemonDataAsync(PokedexNum);
    }
    public class PokemonDetailViewModel
    {
    
    #region stat binders
    
    private int _id;
    public int ID
    {
    get => _id;
    set { _id = value; OnPropertyChanged(); }
    }

    private string _name;
    public string Name
    {
    get => _name;
    set { _name = value; OnPropertyChanged(); }
}
    
    
    private int _hp;
    public int HP
    {
        get => _hp;
        set
        {
            _hp = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(HPProgress));
        }
    }
    public double HPProgress => HP / 200.0;
    
    
    private double _atk;
    public double Attack
    {
        get => _atk;
        set
        {
            _atk = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(AttackProgress));
        }
    }
    public double AttackProgress => Attack / 200.0;
    
    
    private double _def;
    public double Defense
    {
        get => _def;
        set
        {
            _def = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(DefenseProgress));
        }
    }
    public double DefenseProgress => Defense / 200.0;
    
    private double _spatk;
    public double SpAtk
    {
        get => _spatk;
        set
        {
            _spatk = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SpAtkProgress));
        }
    }
    public double SpAtkProgress => SpAtk / 200.0;


    private double _spdef;
    public double SpDef
    {
        get => _spdef;
        set
        {
            _spdef = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SpDefProgress));
        }
    }
    public double SpDefProgress => SpDef / 200.0;


    private double _spd;
    public double Speed
    {
        get => _spd;
        set
        {
            _spd = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SpeedProgress));
        }
    }
    public double SpeedProgress => Speed / 200.0;

    #endregion
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public async Task LoadPokemonDataAsync(int pokemonId)
        {
        string connectionstring = "mongodb+srv://tkhanpsn:Pokegocult@pokedex.mayccu6.mongodb.net";
        string databaseName = "Pokemon";
        string collectionName = "PokeDex";

        var client = new MongoClient(connectionstring);
        var database = client.GetDatabase(databaseName);
        var collection = database.GetCollection<PokemonDetailViewModel>(collectionName);

        var filter = Builders<PokemonDetailViewModel>.Filter.Eq("Id", pokemonId);
        var pokemon = await collection.Find(filter).FirstOrDefaultAsync();

        if (pokemon != null)
        {
        ID = pokemon.ID;
        Name = pokemon.Name;
        HP = pokemon.HP;
        Attack = pokemon.Attack;
        Defense = pokemon.Defense;
        SpAtk = pokemon.SpAtk;
        SpDef = pokemon.SpDef;
        Speed = pokemon.Speed;
        // Add any other properties you need to set
        }
        }
}

}