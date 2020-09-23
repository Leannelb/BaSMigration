using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    //becasue we access <Product> here
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            //here we can use it
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}