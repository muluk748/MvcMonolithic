using MvcMonolithic.Models.DomainModels.PersonAggregates;
using MvcMonolithic.Models.DomainModels.ProductAggregates;

namespace MvcMonolithic.Models.Services.Contracts
{
    public interface IProductRepository// an interface which we only say what we want.
    {
        Task<List<Product>> SelectAll(); //a list of product.

        Task<Product> SelectById(int id);// finding a product by its id.

        Task Insert(Product product);// create a product.

        Task Update(Product product); // changing the information of a product.

        Task Delete (int  id); // removing a product by its id.
    }
}
