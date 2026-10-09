using MvcMonolithic.ApplicationServices.Dtos;

namespace MvcMonolithic.ApplicationServices.Contracts
{   
    //contract for person related applicationservices.
    public interface IPersonApplicationService
    {
        Task<List<GetPersonDto>> GetAllPerson();//a lis of persons.

        Task<PutPersonDto> GetPersonById(int id);//find a person by his/her id.

        Task Post(PostPersonDto postPersonDto);//creating a person.

        Task Put(PutPersonDto putPersonDto);//editing the person.

        Task Delete(int id);//deleting the person.
    }
}
