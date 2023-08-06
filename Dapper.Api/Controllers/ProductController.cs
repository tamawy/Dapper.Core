using Dapper.Core.Entities;
using Dapper.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var data = await _unitOfWork.Products.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.Products.GetByIdAsync(id);
            return (data ==null) ? Ok() : Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Product product)
        {
            var data = await _unitOfWork.Products.AddAsync(product);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var data = await _unitOfWork.Products.DeleteAsync(id);
            return Ok(data);
        }
        [HttpPut]
        // [HttpPatch] => For Partial Update
        public async Task<ActionResult> Update(Product product)
        {
            var data = await _unitOfWork.Products.UpdateAsync(product);
            return Ok(data);
        }
    }
}
