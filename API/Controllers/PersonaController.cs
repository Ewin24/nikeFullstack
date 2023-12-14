using API.Dtos;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Entities;

namespace API.Controllers
{
    [Authorize(Roles = "Employee")]
    public class PersonaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDTO>>> Get11()
        {
            var Personas = await _unitOfWork.Personas.GetAllAsync();
            return _mapper.Map<List<PersonaDTO>>(Personas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonaDTO>> Get(int id)
        {
            var Persona = await _unitOfWork.Personas.GetByIdAsync(id);
            if (Persona == null)
                return NotFound();

            return _mapper.Map<PersonaDTO>(Persona);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Persona>> Post(PersonaDTO PersonaDTO)
        {
            var Persona = _mapper.Map<Persona>(PersonaDTO);
            _unitOfWork.Personas.Add(Persona);
            await _unitOfWork.SaveAsync();
            if (Persona == null)
                return BadRequest();

            PersonaDTO.Id = Persona.Id;
            return CreatedAtAction(nameof(Post), new { id = PersonaDTO.Id }, PersonaDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDTO>> Put(int id, [FromBody] PersonaDTO PersonaDTO)
        {
            if (PersonaDTO == null)
                return NotFound();

            var PersonaBd = await _unitOfWork.Personas.GetByIdAsync(id);
            if (PersonaBd == null)
                return NotFound();

            var Persona = _mapper.Map<Persona>(PersonaDTO);
            _unitOfWork.Personas.Update(Persona);
            await _unitOfWork.SaveAsync();
            return PersonaDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Persona = await _unitOfWork.Personas.GetByIdAsync(id);
            if (Persona == null)
                return NotFound();

            _unitOfWork.Personas.Delete(Persona);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}