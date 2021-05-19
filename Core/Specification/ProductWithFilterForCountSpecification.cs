using Core.Entities;

namespace skinet.Core.Specification
{
    public class ProductWithFilterForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFilterForCountSpecification(ProductSpecsParams productSpecs)
        : base(x => 
               (string.IsNullOrEmpty(productSpecs.Search) || x.Name.ToLower().Contains(productSpecs.Search)) && 
               (!productSpecs.BrandId.HasValue || x.ProductBrandId == productSpecs.BrandId) && 
                (!productSpecs.TypeId.HasValue || x.ProductTypeId == productSpecs.TypeId))
        {
        }
    }
}