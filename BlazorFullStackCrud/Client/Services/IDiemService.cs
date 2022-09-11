namespace BlazorFullStackCrud.Client.Services
{
    public interface IDiemService
    {
        List<Diem> Diems { get; set; }
        Task GetDiems();
        Task<Diem> GetSingleDiem(int id);
        Task CreateDiem(Diem diem);
        Task UpdateDiem(Diem diem);
        Task DeleteDiem(int id);
    }
}
