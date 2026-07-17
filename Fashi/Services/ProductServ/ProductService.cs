using AutoMapper;
using Fashi.Dtos.Product;
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
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository,IFileService fileService,IMapper mapper)
        {
            _productRepository = productRepository;
            _fileService = fileService;
            _mapper = mapper;
            
        }

        public async Task AddProductAsync(ProductCreateDto productDto, List<IFormFile> images,List<int>colorIds)
        {
            if (images != null && images.Count > 6)
            {
                throw new Exception("Max 6 shekil yukleye bilersiz");
            }
          var product=_mapper.Map<Product>(productDto);
       
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

              
            }
            await _productRepository.AddAsync(product);
            await _productRepository.SaveAsync();
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

        public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
        {
            var product=await _productRepository.GetAllProductWithDetailAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(product);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdProductWithDetailAsync(id);
        }

        public async Task UpdateProductAsync(ProductUpdateDto productDto)
        {
            var product=await _productRepository.GetByIdAsync(productDto.Id, p => p.ProductImages,p=>p.ColorProducts);
            if(product==null)
            {
                return;
            }

            _mapper.Map(productDto, product);
            if (productDto.DeleteImagesIds.Any())
            {
              
                    var imageToDelete=product.ProductImages.Where(pi=> productDto.DeleteImagesIds.Contains(pi.Id)).ToList();

                foreach(var image in imageToDelete)
                {
                    _fileService.DeleteImage(image.ImageUrl);
                    product.ProductImages.Remove(image);
                }
            }
            if(productDto.NewImages.Any())
            {
                foreach(var image in productDto.NewImages)
                {
                    string imageUrl=await _fileService.UploadFileAsync(image,"products");
                    product.ProductImages.Add(new ProductImage { ImageUrl=imageUrl });
                }
            }
       
            product.ColorProducts.Clear();
            foreach(var colorId in productDto.ColorIds)
            {
                product.ColorProducts.Add(new ColorProduct { ColorId=colorId, ProductId=product.Id });
            }
            product.UpdateTime= DateTime.UtcNow;
            await _productRepository.UpdateAsync(product);
            await _productRepository.SaveAsync();
        }
    }
}
