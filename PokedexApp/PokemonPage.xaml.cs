using System.Runtime.CompilerServices;
using System.ComponentModel;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using System;

namespace PokedexApp;


public partial class PokemonPage : ContentPage
{
    
    public PokemonPage(string searchText)
    {
        InitializeComponent();
        var viewModel = new PokemonDetailViewModel();
        BindingContext = viewModel;
        //viewModel.LoadPokemonDataAsync(searchText);
        TestConnection();

    }
    private async void TestConnection()
    {
    var viewModel = (PokemonDetailViewModel)BindingContext;
    bool connectionSuccessful = await viewModel.TestMongoConnection();
    if (!connectionSuccessful)
    {
    await DisplayAlert("Connection Error", "Failed to connect to the database", "OK");
    }
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
            Console.WriteLine($"Attempting to connect to database and search for {pokemonName}");
            
            string connectionString = "mongodb+srv://tkhanpsn:Pokegocult@pokedex.mayccu6.mongodb.net";
            string databaseName = "Pokedex";
            string collectionName = "Pokedex.Pokemon";

            var client = new MongoClient(connectionString);
            Console.WriteLine("MongoClient created successfully");

            var database = client.GetDatabase(databaseName);
            Console.WriteLine("Database retrieved successfully");
            

            var collection = database.GetCollection<PokemonDetailViewModel>(collectionName);
            Console.WriteLine("Collection retrieved successfully");


            //Use Builders<PokemonViewModel>.Filter instead of Builders<BsonDocument>.Filter
            var filter = Builders<PokemonDetailViewModel>.Filter.Eq($" Name", "{pokemonName}");
            var pokemon = await collection.Find(filter).FirstOrDefaultAsync();
            Console.WriteLine("Find operation completed");


                if (pokemon != null)
                {
                    // Map database fields to properties
                    Console.WriteLine($"Pokemon Found: {pokemonName}");
                    Number = pokemon.Number;
                    Name = pokemon.Name;
                    Attack = pokemon.Attack;
                    Defense = pokemon.Defense;
                    Speed = pokemon.Speed;
                    HP = pokemon.HP;
                    Type1 = pokemon.Type1;
                    Type2 = pokemon.Type2;
                    Weight = pokemon.Weight;
                    Height = pokemon.Height;
                    BaseTotal = pokemon.BaseTotal;

                    // Add other properties you need to set
                }
                else
                    {
                    await Application.Current.MainPage.DisplayAlert("Error", "Pokemon Not Found", "OK");
                    }
            }
            catch (Exception ex)
            {
            await Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    public async Task<bool> TestMongoConnection()
    {
    try
    {
    Console.WriteLine("Attempting to connect to MongoDB...");
    string connectionString = "mongodb+srv://tkhanpsn:Pokegocult@pokedex.mayccu6.mongodb.net";
    var client = new MongoClient(connectionString);

    // List all databases
    Console.WriteLine("Listing databases:");
    using (var cursor = await client.ListDatabasesAsync())
    {
    await cursor.ForEachAsync(db => Console.WriteLine(db.GetValue("name").AsString));
    }

    // Assuming "Pokedex" is the correct database name
    var database = client.GetDatabase("Pokedex");

    // List all collections in the Pokedex database
    Console.WriteLine("Listing collections in Pokedex database:");
    using (var cursor = await database.ListCollectionNamesAsync())
    {
    await cursor.ForEachAsync(name => Console.WriteLine(name));
    }

    // Now try to access the Pokemon collection
    var collection = database.GetCollection<BsonDocument>("Pokemon");
    var count = await collection.CountDocumentsAsync(new BsonDocument());
    Console.WriteLine($"Document count in Pokemon collection: {count}");

    return true;
    }
    catch (Exception ex)
    {
    Console.WriteLine($"Error: {ex.GetType().Name} - {ex.Message}");
    Console.WriteLine($"Stack trace: {ex.StackTrace}");
    return false;
    }
    }

    }
}


