using API.Dtos;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Entities;

namespace API.Controllers
{
    [Authorize(Roles = "Employee")]
    public class CategoriaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get11()
        {
            var Categorias = await _unitOfWork.Categorias.GetAllAsync();
            return _mapper.Map<List<CategoriaDTO>>(Categorias);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaDTO>> Get(int id)
        {
            var Categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
            if (Categoria == null)
                return NotFound();

            return _mapper.Map<CategoriaDTO>(Categoria);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Categoria>> Post(CategoriaDTO CategoriaDTO)
        {
            var Categoria = _mapper.Map<Categoria>(CategoriaDTO);
            _unitOfWork.Categorias.Add(Categoria);
            await _unitOfWork.SaveAsync();
            if (Categoria == null)
                return BadRequest();

            CategoriaDTO.Id = Categoria.Id;
            return CreatedAtAction(nameof(Post), new { id = CategoriaDTO.Id }, CategoriaDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaDTO>> Put(int id, [FromBody] CategoriaDTO CategoriaDTO)
        {
            if (CategoriaDTO == null)
                return NotFound();

            var CategoriaBd = await _unitOfWork.Categorias.GetByIdAsync(id);
            if (CategoriaBd == null)
                return NotFound();

            var Categoria = _mapper.Map<Categoria>(CategoriaDTO);
            _unitOfWork.Categorias.Update(Categoria);
            await _unitOfWork.SaveAsync();
            return CategoriaDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
            if (Categoria == null)
                return NotFound();

            _unitOfWork.Categorias.Delete(Categoria);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}