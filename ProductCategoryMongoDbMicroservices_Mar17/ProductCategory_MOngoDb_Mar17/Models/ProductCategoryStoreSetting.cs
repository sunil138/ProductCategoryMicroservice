namespace ProductCategory_MOngoDb_Mar17.Models
{
    public class ProductCategoryStoreSetting
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ProductsCategoryCollectionName { get; set; } = null!; 
    }
}
