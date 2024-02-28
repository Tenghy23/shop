using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDomainService _productDomainService;

        public ProductService(
            IProductDomainService productDomainService
            ) 
        {
            _productDomainService = productDomainService;
        }

    }
}
