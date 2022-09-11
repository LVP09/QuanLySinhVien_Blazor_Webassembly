using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiemController : ControllerBase
    {
        private readonly DataContext _context;

        public DiemController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Diem>>> GetListDiem()
        {
            var diems = await _context.Diems.ToListAsync();

            diems.OrderBy(c => c.MaDiem);
            return Ok(diems);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Diem>>> GetSingleDiem(int id)
        {

            var diems = await _context.Diems.FirstOrDefaultAsync(h => h.MaDiem == id);
            if (diems == null)
            {
                return NotFound("Sorry, no diem here. :/");
            }
            return Ok(diems);
        }

        [HttpPost]
        public async Task<ActionResult<List<Diem>>> CreateDiem(Diem diem)
        {
            diem.SinhViensMaSvNavigation = null;
            diem.MonHocMaMhNavigation = null;
            _context.Diems.Add(diem);
            await _context.SaveChangesAsync();

            return Ok(await _context.Diems.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Diem>>> UpdateDiem(Diem diem, int id)
        {
            var dbDiem = await _context.Diems.FirstOrDefaultAsync(sh => sh.MaDiem == id);
            if (dbDiem == null)
                return NotFound("Sorry, but no diem for you. :/");

            dbDiem.SinhViensMaSv= diem.SinhViensMaSv;
            dbDiem.MonHocMaMh= diem.MonHocMaMh;
            dbDiem.DiemThi= diem.DiemThi;
            



            await _context.SaveChangesAsync();

            return Ok(await _context.Diems.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Diem>>> DeleteDiem(int id)
        {
            var dbDiem = await _context.Diems.FirstOrDefaultAsync(sh => sh.MaDiem == id);
            if (dbDiem == null)
                return NotFound("Sorry, but no mon hoc for you. :/");

            _context.Diems.Remove(dbDiem);
            await _context.SaveChangesAsync();

            return Ok(await _context.Diems.ToListAsync());
        }
    }
}
