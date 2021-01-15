using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }

        Expression<Func<T, object>> OrderByDescending { get; }

//get a certain amount of products 
        int Take {get;}
 //skip a certain amount of products 
 // on second page, take the next 5 products, 
 // SKIP the first 5. only load what you need
        int Skip {get;}
        bool IsPagingEnabled {get;}
    }
}