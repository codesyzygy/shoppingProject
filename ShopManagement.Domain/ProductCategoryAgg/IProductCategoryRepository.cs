using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace _0_Framework.Domain
{
    public interface IProductCategoryRepository
    {
        void Create(ProductCategory entity);
        ProductCategory Get(long id);
        List<ProductCategory> GetAll();
        bool Exists ( Expression<Func<ProductCategory, bool>> expression );
      
        void SaveChanges();
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);  




    }
}
