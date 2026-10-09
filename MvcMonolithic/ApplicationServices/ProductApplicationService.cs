using MvcMonolithic.ApplicationServices.Contracts;
using MvcMonolithic.ApplicationServices.Dtos;
using MvcMonolithic.Models.DomainModels.ProductAggregates;
using MvcMonolithic.Models.Services.Contracts;
using System.Threading.Tasks;

namespace MvcMonolithic.ApplicationServices
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IProductRepository _productRepository;

        #region(- Ctor -)
        public ProductApplicationService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion

        #region [- GetAllProduct() -]
        public async Task<List<GetProductDto>> GetAllProduct()
        {
            var products = await _productRepository.SelectAll();

            var getProductDtos = new List<GetProductDto>();

            foreach (var item in products)
            {
                var getProductDto = new GetProductDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity,

                };
                getProductDtos.Add(getProductDto);
            }
            return getProductDtos;
        }

        #endregion

        #region(- GetProductById() -)
        public async Task<PutProductDto> GetProductById(int id)
        {
            var product= await _productRepository.SelectById(id);

            if(product == null)
            {
                return null;
            }

            return new PutProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
            };
        }

        #endregion

        #region(- PostProduct() -)
        public async Task Post(PostProductDto postProductDto)
        {
            var product = new Product
            {
                Name = postProductDto.Name,
                Price = postProductDto.Price,
                Quantity = postProductDto.Quantity
            };
            await _productRepository.Insert(product);
        }

        #endregion

        #region(- Put() -)
        public async Task Put(PutProductDto putProductDto)
        {
            var product = new Product
            {
                Id = putProductDto.Id,
                Name = putProductDto.Name,
                Price = putProductDto.Price,
                Quantity = putProductDto.Quantity,
            };
            await _productRepository.Update(product);
        }

        #endregion

        #region(- Delete() -)

        public async Task Delete (int id)
        {
            await _productRepository.Delete(id);
        }

        #endregion
    }
}
