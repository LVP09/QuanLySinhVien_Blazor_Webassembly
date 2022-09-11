using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocController : ControllerBase
    {
        private readonly DataContext _context;

        public MonHocController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<MonHoc>>> GetListMH()
        {
            var monHocs = await _context.MonHocs.ToListAsync();


            return Ok(monHocs);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<MonHoc>>> GetSingleMH(int id)
        {

            var monHocs = await _context.MonHocs.FirstOrDefaultAsync(h => h.MaMh == id);
            if (monHocs == null)
            {
                return NotFound("Sorry, no mon hoc here. :/");
            }
            return Ok(monHocs);
        }
        [HttpPost]
        public async Task<ActionResult<List<MonHoc>>> CreateMh(MonHoc monHoc)
        {
            
            _context.MonHocs.Add(monHoc);
            await _context.SaveChangesAsync();

            return Ok(await _context.MonHocs.ToListAsync());
        }
    
        [HttpPut("{id}")]
        public async Task<ActionResult<List<MonHoc>>> UpdateMh(MonHoc monHoc, int id)
        {
            var dbmonHoc = await _context.MonHocs

                .FirstOrDefaultAsync(sh => sh.MaMh == id);
            if (dbmonHoc == null)
                return NotFound("Sorry, but no mo hoc for you. :/");

            dbmonHoc.TenMh = monHoc.TenMh;
            dbmonHoc.Ki = monHoc.Ki;
            dbmonHoc.SoTinChi = monHoc.SoTinChi;
          
         

            await _context.SaveChangesAsync();

            return Ok(await _context.MonHocs.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<MonHoc>>> DeleteMh(int id)
        {
            var dbMh = await _context.MonHocs.FirstOrDefaultAsync(sh => sh.MaMh == id);
            if (dbMh == null)
                return NotFound("Sorry, but no mon hoc for you. :/");

            _context.MonHocs.Remove(dbMh);
            await _context.SaveChangesAsync();

            return Ok(await _context.MonHocs.ToListAsync());
        }
    }
}
