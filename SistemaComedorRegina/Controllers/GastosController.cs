using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaComedorRegina.Data;
using SistemaComedorRegina.Domain.Dtos;
using SistemaComedorRegina.Domain.Models;

namespace SistemaComedorRegina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController(Contexto context) : ControllerBase
    {
        private readonly Contexto _context = context;

        // GET: api/Gastos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GastosDto>>> GetGastos()
        {
            return await _context.Gastos
                .OrderByDescending(g => g.Fecha)
                .Select(g => g.ToDto())
                .ToListAsync();
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Gastos>>> GetGastosByFilter(DateTime? from, DateTime? to, string? description)
        {
            IQueryable<Gastos> gastosToFilter = _context.Gastos;

            if(from.HasValue && to.HasValue)
            {
                gastosToFilter = gastosToFilter.Where(g => g.Fecha >= from && g.Fecha <= to);
            }
            if(!string.IsNullOrEmpty(description))
            {
                gastosToFilter = gastosToFilter.Where(g => g.Descripcion.Contains(description));
            }
                
            return await gastosToFilter
                .OrderByDescending(g => g.Fecha)
                .ToListAsync();
        }

        // GET: api/Gastos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GastosDto>> GetGastos(int id)
        {
            var gastos = await _context.Gastos.FindAsync(id);

            if (gastos == null)
            {
                return NotFound();
            }

            return gastos.ToDto();
        }

        // PUT: api/Gastos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGastos(int id, GastosDto gastosDto)
        {
            var gastos = await _context.Gastos.FindAsync(id);
            gastos!.Descripcion = gastosDto.Descripcion;
            gastos.Monto = gastosDto.Monto;
            gastos.Fecha = gastosDto.Fecha;
            _context.Entry(gastos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await GastosExists(id))
                {
                    throw;
                }
                else
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Gastos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GastosDto>> PostGastos(GastosDto gastos)
        {
            _context.Gastos.Add(gastos.ToEntity());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGastos", new { id = gastos.ToEntity().GastoId }, gastos);
        }

        // DELETE: api/Gastos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGastos(int id)
        {
            var gastos = await _context.Gastos.FindAsync(id);
            if (gastos == null)
            {
                return NotFound();
            }

            _context.Gastos.Remove(gastos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> GastosExists(int id)
        {
            return await _context.Gastos.AnyAsync(e => e.GastoId == id);
        }

        
    }
}
