using AutoMapper;
using DomainLayer.Models;
using Shared.DTOs;
using Microsoft.Extensions.Configuration;
namespace Service.MappingProfiles
{
    public class PictureUrlResolver(IConfiguration configuration) : IValueResolver<Product, ProductDto, string>
    {
        //https://localhost:7087/
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (source.PictureUrl is null) return string.Empty;
            else
            {
                return $"{configuration.GetSection("Urls")["BaseUrl"]}{source.PictureUrl}";

            }
        }
    }
}
