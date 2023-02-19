using AssetManagement.Domain.Entities.Identity;


namespace AssetManagement.Application.Services
{
    public interface ITokenService
    {
        public string CreateToken(AppUser appUser);
    }
}
