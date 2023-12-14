using API.Dtos;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Entities;

namespace API.Controllers
{
    [Authorize(Roles = "Employee")]
    public class ProductoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> Get11()
        {
            var Productos = await _unitOfWork.Productos.GetAllAsync();
            return _mapper.Map<List<ProductoDTO>>(Productos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductoDTO>> Get(int id)
        {
            var Producto = await _unitOfWork.Productos.GetByIdAsync(id);
            if (Producto == null)
                return NotFound();

            return _mapper.Map<ProductoDTO>(Producto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Producto>> Post(ProductoDTO ProductoDTO)
        {
            var Producto = _mapper.Map<Producto>(ProductoDTO);
            _unitOfWork.Productos.Add(Producto);
            await _unitOfWork.SaveAsync();
            if (Producto == null)
                return BadRequest();

            ProductoDTO.Id = Producto.Id;
            return CreatedAtAction(nameof(Post), new { id = ProductoDTO.Id }, ProductoDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductoDTO>> Put(int id, [FromBody] ProductoDTO ProductoDTO)
        {
            if (ProductoDTO == null)
                return NotFound();

            var ProductoBd = await _unitOfWork.Productos.GetByIdAsync(id);
            if (ProductoBd == null)
                return NotFound();

            var Producto = _mapper.Map<Producto>(ProductoDTO);
            _unitOfWork.Productos.Update(Producto);
            await _unitOfWork.SaveAsync();
            return ProductoDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Producto = await _unitOfWork.Productos.GetByIdAsync(id);
            if (Producto == null)
                return NotFound();

            _unitOfWork.Productos.Delete(Producto);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}