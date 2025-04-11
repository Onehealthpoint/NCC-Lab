using set3_JWT.Models;

namespace set3_JWT.Services
{
    public interface IAuthService
    {
        TokenResponse Authenticate(LoginModel model);
    }
}
