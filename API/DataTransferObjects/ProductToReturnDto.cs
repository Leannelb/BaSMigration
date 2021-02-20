namespace API.Dtos
{
    public class ProductToReturnDto
    {
        //type prop and enter and the below line is wrote for you
        //gets id from BaseEntity
        //naming convention is PascalCase

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
    }
}