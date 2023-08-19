using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories
{
    public class RepositoryPerson : RepositoryBase<Person>, IPersonRepository
    {
        private readonly SamiDbContext _context;
        public RepositoryPerson(SamiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Person?> FindByEmail(string email)
        {
            return await _context.People.FirstOrDefaultAsync(p => p.Email == email);
        }
    }
}
