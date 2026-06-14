using DomainLayer.Models;
using Shared;

namespace Service.Specifications
{
    public class ProductWithBrandAndTypeSpecifications : BaseSpecification<Product, int>
    {
        public ProductWithBrandAndTypeSpecifications(ProductQueryParms queryParms)
            : base(p => (!queryParms.BrandId.HasValue || queryParms.BrandId == p.BrandId)
            && (!queryParms.TypeId.HasValue || queryParms.TypeId == p.TypeId)
            && (string.IsNullOrWhiteSpace(queryParms.SearchValue)|| p.Name.ToLower().Contains(queryParms.SearchValue.ToLower())))
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
            switch(queryParms.SortingOptions)
            {
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;
                case ProductSortingOptions.NameDesc:
                    AddOrderByDesc(p => p.Name);
                    break;
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDesc(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.Name);
                    break;
            }
        }
        public ProductWithBrandAndTypeSpecifications(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
    }
}
