namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid ProductBrandId { get; set; }

        //public Product(string name, string description, decimal price, string pictureUrl, ProductType productType, Guid productTypeId,
        //    ProductBrand productBrand, Guid productBrandId)
        //{
        //    Name = name;
        //    Description = description;
        //    Price = price;
        //    PictureUrl = pictureUrl;
        //    ProductType = productType;
        //    ProductTypeId = productTypeId;
        //    ProductBrand = productBrand;
        //    ProductBrandId = productBrandId;
        //}
    }
}