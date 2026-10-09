using Microsoft.EntityFrameworkCore;
using MvcMonolithic.Models.DomainModels.PersonAggregates;
using MvcMonolithic.Models.Services.Contracts;

namespace MvcMonolithic.Models.Services.Repositories
{
    public class PersonRepository : IPersonRepository// here we say how the mentioned methods(in contracts) should be done.
    {
        private readonly ProjectDbContext _projectDbContext;//access to database

        #region[- Ctor -]

        public PersonRepository(ProjectDbContext projectDbContext)// inject db context.
        {
            _projectDbContext = projectDbContext;
        }

        #endregion

        #region[- SelectAll() -]
        public async Task<List<Person>> SelectAll()
        {
            try
            {
                return await _projectDbContext.Person.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region(- SellectById() -)
        public async Task<Person> SelectById(int id)
        {
            try
            {
                return await _projectDbContext.Person.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region [- Insert() -]
        public async Task Insert(Person person)
        {
            try
            {
                _projectDbContext.Add(person);
                await _projectDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region(- Update() -)

        public async Task Update(Person person)
        {
            try
            {
                _projectDbContext.Update(person);
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
                var person = await _projectDbContext.Person.FindAsync(id);

                if (person != null)
                {
                    _projectDbContext.Remove(person);
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


