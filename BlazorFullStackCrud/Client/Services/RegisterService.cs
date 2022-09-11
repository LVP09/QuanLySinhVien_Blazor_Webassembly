using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorFullStackCrud.Client.Services
{
    public class RegisterService:IRegisterService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public RegisterService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public async Task Register(User user)
        {
            
            await _http.PostAsJsonAsync("api/register", user);
            _navigationManager.NavigateTo("login");
           
        }
    }
}
