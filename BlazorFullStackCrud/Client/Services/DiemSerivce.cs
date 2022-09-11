using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorFullStackCrud.Client.Services
{
    public class DiemSerivce:IDiemService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public DiemSerivce(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Diem> Diems { get; set; } = new List<Diem>();

        //////////////////sinhvien///////////////
        public async Task CreateDiem(Diem diem)
        {
            var result = await _http.PostAsJsonAsync("api/diem", diem);
            await SetDiems(result);
        }


        public async Task UpdateDiem(Diem diem)
        {
            var result = await _http.PutAsJsonAsync($"api/diem/{diem.MaDiem}", diem);
            await SetDiems(result);
        }

        public async Task DeleteDiem(int id)
        {
            var result = await _http.DeleteAsync($"api/diem/{id}");
            await SetDiems(result);
        }
        private async Task SetDiems(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Diem>>();
            Diems = response;
            _navigationManager.NavigateTo("listdiem");
        }
        public async Task GetDiems()
        {
            var result = await _http.GetFromJsonAsync<List<Diem>>("api/diem");
            if (result != null)
                Diems = result;
        }
        public async Task<Diem> GetSingleDiem(int id)
        {
            var result = await _http.GetFromJsonAsync<Diem>($"api/diem/{id}");
            if (result != null)
                return result;
            throw new Exception("diem not found!");
        }
    }
}
