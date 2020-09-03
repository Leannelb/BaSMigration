namespace Core.Entities
{
    public class Product : BaseEntity
    {
        //type prop and enter and the below line is wrote for you
       //gets id from BaseEntity

        //naming convention is PascalCase
        public string Name { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }

        public ProductType ProductType { get; set; }

        public int ProductTypeId { get; set; }

        public ProdutBrand ProductBrand { get; set; }

        public int ProductBrandId { get; set; }
    }
}