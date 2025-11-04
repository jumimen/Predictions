using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Predictions.Backend.Data;
using Predictions.Shared.Entities;

namespace Predictions.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var country = _context.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            _context.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync(Country country)
        {
            if (country == null)
                return BadRequest("El país no puede ser nulo.");
            _context.Add(country);
            await _context.SaveChangesAsync();
            var uri = Url.Action("GetAsync", new { id = country.Id });
            return Created(uri, country);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Country country)
        {
            var cont = _context.Countries.Find(country.Id);
            if (cont == null)
            {
                return NotFound();
            }
            cont.Name = country.Name;
            _context.Update(cont);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}