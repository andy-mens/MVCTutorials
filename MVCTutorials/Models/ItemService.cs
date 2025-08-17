using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MVCTutorials.Models
{
    public class ItemService
    {
        private readonly IMongoCollection<Item> _items;

        public ItemService(IOptions<MongoDbSettings> mongoSettings, IMongoClient client)
        {
            var database = client.GetDatabase(mongoSettings.Value.DatabaseName);
            _items = database.GetCollection<Item>("Items");
        }

        public async Task<List<Item>> GetAsync()
        {
            return await _items.Find(item => true).ToListAsync();
        }
        //public List<Item> Get() => _items.Find(item => true).ToList();
        public Item Get(string id) => _items.Find(item => item.Id == id).FirstOrDefault();
        public void Create(Item item) => _items.InsertOne(item);
        public void Update(string id, Item itemIn) => _items.ReplaceOne(item => item.Id == id, itemIn);
        public void Remove(string id) => _items.DeleteOne(item => item.Id == id);
    }
}
