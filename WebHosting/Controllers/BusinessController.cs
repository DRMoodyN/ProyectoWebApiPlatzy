using System;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.DTO;
using ServiceLogic.BusinessLogic;
using AutoMapper;
using WebHosting.IWebHosting;

namespace WebHosting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessController : ControllerBase,
    IHttp<BusinessDTO>, IPut<BusinessUpdateDTO>
    {
        private readonly BusinessLogic _business;
        private ILogger<BusinessController> _logger;

        public BusinessController(IUnitOfWord unitOfWord, IMapper mapper, ILogger<BusinessController> logger)
        {
            _business = new(unitOfWord, mapper);
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _business.GetIdAsync(id);
            if (result == null)
            {
                _logger.LogWarning($"El objecto no {id} no existe");
                return NotFound($"No existe el {id}"); //404
            }
            _logger.LogInformation($"GetId de {nameof(_business)}");
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _business.GetAllAsync();
            _logger.LogInformation($"GetAll de {nameof(_business)}");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BusinessDTO model)
        {
            if (model == null)
            {
                _logger.LogError($"El objecto no {nameof(BusinessDTO)} es null");
                return BadRequest("El objecto es null"); // 400
            }
            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"El objecto no {nameof(BusinessDTO)} es incorrecto");
                return UnprocessableEntity(ModelState);
            }
            var result = await _business.AddAsync(model);
            _logger.LogInformation($"Post de {nameof(_business)}");
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, BusinessUpdateDTO model)
        {
            var result = await _business.UpdateAsync(id, model);
            _logger.LogInformation($"Put de {nameof(_business)}");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation($"Delete de {nameof(_business)}");
            return Ok(await _business.DeleteAsync(id));
        }
    }
}