namespace BlazorFullStackCrud.Client.Services
{
    public interface IMonHocService
    {
        List<MonHoc> MonHocs { get; set; }
        Task GetMonHocs();
        Task<MonHoc> GetSingleMh(int id);
        Task CreateMh(MonHoc monhoc);
        Task UpdateMh(MonHoc monhoc);
        Task DeleteMh(int id);
    }
}
