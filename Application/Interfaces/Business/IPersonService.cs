using Domain.Dtos.Person;
using System.Threading.Tasks;

namespace Application.Interfaces.Business
{
    public interface IPersonService
    {
        Task<CreatePersonResponse> Create(CreatePersonRequest p);
    }
}
