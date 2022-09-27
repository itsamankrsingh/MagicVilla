using MagicVillaWebAPI.Data;
using MagicVillaWebAPI.Interfaces;
using MagicVillaWebAPI.Models;
using MagicVillaWebAPI.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaWebAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogging _logger;
        private readonly ApplicationDbContext _db;
        public VillaAPIController(ILogging logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            _logger.Log("Getting All Villas", LogLevel.Info);
            return Ok(_db.VillasTable.ToList());
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        //[ProducesResponseType(200, Type =typeof(VillaDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDto> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.Log($"GetVilla Error with id: {id}", LogLevel.Error);
                return BadRequest();
            }
            var villa = _db.VillasTable.FirstOrDefault(x => x.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villa)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (_db.VillasTable.FirstOrDefault(x => x.Name.ToLower() == villa.Name.ToLower()) != null)
            {
                ModelState.AddModelError("UniqueNameRequiredError", "Villa already Exists!");
                return BadRequest(ModelState);
            }
            if (villa == null)
            {
                return BadRequest(villa);
            }
            if (villa.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Villa model = new()
            {
                Amenity = villa.Amenity,
                Id = villa.Id,
                Name = villa.Name,
                ImageUrl = villa.ImageUrl,
                Sqft = villa.Sqft,
                Occupancy = villa.Occupancy,
                Rate = villa.Rate,
                Details = villa.Details
            };
            _db.VillasTable.Add(model);
            _db.SaveChanges();
            return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa);
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = _db.VillasTable.FirstOrDefault(x => x.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            _db.VillasTable.Remove(villa);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDto villa)
        {
            if (villa == null || id != villa.Id)
            {
                return BadRequest();
            }
            Villa model = new()
            {
                Amenity = villa.Amenity,
                Id = villa.Id,
                Name = villa.Name,
                ImageUrl = villa.ImageUrl,
                Sqft = villa.Sqft,
                Occupancy = villa.Occupancy,
                Rate = villa.Rate,
                Details = villa.Details
            };
            _db.VillasTable.Update(model);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }
            var villa = _db.VillasTable.AsNoTracking().FirstOrDefault(x => x.Id == id);
            VillaDto villaDto = new()
            {
                Amenity = villa.Amenity,
                Id = villa.Id,
                Name = villa.Name,
                ImageUrl = villa.ImageUrl,
                Sqft = villa.Sqft,
                Occupancy = villa.Occupancy,
                Rate = villa.Rate,
                Details = villa.Details
            };
            if (villa == null)
            {
                return BadRequest();
            }
            patchDto.ApplyTo(villaDto, ModelState);
            Villa model = new Villa
            {
                Amenity = villaDto.Amenity,
                Id = villaDto.Id,
                Name = villaDto.Name,
                ImageUrl = villaDto.ImageUrl,
                Sqft = villaDto.Sqft,
                Occupancy = villaDto.Occupancy,
                Rate = villaDto.Rate,
                Details = villaDto.Details
            };
            _db.VillasTable.Update(model);
            _db.SaveChanges();
            return NoContent();

        }
    }
}

