using API.Dtos;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Entities;

namespace API.Controllers
{
    [Authorize(Roles = "Employee")]
    public class CarritoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarritoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CarritoDTO>>> Get11()
        {
            var Carritos = await _unitOfWork.Carritos.GetAllAsync();
            return _mapper.Map<List<CarritoDTO>>(Carritos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CarritoDTO>> Get(int id)
        {
            var Carrito = await _unitOfWork.Carritos.GetByIdAsync(id);
            if (Carrito == null)
                return NotFound();

            return _mapper.Map<CarritoDTO>(Carrito);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Carrito>> Post(CarritoDTO CarritoDTO)
        {
            var Carrito = _mapper.Map<Carrito>(CarritoDTO);
            _unitOfWork.Carritos.Add(Carrito);
            await _unitOfWork.SaveAsync();
            if (Carrito == null)
                return BadRequest();

            CarritoDTO.Id = Carrito.Id;
            return CreatedAtAction(nameof(Post), new { id = CarritoDTO.Id }, CarritoDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CarritoDTO>> Put(int id, [FromBody] CarritoDTO CarritoDTO)
        {
            if (CarritoDTO == null)
                return NotFound();

            var CarritoBd = await _unitOfWork.Carritos.GetByIdAsync(id);
            if (CarritoBd == null)
                return NotFound();

            var Carrito = _mapper.Map<Carrito>(CarritoDTO);
            _unitOfWork.Carritos.Update(Carrito);
            await _unitOfWork.SaveAsync();
            return CarritoDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Carrito = await _unitOfWork.Carritos.GetByIdAsync(id);
            if (Carrito == null)
                return NotFound();

            _unitOfWork.Carritos.Delete(Carrito);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}