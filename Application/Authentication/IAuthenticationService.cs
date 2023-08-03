using System.Threading.Tasks;

namespace Application.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> ValidateUserAsync(UserAuthenticationDto userForAuth);
        Task<string> CreateTokenAsync();
    }
}
