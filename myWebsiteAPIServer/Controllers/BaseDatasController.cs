using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myWebsiteAPIServer.Data;
using myWebsiteAPIServer.Models;

namespace myWebsiteAPIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseDatasController : ControllerBase
    {
        private readonly myWebsiteAPIServerContext _context;

        public BaseDatasController(myWebsiteAPIServerContext context)
        {
            _context = context;
        }

        // GET: api/BaseDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseData>>> GetBaseData()
        {
          if (_context.BaseData == null)
          {
              return NotFound();
          }
            return await _context.BaseData.ToListAsync();
        }

        // GET: api/BaseDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseData>> GetBaseData(int id)
        {
          if (_context.BaseData == null)
          {
              return NotFound();
          }
            var baseData = await _context.BaseData.FindAsync(id);

            if (baseData == null)
            {
                return NotFound();
            }

            return baseData;
        }

        // PUT: api/BaseDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaseData(int id, BaseData baseData)
        {
            if (id != baseData.Id)
            {
                return BadRequest();
            }

            _context.Entry(baseData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaseDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BaseDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BaseData>> PostBaseData(BaseData baseData)
        {
          if (_context.BaseData == null)
          {
              return Problem("Entity set 'myWebsiteAPIServerContext.BaseData'  is null.");
          }
            _context.BaseData.Add(baseData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaseData", new { id = baseData.Id }, baseData);
        }

        // DELETE: api/BaseDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaseData(int id)
        {
            if (_context.BaseData == null)
            {
                return NotFound();
            }
            var baseData = await _context.BaseData.FindAsync(id);
            if (baseData == null)
            {
                return NotFound();
            }

            _context.BaseData.Remove(baseData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BaseDataExists(int id)
        {
            return (_context.BaseData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
