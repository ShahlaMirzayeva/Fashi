using Fashi.Models;
using Fashi.Repositories.ProductRepo;
using Fashi.Services.FileServ;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fashi.Services.ProductServ
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileService _fileService;

        public ProductService(IProductRepository productRepository,IFileService fileService)
        {
            _productRepository = productRepository;
            _fileService = fileService;
            
        }

        public async Task AddProductAsync(Product product, List<IFormFile> images,List<int>colorIds)
        {
            if (images != null && images.Count > 6)
            {
                throw new Exception("Max 6 shekil yukleye bilersiz");
            }
            product.ProductImages = new List<ProductImage>();

            if (images != null)
            {
                foreach (var image in images)
                {
                    string imageUrl = await _fileService.UploadFileAsync(image, "products");
                    product.ProductImages.Add(new ProductImage { ImageUrl=imageUrl });
                }
            }
            product.ColorProducts= new List<ColorProduct>();
            if (colorIds != null)
            {
                foreach (var colorId in colorIds)
                {
                    product.ColorProducts.Add(new ColorProduct { ColorId = colorId });
                }

                await _productRepository.AddAsync(product);
                await _productRepository.SaveAsync();
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            var product =await _productRepository.GetByIdAsync(id, p => p.ProductImages);
            if (product == null)
            {
                return;
            }
            foreach (var image in product.ProductImages)
            {
                _fileService.DeleteImage(image.ImageUrl);
            }
           await _productRepository.DeleteAsync(id);
          await _productRepository.SaveAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await _productRepository.GetAllProductWithDetailAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdProductWithDetailAsync(id);
        }

        public Task UpdateProductAsync(Product product, List<IFormFile> images)
        {
            throw new NotImplementedException();
        }
    }
}
