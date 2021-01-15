using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    //becasue we access <Product> here
    {
        public ProductsWithTypesAndBrandsSpecification(string sort, int? brandId, int? typeId) 
            : base( x =>
                    (!brandId.HasValue || x.ProductBrandId == brandId ) && 
                    (!typeId.HasValue || x.ProductTypeId == typeId )
               ) 
        {
            //here we can use it
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name); // as a default this will order by name

            // use a switch statement to see what the string is - and dependant on this, sort the produdcts
            if(!string.IsNullOrEmpty(sort))
            {
                switch (sort) 
                {
                    case "priceAsc":
                        AddOrderBy(p=>p.Price);
                        break;
                    case "AddOrderByDesc":
                        AddOrderByDescending( p => p.Price );
                        break;
                    default:
                        AddOrderBy( n => n.Name );
                        break;

                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) 
            : base(x => x.Id == id)
            {
                AddInclude(x => x.ProductType);
                AddInclude(x => x.ProductBrand);
            }
    }
}