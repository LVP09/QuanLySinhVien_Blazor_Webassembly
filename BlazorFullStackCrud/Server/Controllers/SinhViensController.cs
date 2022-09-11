using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;


namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class SinhViensController : ControllerBase
    {
        private readonly DataContext _context;

        public SinhViensController(DataContext context)
        {
            _context = context;
           
        }
     

        [HttpGet("GetSinhVien")]
        public async Task<ActionResult<List<SinhVien>>> GetListSV()
        {
            var sinhViens = await _context.SinhViens.ToListAsync();
           
          
            return Ok(sinhViens);
        }
        [HttpGet("lops")]
        public async Task<ActionResult<List<Lop>>> GetLops()
        {
            var comics = await _context.Lops.ToListAsync();
            return Ok(comics);
        }
        [HttpGet("nghanhs")]
        public async Task<ActionResult<List<Nghanh>>> GetNghanhs()
        {
            var comics = await _context.Nghanhs.ToListAsync();
            return Ok(comics);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SinhVien>> GetSingleSV(int id)
        {
           
            var hero = await _context.SinhViens.FirstOrDefaultAsync(h => h.MaSv == id);
            //var idlop = _context.Lops.FirstOrDefault(c =>c.MaLop == hero.MaLop).MaLop;
            if (hero == null)
            {
                return NotFound("Sorry, No student. :/");
            }
            return Ok(hero);
        }
        [HttpGet("lop/{id}")]
        public async Task<ActionResult<Lop>> GetSingleLop(int id)
        {
            var lops = await _context.Lops

                .FirstOrDefaultAsync(h => h.MaLop == id);
            if (lops == null)
            {
                return NotFound("Sorry, no lop here. :/");
            }
            return Ok(lops);
        }
        [HttpGet("nghanh/{id}")]
        public async Task<ActionResult<Nghanh>> GetSingleNghanh(int id)
        {
            var lops = await _context.Nghanhs

                .FirstOrDefaultAsync(h => h.MaNghanh == id);
            if (lops == null)
            {
                return NotFound("Sorry, no lop here. :/");
            }
            return Ok(lops);
        }
        [HttpPost("postSV")]
        public async Task<ActionResult<List<SinhVien>>> CreateSinhVien(SinhVien sinhVien)
        {
            sinhVien.MaLopNavigation = null;
            _context.SinhViens.Add(sinhVien);
            await _context.SaveChangesAsync();

            return Ok(await GetDbSV());
        }
        [HttpPost("postLop")]
        public async Task<ActionResult<List<Lop>>> CreateLop(Lop lop)
        {
            lop.MaNghanhNavigation = null;
            _context.Lops.Add(lop);
            await _context.SaveChangesAsync();

            return Ok(await _context.Lops.ToListAsync());
        }
        [HttpPost("postNghanh")]
        public async Task<ActionResult<List<Nghanh>>> CreateNghanh(Nghanh nghanh)
        {
           
            _context.Nghanhs.Add(nghanh);
            await _context.SaveChangesAsync();

            return Ok(await _context.Nghanhs.ToListAsync());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<SinhVien>>> UpdateSV(SinhVien sinhVien, int id)
        {
            var dbSinhVien = await _context.SinhViens
                
                .FirstOrDefaultAsync(sh => sh.MaSv == id);
            if (dbSinhVien == null)
                return NotFound("Sorry, but no student for you. :/");

            dbSinhVien.TenSv = sinhVien.TenSv;
            dbSinhVien.AnhSv = sinhVien.AnhSv;
            dbSinhVien.NgaySinh = sinhVien.NgaySinh;
            dbSinhVien.SDT = sinhVien.SDT;
            dbSinhVien.Email = sinhVien.Email;
            dbSinhVien.DiaChi = sinhVien.DiaChi;
            dbSinhVien.MaLop = sinhVien.MaLop;

            await _context.SaveChangesAsync();

            return Ok(await GetDbSV());
        }
        [HttpPut("putlop/{id}")]
        public async Task<ActionResult<List<Lop>>> UpdateLop(Lop lop, int id)
        {
            var dbLop = await _context.Lops

                .FirstOrDefaultAsync(sh => sh.MaLop == id);
            if (dbLop == null)
                return NotFound("Sorry, but no data for you. :/");

            dbLop.TenLop = lop.TenLop;
            dbLop.MaNghanh = lop.MaNghanh;
           
            

            await _context.SaveChangesAsync();

            return Ok(await _context.Lops.ToListAsync());
        }
        [HttpPut("putnghanh/{id}")]
        public async Task<ActionResult<List<Nghanh>>> UpdateNghanh(Nghanh nghanh, int id)
        {
            var dbnghanh = await _context.Nghanhs

                .FirstOrDefaultAsync(sh => sh.MaNghanh == id);
            if (dbnghanh == null)
                return NotFound("Sorry, but no data for you. :/");

            dbnghanh.TenNghanh = nghanh.TenNghanh;
  



            await _context.SaveChangesAsync();

            return Ok(await _context.Nghanhs.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SinhVien>>> DeleteSV(int id)
        {
            var dbSV = await _context.SinhViens
            
                .FirstOrDefaultAsync(sh => sh.MaSv == id);
            if (dbSV == null)
                return NotFound("Sorry, but no nghanh for you. :/");

            _context.SinhViens.Remove(dbSV);
            await _context.SaveChangesAsync();

            return Ok(await GetDbSV());
        }
        [HttpDelete("lop/{id}")]
        public async Task<ActionResult<List<Lop>>> DeleteLop(int id)
        {
            var dblop = await _context.Lops

                .FirstOrDefaultAsync(sh => sh.MaLop == id);
            if (dblop == null)
                return NotFound("Sorry, but no hero for you. :/");

            _context.Lops.Remove(dblop);
            await _context.SaveChangesAsync();

            return Ok(await _context.Lops.ToListAsync());
        }
        [HttpDelete("nghanh/{id}")]
        public async Task<ActionResult<List<Nghanh>>> DeleteNghanh(int id)
        {
            var dbnghanh = await _context.Nghanhs.FirstOrDefaultAsync(sh => sh.MaNghanh == id);
            if (dbnghanh == null)
                return NotFound("Sorry, không tìm thấy nghành. :/");

            _context.Nghanhs.Remove(dbnghanh);
            await _context.SaveChangesAsync();

            return Ok(await _context.Nghanhs.ToListAsync());
        }
        private async Task<List<SinhVien>> GetDbSV()
        {
            return await _context.SinhViens.ToListAsync();
        }
    }
}
