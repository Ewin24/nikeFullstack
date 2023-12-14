using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using API.Dtos;
using Persistence.Entities;

namespace API.Controllers
{
    [Authorize(Roles = "Employee")]
    public class DetalleCarritoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DetalleCarritoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DetalleCarritoDTO>>> Get11()
        {
            var DetalleCarritos = await _unitOfWork.DetalleCarritos.GetAllAsync();
            return _mapper.Map<List<DetalleCarritoDTO>>(DetalleCarritos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleCarritoDTO>> Get(int id)
        {
            var DetalleCarrito = await _unitOfWork.DetalleCarritos.GetByIdAsync(id);
            if (DetalleCarrito == null)
                return NotFound();

            return _mapper.Map<DetalleCarritoDTO>(DetalleCarrito);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Detallecarrito>> Post(DetalleCarritoDTO DetalleCarritoDTO)
        {
            var DetalleCarrito = _mapper.Map<Detallecarrito>(DetalleCarritoDTO);
            _unitOfWork.DetalleCarritos.Add(DetalleCarrito);
            await _unitOfWork.SaveAsync();
            if (DetalleCarrito == null)
                return BadRequest();

            DetalleCarritoDTO.Id = DetalleCarrito.Id;
            return CreatedAtAction(nameof(Post), new { id = DetalleCarritoDTO.Id }, DetalleCarritoDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetalleCarritoDTO>> Put(int id, [FromBody] DetalleCarritoDTO DetalleCarritoDTO)
        {
            if (DetalleCarritoDTO == null)
                return NotFound();

            var DetalleCarritoBd = await _unitOfWork.DetalleCarritos.GetByIdAsync(id);
            if (DetalleCarritoBd == null)
                return NotFound();

            var DetalleCarrito = _mapper.Map<Detallecarrito>(DetalleCarritoDTO);
            _unitOfWork.DetalleCarritos.Update(DetalleCarrito);
            await _unitOfWork.SaveAsync();
            return DetalleCarritoDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Detallecarrito = await _unitOfWork.DetalleCarritos.GetByIdAsync(id);
            if (Detallecarrito == null)
                return NotFound();

            _unitOfWork.DetalleCarritos.Delete(Detallecarrito);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}