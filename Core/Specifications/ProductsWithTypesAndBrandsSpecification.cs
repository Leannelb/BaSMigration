using System;
using System.Linq.Expressions;
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

        public ProductsWithTypesAndBrandsSpecification(int id) 
            : base(x => x.Id == id)
            {
                AddInclude(x => x.ProductType);
                AddInclude(x => x.ProductBrand);
            }
    }
}