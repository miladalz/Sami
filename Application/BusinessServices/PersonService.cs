using Application.Interfaces.Business;
using Application.Interfaces.Repositories;
using Domain.Dtos.Person;
using Domain.Entities;
using Domain.Errors;
using System.Threading.Tasks;

namespace Application.BusinessServices
{
    public class PersonService: IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<CreatePersonResponse> Create(CreatePersonRequest p)
        {
            var personExist = await _personRepository.FindByEmail(p.Email);

            if (personExist != null)
            {
                throw new BusinessException("Email has been registered in the system.", 400);
            }

            var result = await _personRepository.Add(new Person()
            {
                Name = p.Name,
                Age = p.Age,
                Email = p.Email,
            });

            return new CreatePersonResponse()
            {
                Id = result.Id,
                Name = result.Name,
                Age = result.Age,
                Email = result.Email,
                CreatedDate = result.CreatedDate
            };
        }
    }
}
