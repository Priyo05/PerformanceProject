using Performance.Business.Interfaces;

namespace Performance.Presentation.Web.Services;
public class AuthService
{ 

    private readonly IAuthRepository _authRepository;

    public AuthService(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

}

