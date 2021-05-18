using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using skinet.API.DTOs;
using skinet.Core.Inferace;
using skinet.Core.Specification;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
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
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDTO>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();

            var products = await this.productRepo.ListAsync(spec);

            return Ok(this.mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(products));
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
        public async Task<ActionResult<ProductToReturnDTO>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await this.productRepo.GetEntityWithSpec(spec);

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
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await this.productTypeRepo.ListAllAsync());
        }
    }
}