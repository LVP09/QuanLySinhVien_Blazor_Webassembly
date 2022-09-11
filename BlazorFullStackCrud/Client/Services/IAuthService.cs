namespace BlazorFullStackCrud.Client.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task Logout();
    }
}
