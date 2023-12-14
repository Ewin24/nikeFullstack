using API.Dtos;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Entities;

namespace API.Controllers
{
    [Authorize(Roles = "Employee")]
    public class InventarioController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InventarioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<InventarioDTO>>> Get11()
        {
            var Inventarios = await _unitOfWork.Inventarios.GetAllAsync();
            return _mapper.Map<List<InventarioDTO>>(Inventarios);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InventarioDTO>> Get(int id)
        {
            var Inventario = await _unitOfWork.Inventarios.GetByIdAsync(id);
            if (Inventario == null)
                return NotFound();

            return _mapper.Map<InventarioDTO>(Inventario);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Inventario>> Post(InventarioDTO InventarioDTO)
        {
            var Inventario = _mapper.Map<Inventario>(InventarioDTO);
            _unitOfWork.Inventarios.Add(Inventario);
            await _unitOfWork.SaveAsync();
            if (Inventario == null)
                return BadRequest();

            InventarioDTO.Id = Inventario.Id;
            return CreatedAtAction(nameof(Post), new { id = InventarioDTO.Id }, InventarioDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InventarioDTO>> Put(int id, [FromBody] InventarioDTO InventarioDTO)
        {
            if (InventarioDTO == null)
                return NotFound();

            var InventarioBd = await _unitOfWork.Inventarios.GetByIdAsync(id);
            if (InventarioBd == null)
                return NotFound();

            var Inventario = _mapper.Map<Inventario>(InventarioDTO);
            _unitOfWork.Inventarios.Update(Inventario);
            await _unitOfWork.SaveAsync();
            return InventarioDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Inventario = await _unitOfWork.Inventarios.GetByIdAsync(id);
            if (Inventario == null)
                return NotFound();

            _unitOfWork.Inventarios.Delete(Inventario);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}