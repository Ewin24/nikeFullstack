using API.Dtos;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Entities;

namespace API.Controllers
{
    [Authorize(Roles = "Employee")]
    public class DetalleOrdenController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DetalleOrdenController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DetalleCarritoDTO>>> Get11()
        {
            var DetalleOrdenes = await _unitOfWork.DetalleOrdenes.GetAllAsync();
            return _mapper.Map<List<DetalleCarritoDTO>>(DetalleOrdenes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleCarritoDTO>> Get(int id)
        {
            var Detalleorden = await _unitOfWork.DetalleOrdenes.GetByIdAsync(id);
            if (Detalleorden == null)
                return NotFound();

            return _mapper.Map<DetalleCarritoDTO>(Detalleorden);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Detalleorden>> Post(DetalleOrdenDTO DetalleCarritoDTO)
        {
            var Detalleorden = _mapper.Map<Detalleorden>(DetalleCarritoDTO);
            _unitOfWork.DetalleOrdenes.Add(Detalleorden);
            await _unitOfWork.SaveAsync();
            if (Detalleorden == null)
                return BadRequest();

            DetalleCarritoDTO.Id = Detalleorden.Id;
            return CreatedAtAction(nameof(Post), new { id = DetalleCarritoDTO.Id }, DetalleCarritoDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetalleOrdenDTO>> Put(int id, [FromBody] DetalleOrdenDTO DetalleCarritoDTO)
        {
            if (DetalleCarritoDTO == null)
                return NotFound();

            var DetalleOrdenBd = await _unitOfWork.DetalleOrdenes.GetByIdAsync(id);
            if (DetalleOrdenBd == null)
                return NotFound();

            var Detalleorden = _mapper.Map<Detalleorden>(DetalleCarritoDTO);
            _unitOfWork.DetalleOrdenes.Update(Detalleorden);
            await _unitOfWork.SaveAsync();
            return DetalleCarritoDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Detalleorden = await _unitOfWork.DetalleOrdenes.GetByIdAsync(id);
            if (Detalleorden == null)
                return NotFound();

            _unitOfWork.DetalleOrdenes.Delete(Detalleorden);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}