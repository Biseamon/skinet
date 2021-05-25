using skinet.Core.Entities.Identity;

namespace skinet.Core.Inferace
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}