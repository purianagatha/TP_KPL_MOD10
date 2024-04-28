using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using tpmodul10_1302223019;


namespace tpmodul10_1302223041.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MahasiswaController : ControllerBase
    {
        private static readonly List<Mahasiswa> anggotaKelompok = new List<Mahasiswa>
        {
            new Mahasiswa("Puri Lalita Anagata", "1302223019"),
            new Mahasiswa("Rd. M. Faisal Ramadhan Junaidi", "1302220093"),
            new Mahasiswa("Muhammad Fajar Mufid", "1302223032"),
            new Mahasiswa("Arga Adolf Lumunon", "1302223038"),
            new Mahasiswa("Gina Soraya", "1302223070"),
            new Mahasiswa("Muhammad Rizqi Fadhilah", "1302220020")
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(anggotaKelompok);
        }

        [HttpPost]
        public IActionResult Create(Mahasiswa mahasiswa)
        {
            anggotaKelompok.Add(mahasiswa);
            return CreatedAtAction(nameof(GetById), new { id = anggotaKelompok.IndexOf(mahasiswa) }, mahasiswa);
        }

        [HttpPost("{id}")]
        public IActionResult GetById(int id)
        {
            if (id < 0 || id >= anggotaKelompok.Count)
            {
                return NotFound();
            }
            return Ok(anggotaKelompok[id]);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= anggotaKelompok.Count)
            {
                return NotFound();
            }
            anggotaKelompok.RemoveAt(id);
            return NoContent();
        }
    }
}