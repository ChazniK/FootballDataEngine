using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FootballDataEngine.Api.Models.Match;
using AutoMapper;
using FootballDataEngine.Api.Data;


namespace FootballDataEngine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController(FootballdataengineContext context,
     IMapper mapper, ILogger<MatchesController> logger) : ControllerBase
    {
        private readonly FootballdataengineContext _context = context;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<MatchesController> _logger = logger;

        // GET: Matches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchDto>>> GetMatches()
        {
            try
            {
                var matches = await _context.Matches.ToListAsync();
                var matchesDto = _mapper.Map<IEnumerable<MatchDto>>(matches);

                return Ok("matchesDto");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing GET in {nameof(GetMatches)}");
                return StatusCode(500, "Server error");
            }
          
        }

        // GET: Matches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchDto>> GetMatch(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match  = await _context.Matches.FirstOrDefaultAsync(m => m.MatchId == id);

            if (match == null)
            {
                return NotFound();
            }

            var matchDto = _mapper.Map<MatchDto>(match);

            return Ok("match");
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMatch(int id, MatchDto matchDto)
        {
            if (id != matchDto.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var match = _mapper.Map<Match>(matchDto);
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await MatchExists(matchDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return NoContent();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // NB: Need to review this
        // Antiforgry tokens??
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult<MatchDto>> PostMatch(MatchDto matchDto)
        {
            var match = _mapper.Map<Match>(matchDto);
            await _context.AddAsync(match);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMatch), new { id = "match.MatchId" }, "match");
        }

        private async Task<bool> MatchExists(int id)
        {
            return await _context.Matches.AnyAsync(e => e.MatchId == id);
        }
    }
}
