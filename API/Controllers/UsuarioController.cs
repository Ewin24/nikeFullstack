using API.Dtos;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Entities;

namespace API.Controllers
{
    [Authorize(Roles = "Employee")]
    public class UsuarioController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> Get11()
        {
            var Usuarios = await _unitOfWork.Usuarios.GetAllAsync();
            return _mapper.Map<List<UsuarioDTO>>(Usuarios);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UsuarioDTO>> Get(int id)
        {
            var Usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
            if (Usuario == null)
                return NotFound();

            return _mapper.Map<UsuarioDTO>(Usuario);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Usuario>> Post(UsuarioDTO UsuarioDTO)
        {
            var Usuario = _mapper.Map<Usuario>(UsuarioDTO);
            _unitOfWork.Usuarios.Add(Usuario);
            await _unitOfWork.SaveAsync();
            if (Usuario == null)
                return BadRequest();

            UsuarioDTO.Id = Usuario.Id;
            return CreatedAtAction(nameof(Post), new { id = UsuarioDTO.Id }, UsuarioDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioDTO>> Put(int id, [FromBody] UsuarioDTO UsuarioDTO)
        {
            if (UsuarioDTO == null)
                return NotFound();

            var UsuarioBd = await _unitOfWork.Usuarios.GetByIdAsync(id);
            if (UsuarioBd == null)
                return NotFound();

            var Usuario = _mapper.Map<Usuario>(UsuarioDTO);
            _unitOfWork.Usuarios.Update(Usuario);
            await _unitOfWork.SaveAsync();
            return UsuarioDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
            if (Usuario == null)
                return NotFound();

            _unitOfWork.Usuarios.Delete(Usuario);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}