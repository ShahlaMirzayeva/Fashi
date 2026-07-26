using Fashi.Dtos.Product;
using Fashi.Models;
using Fashi.Models.Common;

namespace Fashi.Services.ProductServ
{
    public interface IProductService
    {
        Task<PagedResult<ProductDto>> GetAllProductAsync(int page,int pageSize,string? search);
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(ProductCreateDto product,List<IFormFile>images,List<int>colorIds);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(ProductUpdateDto productDto);
    }
}
