using AutoMapper;
using MagicVillaWebAPI.Interfaces;
using MagicVillaWebAPI.Models;
using MagicVillaWebAPI.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVillaWebAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogging _logger;
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public VillaAPIController(ILogging logger, IVillaRepository dbVilla, IMapper mapper)
        {
            _logger = logger;
            _dbVilla = dbVilla;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            try
            {
                _logger.Log("Getting All Villas", LogLevel.Info);
                IEnumerable<Villa> villas = await _dbVilla.GetAllAsync();
                _response.Result = _mapper.Map<List<VillaDto>>(villas);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        //[ProducesResponseType(200, Type =typeof(VillaDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log($"GetVilla Error with id: {id}", LogLevel.Error);
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                var villa = await _dbVilla.GetAsync(x => x.Id == id);
                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<VillaDto>(villa);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VillaCreateDto createDto)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    return BadRequest(ModelState);
                //}
                if (await _dbVilla.GetAsync(x => x.Name.ToLower() == createDto.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("UniqueNameRequiredError", "Villa already Exists!");
                    return BadRequest(ModelState);
                }
                if (createDto == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.Result = createDto;
                    return BadRequest(_response);
                }
                Villa model = _mapper.Map<Villa>(createDto);
                await _dbVilla.CreateAsync(model);
                _response.Result = _mapper.Map<VillaDto>(model);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVilla", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                var villa = await _dbVilla.GetAsync(x => x.Id == id);
                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                await _dbVilla.RemoveAsync(villa);
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] VillaUpdateDto updateDto)
        {
            try
            {
                if (updateDto == null || id != updateDto.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                Villa model = _mapper.Map<Villa>(updateDto);
                await _dbVilla.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }
            var villa = await _dbVilla.GetAsync(x => x.Id == id, tracked: false);
            VillaUpdateDto villaDto = _mapper.Map<VillaUpdateDto>(villa);
            if (villa == null)
            {
                return BadRequest();
            }
            patchDto.ApplyTo(villaDto, ModelState);
            Villa model = _mapper.Map<Villa>(villaDto);
            await _dbVilla.UpdateAsync(model);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
