using MvcMonolithic.ApplicationServices.Contracts;
using MvcMonolithic.ApplicationServices.Dtos;
using MvcMonolithic.Models.DomainModels.PersonAggregates;
using MvcMonolithic.Models.Services.Contracts;
using MvcMonolithic.Models.Services.Repositories;

namespace MvcMonolithic.ApplicationServices
{
    public class PersonApplicationService:IPersonApplicationService//how the methods should be done.
    {
        private readonly IPersonRepository _personRepository;//access to personrepository

        #region(- Ctor -)
        public PersonApplicationService(IPersonRepository personRepository)//inject ipersonrepository.
        {
            _personRepository=personRepository;
        }

        #endregion

        #region [- GetAllPersonDto() -]
        public async Task<List<GetPersonDto>> GetAllPerson()
        {
            var persons = await _personRepository.SelectAll();

            var getPersonDtos = new List<GetPersonDto>();

            foreach (var item in persons)
            {
                var getPersonDto = new GetPersonDto()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                };
                getPersonDtos.Add(getPersonDto);
            }
            return getPersonDtos;
        }

        #endregion

        #region(- GetPersonById() -)
        public async Task<PutPersonDto> GetPersonById(int id)
        {
            var person = await _personRepository.SelectById(id);

            if (person == null)
            {
                return null;
            }
            return new PutPersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
            };
        }

        #endregion

        #region(- PostPersonDto() -)
        public async Task Post(PostPersonDto postPersonDto)
        {
            var person = new Person()
            {
                FirstName = postPersonDto.FirstName,
                LastName = postPersonDto.LastName,
            };
            await _personRepository.Insert(person);
        }

        #endregion

        #region(- Put() -)

        public async Task Put(PutPersonDto putPersonDto)
        {
            var person = new Person()
            {
                Id = putPersonDto.Id,
                FirstName = putPersonDto.FirstName,
                LastName = putPersonDto.LastName,
            };
            await _personRepository.Update(person);
        }

        #endregion

        #region(- Delete() -)

        public async Task Delete(int id)
        {
            await _personRepository.Delete(id);
        }

        #endregion
    }
}
