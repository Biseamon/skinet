using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using skinet.API.DTOs;

namespace skinet.API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDTO, string>
    {
        private readonly IConfiguration config;
        public ProductUrlResolver(IConfiguration config)
        {
            this.config = config;
        }

        public string Resolve(Product source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return this.config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}