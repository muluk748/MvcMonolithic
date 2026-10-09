using MvcMonolithic.Models.DomainModels.PersonAggregates;
using MvcMonolithic.Models.DomainModels.ProductAggregates;
using MvcMonolithic.Models.Services.Contracts;
using Microsoft.EntityFrameworkCore;
namespace MvcMonolithic.Models.Services.Repositories
{
    public class ProductRepository : IProductRepository// here we say how the mentioned methods(in contracts) should be done.
    {
        private readonly ProjectDbContext _projectDbContext; //access to database

        #region(- Ctor -)
        public ProductRepository(ProjectDbContext projectDbContext) // inject db context.
        {
            _projectDbContext = projectDbContext;
        }

        #endregion

        #region(- SellectAll() -)
        public async Task<List<Product>> SelectAll()
        {
            try
            {
                return await _projectDbContext.Product.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region(- SellectById() -)
        public async Task<Product> SelectById(int id)
        {
            try
            {
                return await _projectDbContext.Product.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region(- Insert() -)
        public async Task Insert(Product product)
        {
            try
            {
                _projectDbContext.Add(product);
                await _projectDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region(- Update() -)

        public async Task Update(Product product)
        {
            try
            {
                _projectDbContext.Update(product);
                await _projectDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region(- Delete() -)
        public async Task Delete(int id)
        {
            try
            {
                var product = await _projectDbContext.Product.FindAsync(id);

                if(product != null)
                {
                    _projectDbContext.Remove(product);
                    await _projectDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}




