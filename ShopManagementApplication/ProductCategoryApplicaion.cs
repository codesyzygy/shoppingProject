using _0_Framework.Application;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductCategoryApplicaion : IProductCategoryApplication
    {

        public readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryApplicaion(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }


        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if (_productCategoryRepository.Exists(x=>x.Name==command.Name))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد .لطفا مجدد تلاش کنید.");


            var slug = command.Slug.Slugify();
            var productCategory = new ProductCategory(command.Picture, command.MetaDate,
                command.Description, command.Name, slug,
                command.PictureTitle, command.PictureAlt, command.Keywords);

            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChanges();
            return operation.Succedded();
        
        }

        public OperationResult Edit(Contracts.ProductCategory.EditProductCategory command)
        {
            var operation = new OperationResult();
            var productcategory = _productCategoryRepository.Get(command.Id);

            if ( productcategory==null)
            return operation.Failed("رکورد با اطلاعات درخواست شده یافت نشد");

            if (_productCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id));
            return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد .لطفا مجدد تلاش کنید.");

              var slug = command.Slug.Slugify();
              productcategory.Edit(command.Picture, command.MetaDate,
              command.Description, command.Name, slug,
              command.PictureTitle, command.PictureAlt, command.Keywords);

            _productCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditProductCategory GetDetails(long id)
        {
           return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }
    }
}
