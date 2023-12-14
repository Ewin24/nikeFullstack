using API.Dtos;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Entities;

namespace API.Controllers
{
    [Authorize(Roles = "Employee")]
    public class OrdenController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrdenController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OrdenDTO>>> Get11()
        {
            var Ordenes = await _unitOfWork.Ordenes.GetAllAsync();
            return _mapper.Map<List<OrdenDTO>>(Ordenes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrdenDTO>> Get(int id)
        {
            var Orden = await _unitOfWork.Ordenes.GetByIdAsync(id);
            if (Orden == null)
                return NotFound();

            return _mapper.Map<OrdenDTO>(Orden);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Orden>> Post(OrdenDTO OrdenDTO)
        {
            var Orden = _mapper.Map<Orden>(OrdenDTO);
            _unitOfWork.Ordenes.Add(Orden);
            await _unitOfWork.SaveAsync();
            if (Orden == null)
                return BadRequest();

            OrdenDTO.Id = Orden.Id;
            return CreatedAtAction(nameof(Post), new { id = OrdenDTO.Id }, OrdenDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrdenDTO>> Put(int id, [FromBody] OrdenDTO OrdenDTO)
        {
            if (OrdenDTO == null)
                return NotFound();

            var OrdenBd = await _unitOfWork.Ordenes.GetByIdAsync(id);
            if (OrdenBd == null)
                return NotFound();

            var Orden = _mapper.Map<Orden>(OrdenDTO);
            _unitOfWork.Ordenes.Update(Orden);
            await _unitOfWork.SaveAsync();
            return OrdenDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Orden = await _unitOfWork.Ordenes.GetByIdAsync(id);
            if (Orden == null)
                return NotFound();

            _unitOfWork.Ordenes.Delete(Orden);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}