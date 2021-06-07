using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using skinet.API.Controllers;
using skinet.API.DTOs;
using skinet.API.Errors;
using skinet.API.Helpers;
using skinet.Core.Inferace;
using skinet.Core.Specification;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> productRepo;

        // private readonly IProductRepository repo;
        private readonly IGenericRepository<ProductBrand> productBrandRepo;
        private readonly IGenericRepository<ProductType> productTypeRepo;
        private readonly IMapper mapper;

        public ProductsController(/*IProductRepository repo*/ IGenericRepository<Product> productRepo,
        IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo,
        IMapper mapper)
        {
            this.mapper = mapper;
            this.productTypeRepo = productTypeRepo;
            this.productBrandRepo = productBrandRepo;
            this.productRepo = productRepo;
        }

        //Previous version
        // public ProductsController(IProductRepository repo)
        // {
        //     this.repo = repo;        
        // }

        // [HttpGet]
        // public async Task<ActionResult<List<Product>>> GetProducts()
        // {
        //     var products = await this.repo.GetProductsAsync();

        //     return Ok(products);
        // }

        [HttpGet]
        [Cached(600)]
        public async Task<ActionResult<Pagination<ProductToReturnDTO>>> GetProducts([FromQuery]ProductSpecsParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);

            var countSpec = new ProductWithFilterForCountSpecification(productParams);

            var totalItems = await this.productRepo.CountAsync(countSpec);

            var products = await this.productRepo.ListAsync(spec);

            var data = this.mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(products);

            return Ok(new Pagination<ProductToReturnDTO>(productParams.PageIndex, productParams.PageSize, totalItems, data));
            // return products.Select(p => new ProductToReturnDTO()
            // {
            //     Id = p.Id,
            //     Name = p.Name,
            //     Description = p.Description,
            //     Price = p.Price,
            //     PictureUrl = p.PictureUrl,
            //     ProductBrand = p.ProductBrand.Name,
            //     ProductType = p.ProductType.Name
            // }).ToList();
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<Product>> GetProduct(int id)
        // {
        //     return await this.repo.GetProductByIdAsync(id);
        // }

        [HttpGet("{id}")]
        [Cached(600)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDTO>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await this.productRepo.GetEntityWithSpec(spec);

            if(product == null) return NotFound(new ApiResponse(404));

            return this.mapper.Map<Product, ProductToReturnDTO>(product);
            // return new ProductToReturnDTO()
            // {
            //     Id = product.Id,
            //     Name = product.Name,
            //     Description = product.Description,
            //     Price = product.Price,
            //     PictureUrl = product.PictureUrl,
            //     ProductBrand = product.ProductBrand.Name,
            //     ProductType = product.ProductType.Name
            // };
        }

        // [HttpGet("brands")]
        // public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        // {
        //     return Ok(await this.repo.GetProductBrandsAsync());
        // }

        [HttpGet("brands")]
        [Cached(600)]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await this.productBrandRepo.ListAllAsync());
        }

        // [HttpGet("types")]
        // public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        // {
        //     return Ok(await this.repo.GetProductTypesAsync());
        // }

        [HttpGet("types")]
        [Cached(600)]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await this.productTypeRepo.ListAllAsync());
        }
    }
}