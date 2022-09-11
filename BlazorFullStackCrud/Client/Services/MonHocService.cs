using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorFullStackCrud.Client.Services
{
    public class MonHocService:IMonHocService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public MonHocService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<MonHoc> MonHocs { get; set; } = new List<MonHoc>();

        //////////////////sinhvien///////////////
        public async Task CreateMh(MonHoc monHoc)
        {
            var result = await _http.PostAsJsonAsync("api/monhoc", monHoc);
            await SetMonHocs(result);
        }


        public async Task UpdateMh(MonHoc monHoc)
        {
            var result = await _http.PutAsJsonAsync($"api/monhoc/{monHoc.MaMh}", monHoc);
            await SetMonHocs(result);
        }

        public async Task DeleteMh(int id)
        {
            var result = await _http.DeleteAsync($"api/monhoc/{id}");
            await SetMonHocs(result);
        }
        private async Task SetMonHocs(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<MonHoc>>();
            MonHocs = response;
            _navigationManager.NavigateTo("listmonhoc");
        }
        public async Task GetMonHocs()
        {
            var result = await _http.GetFromJsonAsync<List<MonHoc>>("api/monhoc");
            if (result != null)
                MonHocs = result;
        }
        public async Task<MonHoc> GetSingleMh(int id)
        {
            var result = await _http.GetFromJsonAsync<MonHoc>($"api/monhoc/{id}");
            if (result != null)
                return result;
            throw new Exception("monhoc not found!");
        }
    }
}
