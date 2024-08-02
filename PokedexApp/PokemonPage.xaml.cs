using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

public class PokemonPage
{
    private static string userInput = "";
    public static string GetUserInput() { return userInput; }

    public PokemonPage()
    {
        userInput = Console.ReadLine();
        PokemonDetailViewModel viewModel = new PokemonDetailViewModel();
        viewModel.LoadPokemonDataAsync(userInput);
    }

    public class PokemonDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int number;
        public int Number
        {
            get { return number; }
            set
            {
                if (number != value)
                {
                    int oldNumber = number;
                    number = value;
                    OnPropertyChanged("Number");
                }
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    string oldName = name;
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private int hp;
        public int HP
        {
            get { return hp; }
            set
            {
                if (hp != value)
                {
                    int oldHP = hp;
                    hp = value;
                    OnPropertyChanged("HP");
                    OnPropertyChanged("HPProgress");
                }
            }
        }
        public double HPProgress => hp / 200.0;

        private double atk;
        public double Attack
        {
            get { return atk; }
            set
            {
                if (atk != value)
                {
                    double oldAtk = atk;
                    atk = value;
                    OnPropertyChanged("Attack");
                    OnPropertyChanged("AttackProgress");
                }
            }
        }
        public double AttackProgress => atk / 200.0;

        private double def;
        public double Defense
        {
            get { return def; }
            set
            {
                if (def != value)
                {
                    double oldDef = def;
                    def = value;
                    OnPropertyChanged("Defense");
                    OnPropertyChanged("DefenseProgress");
                }
            }
        }
        public double DefenseProgress => def / 200.0;

        private double spatk;
        public double SpAtk
        {
            get { return spatk; }
            set
            {
                if (spatk != value)
                {
                    double oldSpAtk = spatk;
                    spatk = value;
                    OnPropertyChanged("SpAtk");
                    OnPropertyChanged("SpAtkProgress");
                }
            }
        }
        public double SpAtkProgress => spatk / 200.0;

        private double spdef;
        public double SpDef
        {
            get { return spdef; }
            set
            {
                if (spdef != value)
                {
                    double oldSpDef = spdef;
                    spdef = value;
                    OnPropertyChanged("SpDef");
                    OnPropertyChanged("SpDefProgress");
                }
            }
        }
        public double SpDefProgress => spdef / 200.0;

        private double spd;
        public double Speed
        {
            get { return spd; }
            set
            {
                if (spd != value)
                {
                    double oldSpd = spd;
                    spd = value;
                    OnPropertyChanged("Speed");
                    OnPropertyChanged("SpeedProgress");
                }
            }
        }
        public double SpeedProgress => spd / 200.0;

        private string type1;
        public string Type1
        {
            get { return type1; }
            set
            {
                if (type1 != value)
                {
                    string oldType1 = type1;
                    type1 = value;
                    OnPropertyChanged("Type1");
                }
            }
        }

        private string type2;
        public string Type2
        {
            get { return type2; }
            set
            {
                if (type2 != value)
                {
                    string oldType2 = type2;
                    type2 = value;
                    OnPropertyChanged("Type2");
                }
            }
        }

        private string height;
        public string Height
        {
            get { return height; }
            set
            {
                if (height != value)
                {
                    string oldHeight = height;
                    height = value;
                    OnPropertyChanged("Height");
                }
            }
        }

        private string weight;
        public string Weight
        {
            get { return weight; }
            set
            {
                if (weight != value)
                {
                    string oldWeight = weight;
                    weight = value;
                    OnPropertyChanged("Weight");
                }
            }
        }

        private string baseTotal;
        public string BaseTotal
        {
            get { return baseTotal; }
            set
            {
                if (baseTotal != value)
                {
                    string oldBaseTotal = baseTotal;
                    baseTotal = value;
                    OnPropertyChanged("BaseTotal");
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void LoadPokemonDataAsync(string pokemonName)
        {
            try
            {
                string connectionString = "mongodb+srv://tkhanpsn:<Pokegocult>@pokedex.mayccu6.mongodb.net/";
                string databaseName = "Pokedex";
                string collectionName = "Pokemon";

                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);
                var collection = database.GetCollection<BsonDocument>(collectionName);

                var filter = Builders<BsonDocument>.Filter.Eq("Name", PokemonPage.GetUserInput());
                var pokemon = await collection.Find(filter).FirstOrDefaultAsync();

                if (pokemon != null)
                {
                    Number = pokemon["Number"].AsInt32;
                    Name = pokemon["Name"].AsString;
                    Attack = pokemon["Attack"].AsDouble;
                    Defense = pokemon["Defense"].AsDouble;
                    Speed = pokemon["Speed"].AsDouble;
                    HP = pokemon["HP"].AsInt32;
                    Type1 = pokemon["Type1"].AsString;
                    Type2 = pokemon["Type2"].AsString;
                    Weight = pokemon["Weight"].AsString;
                    Height = pokemon["Height"].AsString;
                    BaseTotal = pokemon["BaseTotal"].AsString;
                }
                else
                {
                    Console.WriteLine("Pokemon Not Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occurred: " + ex.Message);
            }
        }
    }

    public static void Main(string[] args)
    {
        new PokemonPage();
    }
}


