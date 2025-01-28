using PcPartsStore.Identity.Models;

namespace PcPartsStore.Application.Contracts.Infrastructure
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
