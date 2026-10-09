using MvcMonolithic.Models.DomainModels.PersonAggregates;

namespace MvcMonolithic.Models.Services.Contracts
{
    public interface IPersonRepository// an interface which we only say what we want.
    {
        Task<List<Person>> SelectAll();//a list of persons.

        Task<Person> SelectById(int id);// finding a person by its id.

        Task Insert(Person person);// create a person.

        Task Update(Person person);// changing the information of a person.

        Task Delete(int id);// removing a person by his/her id.
    }
}


