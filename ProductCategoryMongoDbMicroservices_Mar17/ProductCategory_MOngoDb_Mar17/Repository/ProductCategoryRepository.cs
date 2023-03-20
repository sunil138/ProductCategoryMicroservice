using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductCategory_MOngoDb_Mar17.Models;

namespace ProductCategory_MOngoDb_Mar17.Repository
{
    public class ProductCategoryRepository
    {
        private readonly IMongoCollection<ProductCategory> _products;
        public ProductCategoryRepository(IOptions<ProductCategoryStoreSetting> setting)
        {
            var mongoClient = new MongoClient(setting.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(setting.Value.DatabaseName);
            _products = mongoDatabase.GetCollection<ProductCategory>(setting.Value.ProductsCategoryCollectionName);
        }

        public async Task<List<ProductCategory>> GetAsync() =>
            await _products.Find(_ => true).ToListAsync();

        public async Task<ProductCategory> GetAsync(string id) =>
            await _products.Find(x => x.id == id).FirstOrDefaultAsync();

        public async Task<ProductCategory>GetAsyncOne(string categoryName)=>
            await _products.Find(x=>x.categoryName==categoryName).FirstOrDefaultAsync();  

        public async Task CreateAsync(ProductCategory productCategory)=>
            await _products.InsertOneAsync(productCategory);

        public async Task UpdateAsync(string id, ProductCategory productCategory) =>
            await _products.ReplaceOneAsync(x => x.id == id, productCategory);

        public async Task DeleteAsync(string id) =>
            await _products.DeleteOneAsync(x => x.id == id); 

    }
}
