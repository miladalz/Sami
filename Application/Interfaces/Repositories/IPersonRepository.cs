using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        Task<Person?> FindByEmail(string email);
    }
}
