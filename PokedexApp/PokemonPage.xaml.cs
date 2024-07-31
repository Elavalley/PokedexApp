using System.Runtime.CompilerServices;
using System.ComponentModel;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using System;

namespace PokedexApp;


public partial class PokemonPage : ContentPage
{
    
    private static string userInput = "";
    public static string GetUserInput() { return userInput; }
    public PokemonPage(string userInput)
    {
        InitializeComponent();
        var viewModel = new PokemonDetailViewModel();
        BindingContext = viewModel;
        viewModel.LoadPokemonDataAsync(userInput);
    }
    public class PokemonDetailViewModel
    {
    
    #region attribute binders
    
    private int number;
    public int Number
    {
    get => number;
    set { number = value; OnPropertyChanged(); }
    }

    private string name;
    public string Name
    {
    get => name;
    set { name = value; OnPropertyChanged(); }
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
    

    private string type1;
    public string Type1
    {
    get => type1;
    set { type1 = value; OnPropertyChanged(); }
    }

    private string type2;
    public string Type2
    {
    get => type2;
    set { type2 = value; OnPropertyChanged(); }
    }

    private string height;
    public string Height
    {
    get => height;
    set { height = value; OnPropertyChanged(); }
    }

    private string weight;
    public string Weight
    {
    get => weight;
    set { weight = value; OnPropertyChanged(); }
    }

    private string baseTotal;
    public string BaseTotal
    {
    get => baseTotal;
    set { baseTotal = value; OnPropertyChanged(); }
    }
        #endregion




        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public async Task LoadPokemonDataAsync(string pokemonName)
    {
        try
            {
            string connectionString = "mongodb+srv://tkhanpsn:Pokegocult@pokedex.mayccu6.mongodb.net";
            string databaseName = "Pokedex";
            string collectionName = "Pokemon";

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            var collection = database.GetCollection<PokemonDetailViewModel>(collectionName);

            

            // Use Builders<PokemonViewModel>.Filter instead of Builders<BsonDocument>.Filter
            var filter = Builders<PokemonDetailViewModel>.Filter.Eq("Name", PokemonPage.userInput);

                var pokemon = await collection.Find(filter).FirstOrDefaultAsync();
                if (pokemon != null)
                {
                    // Map database fields to properties
                    Number = pokemon["Number"].AsInt32;
                    Name = pokemon["Name"].AsString;
                    HP = pokemon["HP"].AsInt32;
                    Attack = pokemon["Attack"].AsDouble;
                    Defense = pokemon["Defense"].AsDouble;
                    Speed = pokemon["Speed"].AsDouble;
                    Type1 = pokemon["Type1"].AsString;
                    Type2 = pokemon.Contains("Type2") ? pokemon["Type2"].AsString : null;
                    Weight = pokemon["Weight"].AsString;
                    Height = pokemon["Height"].AsString;
                    BaseTotal = pokemon["BaseTotal"].AsString;

                    // Add other properties you need to set
                }
                else
                {
                    Console.WriteLine("Pokemon Not Found");
                }
            }
            
            catch (Exception ex)
            {
                Console.WriteLine($"An Error occurred: {ex.Message}");
            }
            }
}
}


