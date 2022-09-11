using Radzen;

namespace BlazorFullStackCrud.Client.Services
{
    public interface ISinhVienService
    {
        List<SinhVien> SinhViens { get; set; }
        List<Lop> Lops { get; set; }
        List<Nghanh> Nghanhs { get; set; }
        void Export(string table, string type, Query query = null);
        Task GetLops();
        Task GetNghanhs();
        Task GetListSV();
        Task<SinhVien> GetSingleSV(int id);
        Task<Lop> GetSingleLop(int id);
        Task<Nghanh> GetSingleNghanh(int id);
        Task CreateSinhVien(SinhVien sinhVien);
        Task UpdateSinhVien(SinhVien sinhVien);
        Task DeleteSinhVien(int id);
        Task CreateLop(Lop lop);
        Task UpdateLop(Lop lop);
        Task DeleteLop(int id);
        Task CreateNghanh(Nghanh nghanh);
        Task UpdateNghanh(Nghanh nghanh);
        Task DeleteNghanh(int id);
    }
}
