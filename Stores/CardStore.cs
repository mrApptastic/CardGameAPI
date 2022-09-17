using CardGameAPI.Models;
using static System.Net.Mime.MediaTypeNames;

namespace CardGameAPI.Stores
{
	public interface ICardStore {
        Card GetRandom();
	}

    public class CardStore: ICardStore
    {
        private readonly ILogger<CardStore> _logger;
        
        public CardStore(ILogger<CardStore> logger)
        {
            _logger = logger;
        }

        public Card GetRandom()
        {
            string basePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.Split("\\bin")[0], "Media");

            var cardFiles = Directory.GetFiles(basePath);

            if (cardFiles == null || cardFiles.Length == 0) {
                throw new Exception("No card files were found.");
            }

            var selected = cardFiles.Skip(new Random().Next(1, cardFiles.Count())).Take(1).FirstOrDefault();

            if (selected == null) {
                throw new Exception("There was an issue when reading the selected card.");
            }

            return new Card() {
                PublicId =  System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(selected)),
                Name =  selected.Substring(selected.LastIndexOf("\\") + 1).Split('.')[0].Replace("-", " "),
                Svg =  File.ReadAllText(selected)                
            };
        }

    }
}
