using Microsoft.AspNetCore.Components;
using Radzen;
using System.Net.Http.Json;

namespace BlazorFullStackCrud.Client.Services
{
    public class SinhVienService : ISinhVienService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public SinhVienService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
        public List<Lop> Lops { get; set; } = new List<Lop>();
        public List<Nghanh> Nghanhs { get; set; } = new List<Nghanh>();

        //////////////////sinhvien///////////////
        public void Export(string table, string type, Query query = null)
        {
            _navigationManager.NavigateTo(query != null ? query.ToUrl($"/listsinhvien/{table}/{type}") : $"/listsinhvien/{table}/{type}", true);
        }
        public async Task CreateSinhVien(SinhVien sinhVien)
        {
            
                var result = await _http.PostAsJsonAsync("api/sinhviens/postSV", sinhVien);
                await SetSinhViens(result);
            
           
        }

       
        public async Task UpdateSinhVien(SinhVien sinhVien)
        {
            var result = await _http.PutAsJsonAsync($"api/sinhviens/{sinhVien.MaSv}", sinhVien);
            await SetSinhViens(result);
        }

        public async Task DeleteSinhVien(int id)
        {
            var result = await _http.DeleteAsync($"api/sinhviens/{id}");
            await SetSinhViens(result);
        }
        private async Task SetSinhViens(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<SinhVien>>();
            SinhViens = response;
            _navigationManager.NavigateTo("listsinhvien");
        }
        public async Task GetListSV()
        {
            var result = await _http.GetFromJsonAsync<List<SinhVien>>("api/sinhviens/GetSinhVien");
            if (result != null)
                SinhViens = result;
        }
          public async Task<SinhVien> GetSingleSV(int id)
        {
            var result = await _http.GetFromJsonAsync<SinhVien>($"api/sinhviens/{id}");
            if (result != null)
             return result;
            throw new Exception("sinhvien not found!");
        }

        /// //////////////////Lớp//////////////////////////////////////////////////


        public async Task CreateLop(Lop lop)
        {
            var result = await _http.PostAsJsonAsync("api/sinhviens/postlop", lop);
            await SetLops(result);
        }


        public async Task UpdateLop(Lop lop)
        {
            var result = await _http.PutAsJsonAsync($"api/sinhviens/putlop/{lop.MaLop}", lop);
            await SetLops(result);
        }

        public async Task DeleteLop(int id)
        {
            var result = await _http.DeleteAsync($"api/sinhviens/lop/{id}");
            await SetLops(result);
        }
        private async Task SetLops(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Lop>>();
            Lops = response;
            _navigationManager.NavigateTo("listlop");
        }
        public async Task GetLops()
        {
            var result = await _http.GetFromJsonAsync<List<Lop>>("api/sinhviens/lops");
            if (result != null)
                Lops = result;
        }
       

      
        public async Task<Lop> GetSingleLop(int id)
        {
            var result = await _http.GetFromJsonAsync<Lop>($"api/sinhviens/lop/{id}");
            if (result != null)
                return result;
            throw new Exception("Hero not found!");
        }
        //nghành
        public async Task CreateNghanh(Nghanh nghanh)
        {
            var result = await _http.PostAsJsonAsync("api/sinhviens/postnghanh", nghanh);
            await SetNghanhs(result);
        }


        public async Task UpdateNghanh(Nghanh nghanh)
        {
            var result = await _http.PutAsJsonAsync($"api/sinhviens/putnghanh/{nghanh.MaNghanh}", nghanh);
            await SetNghanhs(result);
        }

        public async Task DeleteNghanh(int id)
        {
            var result = await _http.DeleteAsync($"api/sinhviens/nghanh/{id}");
            await SetNghanhs(result);
        }
        private async Task SetNghanhs(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Nghanh>>();
            Nghanhs = response;
            _navigationManager.NavigateTo("listnghanh");
        }
        



        public async Task<Nghanh> GetSingleNghanh(int id)
        {
            var result = await _http.GetFromJsonAsync<Nghanh>($"api/sinhviens/nghanh/{id}");
            if (result != null)
                return result;
            throw new Exception("Hero not found!");
        }
        public async Task GetNghanhs()
        {
            var result = await _http.GetFromJsonAsync<List<Nghanh>>("api/sinhviens/nghanhs");
            if (result != null)
                Nghanhs = result;
        }


    }
}
