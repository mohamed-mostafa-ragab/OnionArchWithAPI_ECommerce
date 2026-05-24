using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using ServiceAbstraction;
using Shared.DTOs;

namespace Service
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var Repo = _unitOfWork.GetRepo<ProductBrand, int>();
            var Brands =await Repo.GetAllAsync();
            var BrandDtos = _mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandDto>>(Brands);
            return BrandDtos;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
        {
            var Products =await _unitOfWork.GetRepo<Product, int>().GetAllAsync();
           return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Products);
        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var Repo = _unitOfWork.GetRepo<ProductType, int>();
            var Types =await Repo.GetAllAsync();
            var TypeDtos = _mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(Types);
            return TypeDtos;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var Repo = _unitOfWork.GetRepo<Product, int>();
            var Product =await Repo.GetByIdAsync(id);
            var ProductDto = _mapper.Map<Product, ProductDto>(Product!);
            return ProductDto;
        }
    }
}
